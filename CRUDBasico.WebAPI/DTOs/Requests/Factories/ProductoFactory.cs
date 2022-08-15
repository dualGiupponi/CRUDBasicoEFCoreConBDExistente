using CRUDBasico.Dominio;

namespace CRUDBasico.WebAPI.DTOs.Requests.Factories
{
    public static class ProductoFactory
    {
        public static Producto FromDTO(ProductoRequest productoAlta, Categoria categoria)
        {
            return new Producto(productoAlta.nombre,
                                categoria,
                                productoAlta.descripcion,
                                productoAlta.precio.Value,
                                productoAlta.stock.Value);
        }

        internal static void ActualizarProducto(Producto producto, ProductoRequest productoRequest)
        {
            if (string.IsNullOrEmpty(productoRequest.nombre)
                && productoRequest.nombre != producto.Nombre)
            {
                producto.Nombre = productoRequest.nombre;
            }

            if (string.IsNullOrEmpty(productoRequest.descripcion)
                && productoRequest.descripcion != producto.Descripcion)
            {
                producto.Descripcion = productoRequest.descripcion;
            }

            if (productoRequest.precio.HasValue
                && productoRequest.precio.Value > 0)
            {
                producto.ActualizarPrecio(productoRequest.precio.Value);
            }

            if (productoRequest.stock.HasValue
                && Math.Abs(productoRequest.stock.Value) > 0)
            {
                // Porque si tengo un valor absoluto mayor a cero, quiere decir que es positivo o negativo (no nulo)
                if (productoRequest.stock.Value > 0)
                {
                    producto.AgregarStock(productoRequest.stock.Value);
                }
                else
                {
                    producto.DisminuirStock(productoRequest.stock.Value);
                }
            }
        }

        internal static void ActualizarCategoriaProducto(Producto producto, Categoria categoriaNueva)
        {
            if (categoriaNueva != null && categoriaNueva != producto.Categoria)
            {
                producto.Categoria = categoriaNueva;
            }
        }
    }
}
