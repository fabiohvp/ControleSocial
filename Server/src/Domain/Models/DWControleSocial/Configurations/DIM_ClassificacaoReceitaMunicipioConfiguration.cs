using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControleSocial.Domain.Models.DWControleSocial.Configurations
{
    public class DIM_ClassificacaoReceitaMunicipioConfiguration : EntityTypeConfiguration<DIM_ClassificacaoReceitaDotacaoMunicipio>
    {
        public override void ConfigureEntity(EntityTypeBuilder<DIM_ClassificacaoReceitaDotacaoMunicipio> builder)
        {
            builder.Property(e => e.CodigoCategoria)
                .HasMaxLength(1)
                .IsUnicode(true);

            builder.Property(e => e.CodigoOrigem)
                .HasMaxLength(1)
                .IsUnicode(true);

            builder.Property(e => e.CodigoEspecie)
                .HasMaxLength(1)
                .IsUnicode(true);

            builder.Property(e => e.CodigoRubrica)
                .HasDefaultValue("-")
                .HasMaxLength(1)
                .IsUnicode(true);

            builder.Property(e => e.CodigoAlinea)
                .HasDefaultValue("--")
                .HasMaxLength(2)
                .IsUnicode(true);

            builder.Property(e => e.CodigoSubAlinea)
                .HasDefaultValue("--")
                .HasMaxLength(2)
                .IsUnicode(true);

            builder.Property(e => e.CodigoDetalhamentoNivel1)
                .HasDefaultValue("-")
                .HasMaxLength(1)
                .IsUnicode(true);

            builder.Property(e => e.CodigoDetalhamentoNivel2)
                .HasDefaultValue("--")
                .HasMaxLength(2)
                .IsUnicode(true);

            builder.Property(e => e.CodigoDetalhamentoNivel3)
                .HasDefaultValue("-")
                .HasMaxLength(1)
                .IsUnicode(true);

            builder.Property(e => e.CodigoTipoDetalhamento)
                .HasDefaultValue("-")
                .HasMaxLength(1)
                .IsUnicode(true);

            builder.Property(e => e.NomeCategoria)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeOrigem)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeEspecie)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeRubrica)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeAlinea)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeSubAlinea)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeDetalhamentoNivel1)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeDetalhamentoNivel2)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeDetalhamentoNivel3)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.NomeTipoDetalhamento)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.CodigoCompleto)
                .HasMaxLength(13)
                .IsUnicode(true);

            builder.HasMany(e => e.ReceitasDotacao)
                .WithOne(e => e.ClassificacaoNatureza)
                .HasForeignKey(e => e.IdClassificacaoNatureza)
                .OnDelete(DeleteBehavior.NoAction);

            //    .builder.HasIndex(p => new
            //    {
            //        p.Ano,
            //        p.CodigoAlinea,
            //        p.CodigoCategoria,
            //        p.CodigoDetalhamentoNivel1,
            //        p.CodigoDetalhamentoNivel2,
            //        p.CodigoDetalhamentoNivel3,
            //        p.CodigoEspecie,
            //        p.CodigoOrigem,
            //        p.CodigoRubrica,
            //        p.CodigoSubAlinea,
            //        p.CodigoTipoDetalhamento,
            //        p.NomeAlinea,
            //        p.NomeCategoria,
            //        p.NomeDetalhamentoNivel1,
            //        p.NomeDetalhamentoNivel2,
            //        p.NomeDetalhamentoNivel3,
            //        p.NomeEspecie,
            //        p.NomeOrigem,
            //        p.NomeRubrica,
            //        p.NomeSubAlinea,
            //        p.NomeTipoDetalhamento
            //    })
            //    .IsUnique(true);
        }
    }
}
