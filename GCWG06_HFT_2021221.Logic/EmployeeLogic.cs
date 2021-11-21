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
    }
}
