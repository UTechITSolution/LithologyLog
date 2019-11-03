using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LithologyLog.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Query();

        ICollection<T> GetAll();

        Task<ICollection<T>> GetAllAsync();

        Task<ICollection<T>> GetAllAsNoTrackingAsync();
        ICollection<T> GetAllAsNoTracking();

        T GetById(int id);

        T GetById(string id);

        Task<T> GetByIdAsync(int id);

        Task<T> GetByIdAsync(string id);
 
        T Find(Expression<Func<T, bool>> match);

        Task<T> FindAsync(Expression<Func<T, bool>> match);

        ICollection<T> FindAll(Expression<Func<T, bool>> match);

        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        TransResult<T> Add(T entity);

        TransResult<T> AddUnCommitted(T entity);

        Task<TransResult<T>> AddAsync(T entity);

        Task<TransResult<int>> AddRangeAsync(ICollection<T> entities);

        TransResult<T> AddRange(ICollection<T> entities);

        TransResult<T> AddRangeUnCommitted(ICollection<T> entities);

        TransResult<T> Update(T updated);

        TransResult<T> UpdateUnCommitted(T updated);

        TransResult<T> UpdateRange(ICollection<T> entities);

        TransResult<T> UpdateRangeUnCommitted(ICollection<T> entities);

        Task<TransResult<T>> UpdateAsync(T updated);

        Task<TransResult<T>> UpdateRangeAsync(ICollection<T> entities);

        TransResult<T> Delete(T t);

        TransResult<T> DeleteUnCommitted(T t);

        Task<TransResult<T>> DeleteAsync(T t);

        TransResult<T> DeleteRange(ICollection<T> entities);

        TransResult<T> DeleteRangeUnCommitted(ICollection<T> entities);

        Task<TransResult<T>> DeleteRangeAsync(ICollection<T> entities);

        int Count();

        Task<int> CountAsync();

        IEnumerable<T> Filter(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int? page = null,
            int? pageSize = null);



        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        bool Exist(Expression<Func<T, bool>> predicate);
    }
}
