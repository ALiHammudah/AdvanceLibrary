using AdvanceLibrary.Application.Contract;
using AdvanceLibrary.Application.Contract.Repositries;
using AdvanceLibrary.Application.Contract.Serviese;
using AdvanceLibrary.Domain.Auth;
using AdvanceLibrary.infrastructure.Repostries;
using Microsoft.Extensions.Options;

namespace AdvanceLibrary.infrastructure;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IBookRepositry Books { get; private set; }
    public ICustomerRepositry Customer { get; private set; }
    public IBorrowedBookRepository BorrowedBook { get; private set; }

    public IAuthServices Auth { get; private set; }

    public UnitOfWork(AppDbContext context, IPasswordHash passwordHash, IOptions<JWT> jwt)
    {
        _context = context;
        Books = new BookRepository(_context);
        Customer = new CustomerRepostry(_context);
        BorrowedBook = new BorrowedBookRepostry(_context);
        Auth = new AuthServices(_context, passwordHash, jwt);
    }

    public void Dispose() => _context.Dispose();

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
}
