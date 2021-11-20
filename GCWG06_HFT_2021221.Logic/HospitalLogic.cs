using GCWG06_HFT_2021221.Models;
using GCWG06_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Logic
{
    class HospitalLogic : IHospitalLogic
    {
        IHospitalRepository hospRepo;
        public HospitalLogic(IHospitalRepository hospRepo)
        {
            this.hospRepo = hospRepo;
        }
        public void Create(Hospital hospital)
        {
            if (hospital.Hospital_name == null)
                throw new NullReferenceException("ERROR :: name was null");
            if (hospital.Hospital_name == "")
                throw new Exception("ERROR :: NAME WAS EMPTY STRING");
            hospRepo.Create(hospital);
        }

        public void Delete(int id)
        {
            if (id < 0 || id > hospRepo.GetAll().Count())
                throw new IndexOutOfRangeException("ERROR :: ID VALUE WAS TOO BIG OR SMALL");
            hospRepo.Delete(id);
        }

        public IList<Hospital> GetAllHospitals()
        {
            return hospRepo.GetAll().ToList();
        }

        public Hospital GetHospitalById(int id)
        {
            if (id < 0 || id > hospRepo.GetAll().Count())
                throw new IndexOutOfRangeException("ERROR :: ID VALUE WAS TOO BIG OR SMALL");
            return hospRepo.GetOne(id);
        }

        public void Update(Hospital hospital)
        {
            hospRepo.Update(hospital);
        }
    }
}
