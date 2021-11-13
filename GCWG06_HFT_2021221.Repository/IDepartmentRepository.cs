using GCWG06_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Repository
{
    public interface IDepartmentRepository :
        IRepository<Department>
    {
        void Create(Department department);
        void Update(Department department);
    }
}
