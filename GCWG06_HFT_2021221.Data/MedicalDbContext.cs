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
            Hospital h1 = new Hospital()
            {
                Hospital_id = 1,
                Hospital_name = "First Hospital",
                Hospital_location = "Budapest"
            };

            Department d1 = new Department() { Department_id = 1, Department_name = "", Hospital_id = 1 };
            Department d2 = new Department() { Department_id = 2, Department_name = "", Hospital_id = null };
            Department d3 = new Department() { Department_id = 3, Department_name = "", Hospital_id = 1 };
            Department d4 = new Department() { Department_id = 4, Department_name = "", Hospital_id = 1 };
            Department d5 = new Department() { Department_id = 5, Department_name = "", Hospital_id = 1 };
            Department d6 = new Department() { Department_id = 6, Department_name = "", Hospital_id = 1 };

            Employee e1 = new Employee() { Employee_id = 1, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 1 };
            Employee e2 = new Employee() { Employee_id = 2, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 3 };
            Employee e3 = new Employee() { Employee_id = 3, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 3 };
            Employee e4 = new Employee() { Employee_id = 4, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 4 };
            Employee e5 = new Employee() { Employee_id = 5, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 4 };
            Employee e6 = new Employee() { Employee_id = 6, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 5 };
            Employee e7 = new Employee() { Employee_id = 7, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 4 };
            Employee e8 = new Employee() { Employee_id = 8, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 1 };
            Employee e9 = new Employee() { Employee_id = 9, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 5 };
            Employee e10 = new Employee() { Employee_id = 10, Name = "", Job_title = "", Hire_date = "", Hospital_id = null, Department_id = null };
            Employee e11 = new Employee() { Employee_id = 11, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 4 };
            Employee e12 = new Employee() { Employee_id = 12, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 3 };
            Employee e13 = new Employee() { Employee_id = 13, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 1 };
            Employee e14 = new Employee() { Employee_id = 14, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 4 };
            Employee e15 = new Employee() { Employee_id = 15, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 6 };
            Employee e16 = new Employee() { Employee_id = 16, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 6 };
            Employee e17 = new Employee() { Employee_id = 17, Name = "", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 1 };
            
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

            modelBuilder.Entity<Hospital>().HasData(h1);
            modelBuilder.Entity<Department>().HasData(d1, d2, d3, d4, d5, d6);
            modelBuilder.Entity<Employee>().HasData(e1, e2, e3, e4, e5, e6, e7, e8, e9, e10, e11, e12, e13, e14, e15, e16, e17);
        }
    }
}
