using ControleSocial.Domain.Contexts;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleSocial.Domain.Models.Staging
{
	public class DIM_EsferaAdministrativaStaging : IStaging<DIM_EsferaAdministrativaStaging>
	{
		public long Id { get; set; }
		public string Codigo { get; set; }
		public string Nome { get; set; }

		public string CodigoComparacao
		{
			get
			{
				return $"{Codigo}-{Nome}";
			}
			private set { }
		}

		public IEnumerable<DIM_EsferaAdministrativaStaging> Save(IEnumerable<DIM_EsferaAdministrativaStaging> rows, IObserver<AddRangeObserverResult> observer = default)
		{
			rows = rows
					.GroupBy(o => o.CodigoComparacao)
					.Select(o => o.FirstOrDefault())
					.ToList();

			var precisamSalvar = rows
					.Select(o => new DIM_EsferaAdministrativa
					{
						Codigo = o.Codigo,
						Nome = o.Nome
					})
					.ToList();

			return precisamSalvar.InsertMerge(() => Settings.ServiceProvider.GetService<DWControleSocialContext>(), o => o.Id, o => o.Codigo + "-" + o.Nome, observer)
					.Select(o => new DIM_EsferaAdministrativaStaging
					{
						Id = o.Id,

						Codigo = o.Codigo,
						Nome = o.Nome
					})
					.ToList();
		}
	}
}
