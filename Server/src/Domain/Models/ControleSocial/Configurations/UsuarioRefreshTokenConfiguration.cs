using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleSocial.Domain.Models.ControleSocial.Configurations
{
    public class UsuarioRefreshTokenConfiguration : EntityTypeConfiguration<UsuarioRefreshToken>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UsuarioRefreshToken> builder)
        {
            builder.Property(e => e.Token)
               .HasMaxLength(256)
               .IsUnicode(true);

            builder.Property(e => e.JwtId)
               .HasMaxLength(256)
               .IsUnicode(true);

            builder.HasOne(e => e.Usuario)
                .WithMany(e => e.RefreshTokens)
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
