using ControleSocial.Domain.Models.DWControleSocial;
using WorkflowApi.Core.Workflows;
using System.Linq;
using LinqKit;

namespace ControleSocial.Workflows.Municipio.Receita
{
	public class FiltrarPorAno : QueryableWorkflow<FT_ReceitaDotacaoMunicipio>
	{
		public short Ano { get; set; }

		public FiltrarPorAno(short ano)
		{
			Ano = ano;
		}

		public FiltrarPorAno(long ano)
				: this((short)ano)
		{ }

		public override IQueryable<FT_ReceitaDotacaoMunicipio> Execute(IQueryable<FT_ReceitaDotacaoMunicipio> entryData)
		{
			return entryData
				.Where(o => o.Tempo.Ano == Ano)
				.AsExpandableEFCore();
		}
	}
}
