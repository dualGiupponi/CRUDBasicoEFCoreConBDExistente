namespace CRUDBasico.Dominio
{
    public class Categoria
    {
        public Categoria(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        private Categoria() { }

        public int ID { get; private set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; private set; }
        public DateTime? FechaActualizacion { get; private set; }
        public DateTime? FechaBaja { get; private set; }

        // Métodos de la clase
        public void DarDeBaja()
        {
            FechaBaja = DateTime.Now;
        }

        #region Equals and GetHashCode
        public override bool Equals(object? obj)
        {
            return obj is Categoria categoria &&
                   ID == categoria.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }
        #endregion
    }
}
