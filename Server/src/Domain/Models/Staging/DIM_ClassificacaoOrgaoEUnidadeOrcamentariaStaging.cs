using ControleSocial.Domain.Contexts;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleSocial.Domain.Models.Staging
{
	public class DIM_ClassificacaoOrgaoEUnidadeOrcamentariaStaging : IStaging<DIM_ClassificacaoOrgaoEUnidadeOrcamentariaStaging>
	{
		public long Id { get; set; }
		public string CodigoOrgao { get; set; }
		public string CodigoUnidadeOrcamentaria { get; set; }

		public string NomeOrgao { get; set; }
		public string NomeUnidadeOrcamentaria { get; set; }
		public string CodigoCompleto { get; set; }

		public string CodigoUnidadeGestora { get; set; }

		public string CodigoComparacao
		{
			get
			{
				return $"{CodigoUnidadeGestora}-{CodigoOrgao}-{CodigoUnidadeOrcamentaria}-{NomeOrgao}-{NomeUnidadeOrcamentaria}";
			}
			private set { }
		}

		public IEnumerable<DIM_ClassificacaoOrgaoEUnidadeOrcamentariaStaging> Save(IEnumerable<DIM_ClassificacaoOrgaoEUnidadeOrcamentariaStaging> rows, IObserver<AddRangeObserverResult> observer = default)
		{
			rows = rows
					.GroupBy(o => o.CodigoComparacao)
					.Select(o => o.FirstOrDefault())
					.ToList();

			var precisamSalvar = rows
					.Select(o => new DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio
					{
						CodigoOrgao = o.CodigoOrgao,
						CodigoUnidadeGestora = o.CodigoUnidadeGestora,
						CodigoUnidadeOrcamentaria = o.CodigoUnidadeOrcamentaria,
						NomeOrgao = o.NomeOrgao,
						NomeUnidadeOrcamentaria = o.NomeUnidadeOrcamentaria
					})
					.ToList();

			return precisamSalvar.InsertMerge(() => Settings.ServiceProvider.GetService<DWControleSocialContext>(), o => o.Id, o => o.CodigoUnidadeGestora + "-" + o.CodigoOrgao + "-" + o.CodigoUnidadeOrcamentaria + "-" + o.NomeOrgao + "-" + o.NomeUnidadeOrcamentaria, observer)
					.Select(o => new DIM_ClassificacaoOrgaoEUnidadeOrcamentariaStaging
					{
						Id = o.Id,
						CodigoCompleto = o.CodigoCompleto,

						CodigoOrgao = o.CodigoOrgao,
						CodigoUnidadeGestora = o.CodigoUnidadeGestora,
						CodigoUnidadeOrcamentaria = o.CodigoUnidadeOrcamentaria,
						NomeOrgao = o.NomeOrgao,
						NomeUnidadeOrcamentaria = o.NomeUnidadeOrcamentaria
					})
					.ToList();
		}
	}
}
