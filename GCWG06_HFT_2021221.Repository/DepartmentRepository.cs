using GCWG06_HFT_2021221.Data;
using GCWG06_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        MedicalDbContext ctx;
        public DepartmentRepository(MedicalDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(Department department)
        {
            ctx.Departments.Add(department);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Departments.Remove(GetOne(id));
            ctx.SaveChanges();
        }

        public IQueryable<Department> GetAll()
        {
            return ctx.Departments;
        }

        public Department GetOne(int id)
        {
            return ctx.Departments.FirstOrDefault(x => x.Department_id == id);
        }

        public void Update(Department department)
        {
            var departmentToUpdate = GetOne(department.Department_id);
            departmentToUpdate.Department_name = department.Department_name;
            departmentToUpdate.Employees = department.Employees;
            departmentToUpdate.Hospital = department.Hospital;
            ctx.SaveChanges();
        }
    }
}
