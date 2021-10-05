using Microsoft.EntityFrameworkCore;
using Note_BOR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note_BOR.Contexts
{
    public class ShopContext : DbContext
    
         {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<Shop> Shop { get; set; }
    }
}
