namespace TiendaServicios.Api.Autor.Modelo
{
    public class AutorLibro
    {
        public int Id { get; set; }

        public string IdUnico { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public ICollection<GradoAcademico> ListaGradoAcademico { get; set; }
    }
}
