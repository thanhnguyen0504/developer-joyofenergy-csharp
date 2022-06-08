using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JOIEnergy.Infrastructure.Repository
{
    public abstract class GenericRepositoryBase<T>: IRepository<T> where T: class
    {
        protected JOIEnergyContext context;

        public GenericRepositoryBase(JOIEnergyContext context)
        {
            this.context = context;
        }

        public virtual T Add(T entity)
        {
            return this.context.Add(entity).Entity;
        }

        public virtual void AddRange(List<T> entities)
        {
            this.context.AddRange(entities);
        }

        public virtual IEnumerable<T> All()
        {
            return context.Set<T>().ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().AsQueryable().Where(predicate).ToList();
        }

        public virtual T? Get(Guid id)
        {
            return context.Find<T>(id);
        }

        public virtual IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            
            return this.context.Set<T>().Where<T>(predicate);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            return context.Update(entity)
                .Entity;
        }
    }
}
