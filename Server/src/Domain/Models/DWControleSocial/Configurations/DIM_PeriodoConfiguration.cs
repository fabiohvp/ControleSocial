using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class DIM_PeriodoConfiguration : EntityTypeConfiguration<DIM_Periodo>
    {
        public override void ConfigureEntity(EntityTypeBuilder<DIM_Periodo> builder)
        {
            builder.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.HasMany(e => e.DespesasDotacaoMunicipio)
                .WithOne(e => e.Periodo)
                .HasForeignKey(e => e.IdPeriodo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.PrestacoesContasMensais)
                .WithOne(e => e.Periodo)
                .HasForeignKey(e => e.IdPeriodo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.ReceitasDotacaoMunicipio)
                .WithOne(e => e.Periodo)
                .HasForeignKey(e => e.IdPeriodo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
                {
                    p.Codigo,
                    p.Nome
                })
                .IsUnique(true);
        }
    }
}
