namespace CRUDBasico.WebAPI.DTOs.Requests
{
    public class ProductoRequest
    {
        public string? nombre { get; set; }
        public int? categoriaID { get; set; }
        public string? descripcion { get; set; }
        public decimal? precio { get; set; }
        public int? stock { get; set; }
    }
}
