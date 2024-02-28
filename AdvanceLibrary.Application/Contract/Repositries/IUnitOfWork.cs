using AdvanceLibrary.Application.Contract.Serviese;

namespace AdvanceLibrary.Application.Contract.Repositries;
public interface IUnitOfWork : IDisposable
{
    IBookRepositry Books { get; }
    ICustomerRepositry Customer { get; }
    IBorrowedBookRepository BorrowedBook { get; }

    IAuthServices Auth { get; }
    Task<int> SaveAsync();
}
