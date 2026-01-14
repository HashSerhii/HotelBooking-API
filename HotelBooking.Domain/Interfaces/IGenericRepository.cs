using System.Linq.Expressions;

namespace HotelBooking.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    
    Task<IReadOnlyList<T>> GetAllAsync(
        Expression<Func<T,bool>>? filter = null,
        params Expression<Func<T, object>>[] includes);
    
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}