using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(DIM_ClassificacaoDespesaDotacaoMunicipio))]
    public partial class DIM_ClassificacaoDespesaDotacaoMunicipio : IEntity
    {
        public const string ModalidadeDespesaNaoUtilizada = "91";

        public DIM_ClassificacaoDespesaDotacaoMunicipio()
        {
            DespesasDotacao = new HashSet<FT_DespesaDotacaoMunicipio>();
        }

        [Key]
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public string CodigoCategoria { get; set; }
        public string CodigoGrupo { get; set; }
        public string CodigoModalidade { get; set; }
        public string CodigoElemento { get; set; }
        public string CodigoSubElemento { get; set; }

        public string NomeCategoria { get; set; }
        public string NomeGrupo { get; set; }
        public string NomeModalidade { get; set; }
        public string NomeElemento { get; set; }
        public string NomeSubElemento { get; set; }

        public string CodigoCompleto
        {
            get
            {
                return CodigoCategoria + CodigoGrupo + CodigoModalidade + CodigoElemento + CodigoSubElemento;
            }
            private set { }
        }

        public virtual ICollection<FT_DespesaDotacaoMunicipio> DespesasDotacao { get; }
    }
}
