using GCWG06_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Logic
{
    public interface IDepartmentLogic
    {
        Department GetDepartmentById(int id);
        IList<Department> GetAllDepartments();
        void Create(Department department);
        void Delete(int id);
        void Update(Department department);
    }
}
