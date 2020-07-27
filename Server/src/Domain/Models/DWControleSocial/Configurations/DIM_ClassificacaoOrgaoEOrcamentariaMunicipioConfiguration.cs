using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class DIM_ClassificacaoOrgaoEOrcamentariaMunicipioConfiguration : EntityTypeConfiguration<DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio>
    {
        public override void ConfigureEntity(EntityTypeBuilder<DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio> builder)
        {
            builder.Property(e => e.CodigoUnidadeGestora)
               .IsRequired()
               .HasMaxLength(11)
               .IsUnicode(true);

            builder.Property(e => e.CodigoOrgao)
               .HasMaxLength(6)
               .IsUnicode(true);

            builder.Property(e => e.NomeOrgao)
                .HasMaxLength(60)
                .IsUnicode(true);

            builder.Property(e => e.CodigoUnidadeOrcamentaria)
               .HasMaxLength(6)
               .IsUnicode(true);

            builder.Property(e => e.NomeUnidadeOrcamentaria)
                .HasMaxLength(60)
                .IsUnicode(true);

            builder.Property(e => e.CodigoCompleto)
                .HasMaxLength(12)
                .IsUnicode(true);

            builder.HasMany(e => e.DespesasDotacao)
                .WithOne(e => e.ClassificacaoOrcamentaria)
                .HasForeignKey(e => e.IdClassificacaoOrcamentaria)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
            {
                p.CodigoOrgao,
                p.CodigoUnidadeGestora,
                p.CodigoUnidadeOrcamentaria,
                p.NomeOrgao,
                p.NomeUnidadeOrcamentaria
            })
            .IsUnique(true);
        }
    }
}
