using ControleSocial.Domain.Contexts;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using ControleSocial.Domain.Models.Staging;
using ControleSocial.WebSockets;
using WorkflowApi.Core.Workflows;

namespace ControleSocial.Workflows.Seed
{
	public class Seed : Workflow
	{
		private static Dictionary<string, Type> FilesDictionary = new Dictionary<string, Type>
				{
						{ "despesa-dotacao-municipio", typeof(FT_DespesaDotacaoMunicipioStaging) },
						{ "prestacao-conta-mensal", typeof(FT_PrestacaoContaMensalStaging) },
						{ "receita-dotacao-municipio", typeof(FT_ReceitaDotacaoMunicipioStaging) },
				};

		private static MethodInfo ProcessMethod = typeof(Seed).GetMethod(nameof(Process), BindingFlags.NonPublic | BindingFlags.Instance);

		public Microsoft.AspNetCore.Http.FormFileCollection Files { get; set; }
		private WebSocketObserver WebSocketObserver;

		public Seed(object files)
		{
			Files = files as Microsoft.AspNetCore.Http.FormFileCollection;
		}

		public override void OnAuthorize(IDictionary<string, StringValues> headers)
		{
			if (headers.ContainsKey("socket-guid"))
			{
				var socketGuid = headers["socket-guid"];

				if (WebSocketWorkflowHandler.Observers.ContainsKey(socketGuid))
				{
					WebSocketObserver = WebSocketWorkflowHandler.Observers[socketGuid];
				}
			}

			base.OnAuthorize(headers);
		}

		public override object Execute(object entryData)
		{
			var dbContext = DbContext
					.As<DWControleSocialContext>();

			foreach (var file in Files)
			{
				var item = FilesDictionary.FirstOrDefault(o => file.FileName.Contains(o.Key));
				var observer = new AddRangeObserver(r => WebSocketObserver.OnNext(r), e => WebSocketObserver.OnError(e), WebSocketObserver.OnCompleted, file.FileName);
				ProcessMethod.MakeGenericMethod(item.Value).Invoke(this, new object[] { dbContext, file, observer });
			}
			return true;
		}

		private IEnumerable<T> Process<T>(DWControleSocialContext dbContext, Microsoft.AspNetCore.Http.FormFile file, AddRangeObserver observer)
				where T : IFT_Staging<T>
		{
			var idSeedHistory = default(long);
			var rows = Enumerable.Empty<T>();
			var hashs = new Dictionary<string, string>();

			using (var fileStream = file.OpenReadStream())
			{
				using (var md5 = new MD5CryptoServiceProvider())
				{
					var hash = BitConverter.ToString(md5.ComputeHash(fileStream))
							.Replace("-", string.Empty)
							.ToUpperInvariant();

					var seedHistory = dbContext.SeedHistory.FirstOrDefault(o => o.Hash == hash);
					if (seedHistory == default)
					{
						seedHistory = new __SeedHistory { Arquivo = file.FileName, Hash = hash };
						dbContext.Add(seedHistory);
						dbContext.SaveChanges();
					}
					//else
					//{
					//    throw new InvalidOperationException("Este arquivo já foi carregado");
					//}
					hashs.Add(file.FileName, hash);
					idSeedHistory = seedHistory.Id;
				}
				fileStream.Seek(0, SeekOrigin.Begin);
				rows = ParseCSV<T>(idSeedHistory, fileStream, observer);
			}
			return rows;
		}

		private IEnumerable<T> ParseCSV<T>(long idSeedHistory, Stream fileStream, AddRangeObserver observer)
				where T : IFT_Staging<T>
		{
			Console.WriteLine("Parsing csv");
			var type = typeof(T);
			var parser = new TextFieldParser(fileStream, Encoding.GetEncoding(1252));
			parser.HasFieldsEnclosedInQuotes = true;
			parser.SetDelimiters(",");

			string[] fields;
			var properties = new List<PropertyInfo>();
			var rows = new List<T>();
			var count = 0;

			fields = parser.ReadFields();

			foreach (var field in fields)
			{
				properties.Add(type.GetProperty(field));
			}

			while (!parser.EndOfData)
			{
				fields = parser.ReadFields();
				var row = Activator.CreateInstance<T>();

				for (var i = 0; i < fields.Length; i++)
				{
					row.SetValue(properties[i], fields[i]);
				}
				row.Initialize(idSeedHistory);
				rows.Add(row);

				if (rows.Count == 20000)
				{
					count += rows.Count;
					SaveRows(rows, idSeedHistory, count, observer);
					rows = new List<T>();
				}
			}

			count += rows.Count;
			SaveRows(rows, idSeedHistory, count, observer);

			parser.Close();
			Console.WriteLine($"{count} rows");
			return rows;
		}

		private void SaveRows<T>(List<T> rows, long idSeedHistory, int count, AddRangeObserver observer)
				where T : IFT_Staging<T>
		{
			var obj = Activator.CreateInstance<T>();
			obj.Initialize(idSeedHistory);
			obj.Save(rows, observer);
			Console.WriteLine($"Total processed {count} rows");
		}
	}
}
