using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemo.Database
{
    public class DatabaseContext : DbContext
    {
        private string _databasePath;

        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public virtual DbSet<Models.Department> Departments { get; set; }
        public virtual DbSet<Models.Personnel> Personnel { get; set; }
    }
}
