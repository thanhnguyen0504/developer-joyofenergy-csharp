using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace JOIEnergy.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        T Add(T entity);
        void AddRange(List<T> entities);
        T Update(T entity);
        T? Get(Guid id);
        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
