using ControleSocial.Domain.Models.DWControleSocial;
using System.Linq;
using WorkflowApi.Core.Workflows;
using LinqKit;

namespace ControleSocial.Workflows.Municipio.Despesa
{
	public class FiltrarPorAno : QueryableWorkflow<FT_DespesaDotacaoMunicipio>
	{
		public short Ano { get; set; }

		public FiltrarPorAno(short ano)
		{
			Ano = ano;
		}

		public FiltrarPorAno(long ano)
				: this((short)ano)
		{ }

		public override IQueryable<FT_DespesaDotacaoMunicipio> Execute(IQueryable<FT_DespesaDotacaoMunicipio> entryData)
		{
			return entryData
				.Where(o => o.Tempo.Ano == Ano)
				.AsExpandableEFCore();
		}
	}
}
