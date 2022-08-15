using CRUDBasico.Dominio;

namespace CRUDBasico.WebAPI.DTOs.Requests.Factories
{
    public static class CategoriaFactory
    {
        public static Categoria FromDTO(CategoriaRequest categoriaRequest)
        {
            return new Categoria(categoriaRequest.Nombre, categoriaRequest.Descripcion);
        }
    }
}
