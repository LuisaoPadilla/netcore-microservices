using LibreriaEcommerce.Api.Autor.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibreriaEcommerce.Api.Autor.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected AppDbContext()
        {
        }

        public DbSet<AutorEntity> Autores { get; set; }
    }
}
