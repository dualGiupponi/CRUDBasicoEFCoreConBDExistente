namespace CRUDBasico.WebAPI.DTOs.Responses
{
    public class ProductoResponse
    {
        public int ID { get; private set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool TieneStockDisponible { get; set; }
        public CategoriaProductoResponse? Categoria { get; set; }
    }
}
