using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class DIM_ClassificacaoProgramaEAcaoMunicipioConfiguration : EntityTypeConfiguration<DIM_ClassificacaoProgramaEAcaoMunicipio>
    {
        public override void ConfigureEntity(EntityTypeBuilder<DIM_ClassificacaoProgramaEAcaoMunicipio> builder)
        {
            builder.Property(e => e.CodigoPrograma)
               .HasMaxLength(4)
               .IsUnicode(true);

            builder.Property(e => e.NomePrograma)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.CodigoAcao)
               .HasMaxLength(5)
               .IsUnicode(true);

            builder.Property(e => e.NomeAcao)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.CodigoUnidadeGestora)
               .IsRequired()
               .HasMaxLength(11)
               .IsUnicode(true);

            builder.Property(e => e.CodigoCompleto)
                .HasMaxLength(9)
                .IsUnicode(true);

            builder.HasMany(e => e.DespesasDotacao)
                .WithOne(e => e.ClassificacaoPrograma)
                .HasForeignKey(e => e.IdClassificacaoPrograma)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
                {
                    p.CodigoUnidadeGestora,
                    p.CodigoAcao,
                    p.CodigoPrograma,
                    p.NomeAcao,
                    p.NomePrograma
                })
            .IsUnique(true);
        }
    }
}
