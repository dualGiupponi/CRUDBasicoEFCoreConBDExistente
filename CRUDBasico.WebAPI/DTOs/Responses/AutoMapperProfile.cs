using AutoMapper;
using CRUDBasico.Dominio;

namespace CRUDBasico.WebAPI.DTOs.Responses
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            _ = CreateMap<Producto, ProductoResponse>();
            _ = CreateMap<Categoria, CategoriaResponse>();
            _ = CreateMap<Categoria, CategoriaProductoResponse>();
        }
    }
}
