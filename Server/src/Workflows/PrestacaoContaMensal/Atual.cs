using ControleSocial.Domain.Models.DWControleSocial;
using System;
using System.Linq;
using WorkflowApi.Core.Workflows;

namespace ControleSocial.Workflows.PrestacaoContaMensal
{
	public class Atual : QueryableWorkflow<FT_PrestacaoContaMensal, IQueryable<Atual.Result>>
	{
		public override IQueryable<Atual.Result> Execute(IQueryable<FT_PrestacaoContaMensal> entryData)
		{
			return entryData
					.Select(o => new Result
					{
						Ano = o.Tempo.Ano,
						Mes = o.Tempo.Mes,
						DataHomologacao = o.DataHomologacao,
						DataLimite = o.DataLimite,
						EmAtraso = o.EmAtraso,
						EmDia = o.EmDia,
						EmOmissao = o.EmOmissao,
						EmTempo = o.EmTempo
					})
					.OrderBy(o => o.Ano)
					.ThenBy(o => o.Mes);
		}

		public class Result
		{
			public short Ano { get; set; }
			public short Mes { get; set; }
			public DateTime DataLimite { get; set; }
			public DateTime? DataHomologacao { get; set; }
			public bool EmAtraso { get; set; }
			public bool EmDia { get; set; }
			public bool EmOmissao { get; set; }
			public bool EmTempo { get; set; }
		}
	}
}
