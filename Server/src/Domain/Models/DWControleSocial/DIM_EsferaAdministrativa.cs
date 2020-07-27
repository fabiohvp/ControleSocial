using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(DIM_EsferaAdministrativa))]
    public partial class DIM_EsferaAdministrativa : IEntity
    {
        public const string CodigoEsferaAdministrativaEstado = "500";
        public static readonly IEnumerable<string> CodigosEsferasAdministrativasEstado = new string[] { "500", "501" };
        public static readonly IEnumerable<string> CodigosEsferasAdministrativasConsorcio = new string[] { "501" };

        public DIM_EsferaAdministrativa()
        {
            DespesasDotacaoMunicipio = new HashSet<FT_DespesaDotacaoMunicipio>();
            PrestacoesContasMensais = new HashSet<FT_PrestacaoContaMensal>();
            ReceitasDotacaoMunicipio = new HashSet<FT_ReceitaDotacaoMunicipio>();
        }

        [Key]
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }

        [StringLength(255)]
        public string Codigo { get; set; }

        [StringLength(255)]
        public string Nome { get; set; }
        public long? CodigoIBGE { get; set; }

        public virtual ICollection<FT_DespesaDotacaoMunicipio> DespesasDotacaoMunicipio { get; }
        public virtual ICollection<FT_PrestacaoContaMensal> PrestacoesContasMensais { get; }
        public virtual ICollection<FT_ReceitaDotacaoMunicipio> ReceitasDotacaoMunicipio { get; }
    }
}
