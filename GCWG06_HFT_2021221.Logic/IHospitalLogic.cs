using GCWG06_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Logic
{
    public interface IHospitalLogic
    {
        Hospital GetHospitalById(int id);
        IList<Hospital> GetAllHospitals();
        void Create(Hospital hospital);
        void Delete(int id);
        void Update(Hospital hospital);
    }
}
