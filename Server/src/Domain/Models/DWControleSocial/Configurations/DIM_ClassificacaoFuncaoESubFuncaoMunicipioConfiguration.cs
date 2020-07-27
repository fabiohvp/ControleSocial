using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class DIM_ClassificacaoFuncaoESubFuncaoMunicipioConfiguration : EntityTypeConfiguration<DIM_ClassificacaoFuncaoESubFuncaoMunicipio>
    {
        public override void ConfigureEntity(EntityTypeBuilder<DIM_ClassificacaoFuncaoESubFuncaoMunicipio> builder)
        {
            builder.Property(e => e.CodigoFuncao)
                .HasMaxLength(2)
                .IsUnicode(true);

            builder.Property(e => e.NomeFuncao)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.CodigoSubFuncao)
                .HasMaxLength(3)
                .IsUnicode(true);

            builder.Property(e => e.NomeSubFuncao)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.CodigoCompleto)                
                .HasMaxLength(5)
                .IsUnicode(true);

            builder.HasMany(e => e.DespesasDotacao)
                .WithOne(e => e.ClassificacaoFuncional)
                .HasForeignKey(e => e.IdClassificacaoFuncional)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
            {
                p.CodigoFuncao,
                p.CodigoSubFuncao,
                p.NomeFuncao,
                p.NomeSubFuncao
            })
            .IsUnique(true);
        }
    }
}
