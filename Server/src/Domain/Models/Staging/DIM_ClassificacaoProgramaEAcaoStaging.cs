using ControleSocial.Domain.Contexts;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleSocial.Domain.Models.Staging
{
	public class DIM_ClassificacaoProgramaEAcaoStaging : IStaging<DIM_ClassificacaoProgramaEAcaoStaging>
	{
		public long Id { get; set; }
		public string CodigoAcao { get; set; }
		public string CodigoPrograma { get; set; }

		public string NomeAcao { get; set; }
		public string NomePrograma { get; set; }
		public string CodigoCompleto { get; set; }

		public string CodigoUnidadeGestora { get; set; }

		public string CodigoComparacao
		{
			get
			{
				return $"{CodigoUnidadeGestora}-{CodigoAcao}-{CodigoPrograma}-{NomeAcao}-{NomePrograma}";
			}
			private set { }
		}

		public IEnumerable<DIM_ClassificacaoProgramaEAcaoStaging> Save(IEnumerable<DIM_ClassificacaoProgramaEAcaoStaging> rows, IObserver<AddRangeObserverResult> observer = default)
		{
			rows = rows
					.GroupBy(o => o.CodigoComparacao)
					.Select(o => o.FirstOrDefault())
					.ToList();

			var precisamSalvar = rows
					.Select(o => new DIM_ClassificacaoProgramaEAcaoMunicipio
					{
						CodigoAcao = o.CodigoAcao,
						CodigoPrograma = o.CodigoPrograma,
						CodigoUnidadeGestora = o.CodigoUnidadeGestora,
						NomeAcao = o.NomeAcao,
						NomePrograma = o.NomePrograma
					})
					.ToList();

			return precisamSalvar.InsertMerge(() => Settings.ServiceProvider.GetService<DWControleSocialContext>(), o => o.Id, o => o.CodigoUnidadeGestora + "-" + o.CodigoAcao + "-" + o.CodigoPrograma + "-" + o.NomeAcao + "-" + o.NomePrograma, observer)
					.Select(o => new DIM_ClassificacaoProgramaEAcaoStaging
					{
						Id = o.Id,
						CodigoCompleto = o.CodigoCompleto,

						CodigoAcao = o.CodigoAcao,
						CodigoPrograma = o.CodigoPrograma,
						CodigoUnidadeGestora = o.CodigoUnidadeGestora,
						NomeAcao = o.NomeAcao,
						NomePrograma = o.NomePrograma
					})
					.ToList();
		}
	}
}
