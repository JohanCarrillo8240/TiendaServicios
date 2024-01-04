namespace TiendaServicios.Api.CarritoCompra.RemoteModel
{
    public class LibroRemote
    {
        public int Id { get; set; }

        public string IdUnico { get; set; }

        public string Nombre { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        public string IdAutor { get; set; }
    }
}
