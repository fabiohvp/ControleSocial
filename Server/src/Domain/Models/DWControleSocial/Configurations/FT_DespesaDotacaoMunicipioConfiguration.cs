using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class FT_DespesaDotacaoMunicipioConfiguration : EntityTypeConfiguration<FT_DespesaDotacaoMunicipio>
    {
        public override void ConfigureEntity(EntityTypeBuilder<FT_DespesaDotacaoMunicipio> builder)
        {
            builder.Property(e => e.PrevisaoAtualizada)
                .HasPrecision(20, 2);

            builder.Property(e => e.PrevisaoInicial)
                .HasPrecision(20, 2);

            builder.Property(e => e.Empenhada)
                .HasPrecision(20, 2);

            builder.Property(e => e.Liquidada)
                .HasPrecision(20, 2);

            builder.Property(e => e.Paga)
                .HasPrecision(20, 2);

            builder.HasOne(e => e.Tempo)
                .WithMany(e => e.DespesasDotacaoMunicipio)
                .HasForeignKey(e => e.IdTempo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.EsferaAdministrativa)
                .WithMany(e => e.DespesasDotacaoMunicipio)
                .HasForeignKey(e => e.IdEsferaAdministrativa)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.ClassificacaoFonteRecurso)
                .WithMany(e => e.DespesasDotacao)
                .HasForeignKey(e => e.IdClassificacaoFonteRecurso)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.ClassificacaoFuncional)
                .WithMany(e => e.DespesasDotacao)
                .HasForeignKey(e => e.IdClassificacaoFuncional)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.ClassificacaoNatureza)
                .WithMany(e => e.DespesasDotacao)
                .HasForeignKey(e => e.IdClassificacaoNatureza)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.ClassificacaoOrcamentaria)
                .WithMany(e => e.DespesasDotacao)
                .HasForeignKey(e => e.IdClassificacaoOrcamentaria)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.ClassificacaoPrograma)
                .WithMany(e => e.DespesasDotacao)
                .HasForeignKey(e => e.IdClassificacaoPrograma)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.UnidadeGestora)
                .WithMany(e => e.DespesasDotacaoMunicipio)
                .HasForeignKey(e => e.IdUnidadeGestora)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.SeedHistory)
                .WithMany(e => e.DespesasDotacaoMunicipio)
                .HasForeignKey(e => e.IdSeedHistory)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
            {
                p.IdOriginal
            })
            .IsUnique(true);
        }
    }
}
