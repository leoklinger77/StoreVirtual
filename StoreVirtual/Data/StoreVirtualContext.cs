using Microsoft.EntityFrameworkCore;
using StoreVirtual.Models;

namespace StoreVirtual.Data
{
    public class StoreVirtualContext : DbContext
    {
        public StoreVirtualContext(DbContextOptions<StoreVirtualContext> options) 
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<NewsLetterEmail> NewsLetterEmail { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
    }
}
