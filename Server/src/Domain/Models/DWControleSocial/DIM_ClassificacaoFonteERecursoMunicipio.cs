using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(DIM_ClassificacaoFonteERecursoMunicipio))]
    public partial class DIM_ClassificacaoFonteERecursoMunicipio : IEntity
    {
        public DIM_ClassificacaoFonteERecursoMunicipio()
        {
            DespesasDotacao = new HashSet<FT_DespesaDotacaoMunicipio>();
            ReceitasDotacao = new HashSet<FT_ReceitaDotacaoMunicipio>();
        }

        [Key]
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public string CodigoUnidadeGestora { get; set; }

        public string CodigoGrupo { get; set; }
        public string CodigoFonteReduzida { get; set; }
        public string CodigoDetalhamento { get; set; }

        public string NomeGrupo { get; set; }
        public string NomeFonteReduzida { get; set; }
        public string NomeDetalhamento { get; set; }

        public string CodigoCompleto
        {
            get
            {
                return CodigoGrupo + CodigoFonteReduzida + CodigoDetalhamento;
            }
            private set { }
        }

        public virtual ICollection<FT_DespesaDotacaoMunicipio> DespesasDotacao { get; }
        public virtual ICollection<FT_ReceitaDotacaoMunicipio> ReceitasDotacao { get; }
    }
}
