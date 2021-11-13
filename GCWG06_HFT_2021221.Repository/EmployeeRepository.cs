using GCWG06_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Repository
{
    public class EmployeeRepository :
        Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext ctx) : 
            base(ctx) {}
        public void Create(Employee employee)
        {
            ctx.Set<Employee>().Add(employee);
            ctx.SaveChanges();
        }

        public override Employee GetOne(int id)
        {
            return GetAll()
                .SingleOrDefault(x => x
                .Employee_id == id);
        }

        public void Update(Employee employee)
        {
            var employeeToUpdate = GetOne(employee.Employee_id);
            employeeToUpdate.Name = employee.Name;
            employeeToUpdate.Job_title = employee.Job_title;
            employeeToUpdate.Hospital = employee.Hospital;
            employeeToUpdate.Department = employee.Department;
            employeeToUpdate.Hire_date = employee.Hire_date;
        }
    }
}
