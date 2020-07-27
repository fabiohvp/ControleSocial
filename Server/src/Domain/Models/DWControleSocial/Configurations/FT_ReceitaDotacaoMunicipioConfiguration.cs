using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class FT_ReceitaDotacaoMunicipioConfiguration : EntityTypeConfiguration<FT_ReceitaDotacaoMunicipio>
    {
        public override void ConfigureEntity(EntityTypeBuilder<FT_ReceitaDotacaoMunicipio> builder)
        {
            builder.Property(e => e.Arrecadada)
                .HasPrecision(20, 2);

            builder.Property(e => e.PrevisaoInicial)
                .HasPrecision(20, 2);

            builder.Property(e => e.PrevisaoAtualizada)
                .HasPrecision(20, 2);

            builder.Property(e => e.ArrecadadaFUNDEB)
                .HasPrecision(20, 2);

            builder.Property(e => e.PrevisaoInicialFUNDEB)
                .HasPrecision(20, 2);

            builder.Property(e => e.PrevisaoAtualizadaFUNDEB)
                .HasPrecision(20, 2);

            builder.HasOne(e => e.Tempo)
                .WithMany(e => e.ReceitasDotacaoMunicipio)
                .HasForeignKey(e => e.IdTempo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.EsferaAdministrativa)
                .WithMany(e => e.ReceitasDotacaoMunicipio)
                .HasForeignKey(e => e.IdEsferaAdministrativa)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.ClassificacaoFonteRecurso)
                .WithMany(e => e.ReceitasDotacao)
                .HasForeignKey(e => e.IdClassificacaoFonteRecurso)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.UnidadeGestora)
                .WithMany(e => e.ReceitasDotacaoMunicipio)
                .HasForeignKey(e => e.IdUnidadeGestora)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.ClassificacaoNatureza)
                .WithMany(e => e.ReceitasDotacao)
                .HasForeignKey(e => e.IdClassificacaoNatureza)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.SeedHistory)
                .WithMany(e => e.ReceitasDotacaoMunicipio)
                .HasForeignKey(e => e.IdSeedHistory)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
            {
                p.IdOriginal
            })
            .IsUnique(true);
        }
    }
}
