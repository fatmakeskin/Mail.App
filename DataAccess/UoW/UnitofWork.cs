using DataAccess.BaseRepo;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UoW
{
    public class UnitofWork<T> : IUnitofWork, IDisposable
    {
        private DbContext context;
        public DbContext dbContext
        {
            get
            {
                if (context == null)
                    context = new MasterContext();
                return context;
            }
            set
            {
                context = value;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(context);
        }
        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}
