using ControleSocial.Domain.Models.DWControleSocial;
using WorkflowApi.Core.Workflows;
using System.Linq;

namespace ControleSocial.Workflows.Municipio.Despesa
{
	public class MaioresLiquidadaPorFuncao : Workflow
	{
		public short Ano { get; set; }
		public int Quantidade { get; set; }

		public MaioresLiquidadaPorFuncao(short ano, int quantidade)
		{
			Ano = ano;
			Quantidade = quantidade;
		}

		public MaioresLiquidadaPorFuncao(long ano, long quantidade = 5)
				: this((short)ano, (short)quantidade)
		{ }

		public override object Execute(object entryData)
		{
			if (Quantidade > 10)
			{
				throw new System.InvalidOperationException("A quantidade máxima são 10 anos");
			}

			return entryData
					.AsQueryable<FT_DespesaDotacaoMunicipio>()
					.Where(o => o.Tempo.Ano == Ano)
					.GroupBy(o => o.ClassificacaoFuncional.NomeFuncao)
					.Select(o => new Result
					{
						Nome = o.Key,
						Valor = o.Sum(p => p.Liquidada)
					})
					.OrderByDescending(o => o.Valor)
					.Take(Quantidade);
		}

		public class Result
		{
			public string Nome { get; set; }
			public decimal? Valor { get; set; }
		}
	}
}
