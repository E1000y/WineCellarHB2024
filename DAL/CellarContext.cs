using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CellarContext : IdentityDbContext<CellarUser>
    {
        public CellarContext(): base() // pour nous pour faire des tests
        {

        }
        public CellarContext(DbContextOptions<CellarContext> options) : base(options) // pour asp.net en "production"
    {
        }

        public DbSet<CellarUser>? Users { get; set; }
        public DbSet<Cellar>? Cellars { get; set; }
        public DbSet<Drawer>? Drawers { get; set; }

        public DbSet<Bottle>? Bottles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CellarDB;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);

        }

    }
}
