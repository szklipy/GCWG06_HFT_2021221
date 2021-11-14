using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GCWG06_HFT_2021221.Repository
{
    public abstract class Repository<T> : 
        IRepository<T> where T : class
    {
        protected DbContext ctx;
        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Delete(int id)
        {
            var itemToDelete = GetOne(id);
            ctx.Set<T>().Remove(itemToDelete);
            ctx.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public abstract T GetOne(int id);
    }
}
