using GCWG06_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Repository
{
    public interface IHospitalRepository
    {
        void Create(Hospital hospital);
        Hospital GetOne(int id);
        IQueryable<Hospital> GetAll();
        void Update(Hospital hospital);
        void Delete(int id);
    }
}
