using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class FT_PrestacaoContaMensalConfiguration : EntityTypeConfiguration<FT_PrestacaoContaMensal>
    {
        public override void ConfigureEntity(EntityTypeBuilder<FT_PrestacaoContaMensal> builder)
        {
            builder.Property(p => p.EmAtraso)
               .HasComputedColumnSql("CASE WHEN DataHomologacao is not null and DataHomologacao > DataLimite THEN CONVERT(bit, 1) ELSE CONVERT(bit, 0) END");

            builder.Property(p => p.EmDia)
               .HasComputedColumnSql("CASE WHEN DataHomologacao is not null and DataHomologacao <= DataLimite THEN CONVERT(bit, 1) ELSE CONVERT(bit, 0) END");

            builder.Property(p => p.EmOmissao)
               .HasComputedColumnSql("CASE WHEN DataHomologacao is null and getdate() >= DataLimite THEN CONVERT(bit, 1) ELSE CONVERT(bit, 0) END");

            builder.Property(p => p.EmTempo)
               .HasComputedColumnSql("CASE WHEN DataHomologacao is null and getdate() < DataLimite THEN CONVERT(bit, 1) ELSE CONVERT(bit, 0) END");

            builder.HasOne(e => e.Tempo)
                .WithMany(e => e.PrestacoesContasMensais)
                .HasForeignKey(e => e.IdTempo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.EsferaAdministrativa)
                .WithMany(e => e.PrestacoesContasMensais)
                .HasForeignKey(e => e.IdEsferaAdministrativa)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Periodo)
                .WithMany(e => e.PrestacoesContasMensais)
                .HasForeignKey(e => e.IdPeriodo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.UnidadeGestora)
                .WithMany(e => e.PrestacoesContasMensais)
                .HasForeignKey(e => e.IdUnidadeGestora)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.SeedHistory)
                .WithMany(e => e.PrestacoesContasMensais)
                .HasForeignKey(e => e.IdSeedHistory)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
            {
                p.IdTempo,
                p.IdEsferaAdministrativa,
                p.IdPeriodo,
                p.IdUnidadeGestora
            })
            .IsUnique(true);
        }
    }
}
