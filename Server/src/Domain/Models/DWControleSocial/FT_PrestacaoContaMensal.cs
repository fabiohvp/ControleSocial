using System;
using System.ComponentModel.DataAnnotations;

namespace ControleSocial.Domain.Models.DWControleSocial
{
    [System.ComponentModel.DataAnnotations.Schema.Table(nameof(FT_PrestacaoContaMensal))]
    public partial class FT_PrestacaoContaMensal : IEntity
    {
        [Key]
        public long Id { get; set; }
        public long IdSeedHistory { get; set; }
        public DateTime DataCriacao { get; set; }

        public long IdTempo { get; set; }
        public long IdEsferaAdministrativa { get; set; }
        public long IdPeriodo { get; set; }
        public long IdUnidadeGestora { get; set; }

        public DateTime DataLimite { get; set; }
        public DateTime? DataHomologacao { get; set; }

        public bool EmAtraso { get { return DataHomologacao.HasValue && DataHomologacao.Value > DataLimite; } private set { } }
        public bool EmDia { get { return DataHomologacao.HasValue && DataHomologacao.Value <= DataLimite; } private set { } }
        public bool EmOmissao { get { return !DataHomologacao.HasValue && DateTime.Now >= DataLimite; } private set { } }
        public bool EmTempo { get { return !DataHomologacao.HasValue && DateTime.Now < DataLimite; } private set { } }

        public virtual DIM_EsferaAdministrativa EsferaAdministrativa { get; set; }
        public virtual DIM_Periodo Periodo { get; set; }
        public virtual __SeedHistory SeedHistory { get; set; }
        public virtual DIM_UnidadeGestora UnidadeGestora { get; set; }
        public virtual DIM_Tempo Tempo { get; set; }
    }
}
