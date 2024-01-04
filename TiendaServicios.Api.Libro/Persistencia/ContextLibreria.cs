using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Persistencia
{
    public class ContextLibreria:DbContext
    {
        public ContextLibreria()
        {
            
        }
        public ContextLibreria(DbContextOptions<ContextLibreria> options) : base(options)
        {
            
        }

        public virtual DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
    }
}
