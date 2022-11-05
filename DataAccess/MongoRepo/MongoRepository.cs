using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MongoRepo
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class, IDisposable
    {
        IMongoDatabase database;
        IMongoClient client;
        IMongoCollection<T> collection;
        public MongoRepository()
        {
            GetDatabase();
            GetCollection();
        }
        protected void GetDatabase()
        {
            client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_URI"));
            database = client.GetDatabase(Environment.GetEnvironmentVariable("MONGO_NAME"));
        }
        protected void GetCollection()
        {
            if (database.GetCollection<T>(typeof(T).Name) == null)
                database.CreateCollection(typeof(T).Name);
            collection = database.GetCollection<T>(typeof(T).Name);
        }

        public void Add(T model)
        {
            collection.InsertOne(model);
        }

        public void Delete(Expression<Func<T,bool>> expression)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Where(expression);
            collection.DeleteOne(filter);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            FilterDefinition<T> filter=Builders<T>.Filter.Where(expression);
            return collection.Find(filter).FirstOrDefault();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> queryable=collection.AsQueryable();
            return queryable;
        }

        public void Update(T model)
        {
            collection.ReplaceOne(null, model);
        }
    }
}
