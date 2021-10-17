using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCWG06_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;

namespace GCWG06_HFT_2021221.Data
{
    class MedicalDbContext : DbContext
    {
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public MedicalDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MedicalDb.mdf;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //hospitals
            //departments
            //employees

            //modelbuilders
            //one-many many-many one-one many-one


            //dep. (one-many) emp.
            //hosp. (one-many) emp.
            //hosp. (one-many) dep.

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(employee => employee.Department)
                .WithMany(department => department.Employees)
                .HasForeignKey(employee => employee.Department_id)
                .OnDelete(DeleteBehavior.ClientSetNull);
                //álítólag ez így működik
                entity.HasOne(employee => employee.Hospital)
                .WithMany(hospital => hospital.Employees)
                .HasForeignKey(employee => employee.Hospital_id)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            //modelBuilder.Entity<Employee>(entity =>
            //{
            //    entity.HasOne(employee => employee.Hospital)
            //    .WithMany(hospital => hospital.Employees)
            //    .HasForeignKey(employee => employee.Hospital_id)
            //    .OnDelete(DeleteBehavior.ClientSetNull);
            //});
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasOne(department => department.Hospital)
                .WithMany(hospital => hospital.Departments)
                .HasForeignKey(department => department.Hospital_id)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });


        }
    }
}
