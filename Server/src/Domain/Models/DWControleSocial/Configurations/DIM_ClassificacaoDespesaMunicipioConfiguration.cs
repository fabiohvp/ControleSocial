using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class DIM_ClassificacaoDespesaMunicipioConfiguration : EntityTypeConfiguration<DIM_ClassificacaoDespesaDotacaoMunicipio>
    {
        public override void ConfigureEntity(EntityTypeBuilder<DIM_ClassificacaoDespesaDotacaoMunicipio> builder)
        {
            builder.Property(e => e.CodigoCategoria)
               .HasMaxLength(1)
               .IsUnicode(true);

            builder.Property(e => e.CodigoGrupo)
                .HasMaxLength(1)
                .IsUnicode(true);

            builder.Property(e => e.CodigoModalidade)
                .HasMaxLength(2)
                .IsUnicode(true);

            builder.Property(e => e.CodigoElemento)
                .HasMaxLength(2)
                .IsUnicode(true);

            builder.Property(e => e.CodigoSubElemento)
                .HasMaxLength(2)
                .IsUnicode(true);

            builder.Property(e => e.NomeCategoria)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeGrupo)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeModalidade)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeElemento)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeSubElemento)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.CodigoCompleto)                
                .HasMaxLength(8)
                .IsUnicode(true);

            builder.HasMany(e => e.DespesasDotacao)
                .WithOne(e => e.ClassificacaoNatureza)
                .HasForeignKey(e => e.IdClassificacaoNatureza)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
            {
                p.CodigoCategoria,
                p.CodigoElemento,
                p.CodigoGrupo,
                p.CodigoModalidade,
                p.CodigoSubElemento,
                p.NomeCategoria,
                p.NomeElemento,
                p.NomeGrupo,
                p.NomeModalidade,
                p.NomeSubElemento
            })
            .IsUnique(true);
        }
    }
}
