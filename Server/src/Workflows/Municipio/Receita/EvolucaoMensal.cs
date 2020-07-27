using ControleSocial.Domain.Models.DWControleSocial;
using WorkflowApi.Core.Workflows;
using System.Linq;

namespace ControleSocial.Workflows.Municipio.Receita
{
	public class EvolucaoMensal : QueryableWorkflow<FT_ReceitaDotacaoMunicipio, IQueryable<EvolucaoMensal.Result>>
	{
		public short Ano { get; set; }

		public EvolucaoMensal(short ano)
		{
			Ano = ano;
		}

		public EvolucaoMensal(long ano)
				: this((short)ano)
		{ }

		public override IQueryable<Result> Execute(IQueryable<FT_ReceitaDotacaoMunicipio> entryData)
		{
			return entryData
					.Where(o => o.Tempo.Ano == Ano)
					.GroupBy(o => o.Tempo.Mes)
					.Select(o => new Result
					{
						Ano = Ano,
						Mes = o.Key,
						Arrecadada = o.Sum(p => p.Arrecadada),
						PrevisaoInicial = o.Sum(p => p.PrevisaoInicial)
					})
					.OrderBy(o => o.Ano);
		}

		public class Result
		{
			public short Ano { get; set; }
			public short Mes { get; set; }
			public decimal? Arrecadada { get; set; }
			public decimal? PrevisaoInicial { get; set; }
		}
	}
}
