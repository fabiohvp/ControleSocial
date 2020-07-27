using System;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(FT_ReceitaDotacaoMunicipio))]
    public partial class FT_ReceitaDotacaoMunicipio : IEntity
    {
        [Key]
        public long Id { get; set; }
        public long IdSeedHistory { get; set; }
        public long IdOriginal { get; set; }
        public DateTime DataCriacao { get; set; }
        public long IdClassificacaoFonteRecurso { get; set; }
        public long IdClassificacaoNatureza { get; set; }
        public long IdEsferaAdministrativa { get; set; }
        public long IdPeriodo { get; set; }
        public long IdTempo { get; set; }
        public long IdUnidadeGestora { get; set; }

        public decimal? PrevisaoAtualizada { get; set; }
        public decimal? PrevisaoInicial { get; set; }
        public decimal? Arrecadada { get; set; }
        public decimal? PrevisaoAtualizadaFUNDEB { get; set; }
        public decimal? PrevisaoInicialFUNDEB { get; set; }
        public decimal? ArrecadadaFUNDEB { get; set; }

        public virtual DIM_ClassificacaoFonteERecursoMunicipio ClassificacaoFonteRecurso { get; set; }
        public virtual DIM_ClassificacaoReceitaDotacaoMunicipio ClassificacaoNatureza { get; set; }
        public virtual DIM_EsferaAdministrativa EsferaAdministrativa { get; set; }
        public virtual DIM_Periodo Periodo { get; set; }
        public virtual __SeedHistory SeedHistory { get; set; }
        public virtual DIM_Tempo Tempo { get; set; }
        public virtual DIM_UnidadeGestora UnidadeGestora { get; set; }
    }
}
