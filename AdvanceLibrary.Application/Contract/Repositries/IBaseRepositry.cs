namespace AdvanceLibrary.Application.Contract;
public interface IBaseRepositry<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> FindAsync(Guid id);
    void AddAsync(T item);
    Task DeleteAsync(T item);
}