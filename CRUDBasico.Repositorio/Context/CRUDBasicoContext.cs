using CRUDBasico.Dominio;
using CRUDBasico.Repositorio.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUDBasico.Repositorio.Context
{
    public class CRUDBasicoContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        //public DbSet<ImagenProducto> ImagenesProducto { get; set; }

        public CRUDBasicoContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfiguration(new CategoriaTypeConfiguration());
            _ = modelBuilder.ApplyConfiguration(new ProductoTypeConfiguration());
        }
    }
}
