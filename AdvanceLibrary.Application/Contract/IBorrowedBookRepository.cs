using AdvanceLibrary.Domain.Commends.CustomerBook;
using AdvanceLibrary.Domain.Dtos.Library;
using AdvanceLibrary.Domain.Entities;

namespace AdvanceLibrary.Application.Contract;
public interface IBorrowedBookRepository : IBaseRepositry<CustomerBook>
{
    Task<List<BorrowedBookDto>> GetAllBorrowedAsync();
    Task<string> BorrowBookAsync(BorrowBookCommand model);
    Task<string> ReciveBookAsync(ReceiveBookCommand model);
    Task<BorrowedBookDto> GetBorrowedBookAsync(string BookName);
    Task<BorrowedCustomerDto> GetBorrowedcustomerAsync(string CustomerName);
}