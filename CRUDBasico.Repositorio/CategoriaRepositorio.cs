using CRUDBasico.Dominio;
using CRUDBasico.Dominio.Repositorios;
using CRUDBasico.Repositorio.Context;
using Microsoft.EntityFrameworkCore;

namespace CRUDBasico.Repositorio
{
    internal class CategoriaRepositorio : IRepository<Categoria>
    {
        private readonly CRUDBasicoContext Context;
        public CategoriaRepositorio(CRUDBasicoContext context)
        {
            Context = context;
        }

        public async Task Crear(Categoria entidad)
        {
            _ = Context.Categorias.AddAsync(entidad);
            _ = await Context.SaveChangesAsync();
        }

        public Task<Categoria> Obtener(int id)
        {
            return Context.Categorias
                          .SingleOrDefaultAsync(c => c.ID == id);
        }

        public Task<List<Categoria>> ObtenerTodos()
        {
            return Context.Categorias
                          .Where(c => c.FechaBaja == null)
                          .ToListAsync();
        }
    }
}
