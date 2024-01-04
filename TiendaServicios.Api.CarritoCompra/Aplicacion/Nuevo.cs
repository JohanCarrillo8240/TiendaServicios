using MediatR;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest<Unit>
        {
            public DateTime? FechaCreacionSesion { get; set; }

            public List<string> ProductoLista { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, Unit>
        {
            private readonly ContextCarrito context;

            public Manejador(ContextCarrito context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSesion
                {
                    FechaCreacion = request.FechaCreacionSesion
                };

                context.CarritoSesion.Add(carritoSesion);

                var value = await context.SaveChangesAsync();
                
                if(value == 0)
                {
                    throw new Exception("Error en la inserción del carrito de compras");
                }

                int id = carritoSesion.Id;

                foreach (var producto in request.ProductoLista)
                {
                    var detalleSesion = new CarritoSesionDetalle
                    {
                        FechaCreacion = DateTime.Now,
                        IdCarritoSesion = id,
                        Producto = producto,
                    };

                    context.CarritoSesionDetalle.Add(detalleSesion);
                }
                value = await context.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo agregar el producto");
            }
        }
    }
}
