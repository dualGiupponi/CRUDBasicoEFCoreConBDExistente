namespace CRUDBasico.Dominio.Repositorios
{
    public interface IUnidadDeTrabajo
    {
        public IRepository<Producto> Productos { get; }
        public IRepository<Categoria> Categorias { get; }

        // Almacena todos los cambios y los persiste
        public Task GuardarCambios();
    }
}
