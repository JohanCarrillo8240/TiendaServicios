﻿using FluentValidation;
using MediatR;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest<Unit>
        {
            public string Nombre { get; set; }

            public string Apellido { get; set; }

            public DateTime? FechaNacimiento { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, Unit>
        {
            private readonly ContextAutor context;

            public Manejador(ContextAutor context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorLibro = new AutorLibro
                {
                    Nombre = request.Nombre,
                    FechaNacimiento = request.FechaNacimiento,
                    Apellido = request.Apellido,
                    IdUnico = Guid.NewGuid().ToString()
                };

                context.AutorLibro.Add(autorLibro);
                var valor = await context.SaveChangesAsync();

                if(valor> 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insetar el nuevo autor");
            }
        }
    }
}
