using System;
using System.Collections.Generic;
using System.Linq;
using ControleSocial.Domain.Contexts;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ControleSocial.Domain.Models.Staging
{
	public class DIM_UnidadeGestoraStaging : IStaging<DIM_UnidadeGestoraStaging>
	{
		public long Id { get; set; }
		public string Codigo { get; set; }
		public string CodigoOriginal { get; set; }
		public string CodigoPoder { get; set; }
		public string CodigoTipoUnidadeGestora { get; set; }

		public string Nome { get; set; }
		public string NomePoder { get; set; }
		public string NomeTipoUnidadeGestora { get; set; }

		public string CNPJ { get; set; }
		public string Sigla { get; set; }
		public string EndLogradouro { get; set; }
		public string EndComplemento { get; set; }
		public string EndBairro { get; set; }
		public string EndCidade { get; set; }
		public string EndCEP { get; set; }
		public string Telefone1 { get; set; }
		public string Telefone2 { get; set; }
		public string Fax { get; set; }
		public string Site { get; set; }
		public string HorarioFuncionamento { get; set; }
		public string CodigoUGPai { get; set; }
		public bool ExisteControleInteno { get; set; }

		public string CodigoComparacao
		{
			get
			{
				return $"{Codigo}-{CodigoOriginal}-{CodigoPoder}-{CodigoTipoUnidadeGestora}-{Nome}-{NomePoder}-{NomeTipoUnidadeGestora}";
			}
			private set { }
		}

		public IEnumerable<DIM_UnidadeGestoraStaging> Save(IEnumerable<DIM_UnidadeGestoraStaging> rows, IObserver<AddRangeObserverResult> observer = default)
		{
			rows = rows
					.GroupBy(o => o.CodigoComparacao)
					.Select(o => o.FirstOrDefault())
					.ToList();

			var precisamSalvar = rows
					.Select(o => new DIM_UnidadeGestora
					{
						Codigo = o.Codigo,
						CodigoPoder = o.CodigoPoder,
						CodigoOriginal = o.CodigoOriginal,
						CodigoTipoUnidadeGestora = o.CodigoTipoUnidadeGestora,
						NomePoder = o.NomePoder,
						NomeTipoUnidadeGestora = o.NomeTipoUnidadeGestora,
						Nome = o.Nome
					});

			return precisamSalvar.InsertMerge(() => Settings.ServiceProvider.GetService<DWControleSocialContext>(), o => o.Id, o => o.Codigo + "-" + o.CodigoOriginal + "-" + o.CodigoPoder + "-" + o.CodigoTipoUnidadeGestora + "-" + o.Nome + "-" + o.NomePoder + "-" + o.NomeTipoUnidadeGestora, observer)
					.Select(o => new DIM_UnidadeGestoraStaging
					{
						Id = o.Id,

						Codigo = o.Codigo,
						CodigoPoder = o.CodigoPoder,
						CodigoOriginal = o.CodigoOriginal,
						CodigoTipoUnidadeGestora = o.CodigoTipoUnidadeGestora,
						NomePoder = o.NomePoder,
						NomeTipoUnidadeGestora = o.NomeTipoUnidadeGestora,
						Nome = o.Nome
					})
					.ToList();
		}
	}
}
