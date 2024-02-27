using AdvanceLibrary.Application.Contract;
using Microsoft.EntityFrameworkCore;

namespace AdvanceLibrary.infrastructure.Repostries;
public partial class BaseRepository<T> : IBaseRepositry<T> where T : class
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context) => _context = context;

    public async void AddAsync(T item) => await _context.AddAsync(item);

    public async Task DeleteAsync(T item) => await Task.Run(() => _context.Set<T>().Remove(item));

    public async Task<T> FindAsync(Guid id) => await _context.Set<T>().FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToArrayAsync();
}
