using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(DIM_ClassificacaoProgramaEAcaoMunicipio))]
    public partial class DIM_ClassificacaoProgramaEAcaoMunicipio : IEntity
    {
        public DIM_ClassificacaoProgramaEAcaoMunicipio()
        {
            DespesasDotacao = new HashSet<FT_DespesaDotacaoMunicipio>();
        }

        [Key]
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string CodigoUnidadeGestora { get; set; }

        public string CodigoPrograma { get; set; }
        public string CodigoAcao { get; set; }

        public string NomePrograma { get; set; }
        public string NomeAcao { get; set; }

        public string CodigoCompleto
        {
            get
            {
                return CodigoPrograma?.PadLeft(4, '0') + CodigoAcao?.PadLeft(5, '0');
            }
            private set { }
        }

        public virtual ICollection<FT_DespesaDotacaoMunicipio> DespesasDotacao { get; }
    }
}
