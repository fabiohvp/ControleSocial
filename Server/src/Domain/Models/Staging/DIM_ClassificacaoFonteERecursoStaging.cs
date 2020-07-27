using ControleSocial.Domain.Contexts;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleSocial.Domain.Models.Staging
{
	public class DIM_ClassificacaoFonteERecursoStaging : IStaging<DIM_ClassificacaoFonteERecursoStaging>
	{
		public long Id { get; set; }
		public string CodigoDetalhamento { get; set; }
		public string CodigoFonteReduzida { get; set; }
		public string CodigoGrupo { get; set; }
		public string CodigoCompleto { get; set; }

		public string NomeDetalhamento { get; set; }
		public string NomeFonteReduzida { get; set; }
		public string NomeGrupo { get; set; }

		public string CodigoUnidadeGestora { get; set; }

		public string CodigoComparacao
		{
			get
			{
				return $"{CodigoUnidadeGestora}-{CodigoDetalhamento}-{CodigoFonteReduzida}-{CodigoGrupo}-{NomeDetalhamento}-{NomeFonteReduzida}-{NomeGrupo}";
			}
			private set { }
		}

		public IEnumerable<DIM_ClassificacaoFonteERecursoStaging> Save(IEnumerable<DIM_ClassificacaoFonteERecursoStaging> rows, IObserver<AddRangeObserverResult> observer = default)
		{
			rows = rows
					.GroupBy(o => o.CodigoComparacao)
					.Select(o => o.FirstOrDefault())
					.ToList();

			var precisamSalvar = rows
					.Select(o => new DIM_ClassificacaoFonteERecursoMunicipio
					{
						CodigoDetalhamento = o.CodigoDetalhamento,
						CodigoFonteReduzida = o.CodigoFonteReduzida,
						CodigoGrupo = o.CodigoGrupo,
						CodigoUnidadeGestora = o.CodigoUnidadeGestora,
						NomeDetalhamento = o.NomeDetalhamento,
						NomeFonteReduzida = o.NomeFonteReduzida,
						NomeGrupo = o.NomeGrupo
					})
					.ToList();

			return precisamSalvar.InsertMerge(() => Settings.ServiceProvider.GetService<DWControleSocialContext>(), o => o.Id, o => o.CodigoUnidadeGestora + "-" + o.CodigoDetalhamento + "-" + o.CodigoFonteReduzida + "-" + o.CodigoGrupo + "-" + o.NomeDetalhamento + "-" + o.NomeFonteReduzida + "-" + o.NomeGrupo, observer)
					.Select(o => new DIM_ClassificacaoFonteERecursoStaging
					{
						Id = o.Id,
						CodigoCompleto = o.CodigoCompleto,

						CodigoDetalhamento = o.CodigoDetalhamento,
						CodigoFonteReduzida = o.CodigoFonteReduzida,
						CodigoGrupo = o.CodigoGrupo,
						CodigoUnidadeGestora = o.CodigoUnidadeGestora,
						NomeDetalhamento = o.NomeDetalhamento,
						NomeFonteReduzida = o.NomeFonteReduzida,
						NomeGrupo = o.NomeGrupo
					})
					.ToList();
		}
	}
}
