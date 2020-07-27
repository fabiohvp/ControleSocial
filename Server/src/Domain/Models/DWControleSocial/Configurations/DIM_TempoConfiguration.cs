using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class DIM_TempoConfiguration : EntityTypeConfiguration<DIM_Tempo>
    {
        public override void ConfigureEntity(EntityTypeBuilder<DIM_Tempo> builder)
        {
            builder.Property(e => e.NomeMes)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(e => e.NomeBimestre)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(e => e.NomeTrimestre)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(e => e.NomeQuadrimestre)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(e => e.NomeSemestre)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(e => e.AbreviacaoMes)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.HasMany(e => e.DespesasDotacaoMunicipio)
                .WithOne(e => e.Tempo)
                .HasForeignKey(e => e.IdTempo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.PrestacoesContasMensais)
                .WithOne(e => e.Tempo)
                .HasForeignKey(e => e.IdTempo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.ReceitasDotacaoMunicipio)
                .WithOne(e => e.Tempo)
                .HasForeignKey(e => e.IdTempo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
                {
                    p.Ano,
                    p.Mes
                })
                .IsUnique(true);
        }
    }
}
