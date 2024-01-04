using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Persistencia;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<CarritoDTO>
        {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, CarritoDTO>
        {
            private readonly ContextCarrito context;
            private readonly ILibrosService librosService;

            public Manejador(ContextCarrito context, ILibrosService librosService)
            {
                this.context = context;
                this.librosService = librosService;
            }
            public async Task<CarritoDTO> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = await context.CarritoSesion.FirstOrDefaultAsync(x=>x.Id == request.Id);

                var carritoSesionDetalle = await context.CarritoSesionDetalle.Where(x => x.IdCarritoSesion == request.Id).ToListAsync();

                var listaCarritoDTO = new List<CarritoDetalleDTO>();

                foreach (var libro in carritoSesionDetalle)
                {
                    var response = await librosService.GetLibro(libro.Producto);
                    if (response.resultado)
                    {
                        var objLibro = response.Libro;
                        var carritoDetalle = new CarritoDetalleDTO
                        {
                            Nombre = objLibro.Nombre,
                            FechaPublicacion = objLibro.FechaPublicacion,
                            IdUnico = objLibro.IdUnico,
                        };
                        listaCarritoDTO.Add(carritoDetalle);
                    }
                }

                var carritoSesionDTO = new CarritoDTO
                {
                    Id = carritoSesion.Id,
                    FechaCreacionSesion = carritoSesion.FechaCreacion,
                    ListaProductos = listaCarritoDTO
                };

                return carritoSesionDTO;
            }
        }
    }
}
