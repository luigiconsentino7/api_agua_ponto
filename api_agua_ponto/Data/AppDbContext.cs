using api_agua_ponto.Models;
using Microsoft.EntityFrameworkCore;

namespace api_agua_ponto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Usuario> UsuarioDb { get; set; }
        public DbSet<Rotina> RotinaDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rotina>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Rotinas)
                .HasForeignKey(r => r.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Rotinas);


        }

    }
}
