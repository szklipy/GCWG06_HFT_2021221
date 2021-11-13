using GCWG06_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Repository
{
    public class HospitalRepository :
        Repository<Hospital>, IHospitalRepository
    {
        public HospitalRepository(DbContext ctx) :
            base(ctx) {}
        public override Hospital GetOne(int id)
        {
            return GetAll()
                .SingleOrDefault(x => x
                .Hospital_id == id);
        }
        public void Create(Hospital hospital)
        {
            ctx.Set<Hospital>().Add(hospital);
            ctx.SaveChanges();
        }

        public void Update(Hospital hospital)
        {
            var hospitalToUpdate = GetOne(hospital.Hospital_id);
            hospitalToUpdate.Hospital_name = hospital.Hospital_name;
            hospitalToUpdate.Hospital_location = hospital.Hospital_location;
            hospitalToUpdate.Employees = hospital.Employees;
            hospitalToUpdate.Departments = hospital.Departments;
        }
    }
}
