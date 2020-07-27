namespace ControleSocial.Domain.Contexts
{
    using ControleSocial.Domain.Models.ControleSocial.Configurations;
    using Microsoft.EntityFrameworkCore;
    using Models.ControleSocial;

    public partial class ControleSocialContext : DbContext
    {
        public ControleSocialContext(DbContextOptions<ControleSocialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioRefreshToken> UsuarioRefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioRefreshTokenConfiguration());
        }
    }
}
