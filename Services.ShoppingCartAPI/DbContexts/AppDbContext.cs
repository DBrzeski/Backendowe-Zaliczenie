using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ShoppingCartAPI.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //public DbSet<Product> Products { get; set; }
        //public DbSet<CartHeader> CartHeaders { get; set; }
        //public DbSet<CartDetails> CartDetails { get; set; }
    }

}

