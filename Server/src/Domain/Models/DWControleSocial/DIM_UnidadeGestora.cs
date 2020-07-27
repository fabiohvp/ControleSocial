using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(DIM_UnidadeGestora))]
    public partial class DIM_UnidadeGestora : IEntity
    {
        public DIM_UnidadeGestora()
        {
            DespesasDotacaoMunicipio = new HashSet<FT_DespesaDotacaoMunicipio>();
            PrestacoesContasMensais = new HashSet<FT_PrestacaoContaMensal>();
            ReceitasDotacaoMunicipio = new HashSet<FT_ReceitaDotacaoMunicipio>();
        }

        [Key]
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string CodigoOriginal { get; set; }
        public string NomePoder { get; set; }
        public string CodigoPoder { get; set; }
        public string CodigoTipoUnidadeGestora { get; set; }
        public string NomeTipoUnidadeGestora { get; set; }

        public virtual ICollection<FT_DespesaDotacaoMunicipio> DespesasDotacaoMunicipio { get; }
        public virtual ICollection<FT_PrestacaoContaMensal> PrestacoesContasMensais { get; }
        public virtual ICollection<FT_ReceitaDotacaoMunicipio> ReceitasDotacaoMunicipio { get; }
    }
}
