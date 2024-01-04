namespace TiendaServicios.Api.Autor.Modelo
{
    public class GradoAcademico
    {
        public int Id { get; set; }

        public string IdUnico { get; set; }

        public string Nombre { get; set; }

        public string CentroAcademico { get; set; }

        public DateTime? FechaGrado { get; set; }

        public int IdAutor { get; set; }

        public AutorLibro AutorLibro { get; set; }
    }
}
