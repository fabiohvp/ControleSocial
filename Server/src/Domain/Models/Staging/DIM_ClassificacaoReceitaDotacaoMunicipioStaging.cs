using ControleSocial.Domain.Contexts;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace ControleSocial.Domain.Models.Staging
{
	public class DIM_ClassificacaoReceitaDotacaoMunicipioStaging : IStaging<DIM_ClassificacaoReceitaDotacaoMunicipioStaging>
	{
		private string _CodigoRubrica;
		private string _CodigoAlinea;
		private string _CodigoSubAlinea;
		private string _CodigoDetalhamentoNivel1;
		private string _CodigoDetalhamentoNivel2;
		private string _CodigoDetalhamentoNivel3;
		private string _CodigoTipoDetalhamento;

		public long Id { get; set; }
		public string CodigoCategoria { get; set; }
		public string CodigoOrigem { get; set; }
		public string CodigoEspecie { get; set; }
		public string CodigoRubrica { get { return _CodigoRubrica; } set { _CodigoRubrica = FormatarStringVazia(value, 1); } }
		public string CodigoAlinea { get { return _CodigoAlinea; } set { _CodigoAlinea = FormatarStringVazia(value, 2); } }
		public string CodigoSubAlinea { get { return _CodigoSubAlinea; } set { _CodigoSubAlinea = FormatarStringVazia(value, 2); } }
		public string CodigoDetalhamentoNivel1 { get { return _CodigoDetalhamentoNivel1; } set { _CodigoDetalhamentoNivel1 = FormatarStringVazia(value, 1); } }
		public string CodigoDetalhamentoNivel2 { get { return _CodigoDetalhamentoNivel2; } set { _CodigoDetalhamentoNivel2 = FormatarStringVazia(value, 2); } }
		public string CodigoDetalhamentoNivel3 { get { return _CodigoDetalhamentoNivel3; } set { _CodigoDetalhamentoNivel3 = FormatarStringVazia(value, 1); } }
		public string CodigoTipoDetalhamento { get { return _CodigoTipoDetalhamento; } set { _CodigoTipoDetalhamento = FormatarStringVazia(value, 1); } }
		public string CodigoCompleto { get; set; }

		public string NomeCategoria { get; set; }
		public string NomeOrigem { get; set; }
		public string NomeEspecie { get; set; }
		public string NomeRubrica { get; set; }
		public string NomeAlinea { get; set; }
		public string NomeSubAlinea { get; set; }
		public string NomeDetalhamentoNivel1 { get; set; }
		public string NomeDetalhamentoNivel2 { get; set; }
		public string NomeDetalhamentoNivel3 { get; set; }
		public string NomeTipoDetalhamento { get; set; }

		public string CodigoComparacao
		{
			get
			{
				return $"{CodigoCategoria}-{CodigoOrigem}-{CodigoEspecie}-{CodigoRubrica}-{CodigoAlinea}-{CodigoSubAlinea}-{CodigoDetalhamentoNivel1}-{CodigoDetalhamentoNivel2}-{CodigoDetalhamentoNivel3}-{CodigoTipoDetalhamento}-{NomeCategoria}-{NomeOrigem}-{NomeEspecie}-{NomeRubrica}-{NomeAlinea}-{NomeSubAlinea}-{NomeDetalhamentoNivel1}-{NomeDetalhamentoNivel2}-{NomeDetalhamentoNivel3}-{NomeTipoDetalhamento}";
			}
			private set { }
		}

		private static string FormatarStringVazia(string value, int size)
		{
			return string.IsNullOrEmpty(value) ? "-".PadLeft(size, '-') : value;
		}

		public IEnumerable<DIM_ClassificacaoReceitaDotacaoMunicipioStaging> Save(IEnumerable<DIM_ClassificacaoReceitaDotacaoMunicipioStaging> rows, IObserver<AddRangeObserverResult> observer = default)
		{
			rows = rows
					.GroupBy(o => o.CodigoComparacao)
					.Select(o => o.FirstOrDefault())
					.ToList();

			using (var dbContext = Settings.ServiceProvider.GetService<DWControleSocialContext>())
			{
				var precisamSalvar = rows
						.Select(o => new DIM_ClassificacaoReceitaDotacaoMunicipio
						{
							CodigoCategoria = o.CodigoCategoria,
							CodigoOrigem = o.CodigoOrigem,
							CodigoEspecie = o.CodigoEspecie,
							CodigoRubrica = o.CodigoRubrica,
							CodigoAlinea = o.CodigoAlinea,
							CodigoSubAlinea = o.CodigoSubAlinea,
							CodigoDetalhamentoNivel1 = o.CodigoDetalhamentoNivel1,
							CodigoDetalhamentoNivel2 = o.CodigoDetalhamentoNivel2,
							CodigoDetalhamentoNivel3 = o.CodigoDetalhamentoNivel3,
							CodigoTipoDetalhamento = o.CodigoTipoDetalhamento,

							NomeCategoria = o.NomeCategoria,
							NomeOrigem = o.NomeOrigem,
							NomeEspecie = o.NomeEspecie,
							NomeRubrica = o.NomeRubrica,
							NomeAlinea = o.NomeAlinea,
							NomeSubAlinea = o.NomeSubAlinea,
							NomeDetalhamentoNivel1 = o.NomeDetalhamentoNivel1,
							NomeDetalhamentoNivel2 = o.NomeDetalhamentoNivel2,
							NomeDetalhamentoNivel3 = o.NomeDetalhamentoNivel3,
							NomeTipoDetalhamento = o.NomeTipoDetalhamento
						})
						.ToList();

				return precisamSalvar.InsertMerge(() => Settings.ServiceProvider.GetService<DWControleSocialContext>(), o => o.Id, o => o.CodigoCategoria + "-" + o.CodigoOrigem + "-" + o.CodigoEspecie + "-" + o.CodigoRubrica + "-" + o.CodigoAlinea + "-" + o.CodigoSubAlinea + "-" + o.CodigoDetalhamentoNivel1 + "-" + o.CodigoDetalhamentoNivel2 + "-" + o.CodigoDetalhamentoNivel3 + "-" + o.CodigoTipoDetalhamento + "-" + o.NomeCategoria + "-" + o.NomeOrigem + "-" + o.NomeEspecie + "-" + o.NomeRubrica + "-" + o.NomeAlinea + "-" + o.NomeSubAlinea + "-" + o.NomeDetalhamentoNivel1 + "-" + o.NomeDetalhamentoNivel2 + "-" + o.NomeDetalhamentoNivel3 + "-" + o.NomeTipoDetalhamento, observer)
						.Select(o => new DIM_ClassificacaoReceitaDotacaoMunicipioStaging
						{
							Id = o.Id,
							CodigoCompleto = o.CodigoCompleto,

							CodigoCategoria = o.CodigoCategoria,
							CodigoOrigem = o.CodigoOrigem,
							CodigoEspecie = o.CodigoEspecie,
							CodigoRubrica = o.CodigoRubrica,
							CodigoAlinea = o.CodigoAlinea,
							CodigoSubAlinea = o.CodigoSubAlinea,
							CodigoDetalhamentoNivel1 = o.CodigoDetalhamentoNivel1,
							CodigoDetalhamentoNivel2 = o.CodigoDetalhamentoNivel2,
							CodigoDetalhamentoNivel3 = o.CodigoDetalhamentoNivel3,
							CodigoTipoDetalhamento = o.CodigoTipoDetalhamento,

							NomeCategoria = o.NomeCategoria,
							NomeOrigem = o.NomeOrigem,
							NomeEspecie = o.NomeEspecie,
							NomeRubrica = o.NomeRubrica,
							NomeAlinea = o.NomeAlinea,
							NomeSubAlinea = o.NomeSubAlinea,
							NomeDetalhamentoNivel1 = o.NomeDetalhamentoNivel1,
							NomeDetalhamentoNivel2 = o.NomeDetalhamentoNivel2,
							NomeDetalhamentoNivel3 = o.NomeDetalhamentoNivel3,
							NomeTipoDetalhamento = o.NomeTipoDetalhamento
						})
						.ToList();
			}
		}
	}
}
