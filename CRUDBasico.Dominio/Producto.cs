namespace CRUDBasico.Dominio
{
    public class Producto
    {
        /// <summary>
        /// Constructor que permite generar un nuevo objeto inicializado
        /// </summary>
        /// <param name="nombre">Nombre del producto</param>
        /// <param name="descripcion">Descripcion del producto</param>
        /// <param name="precio">Precio del producto</param>
        /// <param name="stock">Stock actual del producto</param>
        public Producto(string nombre,
                        Categoria categoria,
                        string descripcion,
                        decimal precio,
                        int stock)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio < 0 ? throw new ArgumentException("El precio no puede ser negativo") : precio;
            Stock = stock < 0 ? throw new ArgumentException("El stock no puede ser negativo") : stock;
            Categoria = categoria;
        }

        // Constructor para Entity Framework
        private Producto() { }

        public int ID { get; private set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; private set; }
        public int Stock { get; private set; }
        public Categoria Categoria { get; set; }
        public DateTime FechaAlta { get; private set; }
        public DateTime? FechaActualizacion { get; private set; }
        public DateTime? FechaBaja { get; private set; }

        // Métodos de la clase
        public void ActualizarPrecio(decimal precioNuevo)
        {
            if (precioNuevo < 0) throw new ArgumentException("El precio del producto no puede ser negativo");
            Precio = precioNuevo;
        }
        public void AgregarStock(int stockASumar)
        {
            if (stockASumar < 0)
            {
                throw new ArgumentException("El stock no puede ser negativo");
            }

            Stock += stockASumar;
        }
        public void DisminuirStock(int stockARestar)
        {
            if (stockARestar < 0)
            {
                throw new ArgumentException("El stock no puede ser negativo");
            }

            Stock -= stockARestar;
        }
        public bool TieneStockDisponible => Stock > 0;
        public void DarDeBaja()
        {
            FechaBaja = DateTime.Now;
        }

        #region Equals and GetHashCode
        public override bool Equals(object? obj)
        {
            return obj is Producto producto &&
                   ID == producto.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }
        #endregion
    }
}
