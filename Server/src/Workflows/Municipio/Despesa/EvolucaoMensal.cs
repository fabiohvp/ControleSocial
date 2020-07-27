using ControleSocial.Domain.Models.DWControleSocial;
using WorkflowApi.Core.Workflows;
using System.Linq;

namespace ControleSocial.Workflows.Municipio.Despesa
{
	public class EvolucaoMensal : QueryableWorkflow<FT_DespesaDotacaoMunicipio, IQueryable<EvolucaoMensal.Result>>
	{
		public short Ano { get; set; }

		public EvolucaoMensal(short ano)
		{
			Ano = ano;
		}

		public EvolucaoMensal(long ano)
				: this((short)ano)
		{ }

		public override IQueryable<Result> Execute(IQueryable<FT_DespesaDotacaoMunicipio> entryData)
		{
			return entryData
					.Where(o => o.Tempo.Ano == Ano)
					.GroupBy(o => o.Tempo.Mes)
					.Select(o => new Result
					{
						Ano = Ano,
						Mes = o.Key,
						Empenhada = o.Sum(p => p.Empenhada),
						Liquidada = o.Sum(p => p.Liquidada),
						Paga = o.Sum(p => p.Paga),
						PrevisaoInicial = o.Sum(p => p.PrevisaoInicial)
					})
					.OrderBy(o => o.Ano);
		}

		public class Result
		{
			public short Ano { get; set; }
			public short Mes { get; set; }
			public decimal? Empenhada { get; set; }
			public decimal? Liquidada { get; set; }
			public decimal? Paga { get; set; }
			public decimal? PrevisaoInicial { get; set; }
		}
	}
}
