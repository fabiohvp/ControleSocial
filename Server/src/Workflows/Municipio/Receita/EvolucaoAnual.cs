using ControleSocial.Domain.Models.DWControleSocial;
using WorkflowApi.Core.Workflows;
using System.Linq;

namespace ControleSocial.Workflows.Municipio.Receita
{
	public class EvolucaoAnual : QueryableWorkflow<FT_ReceitaDotacaoMunicipio, IQueryable<EvolucaoAnual.Result>>
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

		public override IQueryable<Result> Execute(IQueryable<FT_ReceitaDotacaoMunicipio> entryData)
		{
			if (Quantidade > 10)
			{
				throw new System.InvalidOperationException("A quantidade máxima são 10 anos");
			}

			var quantidade = Quantidade - 1;
			var anoInicial = Ano - quantidade;
			var anoFinal = Ano;

			if (anoInicial < Settings.AnoMinimo)
			{
				anoInicial = Settings.AnoMinimo;
				anoFinal = (short)(anoInicial + quantidade);
			}

			return entryData
					.Where(o => o.Tempo.Ano >= anoInicial && o.Tempo.Ano <= anoFinal)
					.GroupBy(o => o.Tempo.Ano)
					.Select(o => new Result
					{
						Ano = o.Key,
						Arrecadada = o.Sum(p => p.Arrecadada),
						PrevisaoInicial = o.Sum(p => p.PrevisaoInicial)
					})
					.OrderBy(o => o.Ano);
		}

		public class Result
		{
			public short Ano { get; set; }
			public decimal? Arrecadada { get; set; }
			public decimal? PrevisaoInicial { get; set; }
		}
	}
}
