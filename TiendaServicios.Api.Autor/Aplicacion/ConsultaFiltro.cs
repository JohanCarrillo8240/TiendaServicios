using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorDTO>
        {
            public string AutorGuid { get; set; }
        }
        public class Manejador : IRequestHandler<AutorUnico, AutorDTO>
        {
            private readonly ContextAutor context;
            private readonly IMapper mapper;

            public Manejador(ContextAutor context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<AutorDTO> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await context.AutorLibro.FirstOrDefaultAsync(a => a.IdUnico == request.AutorGuid);

                if(autor == null)
                {
                    throw new Exception("No se encontró Autor");
                }

                var autorDTO = mapper.Map<AutorDTO>(autor);

                return autorDTO;
            }
        }
    }
}
