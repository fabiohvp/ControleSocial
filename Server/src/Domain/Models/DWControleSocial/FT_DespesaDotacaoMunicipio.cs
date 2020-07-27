using System;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(FT_DespesaDotacaoMunicipio))]
    public partial class FT_DespesaDotacaoMunicipio : IEntity
    {
        [Key]
        public long Id { get; set; }
        public long IdSeedHistory { get; set; }
        public long IdOriginal { get; set; }
        public DateTime DataCriacao { get; set; }
        public long IdClassificacaoFonteRecurso { get; set; }
        public long IdClassificacaoFuncional { get; set; }
        public long IdClassificacaoNatureza { get; set; }
        public long IdClassificacaoOrcamentaria { get; set; }
        public long IdClassificacaoPrograma { get; set; }
        public long IdEsferaAdministrativa { get; set; }
        public long IdPeriodo { get; set; }
        public long IdTempo { get; set; }
        public long IdUnidadeGestora { get; set; }

        public decimal? PrevisaoAtualizada { get; set; }
        public decimal? PrevisaoInicial { get; set; }
        public decimal? Empenhada { get; set; }
        public decimal? Liquidada { get; set; }
        public decimal? Paga { get; set; }

        public virtual DIM_ClassificacaoFonteERecursoMunicipio ClassificacaoFonteRecurso { get; set; }
        public virtual DIM_ClassificacaoFuncaoESubFuncaoMunicipio ClassificacaoFuncional { get; set; }
        public virtual DIM_ClassificacaoDespesaDotacaoMunicipio ClassificacaoNatureza { get; set; }
        public virtual DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio ClassificacaoOrcamentaria { get; set; }
        public virtual DIM_ClassificacaoProgramaEAcaoMunicipio ClassificacaoPrograma { get; set; }
        public virtual DIM_EsferaAdministrativa EsferaAdministrativa { get; set; }
        public virtual DIM_Periodo Periodo { get; set; }
        public virtual __SeedHistory SeedHistory { get; set; }
        public virtual DIM_Tempo Tempo { get; set; }
        public virtual DIM_UnidadeGestora UnidadeGestora { get; set; }
    }
}
