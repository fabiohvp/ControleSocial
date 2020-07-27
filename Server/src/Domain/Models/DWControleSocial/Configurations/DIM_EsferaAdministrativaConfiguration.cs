using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class DIM_EsferaAdministrativaConfiguration : EntityTypeConfiguration<DIM_EsferaAdministrativa>
    {
        public override void ConfigureEntity(EntityTypeBuilder<DIM_EsferaAdministrativa> builder)
        {
            builder.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(true);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.HasMany(e => e.DespesasDotacaoMunicipio)
                .WithOne(e => e.EsferaAdministrativa)
                .HasForeignKey(e => e.IdEsferaAdministrativa)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.PrestacoesContasMensais)
                .WithOne(e => e.EsferaAdministrativa)
                .HasForeignKey(e => e.IdEsferaAdministrativa)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.ReceitasDotacaoMunicipio)
                .WithOne(e => e.EsferaAdministrativa)
                .HasForeignKey(e => e.IdEsferaAdministrativa)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
                {
                    p.Codigo
                })
                .IsUnique(true);
        }
    }
}