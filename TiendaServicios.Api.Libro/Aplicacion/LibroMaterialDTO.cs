namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class LibroMaterialDTO
    {
        public string IdUnico { get; set; }

        public string Nombre { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        public string IdAutor { get; set; }
    }
}
