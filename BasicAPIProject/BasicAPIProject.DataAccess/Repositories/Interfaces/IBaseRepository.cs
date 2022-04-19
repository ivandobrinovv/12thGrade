using BasicAPIProject.DataAccess.Entities;
using System.Linq.Expressions;

namespace BasicAPIProject.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<Guid> CreateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        ValueTask<T> GetByIdAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}