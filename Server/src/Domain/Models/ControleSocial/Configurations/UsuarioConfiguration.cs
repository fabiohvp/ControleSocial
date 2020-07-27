using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleSocial.Domain.Models.ControleSocial.Configurations
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(e => e.Nome)
               .HasMaxLength(80)
               .IsUnicode(true);

            builder.Property(e => e.Email)
               .HasMaxLength(60)
               .IsUnicode(true);

            builder.Property(e => e.Senha)
               .HasMaxLength(50)
               .IsUnicode(true);

            builder.Property(e => e.Roles)
               .HasMaxLength(4000)
               .IsUnicode(true);

            builder.HasData(new Usuario
            {
                Id = 1,
                Email = "a",
                Senha = "a",
                Nome = "Fábio Henriques",
                Roles = "Admin"
            });
        }
    }
}
