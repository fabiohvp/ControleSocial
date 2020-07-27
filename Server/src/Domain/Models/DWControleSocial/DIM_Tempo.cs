using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(DIM_Tempo))]
    public partial class DIM_Tempo : IEntity
    {
        public const int MesInicial = 1;
        public const int MesFinal = 12;

        public DIM_Tempo()
        {
            DespesasDotacaoMunicipio = new HashSet<FT_DespesaDotacaoMunicipio>();
            PrestacoesContasMensais = new HashSet<FT_PrestacaoContaMensal>();
            ReceitasDotacaoMunicipio = new HashSet<FT_ReceitaDotacaoMunicipio>();
        }

        [Key]
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public short Ano { get; set; }
        public short Mes { get; set; }
        public DateTime Data { get; set; }

        public short Bimestre { get; set; }

        public short Trimestre { get; set; }

        public short Quadrimestre { get; set; }

        public short Semestre { get; set; }

        public string NomeMes { get; set; }

        public string NomeBimestre { get; set; }

        public string NomeTrimestre { get; set; }

        public string NomeQuadrimestre { get; set; }

        public string NomeSemestre { get; set; }

        public string AbreviacaoMes { get; set; }

        public virtual ICollection<FT_DespesaDotacaoMunicipio> DespesasDotacaoMunicipio { get; }
        public virtual ICollection<FT_PrestacaoContaMensal> PrestacoesContasMensais { get; }
        public virtual ICollection<FT_ReceitaDotacaoMunicipio> ReceitasDotacaoMunicipio { get; }
    }
}
