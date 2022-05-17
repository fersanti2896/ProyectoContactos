using ContactoAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ContactoAPI.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Contacto> Contactos { get; set; }
    }
}
