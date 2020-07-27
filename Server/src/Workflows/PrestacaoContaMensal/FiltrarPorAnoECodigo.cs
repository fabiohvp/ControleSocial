using ControleSocial.Domain.Models.DWControleSocial;
using LinqKit;
using System.Linq;
using WorkflowApi.Core.Workflows;

namespace ControleSocial.Workflows.PrestacaoContaMensal
{
	public class FiltrarPorAnoECodigo : QueryableWorkflow<FT_PrestacaoContaMensal>
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

		public override IQueryable<FT_PrestacaoContaMensal> Execute(IQueryable<FT_PrestacaoContaMensal> entryData)
		{
			return entryData
				.Where(o => o.Tempo.Ano == Ano && o.UnidadeGestora.Codigo.StartsWith(Codigo))
				.AsExpandableEFCore();
		}
	}
}
