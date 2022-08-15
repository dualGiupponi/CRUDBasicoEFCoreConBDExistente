using AutoMapper;
using CRUDBasico.Dominio.Repositorios;
using CRUDBasico.WebAPI.DTOs.Requests;
using CRUDBasico.WebAPI.DTOs.Requests.Factories;
using CRUDBasico.WebAPI.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDBasico.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IUnidadDeTrabajo UnidadDeTrabajo;
        private readonly IMapper Mapper;

        public ProductosController(IUnidadDeTrabajo unidadDeTrabajo, IMapper mapper)
        {
            UnidadDeTrabajo = unidadDeTrabajo ?? throw new ArgumentNullException(nameof(unidadDeTrabajo));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Dominio.Producto> productos = await UnidadDeTrabajo.Productos.ObtenerTodos();
            return Ok(
                Mapper.Map<IEnumerable<ProductoResponse>>(productos)
                );
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Dominio.Producto producto = await UnidadDeTrabajo.Productos.Obtener(id);
            return producto == null
                ? NotFound("Producto no encontrado")
                : Ok(
                    Mapper.Map<ProductoResponse>(producto)
                    );
        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoRequest producto)
        {
            // "Capa" de validacion
            Dominio.Categoria categoriaEntidad = await UnidadDeTrabajo.Categorias.Obtener(producto.categoriaID.Value);
            if (categoriaEntidad == null)
            {
                return BadRequest("La categoria indicada no existe");
            }

            // "Capa" de conversion DTO -> Dominio
            Dominio.Producto productoEntidad = ProductoFactory.FromDTO(producto, categoriaEntidad);
            await UnidadDeTrabajo.Productos.Crear(productoEntidad);

            return Ok();
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductoRequest productoRequest)
        {
            Dominio.Producto producto = await UnidadDeTrabajo.Productos.Obtener(id);
            if (producto == null)
            {
                return NotFound("No existe ningún producto en la base de datos con ese ID");
            }

            if (productoRequest.categoriaID.HasValue)
            {
                Dominio.Categoria categoria = await UnidadDeTrabajo.Categorias.Obtener(productoRequest.categoriaID.Value);
                if (categoria == null)
                {
                    return NotFound("La categoría indicada no existe en la base de datos");
                }

                ProductoFactory.ActualizarCategoriaProducto(producto, categoria);
            }
            ProductoFactory.ActualizarProducto(producto, productoRequest);

            await UnidadDeTrabajo.GuardarCambios();

            return Ok();
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Dominio.Producto producto = await UnidadDeTrabajo.Productos.Obtener(id);
            if (producto == null)
            {
                return NotFound("El producto solicitado no existe");
            }

            producto.DarDeBaja();

            await UnidadDeTrabajo.GuardarCambios();

            return Ok();
        }
    }
}
