using GCWG06_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Repository
{
    public interface IDepartmentRepository
    {
        void Create(Department department);
        Department GetOne(int id);
        IQueryable<Department> GetAll();
        void Update(Department department);
        void Delete(int id);
    }
}
