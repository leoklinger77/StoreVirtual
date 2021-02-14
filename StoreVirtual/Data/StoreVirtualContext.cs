using Microsoft.EntityFrameworkCore;
using StoreVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
