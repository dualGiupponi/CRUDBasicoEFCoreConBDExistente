namespace CRUDBasico.Dominio.Repositorios
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> ObtenerTodos();
        public Task<T> Obtener(int id);
        public Task Crear(T entidad);
    }
}
