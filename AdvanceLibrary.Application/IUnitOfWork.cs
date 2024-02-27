using AdvanceLibrary.Application.Contract;

namespace AdvanceLibrary.Application;
public interface IUnitOfWork : IDisposable
{
    IBookRepositry Books { get; }
    ICustomerRepositry Customer { get; }
    IBorrowedBookRepository BorrowedBook { get; }

    IAuthServices Auth { get; }
    Task<int> SaveAsync();
}
