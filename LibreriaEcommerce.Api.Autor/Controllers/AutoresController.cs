using LibreriaEcommerce.Api.Autor.Application;
using LibreriaEcommerce.Api.Autor.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaEcommerce.Api.Autor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IMediator mediator;

        public AutoresController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [HttpGet("Lista")]
        public async Task<ActionResult<List<AutorDTO>>> GetAutors()
        {
            return await mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("UnicoAutor/{id:int}")]
        public async Task<ActionResult<AutorDTO>> GetAutorById([FromRoute] int id)
        {
            return await mediator.Send(new ConsultaFiltro.AutorUnico() { AutorId = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create([FromBody] Nuevo.Ejecuta data) 
        {
            try
            {
                await mediator.Send(data);
                return Ok("Se guardo correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
