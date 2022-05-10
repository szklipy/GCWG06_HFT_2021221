using GCWG06_HFT_2021221.Models;
using GCWG06_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        
        IEmployeeRepository empRepo;
        #region CRUD methods
        public EmployeeLogic(IEmployeeRepository empRepo)
        {
            this.empRepo = empRepo;
        }
        public void Create(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(
                    nameof(employee)
                );
            }
            //if (employee.Salary == null || employee.Salary<0)
            //{
            //    throw new ArgumentException(
            //        "Price is not valid"
            //        );
            //}
            empRepo.Create(employee);
        }
        public void Delete(int id)
        {
            empRepo.Delete(id);
        }

        public IList<Employee> GetAllEmployees()
        {
            return empRepo.GetAll().ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return empRepo.GetOne(id);
        }

        public void Update(Employee employee)
        {
            empRepo.Update(employee);
        }
        #endregion

        #region non-CRUD methods
        public double AVGSalary()
        {
            return empRepo.GetAll().Average(c => c.Salary) ?? 0;
        }
        public IList<AveragesResultSal> GetSalaryAverages()
        {
            var q = from employee in empRepo.GetAll()
                    group employee
                    by new
                    {
                        employee.Department.Department_id,
                        employee.Department.Department_name
                    }
                    into grp
                    select new AveragesResultSal()
                    {
                        DepartmentName = grp.Key.Department_name,
                        AverageSalary = grp.Average(x => x.Salary) ?? 0
                    };
            return q.ToList();
        }
        public IEnumerable<KeyValuePair<int, double>> AVGSalaryByDepartments()
        {
            return from x in empRepo.GetAll()
                   group x by x.Department.Department_id into g
                   select new
                   KeyValuePair<int, double>
                   (
                       g.Key,
                       g.Average(c => c.Salary) ?? 0
                   );
        }

        public IList<AveragesResultEmp> GetEmployeesAverages()
        {
            var q = from employee in empRepo.GetAll()
                    group employee
                    by new
                    {
                        employee.Department.Department_id,
                        employee.Department.Department_name
                    }
                    into grp
                    select new AveragesResultEmp()
                    {
                        DepartmentName = grp.Key.Department_name,
                        AverageEmployeeNumber = grp.Average(x => x.Department.Employees.Count())
                    };
            return q.ToList();
        }
        public IEnumerable<KeyValuePair<int,double>> AVGEmployeesByDepartment()
        {
            return from x in empRepo.GetAll()
                   group x by x.Department.Department_id into g
                   select new
                   KeyValuePair<int, double>
                   (
                       g.Key,
                       g.Average(c => c.Department.Employees.Count())
                   );
        }

        #endregion
    }
}
