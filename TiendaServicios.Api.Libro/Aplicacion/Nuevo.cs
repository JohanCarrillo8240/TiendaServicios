using FluentValidation;
using MediatR;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest<Unit>
        {
            public string Nombre { get; set; }

            public DateTime? FechaPublicacion { get; set; }

            public string IdAutor { get; set; }
        }

        public class EjecutaValidacion:AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotEmpty();
                RuleFor(x => x.IdAutor).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, Unit>
        {
            private readonly ContextLibreria context;

            public Manejador(ContextLibreria context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libro = new LibreriaMaterial
                {
                    Nombre = request.Nombre,
                    FechaPublicacion = request.FechaPublicacion,
                    IdAutor = request.IdAutor,
                    IdUnico = Guid.NewGuid().ToString()
                };
                context.LibreriaMaterial.Add(libro);

                var valor = await context.SaveChangesAsync();

                if(valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo agregar el libro");
            }
        }
    }
}
