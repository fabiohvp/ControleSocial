using ControleSocial.Domain.Models.DWControleSocial;
using System.Linq;
using WorkflowApi.Core.Workflows;
using LinqKit;

namespace ControleSocial.Workflows.Municipio.Despesa
{
	public class FiltrarPorAnoECodigo : QueryableWorkflow<FT_DespesaDotacaoMunicipio>
	{
		public short Ano { get; set; }
		public string Codigo { get; set; }

		public FiltrarPorAnoECodigo(short ano, string codigo)
		{
			Ano = ano;
			Codigo = codigo;
		}

		public FiltrarPorAnoECodigo(long ano, string codigo)
				: this((short)ano, codigo)
		{ }

		public override IQueryable<FT_DespesaDotacaoMunicipio> Execute(IQueryable<FT_DespesaDotacaoMunicipio> entryData)
		{
			return entryData
				.Where(o => o.Tempo.Ano == Ano && o.UnidadeGestora.Codigo.StartsWith(Codigo))
				.AsExpandableEFCore();
		}
	}
}
