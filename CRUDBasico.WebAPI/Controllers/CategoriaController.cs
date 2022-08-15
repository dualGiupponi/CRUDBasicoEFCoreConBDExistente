using CRUDBasico.Dominio.Repositorios;
using CRUDBasico.WebAPI.DTOs.Requests;
using CRUDBasico.WebAPI.DTOs.Requests.Factories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDBasico.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnidadDeTrabajo UnidadDeTrabajo;

        public CategoriasController(IUnidadDeTrabajo unidadDeTrabajo)
        {
            UnidadDeTrabajo = unidadDeTrabajo ?? throw new ArgumentNullException(nameof(unidadDeTrabajo));
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await UnidadDeTrabajo.Categorias.ObtenerTodos());
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Dominio.Categoria categoria = await UnidadDeTrabajo.Categorias.Obtener(id);
            return categoria == null ? NotFound("La categoria no existe") : Ok(categoria);
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaRequest categoriaAlta)
        {
            // "Capa" de validación

            // "Capa" de transformación DTO -> Dominio
            Dominio.Categoria categoriaEntidad = CategoriaFactory.FromDTO(categoriaAlta);
            await UnidadDeTrabajo.Categorias.Crear(categoriaEntidad);

            return Ok();
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
