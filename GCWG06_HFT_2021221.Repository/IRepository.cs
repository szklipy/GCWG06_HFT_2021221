using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Repository
{
    public interface IRepository<T> where T :class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();
        void Delete(int id);
    }
}
