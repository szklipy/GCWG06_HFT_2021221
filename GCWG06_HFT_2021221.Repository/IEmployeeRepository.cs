using GCWG06_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Repository
{
    public interface IEmployeeRepository
    {
        void Create(Employee employee);
        Employee GetOne(int id);
        IQueryable<Employee> GetAll();
        void Update(Employee employee);
        void Delete(int id);
    }
}
