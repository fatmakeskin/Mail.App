using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BaseRepo
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T,bool>> expression);
        IQueryable<T> GetAll();
        void Add(T model);
        void Delete(T model);
        void Update(T model);
    }
}
