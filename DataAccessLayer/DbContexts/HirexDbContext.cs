using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DbContexts
{
    public class HirexDbContext : DbContext
    {
        public DbSet<DesignerEntity> Designers { get; set; }

        public DbSet<WorkEntity> Works { get; set; }

        public HirexDbContext(DbContextOptions<HirexDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=hirex;Trusted_Connection=True;");
        }
    }
}
