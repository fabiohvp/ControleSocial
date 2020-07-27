using ControleSocial.Domain.Models.DWControleSocial;
using LinqKit;
using System.Linq;
using WorkflowApi.Core.Workflows;

namespace ControleSocial.Workflows.Municipio.Receita
{
	public class FiltrarPorCodigo : QueryableWorkflow<FT_ReceitaDotacaoMunicipio>
	{
		public string Codigo { get; set; }

		public FiltrarPorCodigo(string codigo)
		{
			Codigo = codigo;
		}

		public override IQueryable<FT_ReceitaDotacaoMunicipio> Execute(IQueryable<FT_ReceitaDotacaoMunicipio> entryData)
		{
			return entryData
				.Where(o => o.UnidadeGestora.Codigo.StartsWith(Codigo))
				.AsExpandableEFCore();
		}
	}
}
