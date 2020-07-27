using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(DIM_ClassificacaoReceitaDotacaoMunicipio))]
    public partial class DIM_ClassificacaoReceitaDotacaoMunicipio : IEntity
        , IDIM_ClassificacaoReceitaMunicipio
    {
        public const short AnoInicioUsoEmentarioReceita = 2018;

        public DIM_ClassificacaoReceitaDotacaoMunicipio()
        {
            ReceitasDotacao = new HashSet<FT_ReceitaDotacaoMunicipio>();
        }

        [Key]
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public string CodigoCategoria { get; set; }
        public string CodigoOrigem { get; set; }
        public string CodigoEspecie { get; set; }
        public string CodigoRubrica { get; set; }
        public string CodigoAlinea { get; set; }
        public string CodigoSubAlinea { get; set; }

        public string CodigoDetalhamentoNivel1 { get; set; }
        public string CodigoDetalhamentoNivel2 { get; set; }
        public string CodigoDetalhamentoNivel3 { get; set; }
        public string CodigoTipoDetalhamento { get; set; }


        public string NomeCategoria { get; set; }
        public string NomeOrigem { get; set; }
        public string NomeEspecie { get; set; }
        public string NomeRubrica { get; set; }
        public string NomeAlinea { get; set; }
        public string NomeSubAlinea { get; set; }

        public string NomeDetalhamentoNivel1 { get; set; }
        public string NomeDetalhamentoNivel2 { get; set; }
        public string NomeDetalhamentoNivel3 { get; set; }
        public string NomeTipoDetalhamento { get; set; }

        public string CodigoCompleto
        {
            get
            {
                return CodigoCategoria + CodigoOrigem + CodigoEspecie + CodigoRubrica + CodigoAlinea + CodigoSubAlinea + CodigoDetalhamentoNivel1 + CodigoDetalhamentoNivel2 + CodigoDetalhamentoNivel3 + CodigoTipoDetalhamento;
            }
            private set { }
        }

        public virtual ICollection<FT_ReceitaDotacaoMunicipio> ReceitasDotacao { get; }
    }

    public interface IDIM_ClassificacaoReceitaMunicipio
    {
        public string CodigoCategoria { get; set; }
        public string CodigoOrigem { get; set; }
        public string CodigoEspecie { get; set; }
        public string CodigoRubrica { get; set; }
        public string CodigoAlinea { get; set; }
        public string CodigoSubAlinea { get; set; }

        public string CodigoDetalhamentoNivel1 { get; set; }
        public string CodigoDetalhamentoNivel2 { get; set; }
        public string CodigoDetalhamentoNivel3 { get; set; }
        public string CodigoTipoDetalhamento { get; set; }


        public string NomeCategoria { get; set; }
        public string NomeOrigem { get; set; }
        public string NomeEspecie { get; set; }
        public string NomeRubrica { get; set; }
        public string NomeAlinea { get; set; }
        public string NomeSubAlinea { get; set; }

        public string NomeDetalhamentoNivel1 { get; set; }
        public string NomeDetalhamentoNivel2 { get; set; }
        public string NomeDetalhamentoNivel3 { get; set; }
        public string NomeTipoDetalhamento { get; set; }
    }
}
