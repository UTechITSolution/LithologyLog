using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LithologyLog.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class;

        DbContext GetContext();

        Task<TransResult<int>> Commit();

        void Rollback();
    }
}
