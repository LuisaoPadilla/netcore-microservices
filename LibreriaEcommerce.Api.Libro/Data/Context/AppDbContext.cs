using LibreriaEcommerce.Api.Libro.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibreriaEcommerce.Api.Libro.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public DbSet<LibroEntity> Libros { get; set; }
    }
}
