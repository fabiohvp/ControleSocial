using ControleSocial.Domain.Contexts;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleSocial.Domain.Models.Staging
{
	public class FT_ReceitaDotacaoMunicipioStaging : IFT_Staging<FT_ReceitaDotacaoMunicipioStaging>
	{
		public long IdSeedHistory { get; set; }
		public long IdOriginal { get; set; }
		public long IdClassificacaoNatureza { get; set; }
		public long IdClassificacaoFonteRecurso { get; set; }
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

		public string CodigoCategoriaNatureza { get; set; }
		public string CodigoOrigemNatureza { get; set; }
		public string CodigoEspecieNatureza { get; set; }
		public string CodigoRubricaNatureza { get; set; }
		public string CodigoAlineaNatureza { get; set; }
		public string CodigoSubAlineaNatureza { get; set; }
		public string CodigoDetalhamentoNivel1Natureza { get; set; }
		public string CodigoDetalhamentoNivel2Natureza { get; set; }
		public string CodigoDetalhamentoNivel3Natureza { get; set; }
		public string CodigoTipoDetalhamentoNatureza { get; set; }
		public string CodigoCompletoNatureza { get; set; }

		public string NomeCategoriaNatureza { get; set; }
		public string NomeOrigemNatureza { get; set; }
		public string NomeEspecieNatureza { get; set; }
		public string NomeRubricaNatureza { get; set; }
		public string NomeAlineaNatureza { get; set; }
		public string NomeSubAlineaNatureza { get; set; }
		public string NomeDetalhamentoNivel1Natureza { get; set; }
		public string NomeDetalhamentoNivel2Natureza { get; set; }
		public string NomeDetalhamentoNivel3Natureza { get; set; }
		public string NomeTipoDetalhamentoNatureza { get; set; }

		public string CodigoDetalhamentoFonteERecurso { get; set; }
		public string CodigoFonteReduzidaFonteERecurso { get; set; }
		public string CodigoGrupoFonteERecurso { get; set; }
		public string CodigoCompletoFonteERecurso { get; set; }

		public string NomeDetalhamentoFonteERecurso { get; set; }
		public string NomeFonteReduzidaFonteERecurso { get; set; }
		public string NomeGrupoFonteERecurso { get; set; }

		public decimal? PrevisaoAtualizada { get; set; }
		public decimal? PrevisaoInicial { get; set; }
		public decimal? Arrecadada { get; set; }

		public decimal? PrevisaoAtualizadaFUNDEB { get; set; }
		public decimal? PrevisaoInicialFUNDEB { get; set; }
		public decimal? ArrecadadaFUNDEB { get; set; }

		public string CodigoComparacao { get { return IdOriginal.ToString(); } }

		private DIM_ClassificacaoFonteERecursoStaging ClassificacaoFonteRecursoStaging { get; set; }
		private DIM_ClassificacaoReceitaDotacaoMunicipioStaging ClassificacaoNaturezaStaging { get; set; }
		private DIM_EsferaAdministrativaStaging EsferaAdministrativaStaging { get; set; }
		private DIM_PeriodoStaging PeriodoStaging { get; set; }
		private DIM_TempoStaging TempoStaging { get; set; }
		private DIM_UnidadeGestoraStaging UnidadeGestoraStaging { get; set; }

		public void Initialize(long idSeedHistory)
		{
			IdSeedHistory = idSeedHistory;

			ClassificacaoFonteRecursoStaging = new DIM_ClassificacaoFonteERecursoStaging
			{
				CodigoCompleto = CodigoCompletoFonteERecurso?.ToUpperRemovingBreaklines(),
				CodigoUnidadeGestora = CodigoUnidadeGestora,

				CodigoDetalhamento = CodigoDetalhamentoFonteERecurso?.ToUpperRemovingBreaklines(),
				CodigoFonteReduzida = CodigoFonteReduzidaFonteERecurso?.ToUpperRemovingBreaklines(),
				CodigoGrupo = CodigoGrupoFonteERecurso?.ToUpperRemovingBreaklines(),

				NomeDetalhamento = NomeDetalhamentoFonteERecurso?.ToUpperRemovingBreaklines(),
				NomeFonteReduzida = NomeFonteReduzidaFonteERecurso?.ToUpperRemovingBreaklines(),
				NomeGrupo = NomeGrupoFonteERecurso?.ToUpperRemovingBreaklines()
			};

			ClassificacaoNaturezaStaging = new DIM_ClassificacaoReceitaDotacaoMunicipioStaging
			{
				CodigoCompleto = CodigoCompletoNatureza?.ToUpperRemovingBreaklines(),

				CodigoCategoria = CodigoCategoriaNatureza?.ToUpperRemovingBreaklines(),
				CodigoOrigem = CodigoOrigemNatureza?.ToUpperRemovingBreaklines(),
				CodigoEspecie = CodigoEspecieNatureza?.ToUpperRemovingBreaklines(),
				CodigoRubrica = CodigoRubricaNatureza?.ToUpperRemovingBreaklines(),
				CodigoAlinea = CodigoAlineaNatureza?.ToUpperRemovingBreaklines(),
				CodigoSubAlinea = CodigoSubAlineaNatureza?.ToUpperRemovingBreaklines(),
				CodigoDetalhamentoNivel1 = CodigoDetalhamentoNivel1Natureza?.ToUpperRemovingBreaklines(),
				CodigoDetalhamentoNivel2 = CodigoDetalhamentoNivel2Natureza?.ToUpperRemovingBreaklines(),
				CodigoDetalhamentoNivel3 = CodigoDetalhamentoNivel3Natureza?.ToUpperRemovingBreaklines(),
				CodigoTipoDetalhamento = CodigoTipoDetalhamentoNatureza?.ToUpperRemovingBreaklines(),

				NomeCategoria = NomeCategoriaNatureza?.ToUpperRemovingBreaklines(),
				NomeOrigem = NomeOrigemNatureza?.ToUpperRemovingBreaklines(),
				NomeEspecie = NomeEspecieNatureza?.ToUpperRemovingBreaklines(),
				NomeRubrica = NomeRubricaNatureza?.ToUpperRemovingBreaklines(),
				NomeAlinea = NomeAlineaNatureza?.ToUpperRemovingBreaklines(),
				NomeSubAlinea = NomeSubAlineaNatureza?.ToUpperRemovingBreaklines(),
				NomeDetalhamentoNivel1 = NomeDetalhamentoNivel1Natureza?.ToUpperRemovingBreaklines(),
				NomeDetalhamentoNivel2 = NomeDetalhamentoNivel2Natureza?.ToUpperRemovingBreaklines(),
				NomeDetalhamentoNivel3 = NomeDetalhamentoNivel3Natureza?.ToUpperRemovingBreaklines(),
				NomeTipoDetalhamento = NomeTipoDetalhamentoNatureza?.ToUpperRemovingBreaklines()
			};

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

		public IEnumerable<FT_ReceitaDotacaoMunicipioStaging> Save(IEnumerable<FT_ReceitaDotacaoMunicipioStaging> rows, IObserver<AddRangeObserverResult> observer = default)
		{
			observer.OnNext(new AddRangeObserverResult
			{
				Id = "teste",
				Metadata = new HashSet<string> { "info:Processing dimensions" }
			});
			observer.OnCompleted();

			var tempos = rows.Select(o => o.TempoStaging);
			tempos = new DIM_TempoStaging().Save(tempos);

			var periodos = new[] { PeriodoStaging }.AsEnumerable();
			periodos = new DIM_PeriodoStaging().Save(periodos);

			var unidadesGestoras = rows.Select(o => o.UnidadeGestoraStaging);
			unidadesGestoras = new DIM_UnidadeGestoraStaging().Save(unidadesGestoras);

			var esferasAdministrativas = rows.Select(o => o.EsferaAdministrativaStaging);
			esferasAdministrativas = new DIM_EsferaAdministrativaStaging().Save(esferasAdministrativas);

			var classificacoesFontesRecursos = rows.Select(o => o.ClassificacaoFonteRecursoStaging);
			classificacoesFontesRecursos = new DIM_ClassificacaoFonteERecursoStaging().Save(classificacoesFontesRecursos);

			var classificacoesNaturezas = rows.Select(o => o.ClassificacaoNaturezaStaging);
			classificacoesNaturezas = new DIM_ClassificacaoReceitaDotacaoMunicipioStaging().Save(classificacoesNaturezas);

			var precisamSalvar = (
					from row in rows
					join cfr in classificacoesFontesRecursos on row.ClassificacaoFonteRecursoStaging.CodigoComparacao equals cfr.CodigoComparacao
					join cfn in classificacoesNaturezas on row.ClassificacaoNaturezaStaging.CodigoComparacao equals cfn.CodigoComparacao
					join ea in esferasAdministrativas on row.EsferaAdministrativaStaging.CodigoComparacao equals ea.CodigoComparacao
					join pe in periodos on row.PeriodoStaging.CodigoComparacao equals pe.CodigoComparacao
					join te in tempos on row.TempoStaging.CodigoComparacao equals te.CodigoComparacao
					join ug in unidadesGestoras on row.UnidadeGestoraStaging.CodigoComparacao equals ug.CodigoComparacao
					select new FT_ReceitaDotacaoMunicipio
					{
						Arrecadada = row.Arrecadada,
						ArrecadadaFUNDEB = row.ArrecadadaFUNDEB,
						IdClassificacaoFonteRecurso = cfr.Id,
						IdClassificacaoNatureza = cfn.Id,
						IdEsferaAdministrativa = ea.Id,
						IdOriginal = row.IdOriginal,
						IdPeriodo = pe.Id,
						IdSeedHistory = IdSeedHistory,
						IdTempo = te.Id,
						IdUnidadeGestora = ug.Id,
						PrevisaoAtualizada = row.PrevisaoAtualizada,
						PrevisaoAtualizadaFUNDEB = row.PrevisaoAtualizadaFUNDEB,
						PrevisaoInicial = row.PrevisaoInicial,
						PrevisaoInicialFUNDEB = row.PrevisaoInicialFUNDEB
					})
					.ToList();

			observer.OnNext(new AddRangeObserverResult
			{
				Metadata = new HashSet<string> { "info:Processing facts" }
			});

			precisamSalvar.InsertMerge(() => Settings.ServiceProvider.GetService<DWControleSocialContext>(), o => o.Id, o => o.IdOriginal.ToString(), observer);
			return rows;
		}
	}
}