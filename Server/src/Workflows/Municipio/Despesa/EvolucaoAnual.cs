using ControleSocial.Domain.Models.DWControleSocial;
using WorkflowApi.Core.Workflows;
using System.Linq;

namespace ControleSocial.Workflows.Municipio.Despesa
{
	public class EvolucaoAnual : QueryableWorkflow<FT_DespesaDotacaoMunicipio, IQueryable<EvolucaoAnual.Result>>
	{
		public short Ano { get; set; }
		public int Quantidade { get; set; }

		public EvolucaoAnual(short ano, int quantidade)
		{
			Ano = ano;
			Quantidade = quantidade;
		}

		public EvolucaoAnual(long ano, long quantidade = 5)
				: this((short)ano, (short)quantidade)
		{ }

		public override IQueryable<Result> Execute(IQueryable<FT_DespesaDotacaoMunicipio> entryData)
		{
			if (Quantidade > 10)
			{
				throw new System.InvalidOperationException("A quantidade máxima são 10 anos");
			}

			var quantidade = Quantidade - 1;
			var anoInicial = Ano - quantidade;
			var anoFinal = Ano;

			if (anoInicial < 2009)
			{
				anoInicial = 2009;
				anoFinal = (short)(anoInicial + quantidade);
			}

			return entryData
					.Where(o => o.Tempo.Ano >= anoInicial && o.Tempo.Ano <= anoFinal)
					.GroupBy(o => o.Tempo.Ano)
					.Select(o => new Result
					{
						Ano = o.Key,
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
			public decimal? Empenhada { get; set; }
			public decimal? Liquidada { get; set; }
			public decimal? Paga { get; set; }
			public decimal? PrevisaoInicial { get; set; }
		}
	}
}
