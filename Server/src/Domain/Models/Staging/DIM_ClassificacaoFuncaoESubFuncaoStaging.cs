using ControleSocial.Domain.Contexts;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleSocial.Domain.Models.Staging
{
	public class DIM_ClassificacaoFuncaoESubFuncaoStaging : IStaging<DIM_ClassificacaoFuncaoESubFuncaoStaging>
	{
		public long Id { get; set; }
		public string CodigoFuncao { get; set; }
		public string CodigoSubFuncao { get; set; }

		public string NomeFuncao { get; set; }
		public string NomeSubFuncao { get; set; }
		public string CodigoCompleto { get; set; }

		public string CodigoComparacao
		{
			get
			{
				return $"{CodigoFuncao}-{CodigoSubFuncao}-{NomeFuncao}-{NomeSubFuncao}";
			}
			private set { }
		}

		public IEnumerable<DIM_ClassificacaoFuncaoESubFuncaoStaging> Save(IEnumerable<DIM_ClassificacaoFuncaoESubFuncaoStaging> rows, IObserver<AddRangeObserverResult> observer = default)
		{
			rows = rows
					.GroupBy(o => o.CodigoComparacao)
					.Select(o => o.FirstOrDefault())
					.ToList();

			var precisamSalvar = rows
					.Select(o => new DIM_ClassificacaoFuncaoESubFuncaoMunicipio
					{
						CodigoFuncao = o.CodigoFuncao,
						CodigoSubFuncao = o.CodigoSubFuncao,
						NomeFuncao = o.NomeFuncao,
						NomeSubFuncao = o.NomeSubFuncao
					})
					.ToList();

			return precisamSalvar.InsertMerge(() => Settings.ServiceProvider.GetService<DWControleSocialContext>(), o => o.Id, o => o.CodigoFuncao + "-" + o.CodigoSubFuncao + "-" + o.NomeFuncao + "-" + o.NomeSubFuncao, observer)
					.Select(o => new DIM_ClassificacaoFuncaoESubFuncaoStaging
					{
						Id = o.Id,
						CodigoCompleto = o.CodigoCompleto,

						CodigoFuncao = o.CodigoFuncao,
						CodigoSubFuncao = o.CodigoSubFuncao,
						NomeFuncao = o.NomeFuncao,
						NomeSubFuncao = o.NomeSubFuncao
					})
					.ToList();
		}
	}
}
