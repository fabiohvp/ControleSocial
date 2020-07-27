using ControleSocial.Domain.Contexts;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControleSocial.Domain.Models.Staging
{
	public class FT_PrestacaoContaMensalStaging : IFT_Staging<FT_PrestacaoContaMensalStaging>
	{
		public long IdSeedHistory { get; set; }
		public long IdOriginal { get; set; }
		public long IdEsferaAdministrativa { get; set; }
		public long IdPeriodo { get; set; }
		public long IdTempo { get; set; }
		public long IdUnidadeGestora { get; set; }

		public short Ano { get; set; }
		public short Mes { get; set; }

		public string CodigoEsferaAdministrativa { get; set; }
		public string CodigoIBGEEsferaAdministrativa { get; set; }
		public string CodigoOriginalUnidadeGestora { get; set; }
		public string CodigoPoderUnidadeGestora { get; set; }
		public string CodigoTipoUnidadeGestora { get; set; }
		public string CodigoUnidadeGestora { get; set; }

		public string NomeEsferaAdministrativa { get; set; }
		public string NomePoderUnidadeGestora { get; set; }
		public string NomeTipoUnidadeGestora { get; set; }
		public string NomeUnidadeGestora { get; set; }

		public DateTime DataLimite { get; set; }
		public DateTime? DataHomologacao { get; set; }

		public string CodigoComparacao
		{
			get
			{
				return $"{IdEsferaAdministrativa}-{IdPeriodo}-{IdTempo}-{IdUnidadeGestora}";
			}
		}

		private static Expression<Func<FT_PrestacaoContaMensal, string>> GetCodigoComparacao = o => o.IdEsferaAdministrativa.ToString() + "-" + o.IdPeriodo.ToString() + "-" + o.IdTempo.ToString() + "-" + o.IdUnidadeGestora.ToString();

		private DIM_EsferaAdministrativaStaging EsferaAdministrativaStaging { get; set; }
		private DIM_PeriodoStaging PeriodoStaging { get; set; }
		private DIM_TempoStaging TempoStaging { get; set; }
		private DIM_UnidadeGestoraStaging UnidadeGestoraStaging { get; set; }

		public void Initialize(long idSeedHistory)
		{
			IdSeedHistory = idSeedHistory;

			EsferaAdministrativaStaging = new DIM_EsferaAdministrativaStaging
			{
				Codigo = CodigoEsferaAdministrativa,
				Nome = NomeEsferaAdministrativa
			};

			PeriodoStaging = DIM_PeriodoStaging.GetMensal();

			TempoStaging = new DIM_TempoStaging
			{
				Ano = Ano,
				Mes = Mes
			};

			UnidadeGestoraStaging = new DIM_UnidadeGestoraStaging
			{
				Codigo = CodigoUnidadeGestora,
				CodigoOriginal = CodigoOriginalUnidadeGestora,
				CodigoPoder = CodigoPoderUnidadeGestora,
				CodigoTipoUnidadeGestora = CodigoTipoUnidadeGestora,
				Nome = NomeUnidadeGestora,
				NomePoder = NomePoderUnidadeGestora,
				NomeTipoUnidadeGestora = NomeTipoUnidadeGestora
			};
		}

		public IEnumerable<FT_PrestacaoContaMensalStaging> Save(IEnumerable<FT_PrestacaoContaMensalStaging> rows, IObserver<AddRangeObserverResult> observer = default)
		{
			observer.OnNext(new AddRangeObserverResult
			{
				Metadata = new HashSet<string> { "info:Processing dimensions" }
			});

			var tempos = rows.Select(o => o.TempoStaging);
			tempos = new DIM_TempoStaging().Save(tempos);

			var periodos = new[] { PeriodoStaging }.AsEnumerable();
			periodos = new DIM_PeriodoStaging().Save(periodos);

			var unidadesGestoras = rows.Select(o => o.UnidadeGestoraStaging);
			unidadesGestoras = new DIM_UnidadeGestoraStaging().Save(unidadesGestoras);

			var esferasAdministrativas = rows.Select(o => o.EsferaAdministrativaStaging);
			esferasAdministrativas = new DIM_EsferaAdministrativaStaging().Save(esferasAdministrativas);

			using (var dbContext = Settings.ServiceProvider.GetService<DWControleSocialContext>())
			{
				var precisamSalvar = (
						from row in rows
						join ea in esferasAdministrativas on row.EsferaAdministrativaStaging.CodigoComparacao equals ea.CodigoComparacao
						join pe in periodos on row.PeriodoStaging.CodigoComparacao equals pe.CodigoComparacao
						join te in tempos on row.TempoStaging.CodigoComparacao equals te.CodigoComparacao
						join ug in unidadesGestoras on row.UnidadeGestoraStaging.CodigoComparacao equals ug.CodigoComparacao
						select new FT_PrestacaoContaMensal
						{
							DataHomologacao = row.DataHomologacao,
							DataLimite = row.DataLimite,
							IdEsferaAdministrativa = ea.Id,
							IdPeriodo = pe.Id,
							IdSeedHistory = IdSeedHistory,
							IdTempo = te.Id,
							IdUnidadeGestora = ug.Id
						})
						.ToList();

				observer.OnNext(new AddRangeObserverResult
				{
					Metadata = new HashSet<string> { "info:Processing facts" }
				});

				precisamSalvar.InsertMerge
				(
						() => Settings.ServiceProvider.GetService<DWControleSocialContext>(),
						o => o.Id,
						GetCodigoComparacao,
						observer,
						o => new
						{
							o.DataHomologacao
						}
				);
			}
			return rows;
		}
	}
}