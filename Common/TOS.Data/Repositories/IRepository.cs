using System.Collections.Generic;
using System.Threading.Tasks;

namespace TOS.Data.Repositories
{
    public interface IRepository<TModel, TId>
    {
        TId Add(TModel model);
        Task<TId> AddAsync(TModel model);
        void AddRange(IEnumerable<TModel> models);
        Task AddRangeAsync(IEnumerable<TModel> models);
        void Update(TModel model);
        Task UpdateAsync(TModel model);
        TModel GetById(TId id);
        Task<TModel> GetByIdAsync(TId id);
        bool Delete(TId id);
        Task<bool> DeleteAsync(TId id);
    }
}
