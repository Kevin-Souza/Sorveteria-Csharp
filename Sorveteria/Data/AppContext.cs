using Microsoft.EntityFrameworkCore;
using Sorveteria.Models;

namespace Sorveteria.Data
{
    public class AppCont : DbContext
    {
        public AppCont(DbContextOptions<AppCont> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
