using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(DIM_Periodo))]
    public partial class DIM_Periodo : IEntity
    {
        public DIM_Periodo()
        {
            DespesasDotacaoMunicipio = new HashSet<FT_DespesaDotacaoMunicipio>();
            PrestacoesContasMensais = new HashSet<FT_PrestacaoContaMensal>();
            ReceitasDotacaoMunicipio = new HashSet<FT_ReceitaDotacaoMunicipio>();
        }

        [Key]
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public string Codigo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<FT_DespesaDotacaoMunicipio> DespesasDotacaoMunicipio { get; }
        public virtual ICollection<FT_PrestacaoContaMensal> PrestacoesContasMensais { get; }
        public virtual ICollection<FT_ReceitaDotacaoMunicipio> ReceitasDotacaoMunicipio { get; }
    }
}