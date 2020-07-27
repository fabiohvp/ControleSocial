using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class __SeedHistoryConfiguration : EntityTypeConfiguration<__SeedHistory>
    {
        public override void ConfigureEntity(EntityTypeBuilder<__SeedHistory> builder)
        {
            builder.Property(e => e.DataCriacao)
                .HasDefaultValueSql("getdate()");

            builder.Property(e => e.Arquivo)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(true);

            builder.Property(e => e.Hash)
                .IsRequired()
                .HasMaxLength(32)
                .IsUnicode(true);

            builder.HasMany(e => e.PrestacoesContasMensais)
                .WithOne(e => e.SeedHistory)
                .HasForeignKey(e => e.IdSeedHistory)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.DespesasDotacaoMunicipio)
                .WithOne(e => e.SeedHistory)
                .HasForeignKey(e => e.IdSeedHistory)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.ReceitasDotacaoMunicipio)
                .WithOne(e => e.SeedHistory)
                .HasForeignKey(e => e.IdSeedHistory)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
                {
                    p.Hash
                })
                .IsUnique(true);
        }
    }
}
