using ControleSocial.Domain.Models.DWControleSocial;
using LinqKit;
using System.Linq;
using WorkflowApi.Core.Workflows;

namespace ControleSocial.Workflows.Municipio.Receita
{
	public class FiltrarPorAnoECodigo : QueryableWorkflow<FT_ReceitaDotacaoMunicipio>
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

		public override IQueryable<FT_ReceitaDotacaoMunicipio> Execute(IQueryable<FT_ReceitaDotacaoMunicipio> entryData)
		{
			return entryData
				.Where(o => o.Tempo.Ano == Ano && o.UnidadeGestora.Codigo.StartsWith(Codigo))
				.AsExpandableEFCore();
		}
	}
}
