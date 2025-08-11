using LibreriaEcommerce.Api.Libro.Application;
using LibreriaEcommerce.Api.Libro.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaEcommerce.Api.Libro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly IMediator mediator;

        public LibrosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LibroDTO>>> GetList()
        {
            return await mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{libroId}")]
        public async Task<ActionResult<LibroDTO>> GetList([FromRoute] Guid libroId)
        {
            return await mediator.Send(new ConsultaFiltro.Ejecuta { LibroId = libroId });
        }

        [HttpPost]
        public async Task<ActionResult<List<LibroDTO>>> Create([FromBody] Nuevo.Ejecuta data)
        {
            try
            {
                await mediator.Send(data);
                return Ok($"El Libro {data.Titulo} se agrego correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
