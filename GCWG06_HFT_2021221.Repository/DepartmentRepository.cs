using GCWG06_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Repository
{
    public class DepartmentRepository :
        Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext ctx) : 
            base(ctx) {}
        public override Department GetOne(int id)
        {
            return GetAll()
                .SingleOrDefault(x => x
                .Department_id == id);
        }
        public void Create(Department department)
        {
            ctx.Set<Department>().Add(department);
            ctx.SaveChanges();
        }

        public void Update(Department department)
        {
            var departmentToUpdate = GetOne(department.Department_id);
            //biztos h ez kell?
            departmentToUpdate.Department_name = department.Department_name;
            departmentToUpdate.Employees = department.Employees;
            departmentToUpdate.Hospital = department.Hospital;
            //vajon kell e ide is ctx.SaveChanges(); ?
        }
    }
}
