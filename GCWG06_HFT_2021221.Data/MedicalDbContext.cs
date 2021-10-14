using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GCWG06_HFT_2021221.Data
{
    class MedicalDbContext : DbContext
    {
        //public virtual DbSet<Hospital> Hospitals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MedicalDb.mdf;Integrated Security=True");
            }
        }
    }
}
