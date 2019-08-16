using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inplaynet.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity, object key);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(int id);
    }
}
