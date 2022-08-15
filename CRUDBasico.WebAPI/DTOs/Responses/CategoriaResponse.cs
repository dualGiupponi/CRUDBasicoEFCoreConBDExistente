namespace CRUDBasico.WebAPI.DTOs.Responses
{
    public class CategoriaResponse
    {
        public int ID { get; private set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
