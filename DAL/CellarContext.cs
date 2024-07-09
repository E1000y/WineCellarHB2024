using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CellarContext : DbContext
    {
        public DbSet<CellarUser>? Users { get; set; }
        public DbSet<Cellar>? Cellars { get; set; }
        public DbSet<Drawer>? Drawers { get; set; }

        public DbSet<Bottle>? Bottles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CellarDB;Integrated Security=True");
        }


        public CellarContext() : base() { } // pour nous pour faire des tests

        public CellarContext(DbContextOptions options) : base(options) { } // pour asp.net en "production"


    }
}
