using ControleSocial.Domain.Models.DWControleSocial;
using WorkflowApi.Core.Workflows;
using System.Linq;

namespace ControleSocial.Workflows.Municipio.Despesa
{
	public class Liquidada : QueryableWorkflow<FT_DespesaDotacaoMunicipio, decimal?>
	{
		public override decimal? Execute(IQueryable<FT_DespesaDotacaoMunicipio> entryData)
		{
			return entryData
					.Sum(o => o.Liquidada);
		}
	}
}
