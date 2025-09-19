using Microsoft.EntityFrameworkCore;
using Sale.Shared.Modelo.Entidades;

namespace Sale.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        { 
        
        }
        
        public DbSet<Pais> Tbl_pais { get; set; }
        public DbSet<Provincia> Tbl_Provincia { get; set; }
        public DbSet<Ciudad> Tbl_Ciudad { get; set; }
        public DbSet<Empresa> Tbl_Empresa { get; set; }
        public DbSet<Sucursal> Tbl_Sucursal { get; set; }
        public DbSet<Persona> Tbl_Persona { get; set; }
        public DbSet<Menu> Tbl_Menu { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Pais>().HasIndex(x => x.Nombre_pais).IsUnique(); ///Crea  un indece unico en el nombre
                modelBuilder.Entity<Provincia>().HasIndex(x => x.Nombre_provincia).IsUnique(); ///Crea  un indece unico en el nombre
                modelBuilder.Entity<Ciudad>().HasIndex(x => x.Nombre_ciudad).IsUnique(); ///Crea  un indece unico en el nombre
                modelBuilder.Entity<Empresa>().HasIndex(x => x.Nombre_Empresa).IsUnique(); ///Crea  un indece unico en el nombre
                modelBuilder.Entity<Sucursal>().HasIndex(x => x.Nombre_sucursal).IsUnique(); ///Crea  un indece unico en el nombre
                modelBuilder.Entity<Persona>().HasIndex(x => x.Numero_documento).IsUnique(); ///Crea  un indece unico en el nombre
                modelBuilder.Entity<Ciudad>().HasIndex(x => x.Nombre_ciudad).IsUnique(); ///Crea  un indece unico en el nombre
            //// relacionar de tablas
            /// ******************
            // Relación Pais -> Provincia (uno a muchos)
            modelBuilder.Entity<Provincia>()
             .HasOne<Pais>()
             .WithMany()
             .HasForeignKey(p => p.Id_pais);

        }
    }
}
