using ControleSocial.Domain.Contexts;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleSocial.Domain.Models.Staging
{
	public class FT_DespesaDotacaoMunicipioStaging : IFT_Staging<FT_DespesaDotacaoMunicipioStaging>
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

		public string NomeUnidadeGestora { get; set; }
		public string NomePoderUnidadeGestora { get; set; }
		public string NomeTipoUnidadeGestora { get; set; }
		public string NomeEsferaAdministrativa { get; set; }

		public string CodigoCategoriaNatureza { get; set; }
		public string CodigoElementoNatureza { get; set; }
		public string CodigoGrupoNatureza { get; set; }
		public string CodigoModalidadeNatureza { get; set; }
		public string CodigoSubElementoNatureza { get; set; }
		public string CodigoCompletoNatureza { get; set; }

		public string NomeCategoriaNatureza { get; set; }
		public string NomeGrupoNatureza { get; set; }
		public string NomeModalidadeNatureza { get; set; }
		public string NomeElementoNatureza { get; set; }
		public string NomeSubElementoNatureza { get; set; }

		public string CodigoDetalhamentoFonteERecurso { get; set; }
		public string CodigoEspecificacaoFonteERecurso { get; set; }
		public string CodigoGrupoFonteERecurso { get; set; }
		public string CodigoCompletoFonteERecurso { get; set; }

		public string NomeDetalhamentoFonteERecurso { get; set; }
		public string NomeEspecificacaoFonteERecurso { get; set; }
		public string NomeGrupoFonteERecurso { get; set; }

		public string CodigoFuncaoFuncaoESubFuncao { get; set; }
		public string CodigoSubFuncaoFuncaoESubFuncao { get; set; }
		public string CodigoCompletoFuncaoESubFuncao { get; set; }

		public string NomeFuncaoFuncaoESubFuncao { get; set; }
		public string NomeSubFuncaoFuncaoESubFuncao { get; set; }

		public string CodigoAcaoProgramaEAcao { get; set; }
		public string CodigoProgramaProgramaEAcao { get; set; }
		public string CodigoCompletoProgramaEAcao { get; set; }

		public string NomeAcaoProgramaEAcao { get; set; }
		public string NomeProgramaProgramaEAcao { get; set; }

		public string CodigoOrgaoOrgaoEUnidadeOrcamentaria { get; set; }
		public string CodigoUnidadeOrcamentariaOrgaoEUnidadeOrcamentaria { get; set; }
		public string CodigoCompletoOrgaoEUnidadeOrcamentaria { get; set; }

		public string NomeOrgaoOrgaoEUnidadeOrcamentaria { get; set; }
		public string NomeUnidadeOrcamentariaOrgaoEUnidadeOrcamentaria { get; set; }

		public decimal? Liquidada { get; set; }
		public decimal? Paga { get; set; }
		public decimal? PrevisaoAtualizada { get; set; }
		public decimal? PrevisaoInicial { get; set; }
		public decimal? Empenhada { get; set; }

		public string CodigoComparacao { get; }

		private DIM_ClassificacaoDespesaDotacaoMunicipioStaging ClassificacaoNaturezaStaging { get; set; }
		private DIM_ClassificacaoFonteERecursoStaging ClassificacaoFonteERecursoStaging { get; set; }
		private DIM_ClassificacaoFuncaoESubFuncaoStaging ClassificacaoFuncaoESubFuncaoStaging { get; set; }
		private DIM_ClassificacaoOrgaoEUnidadeOrcamentariaStaging ClassificacaoOrgaoEUnidadeOrcamentariaStaging { get; set; }
		private DIM_ClassificacaoProgramaEAcaoStaging ClassificacaoProgramaEAcaoStaging { get; set; }
		private DIM_EsferaAdministrativaStaging EsferaAdministrativaStaging { get; set; }
		private DIM_PeriodoStaging PeriodoStaging { get; set; }
		private DIM_TempoStaging TempoStaging { get; set; }
		private DIM_UnidadeGestoraStaging UnidadeGestoraStaging { get; set; }

		public void Initialize(long idSeedHistory)
		{
			IdSeedHistory = idSeedHistory;

			ClassificacaoNaturezaStaging = new DIM_ClassificacaoDespesaDotacaoMunicipioStaging
			{
				CodigoCompleto = CodigoCompletoNatureza?.ToUpperRemovingBreaklines(),

				CodigoCategoria = CodigoCategoriaNatureza?.ToUpperRemovingBreaklines(),
				CodigoGrupo = CodigoGrupoNatureza?.ToUpperRemovingBreaklines(),
				CodigoModalidade = CodigoModalidadeNatureza?.ToUpperRemovingBreaklines(),
				CodigoElemento = CodigoElementoNatureza?.ToUpperRemovingBreaklines(),
				CodigoSubElemento = CodigoSubElementoNatureza?.ToUpperRemovingBreaklines(),

				NomeCategoria = NomeCategoriaNatureza?.ToUpperRemovingBreaklines(),
				NomeGrupo = NomeGrupoNatureza?.ToUpperRemovingBreaklines(),
				NomeModalidade = NomeModalidadeNatureza?.ToUpperRemovingBreaklines(),
				NomeElemento = NomeElementoNatureza?.ToUpperRemovingBreaklines(),
				NomeSubElemento = NomeSubElementoNatureza?.ToUpperRemovingBreaklines()
			};

			ClassificacaoFonteERecursoStaging = new DIM_ClassificacaoFonteERecursoStaging
			{
				CodigoCompleto = CodigoCompletoFonteERecurso?.ToUpperRemovingBreaklines(),
				CodigoUnidadeGestora = CodigoUnidadeGestora,

				CodigoDetalhamento = CodigoDetalhamentoFonteERecurso?.ToUpperRemovingBreaklines(),
				CodigoFonteReduzida = CodigoEspecificacaoFonteERecurso?.ToUpperRemovingBreaklines(),
				CodigoGrupo = CodigoGrupoFonteERecurso?.ToUpperRemovingBreaklines(),

				NomeDetalhamento = NomeDetalhamentoFonteERecurso?.ToUpperRemovingBreaklines(),
				NomeFonteReduzida = NomeEspecificacaoFonteERecurso?.ToUpperRemovingBreaklines(),
				NomeGrupo = NomeGrupoFonteERecurso?.ToUpperRemovingBreaklines()
			};

			ClassificacaoFuncaoESubFuncaoStaging = new DIM_ClassificacaoFuncaoESubFuncaoStaging
			{
				CodigoFuncao = CodigoFuncaoFuncaoESubFuncao?.ToUpperRemovingBreaklines(),
				CodigoSubFuncao = CodigoSubFuncaoFuncaoESubFuncao?.ToUpperRemovingBreaklines(),
				NomeFuncao = NomeFuncaoFuncaoESubFuncao?.ToUpperRemovingBreaklines(),
				NomeSubFuncao = NomeSubFuncaoFuncaoESubFuncao?.ToUpperRemovingBreaklines()
			};

			ClassificacaoOrgaoEUnidadeOrcamentariaStaging = new DIM_ClassificacaoOrgaoEUnidadeOrcamentariaStaging
			{
				CodigoOrgao = CodigoOrgaoOrgaoEUnidadeOrcamentaria?.ToUpperRemovingBreaklines(),
				CodigoUnidadeGestora = CodigoUnidadeGestora,
				CodigoUnidadeOrcamentaria = CodigoUnidadeOrcamentariaOrgaoEUnidadeOrcamentaria?.ToUpperRemovingBreaklines(),
				NomeOrgao = NomeOrgaoOrgaoEUnidadeOrcamentaria?.ToUpperRemovingBreaklines(),
				NomeUnidadeOrcamentaria = NomeUnidadeOrcamentariaOrgaoEUnidadeOrcamentaria?.ToUpperRemovingBreaklines()
			};

			ClassificacaoProgramaEAcaoStaging = new DIM_ClassificacaoProgramaEAcaoStaging
			{
				CodigoAcao = CodigoAcaoProgramaEAcao?.ToUpperRemovingBreaklines(),
				CodigoPrograma = CodigoProgramaProgramaEAcao?.ToUpperRemovingBreaklines(),
				CodigoUnidadeGestora = CodigoUnidadeGestora,
				NomeAcao = NomeAcaoProgramaEAcao?.ToUpperRemovingBreaklines(),
				NomePrograma = NomeProgramaProgramaEAcao?.ToUpperRemovingBreaklines()
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
				NomeTipoUnidadeGestora = NomeTipoUnidadeGestora,
			};
		}

		public IEnumerable<FT_DespesaDotacaoMunicipioStaging> Save(IEnumerable<FT_DespesaDotacaoMunicipioStaging> rows, IObserver<AddRangeObserverResult> observer = default)
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

			var classificacoesNaturezas = rows.Select(o => o.ClassificacaoNaturezaStaging);
			classificacoesNaturezas = new DIM_ClassificacaoDespesaDotacaoMunicipioStaging().Save(classificacoesNaturezas);

			var classificacoesFontesRecursos = rows.Select(o => o.ClassificacaoFonteERecursoStaging);
			classificacoesFontesRecursos = new DIM_ClassificacaoFonteERecursoStaging().Save(classificacoesFontesRecursos);

			var classificacoesFuncaoSubFuncao = rows.Select(o => o.ClassificacaoFuncaoESubFuncaoStaging);
			classificacoesFuncaoSubFuncao = new DIM_ClassificacaoFuncaoESubFuncaoStaging().Save(classificacoesFuncaoSubFuncao);

			var classificacoesOrgaoEUnidadeOrcamentaria = rows.Select(o => o.ClassificacaoOrgaoEUnidadeOrcamentariaStaging);
			classificacoesOrgaoEUnidadeOrcamentaria = new DIM_ClassificacaoOrgaoEUnidadeOrcamentariaStaging().Save(classificacoesOrgaoEUnidadeOrcamentaria);

			var classificacoesProgramaAcao = rows.Select(o => o.ClassificacaoProgramaEAcaoStaging);
			classificacoesProgramaAcao = new DIM_ClassificacaoProgramaEAcaoStaging().Save(classificacoesProgramaAcao);

			var precisamSalvar = (
					from row in rows
					join cfr in classificacoesFontesRecursos on row.ClassificacaoFonteERecursoStaging.CodigoComparacao equals cfr.CodigoComparacao
					join cfn in classificacoesNaturezas on row.ClassificacaoNaturezaStaging.CodigoComparacao equals cfn.CodigoComparacao
					join cff in classificacoesFuncaoSubFuncao on row.ClassificacaoFuncaoESubFuncaoStaging.CodigoComparacao equals cff.CodigoComparacao
					join cfo in classificacoesOrgaoEUnidadeOrcamentaria on row.ClassificacaoOrgaoEUnidadeOrcamentariaStaging.CodigoComparacao equals cfo.CodigoComparacao
					join cfp in classificacoesProgramaAcao on row.ClassificacaoProgramaEAcaoStaging.CodigoComparacao equals cfp.CodigoComparacao
					join ea in esferasAdministrativas on row.EsferaAdministrativaStaging.CodigoComparacao equals ea.CodigoComparacao
					join pe in periodos on row.PeriodoStaging.CodigoComparacao equals pe.CodigoComparacao
					join te in tempos on row.TempoStaging.CodigoComparacao equals te.CodigoComparacao
					join ug in unidadesGestoras on row.UnidadeGestoraStaging.CodigoComparacao equals ug.CodigoComparacao
					select new FT_DespesaDotacaoMunicipio
					{
						Empenhada = row.Empenhada,
						IdClassificacaoNatureza = cfn.Id,
						IdClassificacaoFonteRecurso = cfr.Id,
						IdClassificacaoFuncional = cff.Id,
						IdClassificacaoOrcamentaria = cfo.Id,
						IdClassificacaoPrograma = cfp.Id,
						IdEsferaAdministrativa = ea.Id,
						IdOriginal = row.IdOriginal,
						IdPeriodo = pe.Id,
						IdSeedHistory = IdSeedHistory,
						IdTempo = te.Id,
						IdUnidadeGestora = ug.Id,
						Liquidada = row.Liquidada,
						Paga = row.Paga,
						PrevisaoAtualizada = row.PrevisaoAtualizada,
						PrevisaoInicial = row.PrevisaoInicial
					})
					.ToList();

			observer.OnNext(new AddRangeObserverResult
			{
				Metadata = new HashSet<string> { "info:Processing facts" }
			});

			precisamSalvar.InsertMerge(() => Settings.ServiceProvider.GetService<DWControleSocialContext>(), o => o.Id, o => o.IdOriginal, observer);
			return rows;
		}
	}
}