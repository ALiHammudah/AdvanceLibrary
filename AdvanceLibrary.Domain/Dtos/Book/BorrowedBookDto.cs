using AdvanceLibrary.Domain.Dtos.CustomerDto.Customer;

namespace AdvanceLibrary.Domain.Dtos.Book;
public class BorrowedBookDto
{
    public string BookName { get; set; }
    public List<BorrowedCustomerDto> Customers { get; set; } = [];
}
