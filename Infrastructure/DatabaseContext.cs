using Domian.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Employee
            modelBuilder.Entity<Employee>().ToTable("Employee").HasKey(p => p.Id);
            modelBuilder.Entity<Employee>().Property(p=>p.SSN).HasMaxLength(255);
            modelBuilder.Entity<Employee>().Property(p => p.Name).HasMaxLength(255);
            modelBuilder.Entity<Employee>().Property(p => p.Phone).HasMaxLength(255);
            modelBuilder.Entity<Employee>().Property(p => p.Mobile).HasMaxLength(255);

            // Department
            modelBuilder.Entity<Department>().ToTable("Department").HasKey(p => p.Id);
            modelBuilder.Entity<Department>().Property(p => p.Name).HasMaxLength(255);
            modelBuilder.Entity<Department>().Property(p => p.Details).HasMaxLength(255);

        }
    }
}
