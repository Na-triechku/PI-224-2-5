namespace Jobs.DAL.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();

    Task<T> GetByIdAsync(int id);

    Task<List<T>> FindAsync(Func<T, bool> predicate);

    Task<T> CreateAsync(T vacancy);

    Task UpdateAsync(T vacancy);

    Task DeleteAsync(T item);
}