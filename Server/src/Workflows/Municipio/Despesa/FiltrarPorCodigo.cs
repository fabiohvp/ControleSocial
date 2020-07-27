using ControleSocial.Domain.Models.DWControleSocial;
using WorkflowApi.Core.Workflows;
using System.Linq;
using LinqKit;

namespace ControleSocial.Workflows.Municipio.Despesa
{
	public class FiltrarPorCodigo : QueryableWorkflow<FT_DespesaDotacaoMunicipio>
	{
		public string Codigo { get; set; }

		public FiltrarPorCodigo(string codigo)
		{
			Codigo = codigo;
		}

		public override IQueryable<FT_DespesaDotacaoMunicipio> Execute(IQueryable<FT_DespesaDotacaoMunicipio> entryData)
		{
			return entryData
				.Where(o => o.UnidadeGestora.Codigo.StartsWith(Codigo))
				.AsExpandableEFCore();
		}
	}
}
