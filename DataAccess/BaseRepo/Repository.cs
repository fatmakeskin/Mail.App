using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BaseRepo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> set;
        public Repository(DbContext _context)
        {
            context = _context;
            set = context.Set<T>();
        }
        public void Add(T model)
        {
            set.Add(model);
        }

        public void Delete(T model)
        {
            context.Entry(model).State = EntityState.Deleted;
            set.Attach(model);
            set.Remove(model);
        }     

        public T Get(Expression<Func<T, bool>> expression)
        {
            var data = set.Where(expression);
            return data.FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            var data = set;
            return data;
        }

        public void Update(T model)
        {
            set.Attach(model);
            context.Entry(model).State = EntityState.Modified;
        }
    }
}
