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
        //employees dbset also needed
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
    }
}
