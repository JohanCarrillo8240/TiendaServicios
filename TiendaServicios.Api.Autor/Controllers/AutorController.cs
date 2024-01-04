using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Autor.Modelo;
using static TiendaServicios.Api.Autor.Aplicacion.Nuevo;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IValidator<Ejecuta> validator;

        public AutorController(IMediator mediator, IValidator<Ejecuta> validator)
        {
            this.mediator = mediator;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDTO>>> GetAutores()
        {
            return await mediator.Send(new Consulta.ListaAutor());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDTO>> GetAutorLibro(string id)
        {
            return await mediator.Send(new ConsultaFiltro.AutorUnico { AutorGuid = id });
        }


        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await mediator.Send(data);
        }

    }
}
