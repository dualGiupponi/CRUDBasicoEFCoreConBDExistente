using CRUDBasico.Dominio;
using CRUDBasico.Dominio.Repositorios;
using CRUDBasico.Repositorio.Context;

namespace CRUDBasico.Repositorio
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo, IDisposable
    {
        private readonly CRUDBasicoContext Context;

        private readonly ProductoRepositorio ProductosRepositorio;
        private readonly CategoriaRepositorio CategoriasRepositorio;

        public UnidadDeTrabajo(CRUDBasicoContext context)
        {
            Context = context;

            ProductosRepositorio = new ProductoRepositorio(context);
            CategoriasRepositorio = new CategoriaRepositorio(context);
        }

        public IRepository<Producto> Productos => ProductosRepositorio;
        public IRepository<Categoria> Categorias => CategoriasRepositorio;
        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task GuardarCambios()
        {
            _ = await Context.SaveChangesAsync();
        }
    }
}
