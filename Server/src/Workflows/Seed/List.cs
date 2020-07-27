using System;
using ControleSocial.Domain.Models.DWControleSocial;
using LinqKit;
using System.Linq;
using WorkflowApi.Core.Workflows;

namespace ControleSocial.Workflows.Seed
{
	public class List : QueryableWorkflow<__SeedHistory, IQueryable<List.Result>>
	{
		public override IQueryable<Result> Execute(IQueryable<__SeedHistory> entryData)
		{
			return entryData
				.Select(o => new Result
				{
					Id = o.Id,
					DataCriacao = o.DataCriacao,
					Arquivo = o.Arquivo
				});
		}

		public class Result
		{
			public long Id { get; set; }
			public DateTime DataCriacao { get; set; }
			public string Arquivo { get; set; }
		}
	}
}
