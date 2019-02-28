using Microsoft.EntityFrameworkCore;
using OrganikV1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganikV1.Dal
{
    public class OrganikV1DbContext:DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<ProductPhoto> ProductPhoto { get; set; }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CAGLAR-YILDIRIM;Database=OrganikV1;Trusted_Connection=true", b => b.MigrationsAssembly("OrganikV1.Web"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().ToTable("Categories");
            modelBuilder.Entity<Products>().ToTable("Products");
            modelBuilder.Entity<Comments>().ToTable("Comments");
            modelBuilder.Entity<ProductPhoto>().ToTable("ProductPhoto");
        }
    }


}
