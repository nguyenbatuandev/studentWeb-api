using System.Linq.Expressions;

namespace student.Data.Repository
{
    public interface IColeggeRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter);
        Task<T> CreateAsync(T dbRecord);
        Task<T> DeleteAsync(Expression<Func<T, bool>> filter);
        Task<T> UpdateAsync(Expression<Func<T, bool>> filter, T dbRecord);
    }
}
