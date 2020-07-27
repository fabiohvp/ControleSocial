using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio))]
    public partial class DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio : IEntity
    {
        public DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio()
        {
            DespesasDotacao = new HashSet<FT_DespesaDotacaoMunicipio>();
        }

        [Key]
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string CodigoUnidadeGestora { get; set; }

        public string CodigoOrgao { get; set; }
        public string NomeOrgao { get; set; }

        public string CodigoUnidadeOrcamentaria { get; set; }
        public string NomeUnidadeOrcamentaria { get; set; }

        public string CodigoCompleto
        {
            get
            {
                return CodigoOrgao?.PadLeft(6, '0') + CodigoUnidadeOrcamentaria?.PadLeft(6, '0');
            }
            private set { }
        }

        public virtual ICollection<FT_DespesaDotacaoMunicipio> DespesasDotacao { get; }
    }
}
