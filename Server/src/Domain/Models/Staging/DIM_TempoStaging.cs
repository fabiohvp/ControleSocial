using ControleSocial.Domain.Contexts;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleSocial.Domain.Models.Staging
{
	public class DIM_TempoStaging : IStaging<DIM_TempoStaging>
	{
		public long Id { get; set; }
		public short Ano { get; set; }
		public short Mes { get; set; }

		public string CodigoComparacao
		{
			get
			{
				return $"{Ano}-{Mes}";
			}
			private set { }
		}

		public IEnumerable<DIM_TempoStaging> Save(IEnumerable<DIM_TempoStaging> rows, IObserver<AddRangeObserverResult> observer = default)
		{
			rows = rows
					.GroupBy(o => o.CodigoComparacao)
					.Select(o => o.FirstOrDefault())
					.ToList();

			var precisamSalvar = rows
					.Select(o => new DIM_Tempo
					{
						Ano = o.Ano,
						Mes = o.Mes
					})
					.ToList();

			return precisamSalvar.InsertMerge(() => Settings.ServiceProvider.GetService<DWControleSocialContext>(), o => o.Id, o => o.Ano.ToString() + "-" + o.Mes.ToString(), observer)
					.Select(o => new DIM_TempoStaging
					{
						Id = o.Id,
						Ano = o.Ano,
						Mes = o.Mes
					})
					.ToList();
		}
	}
}
