using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class ConsultaFiltro
    {
        public class LibroUnico : IRequest<LibroMaterialDTO> 
        {
            public string Id { get; set; }
        }

        public class Manejador : IRequestHandler<LibroUnico, LibroMaterialDTO>
        {
            private readonly ContextLibreria context;
            private readonly IMapper mapper;

            public Manejador(ContextLibreria context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<LibroMaterialDTO> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libro = await context.LibreriaMaterial.FirstOrDefaultAsync(x => x.IdUnico == request.Id);

                if(libro == null)
                {
                    throw new Exception("No se encontró el libro");
                }

                var libroDTO = mapper.Map<LibroMaterialDTO>(libro);

                return libroDTO;
            }
        }
    }
}
