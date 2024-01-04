using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorDTO>>
        {

        }

        public class Manejador : IRequestHandler<ListaAutor, List<AutorDTO>>
        {
            private readonly ContextAutor context;
            private readonly IMapper mapper;

            public Manejador(ContextAutor context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<List<AutorDTO>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await context.AutorLibro.ToListAsync();

                var autoresDTO = mapper.Map<List<AutorLibro> ,List<AutorDTO>>(autores);

                return autoresDTO;
            }
        }
    }
}
