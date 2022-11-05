using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MongoRepo
{
    public interface IMongoRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        void Add(T model);
        void Update(T model);
        void Delete(Expression<Func<T,bool>> expression);
    }
}
