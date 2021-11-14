using GCWG06_HFT_2021221.Data;
using GCWG06_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        MedicalDbContext ctx;
        public EmployeeRepository(MedicalDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(Employee employee)
        {
            ctx.Employees.Add(employee);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Employees.Remove(GetOne(id));
            ctx.SaveChanges();
        }

        public IQueryable<Employee> GetAll()
        {
            return ctx.Employees;
        }

        public Employee GetOne(int id)
        {
            return ctx.Employees.FirstOrDefault(x => x.Employee_id == id);
        }

        public void Update(Employee employee)
        {
            var employeeToUpdate = GetOne(employee.Employee_id);
            employeeToUpdate.Name = employee.Name;
            employeeToUpdate.Job_title = employee.Job_title;
            employeeToUpdate.Hospital = employee.Hospital;
            employeeToUpdate.Department = employee.Department;
            employeeToUpdate.Hire_date = employee.Hire_date;
            ctx.SaveChanges();
        }
    }
}
