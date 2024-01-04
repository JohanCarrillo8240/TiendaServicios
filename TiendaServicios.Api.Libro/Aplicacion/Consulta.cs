using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<LibroMaterialDTO>>
        {

        }

        public class Manejador : IRequestHandler<Ejecuta, List<LibroMaterialDTO>>
        {
            private readonly ContextLibreria context;
            private readonly IMapper mapper;

            public Manejador(ContextLibreria context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<List<LibroMaterialDTO>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libros = await context.LibreriaMaterial.ToListAsync();

                var librosDTO = mapper.Map<List<LibroMaterialDTO>>(libros);

                return librosDTO;
            }
        }
    }
}
