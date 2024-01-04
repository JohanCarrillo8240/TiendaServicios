using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaServicios.Api.CarritoCompra.Modelo
{
    public class CarritoSesionDetalle
    {
        public int Id { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string Producto { get; set; }

        public int IdCarritoSesion { get; set; }

        [ForeignKey("IdCarritoSesion")]
        public CarritoSesion CarritoSesion { get; set; }
    }
}
