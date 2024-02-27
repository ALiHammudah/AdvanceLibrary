using AdvanceLibrary.Application.Contract;
using AdvanceLibrary.Domain.Commends.CustomerBook;
using AdvanceLibrary.Domain.Dtos.Library;
using AdvanceLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvanceLibrary.infrastructure.Repostries;
public class BorrowedBookRepostry : BaseRepository<CustomerBook>, IBorrowedBookRepository
{
    public BorrowedBookRepostry(AppDbContext context) : base(context) { }

    public async Task<string> BorrowBookAsync(BorrowBookCommand model)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Name == model.BookName);
        if (book is null) return "book not found!";

        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Name == model.CustomerName);
        if (customer is null) return "customer not found";

        if (book.Quantity == 1) return "no enaugh book";

        var borrowedbook = await _context.CustomerBooks
            .FirstOrDefaultAsync(c => c.BookId == book.Id && c.CustomerId == customer.Id);
        if (borrowedbook is not null) return "is already borrowed";

        await _context.CustomerBooks.AddAsync(new CustomerBook
        {
            Id = Guid.NewGuid(),
            BookId = book.Id,
            CustomerId = customer.Id,
        });

        book.Quantity--;

        await _context.SaveChangesAsync();
        return $"customer :{customer.Name} borrowed book:{book.Name}";
    }

    public async Task<List<BorrowedBookDto>> GetAllBorrowedAsync()
    {
        var borrowedbook = await _context.Books
            .Include(b => b.CustomerBooks)
            .ThenInclude(b => b.Customer)
            .Select(b => new BorrowedBookDto
            {
                BookName = b.Name,
                List = b.CustomerBooks
                .Select(b => new ListDto
                {
                    Name = b.Customer.Name
                }).ToList()
            }).ToListAsync();

        return borrowedbook;
    }

    public async Task<BorrowedBookDto> GetBorrowedBookAsync(string BookName)
    {
        var book = await _context.Books.FirstOrDefaultAsync(i => i.Name == BookName);
        if (book is null) return null;

        var borrowedbook = await _context.Books
           .Where(x => x.Name == BookName)
           .Include(i => i.CustomerBooks)
           .ThenInclude(c => c.Customer)
           .Select(i => new BorrowedBookDto
           {
               BookName = i.Name,
               List = i.CustomerBooks
               .Select(b => new ListDto
               {
                   Name = b.Customer.Name
               }).ToList()
           }).FirstOrDefaultAsync();

        return borrowedbook;
    }

    public async Task<BorrowedCustomerDto> GetBorrowedcustomerAsync(string CustomerName)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Name == CustomerName);
        if (customer is null) return null;

        var borrowedbook = await _context.Customers
            .Where(x => x.Name == CustomerName)
            .Include(i => i.CustomerBooks)
            .ThenInclude(c => c.Book)
            .Select(i => new BorrowedCustomerDto
            {
                CustomerName = i.Name,
                List = i.CustomerBooks
                .Select(b => new ListDto
                {
                    Name = b.Book.Name,
                }).ToList(),
            }).FirstOrDefaultAsync();

        return borrowedbook;
    }

    public async Task<string> ReciveBookAsync(ReceiveBookCommand model)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Name == model.BookName);
        if (book is null) return "book not found!";

        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Name == model.CustomerName);
        if (customer is null) return "customer not found";

        var borrowedbook = await _context.CustomerBooks
            .FirstOrDefaultAsync(b => b.BookId == book.Id && b.CustomerId == customer.Id);
        if (borrowedbook is null) return "is not borrowed yet!";

        book.Quantity++;

        await Task.Run(() => _context.CustomerBooks.Remove(borrowedbook));
        await _context.SaveChangesAsync();

        return $"customer :{customer.Name} received book:{book.Name}";
    }
}