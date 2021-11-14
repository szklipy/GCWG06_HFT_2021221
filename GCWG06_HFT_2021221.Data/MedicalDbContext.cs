﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCWG06_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;

namespace GCWG06_HFT_2021221.Data
{
    public class MedicalDbContext : DbContext
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

            //modelbuilders
            //one-many many-many one-one many-one
 Department d1 = new Department() { Department_id = 1, Department_name = "Internal Medicine Infectology", Hospital_id = 1 };
            Department d2 = new Department() { Department_id = 2, Department_name = "Hospice department", Hospital_id = null };
            Department d3 = new Department() { Department_id = 3, Department_name = "Central Operating Room", Hospital_id = 1 };
            Department d4 = new Department() { Department_id = 4, Department_name = "Pathology", Hospital_id = 1 };
            Department d5 = new Department() { Department_id = 5, Department_name = "Department of Urology", Hospital_id = 1 };
            Department d6 = new Department() { Department_id = 6, Department_name = "Department of Infectious Diseases", Hospital_id = 1 };

            Employee e1 = new Employee() { Employee_id = 1, Name = "Steven John", Job_title = "doctor", Hire_date = "", Hospital_id = 1, Department_id = 1 };
            Employee e2 = new Employee() { Employee_id = 2, Name = "Margaret Jobs", Job_title = "doctor", Hire_date = "", Hospital_id = 1, Department_id = 3 };
            Employee e3 = new Employee() { Employee_id = 3, Name = "Bob Dylan", Job_title = "doctor", Hire_date = "", Hospital_id = 1, Department_id = 3 };
            Employee e4 = new Employee() { Employee_id = 4, Name = "Donald Trump", Job_title = "head physician", Hire_date = "", Hospital_id = 1, Department_id = 4 };
            Employee e5 = new Employee() { Employee_id = 5, Name = "Hilary Clinton", Job_title = "doctor", Hire_date = "", Hospital_id = 1, Department_id = 4 };
            Employee e6 = new Employee() { Employee_id = 6, Name = "Cameron Diaz", Job_title = "head physician", Hire_date = "", Hospital_id = 1, Department_id = 5 };
            Employee e7 = new Employee() { Employee_id = 7, Name = "Bruce Willis", Job_title = "doctor", Hire_date = "", Hospital_id = 1, Department_id = 4 };
            Employee e8 = new Employee() { Employee_id = 8, Name = "Tom Cruse", Job_title = "head physician", Hire_date = "", Hospital_id = 1, Department_id = 1 };
            Employee e9 = new Employee() { Employee_id = 9, Name = "Bradley Cooper", Job_title = "nurse", Hire_date = "", Hospital_id = 1, Department_id = 5 };
            Employee e10 = new Employee() { Employee_id = 10, Name = "Brad Pitt", Job_title = "nurse", Hire_date = "", Hospital_id = null, Department_id = null };
            Employee e11 = new Employee() { Employee_id = 11, Name = "Steven Simons", Job_title = "nurse", Hire_date = "", Hospital_id = 1, Department_id = 4 };
            Employee e12 = new Employee() { Employee_id = 12, Name = "John Wick", Job_title = "doctor", Hire_date = "", Hospital_id = 1, Department_id = 3 };
            Employee e13 = new Employee() { Employee_id = 13, Name = "Jackey Chan", Job_title = "nurse", Hire_date = "", Hospital_id = 1, Department_id = 1 };
            Employee e14 = new Employee() { Employee_id = 14, Name = "Lee Shang", Job_title = "doctor", Hire_date = "", Hospital_id = 1, Department_id = 4 };
            Employee e15 = new Employee() { Employee_id = 15, Name = "Usain Bolt", Job_title = "", Hire_date = "", Hospital_id = 1, Department_id = 6 };
            Employee e16 = new Employee() { Employee_id = 16, Name = "John Newmann", Job_title = "head physician", Hire_date = "", Hospital_id = 1, Department_id = 6 };
            Employee e17 = new Employee() { Employee_id = 17, Name = "Albert Robinson", Job_title = "nurse", Hire_date = "", Hospital_id = 1, Department_id = 1 };
            

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
