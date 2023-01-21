﻿using Microsoft.EntityFrameworkCore;

namespace MVC_Task2.Models
{
    public class Companydbcontext:DbContext
    {
        public Companydbcontext()
        {

        }
        public Companydbcontext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-539NPC2;Initial Catalog=DbCompany;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<departmentLocation>().HasKey("DeptNumber", "location");
            modelBuilder.Entity<WorksOn>().HasKey("EmpSSN", "projNum");
            //modelBuilder.Entity<Dependant>().HasKey("EmpSSN", "Name");
            modelBuilder.Entity<Employee>().HasOne(s => s.supervisor).WithMany(e => e.Employees);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Dependant> Dependants { get; set; }
        public DbSet<WorksOn> worksOns { get; set; }
        public DbSet<departmentLocation> departmentLocations { get; set; }
    }
}
