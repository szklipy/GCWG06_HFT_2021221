using System;
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

            Employee e1 = new Employee() { Employee_id = 1, Name = "Steven John", Job_title = "doctor", Hire_date = "2000.01.21", Hospital_id = 1, Department_id = 1 ,Salary = 781000};
            Employee e2 = new Employee() { Employee_id = 2, Name = "Margaret Jobs", Job_title = "doctor", Hire_date = "1999.12.29", Hospital_id = 1, Department_id = 3, Salary = 567000 };
            Employee e3 = new Employee() { Employee_id = 3, Name = "Bob Dylan", Job_title = "doctor", Hire_date = "2000.06.19", Hospital_id = 1, Department_id = 3, Salary = 678000 };
            Employee e4 = new Employee() { Employee_id = 4, Name = "Donald Trump", Job_title = "head physician", Hire_date = "2000.10.26", Hospital_id = 1, Department_id = 4, Salary = 890000 };
            Employee e5 = new Employee() { Employee_id = 5, Name = "Hilary Clinton", Job_title = "doctor", Hire_date = "2003.04.22", Hospital_id = 1, Department_id = 4, Salary = 120000 };
            Employee e6 = new Employee() { Employee_id = 6, Name = "Cameron Diaz", Job_title = "head physician", Hire_date = "2003.11.12", Hospital_id = 1, Department_id = 5, Salary = 970000 };
            Employee e7 = new Employee() { Employee_id = 7, Name = "Bruce Willis", Job_title = "doctor", Hire_date = "2004.03.24", Hospital_id = 1, Department_id = 4, Salary = 69000 };
            Employee e8 = new Employee() { Employee_id = 8, Name = "Tom Cruse", Job_title = "head physician", Hire_date = "2004.06.18", Hospital_id = 1, Department_id = 1, Salary = 1000000 };
            Employee e9 = new Employee() { Employee_id = 9, Name = "Bradley Cooper", Job_title = "nurse", Hire_date = "2007.08.23", Hospital_id = 1, Department_id = 5, Salary = 15000 };
            Employee e10 = new Employee() { Employee_id = 10, Name = "Brad Pitt", Job_title = "nurse", Hire_date = "2008.10.21", Hospital_id = null, Department_id = null, Salary = 0 };
            Employee e11 = new Employee() { Employee_id = 11, Name = "Steven Simons", Job_title = "nurse", Hire_date = "2009.02.11", Hospital_id = 1, Department_id = 4, Salary = 20000 };
            Employee e12 = new Employee() { Employee_id = 12, Name = "John Wick", Job_title = "doctor", Hire_date = "2011.07.20", Hospital_id = 1, Department_id = 3, Salary = 56000 };
            Employee e13 = new Employee() { Employee_id = 13, Name = "Jackey Chan", Job_title = "nurse", Hire_date = "2014.08.20", Hospital_id = 1, Department_id = 1, Salary = 19000 };
            Employee e14 = new Employee() { Employee_id = 14, Name = "Lee Shang", Job_title = "doctor", Hire_date = "2015.05.06", Hospital_id = 1, Department_id = 4, Salary = 34000 };
            Employee e15 = new Employee() { Employee_id = 15, Name = "Usain Bolt", Job_title = "", Hire_date = "2016.08.02", Hospital_id = 1, Department_id = 6, Salary = 10000 };
            Employee e16 = new Employee() { Employee_id = 16, Name = "John Newmann", Job_title = "head physician", Hire_date = "2018.04.06", Hospital_id = 1, Department_id = 6, Salary = 870000 };
            Employee e17 = new Employee() { Employee_id = 17, Name = "Albert Robinson", Job_title = "nurse", Hire_date = "1999.10.11", Hospital_id = 1, Department_id = 1, Salary = 1000 };
            
            

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
