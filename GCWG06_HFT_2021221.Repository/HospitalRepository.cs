using GCWG06_HFT_2021221.Data;
using GCWG06_HFT_2021221.Models;
using System;
using System.Linq;

namespace GCWG06_HFT_2021221.Repository
{
    public class HospitalRepository : IHospitalRepository
    {
        MedicalDbContext ctx;
        public HospitalRepository(MedicalDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(Hospital hospital)
        {
            ctx.Hospitals.Add(hospital);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Hospitals.Remove(GetOne(id));
            ctx.SaveChanges();
        }

        public IQueryable<Hospital> GetAll()
        {
            return ctx.Hospitals;
        }

        public Hospital GetOne(int id)
        {
            return ctx.Hospitals.FirstOrDefault(x => x.Hospital_id == id);
        }

        public void Update(Hospital hospital)
        {
            var hospitalToUpdate = GetOne(hospital.Hospital_id);
            hospitalToUpdate.Hospital_name = hospital.Hospital_name;
            hospitalToUpdate.Hospital_location = hospital.Hospital_location;
            hospitalToUpdate.Employees = hospital.Employees;
            hospitalToUpdate.Departments = hospital.Departments;
            ctx.SaveChanges();
        }
    }
}
