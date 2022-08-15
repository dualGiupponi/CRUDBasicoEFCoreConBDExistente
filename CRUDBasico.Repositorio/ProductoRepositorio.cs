using CRUDBasico.Dominio;
using CRUDBasico.Dominio.Repositorios;
using CRUDBasico.Repositorio.Context;
using Microsoft.EntityFrameworkCore;

namespace CRUDBasico.Repositorio
{
    public class ProductoRepositorio : IRepository<Producto>
    {
        private readonly CRUDBasicoContext Context;
        public ProductoRepositorio(CRUDBasicoContext context)
        {
            Context = context;
        }

        public async Task Crear(Producto entidad)
        {
            _ = await Context.Productos.AddAsync(entidad);
            _ = await Context.SaveChangesAsync();
        }

        public Task<Producto> Obtener(int id)
        {
            return Context.Productos
                          .Include(p => p.Categoria)
                          .SingleOrDefaultAsync(p => p.ID == id);
        }

        public Task<List<Producto>> ObtenerTodos()
        {
            return Context.Productos
                                .Where(p => p.FechaBaja == null)
                                .Include(p => p.Categoria)
                                .ToListAsync();
        }
    }
}
