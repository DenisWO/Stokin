using Microsoft.EntityFrameworkCore;
using Stokin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stokin.Data
{
    public class StokinDbContext : DbContext
    {
        public StokinDbContext(DbContextOptions options) :base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
