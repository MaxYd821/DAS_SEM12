using Microsoft.EntityFrameworkCore;
using DAS_SEM12.Models;

namespace DAS_SEM12.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(tb =>
            { 
                tb.HasKey(col => col.idUsuario);
                tb.Property(col => col.idUsuario).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.Nombre).HasMaxLength(50);
                tb.Property(col => col.Apellido).HasMaxLength(50);
                tb.Property(col => col.correo).HasMaxLength(50);
                tb.Property(col => col.password).HasMaxLength(50);
                tb.HasOne(u => u.rol)
                    .WithMany(r => r.Usuarios)
                    .HasForeignKey(u => u.idRol)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Rol>(tb => { 
                tb.HasKey(col => col.idRol);
                tb.Property(col => col.idRol).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.Nombre).HasMaxLength(50);
                tb.Property(col => col.Descripcion).HasMaxLength(200);
            });

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Rol>().ToTable("Rol");
        }
    }
}
