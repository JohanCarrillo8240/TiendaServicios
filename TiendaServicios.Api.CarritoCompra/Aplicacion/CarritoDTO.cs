namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class CarritoDTO
    {
        public int Id { get; set; }

        public DateTime? FechaCreacionSesion { get; set; }

        public List<CarritoDetalleDTO> ListaProductos { get; set; }
    }
}
