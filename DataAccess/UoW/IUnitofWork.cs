using DataAccess.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UoW
{
    public interface IUnitofWork
    {
        public IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
