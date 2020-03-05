using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Pegas.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private PegasEntities dataContext;
        private readonly IDbSet<T> dbset;
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }
        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }
        protected PegasEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
            DataContext.SaveChanges();
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
            DataContext.SaveChanges();
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
            DataContext.SaveChanges();
        }
        public virtual void Delete(int id)
        {
            var obj = dbset.Find(id);
            if (obj != null)
            {
                dbset.Remove(obj);
                DataContext.SaveChanges();
            }
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
            DataContext.SaveChanges();
        }
        public virtual T GetById(int id)
        {
            return dbset.Find(id);
        }
        public virtual T GetByDetail(string detail)
        {
            return dbset.Find(detail);
        }
        public virtual IQueryable<T> GetAll()
        {
            return dbset.AsQueryable();
        }
        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).AsQueryable();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }
        public IList<T> GetAllToList()
        {
            return dbset.ToList();
        }
    }
}