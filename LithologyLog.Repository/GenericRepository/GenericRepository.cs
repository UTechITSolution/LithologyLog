using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LithologyLog.Repository
{

    public class TransResult<T>
    {
        public T Object { get; set; }
        public bool IsSuccess { get; set; }
 
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(context);
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }

        public ICollection<T> GetAllAsNoTracking()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public ICollection<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<ICollection<T>> GetAllAsNoTrackingAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
 

        public T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().FirstOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public TransResult<T> Add(T entity)
        {
            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                result.Object = entity;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public TransResult<T> AddUnCommitted(T entity)
        {

            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {
                _context.Set<T>().Add(entity);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public async Task<TransResult<T>> AddAsync(T entity)
        {
            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {
                _context.Set<T>().Add(entity);
                var commitReult = await _unitOfWork.Commit();
                result.IsSuccess = commitReult.IsSuccess;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
            }

            return result;

        }

        public TransResult<T> AddRange(ICollection<T> entities)
        {
            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {
                _context.Set<T>().AddRange(entities);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;


        }

        public TransResult<T> AddRangeUnCommitted(ICollection<T> entities)
        {
            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {
                _context.Set<T>().AddRange(entities);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public async Task<TransResult<int>> AddRangeAsync(ICollection<T> entities)
        {

            await _context.Set<T>().AddRangeAsync(entities);

            return await _unitOfWork.Commit();

        }

        public TransResult<T> Update(T updated)
        {
            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            if (updated == null)
            {
                return new TransResult<T>() { IsSuccess = false }; ;
            }
            try
            {
                _context.Set<T>().Attach(updated);
                _context.Entry(updated).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;

        }

        public TransResult<T> UpdateUnCommitted(T updated)
        {
            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {
                _context.Set<T>().Attach(updated);
                _context.Entry(updated).State = EntityState.Modified;
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public TransResult<T> UpdateRange(ICollection<T> entities)
        {
            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {

                foreach (var updated in entities)
                {
                    _context.Set<T>().Attach(updated);
                    _context.Entry(updated).State = EntityState.Modified;
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public TransResult<T> UpdateRangeUnCommitted(ICollection<T> entities)
        {
            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {

                foreach (var updated in entities)
                {
                    _context.Set<T>().Attach(updated);
                    _context.Entry(updated).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public async Task<TransResult<T>> UpdateAsync(T updated)
        {

            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            if (updated == null)
            {
                return new TransResult<T>() { IsSuccess = false }; ;
            }
            try
            {
                _context.Set<T>().Attach(updated);
                _context.Entry(updated).State = EntityState.Modified;
                var commitReult = await _unitOfWork.Commit();
                result.IsSuccess = commitReult.IsSuccess;
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public async Task<TransResult<T>> UpdateRangeAsync(ICollection<T> entities)
        {
            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {

                foreach (var updated in entities)
                {
                    _context.Set<T>().Attach(updated);
                    _context.Entry(updated).State = EntityState.Modified;
                }

                var commitReult = await _unitOfWork.Commit();
                result.IsSuccess = commitReult.IsSuccess;
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;


        }

        public TransResult<T> Delete(T t)
        {
            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {
                _context.Set<T>().Remove(t);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public TransResult<T> DeleteUnCommitted(T t)
        {

            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {
                _context.Set<T>().Remove(t);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public async Task<TransResult<T>> DeleteAsync(T t)
        {
            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {
                _context.Set<T>().Remove(t);

                var commitReult = await _unitOfWork.Commit();
                result.IsSuccess = commitReult.IsSuccess;
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public TransResult<T> DeleteRange(ICollection<T> entities)
        {
            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {
                _context.Set<T>().RemoveRange(entities);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public TransResult<T> DeleteRangeUnCommitted(ICollection<T> entities)
        {

            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {
                _context.Set<T>().RemoveRange(entities);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public async Task<TransResult<T>> DeleteRangeAsync(ICollection<T> entities)
        {
            TransResult<T> result = new TransResult<T>() { IsSuccess = true };

            try
            {
                _context.Set<T>().RemoveRange(entities);

                var commitReult = await _unitOfWork.Commit();
                result.IsSuccess = commitReult.IsSuccess;
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int? page = null,
            int? pageSize = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (includeProperties != null)
            {
                foreach (
                    var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public bool Exist(Expression<Func<T, bool>> predicate)
        {
            var exist = _context.Set<T>().Where(predicate);
            return exist.Any() ? true : false;
        }


    }
}
