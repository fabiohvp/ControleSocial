using ControleSocial.Domain.Contexts;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleSocial.Domain.Models.Staging
{
	public class DIM_ClassificacaoDespesaDotacaoMunicipioStaging : IStaging<DIM_ClassificacaoDespesaDotacaoMunicipioStaging>
	{
		public long Id { get; set; }
		public string CodigoCategoria { get; set; }
		public string CodigoGrupo { get; set; }
		public string CodigoModalidade { get; set; }
		public string CodigoElemento { get; set; }
		public string CodigoSubElemento { get; set; }
		public string CodigoCompleto { get; set; }

		public string NomeCategoria { get; set; }
		public string NomeGrupo { get; set; }
		public string NomeModalidade { get; set; }
		public string NomeElemento { get; set; }
		public string NomeSubElemento { get; set; }

		public string CodigoComparacao
		{
			get
			{
				return $"{CodigoCategoria}-{CodigoGrupo}-{CodigoModalidade}-{CodigoElemento}-{CodigoSubElemento}-{NomeCategoria}-{NomeGrupo}-{NomeModalidade}-{NomeElemento}-{NomeSubElemento}";
			}
			private set { }
		}

		public IEnumerable<DIM_ClassificacaoDespesaDotacaoMunicipioStaging> Save(IEnumerable<DIM_ClassificacaoDespesaDotacaoMunicipioStaging> rows, IObserver<AddRangeObserverResult> observer = default)
		{
			rows = rows
					.GroupBy(o => o.CodigoComparacao)
					.Select(o => o.FirstOrDefault())
					.ToList();

			var precisamSalvar = rows
					.Select(o => new DIM_ClassificacaoDespesaDotacaoMunicipio
					{
						CodigoCategoria = o.CodigoCategoria,
						CodigoGrupo = o.CodigoGrupo,
						CodigoModalidade = o.CodigoModalidade,
						CodigoElemento = o.CodigoElemento,
						CodigoSubElemento = o.CodigoSubElemento,

						NomeCategoria = o.NomeCategoria,
						NomeGrupo = o.NomeGrupo,
						NomeModalidade = o.NomeModalidade,
						NomeElemento = o.NomeElemento,
						NomeSubElemento = o.NomeSubElemento
					})
					.ToList();

			return precisamSalvar.InsertMerge(() => Settings.ServiceProvider.GetService<DWControleSocialContext>(), o => o.Id, o => o.CodigoCategoria + "-" + o.CodigoGrupo + "-" + o.CodigoModalidade + "-" + o.CodigoElemento + "-" + o.CodigoSubElemento + "-" + o.NomeCategoria + "-" + o.NomeGrupo + "-" + o.NomeModalidade + "-" + o.NomeElemento + "-" + o.NomeSubElemento, observer)
					.Select(o => new DIM_ClassificacaoDespesaDotacaoMunicipioStaging
					{
						Id = o.Id,
						CodigoCompleto = o.CodigoCompleto,

						CodigoCategoria = o.CodigoCategoria,
						CodigoGrupo = o.CodigoGrupo,
						CodigoModalidade = o.CodigoModalidade,
						CodigoElemento = o.CodigoElemento,
						CodigoSubElemento = o.CodigoSubElemento,

						NomeCategoria = o.NomeCategoria,
						NomeGrupo = o.NomeGrupo,
						NomeModalidade = o.NomeModalidade,
						NomeElemento = o.NomeElemento,
						NomeSubElemento = o.NomeSubElemento
					})
					.ToList();
		}
	}
}
