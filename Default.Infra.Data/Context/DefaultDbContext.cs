using Default.Domain.Entities;
using Default.Infra.Data.EntityMappingConfig;
using Microsoft.EntityFrameworkCore;

namespace Default.Infra.Data.Context
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
