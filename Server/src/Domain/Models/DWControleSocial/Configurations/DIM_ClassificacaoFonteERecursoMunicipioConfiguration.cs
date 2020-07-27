using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class DIM_ClassificacaoFonteERecursoMunicipioConfiguration : EntityTypeConfiguration<DIM_ClassificacaoFonteERecursoMunicipio>
    {
        public override void ConfigureEntity(EntityTypeBuilder<DIM_ClassificacaoFonteERecursoMunicipio> builder)
        {
            builder.Property(e => e.CodigoUnidadeGestora)
               .IsRequired()
               .HasMaxLength(11)
               .IsUnicode(true);

            builder.Property(e => e.CodigoGrupo)
               .HasMaxLength(1)
               .IsUnicode(true);

            builder.Property(e => e.CodigoFonteReduzida)
                .HasMaxLength(7)
                .IsUnicode(true);

            builder.Property(e => e.CodigoDetalhamento)
                .HasMaxLength(7)
                .IsUnicode(true);

            builder.Property(e => e.NomeGrupo)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeFonteReduzida)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeDetalhamento)
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.Property(e => e.CodigoCompleto)                
                .HasMaxLength(15)
                .IsUnicode(true);

            builder.HasMany(e => e.DespesasDotacao)
                .WithOne(e => e.ClassificacaoFonteRecurso)
                .HasForeignKey(e => e.IdClassificacaoFonteRecurso)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.ReceitasDotacao)
                .WithOne(e => e.ClassificacaoFonteRecurso)
                .HasForeignKey(e => e.IdClassificacaoFonteRecurso)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
            {
                p.CodigoUnidadeGestora,
                p.CodigoDetalhamento,
                p.CodigoFonteReduzida,
                p.CodigoGrupo,
                p.NomeDetalhamento,
                p.NomeFonteReduzida,
                p.NomeGrupo
            })
            .IsUnique(true);
        }
    }
}