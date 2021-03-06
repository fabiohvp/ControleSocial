﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(__SeedHistory))]
    public partial class __SeedHistory : IEntity
    {
        public __SeedHistory()
        {
            DespesasDotacaoMunicipio = new HashSet<FT_DespesaDotacaoMunicipio>();
            PrestacoesContasMensais = new HashSet<FT_PrestacaoContaMensal>();
            ReceitasDotacaoMunicipio = new HashSet<FT_ReceitaDotacaoMunicipio>();
        }

        [Key]
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public string Arquivo { get; set; }
        public string Hash { get; set; }

        public virtual ICollection<FT_DespesaDotacaoMunicipio> DespesasDotacaoMunicipio { get; }
        public virtual ICollection<FT_PrestacaoContaMensal> PrestacoesContasMensais { get; }
        public virtual ICollection<FT_ReceitaDotacaoMunicipio> ReceitasDotacaoMunicipio { get; }
    }
}