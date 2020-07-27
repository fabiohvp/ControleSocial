using ControleSocial.Domain.Contexts;
using WorkflowApi.Core.Workflows;
using System.Linq;

namespace ControleSocial.Workflows.Municipio.Gestao
{
	public class NumeroHabitantes : Workflow
	{
		public short Ano { get; set; }
		public string Codigo { get; set; }

		public NumeroHabitantes(long ano, string codigo)
		{
			Ano = (short)ano;
			Codigo = codigo;
		}

		public override object Execute(object entryData)
		{
			//TODO: Acertar
			return 1;
			//return DbContext
			//    .As<DWControleSocialContext>()
			//    .Gestao
			//    .Where(o => o.Ano == Ano && o.EsferaAdministrativa.Codigo.StartsWith(Codigo.Substring(0, 3)))
			//    .Select(o => o.Populacao)
			//    .Single();
		}
	}
}
