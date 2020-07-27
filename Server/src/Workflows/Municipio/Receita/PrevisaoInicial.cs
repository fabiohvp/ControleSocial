using ControleSocial.Domain.Models.DWControleSocial;
using WorkflowApi.Core.Workflows;
using System.Linq;

namespace ControleSocial.Workflows.Municipio.Receita
{
	public class PrevisaoInicial : QueryableWorkflow<FT_ReceitaDotacaoMunicipio, decimal?>
	{
		public override decimal? Execute(IQueryable<FT_ReceitaDotacaoMunicipio> entryData)
		{
			return entryData
								.Sum(o => o.PrevisaoInicial);
		}
	}
}
