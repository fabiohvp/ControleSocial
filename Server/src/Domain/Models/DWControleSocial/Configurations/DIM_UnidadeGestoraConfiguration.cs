using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class DIM_UnidadeGestoraConfiguration : EntityTypeConfiguration<DIM_UnidadeGestora>
    {
        public override void ConfigureEntity(EntityTypeBuilder<DIM_UnidadeGestora> builder)
        {
            builder.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(true);

            builder.Property(e => e.CodigoOriginal)
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(e => e.CodigoPoder)
                .HasMaxLength(Poder.TamanhoCodigoPoder)
                .IsUnicode(true);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomePoder)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.CodigoTipoUnidadeGestora)
               .HasMaxLength(2)
               .IsUnicode(true);

            builder.Property(e => e.NomeTipoUnidadeGestora)
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.HasMany(e => e.DespesasDotacaoMunicipio)
                .WithOne(e => e.UnidadeGestora)
                .HasForeignKey(e => e.IdUnidadeGestora)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.PrestacoesContasMensais)
                .WithOne(e => e.UnidadeGestora)
                .HasForeignKey(e => e.IdUnidadeGestora)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.ReceitasDotacaoMunicipio)
                .WithOne(e => e.UnidadeGestora)
                .HasForeignKey(e => e.IdUnidadeGestora)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
                {
                    p.Codigo,
                    p.CodigoOriginal,
                    p.Nome,
                    p.NomePoder,
                    p.CodigoTipoUnidadeGestora,
                    p.NomeTipoUnidadeGestora
                })
                .IsUnique(true);
        }
    }
}
