using GCWG06_HFT_2021221.Models;
using GCWG06_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Logic
{
    class DepartmentLogic : IDepartmentLogic
    {
        IDepartmentRepository depRepo;
        public DepartmentLogic(IDepartmentRepository depRepo)
        {
            this.depRepo = depRepo;
        }
        public void Create(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(
                    nameof(department)
                );
            }
            depRepo.Create(department);
        }

        public void Delete(int id)
        {
            depRepo.Delete(id);
        }

        public IList<Department> GetAllDepartments()
        {
            return depRepo.GetAll().ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return depRepo.GetOne(id);
        }

        public void Update(Department department)
        {
            depRepo.Update(department);
        }
    }
}
