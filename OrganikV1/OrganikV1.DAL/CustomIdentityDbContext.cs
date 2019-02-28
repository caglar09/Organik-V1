using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrganikV1.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganikV1.Dal
{
    public class CustomIdentityDbContext:IdentityDbContext<CustomUser, CustomUserRole, string>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CAGLAR-YILDIRIM;Database=OrganikV1;Trusted_Connection=true", b => b.MigrationsAssembly("OrganikV1.Web"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomUser>().ToTable("AspNetUsers");
        }
    
    }
}
