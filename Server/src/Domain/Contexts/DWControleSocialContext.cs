namespace ControleSocial.Domain.Contexts
{
    using ControleSocial.Domain.Models.DWControleSocial.Configurations;
    using Microsoft.EntityFrameworkCore;
    using Models.DWControleSocial;
    using System;

    public partial class DWControleSocialContext : DbContext
    {
        public DWControleSocialContext(DbContextOptions<DWControleSocialContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(TimeSpan.FromMinutes(60));
        }

        //Used for comparison only
        protected DbSet<EntityFrameworkCore.MemoryJoin.QueryModelClass> QueryData { get; set; }
        public virtual DbSet<__SeedHistory> SeedHistory { get; set; }

        public virtual DbSet<DIM_EsferaAdministrativa> EsferaAdministrativa { get; set; }
        public virtual DbSet<DIM_Periodo> Periodo { get; set; }
        public virtual DbSet<DIM_Tempo> Tempo { get; set; }
        public virtual DbSet<DIM_UnidadeGestora> UnidadeGestora { get; set; }

        public virtual DbSet<FT_PrestacaoContaMensal> PrestacaoContaMensal { get; set; }

        #region Municipio

        public virtual DbSet<DIM_ClassificacaoDespesaDotacaoMunicipio> ClassificacaoDespesaDotacaoMunicipio { get; set; }
        public virtual DbSet<DIM_ClassificacaoFuncaoESubFuncaoMunicipio> ClassificacaoFuncaoESubFuncaoMunicipio { get; set; }
        public virtual DbSet<DIM_ClassificacaoFonteERecursoMunicipio> ClassificacaoFonteERecursoMunicipio { get; set; }
        public virtual DbSet<DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio> ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio { get; set; }
        public virtual DbSet<DIM_ClassificacaoProgramaEAcaoMunicipio> ClassificacaoProgramaEAcaoMunicipio { get; set; }
        public virtual DbSet<DIM_ClassificacaoReceitaDotacaoMunicipio> ClassificacaoReceitaDotacaoMunicipio { get; set; }

        public virtual DbSet<FT_DespesaDotacaoMunicipio> DespesaDotacaoMunicipio { get; set; }
        public virtual DbSet<FT_ReceitaDotacaoMunicipio> ReceitaDotacaoMunicipio { get; set; }

        #endregion Municipio
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new __SeedHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new DIM_EsferaAdministrativaConfiguration());
            modelBuilder.ApplyConfiguration(new DIM_PeriodoConfiguration());
            modelBuilder.ApplyConfiguration(new DIM_TempoConfiguration());
            modelBuilder.ApplyConfiguration(new DIM_UnidadeGestoraConfiguration());
            modelBuilder.ApplyConfiguration(new FT_PrestacaoContaMensalConfiguration());
            //municipios
            modelBuilder.ApplyConfiguration(new DIM_ClassificacaoDespesaMunicipioConfiguration());
            modelBuilder.ApplyConfiguration(new DIM_ClassificacaoFonteERecursoMunicipioConfiguration());
            modelBuilder.ApplyConfiguration(new DIM_ClassificacaoFuncaoESubFuncaoMunicipioConfiguration());
            modelBuilder.ApplyConfiguration(new DIM_ClassificacaoOrgaoEOrcamentariaMunicipioConfiguration());
            modelBuilder.ApplyConfiguration(new DIM_ClassificacaoProgramaEAcaoMunicipioConfiguration());
            modelBuilder.ApplyConfiguration(new DIM_ClassificacaoReceitaMunicipioConfiguration());
            modelBuilder.ApplyConfiguration(new FT_DespesaDotacaoMunicipioConfiguration());
            modelBuilder.ApplyConfiguration(new FT_ReceitaDotacaoMunicipioConfiguration());
        }
    }
}
