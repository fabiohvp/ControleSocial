using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(DIM_ClassificacaoFuncaoESubFuncaoMunicipio))]
    public partial class DIM_ClassificacaoFuncaoESubFuncaoMunicipio : IEntity
    {
        public const long IdNaoSeAplica = 1;
        public const short TamanhoCodigoFuncao = 2;
        public const short TamanhoCodigoSubFuncao = 5;

        public DIM_ClassificacaoFuncaoESubFuncaoMunicipio()
        {
            DespesasDotacao = new HashSet<FT_DespesaDotacaoMunicipio>();
        }

        [Key]
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public string CodigoFuncao { get; set; }
        public string CodigoSubFuncao { get; set; }

        public string NomeFuncao { get; set; }
        public string NomeSubFuncao { get; set; }

        public string CodigoCompleto
        {
            get
            {
                return CodigoFuncao + CodigoSubFuncao;
            }
            private set { }
        }

        public virtual ICollection<FT_DespesaDotacaoMunicipio> DespesasDotacao { get; }
    }
}
