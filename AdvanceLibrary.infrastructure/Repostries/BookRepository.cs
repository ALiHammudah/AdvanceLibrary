using AdvanceLibrary.Application.Contract;
using AdvanceLibrary.Domain.Commends.Book;
using AdvanceLibrary.Domain.Dtos.Api;
using AdvanceLibrary.Domain.Dtos.Book;
using AdvanceLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvanceLibrary.infrastructure.Repostries;
public class BookRepository : BaseRepository<Book>, IBookRepositry
{
    public BookRepository(AppDbContext context) : base(context) { }

    public async Task<List<BookDto>> GetAllBookAsync()
    {
        return await _context.Books.Select(i => new BookDto
        {
            Id = i.Id,
            Name = i.Name,
        }).ToListAsync();
    }

    public async Task<BookDitailDto> FindBookAsync(Guid id)
    {
        var book = await _context.Books
            .Select(i => new BookDitailDto
            {
                BookId = i.Id,
                BookName = i.Name,
                Quantity = i.Quantity,
                AuthorName = i.Author
            }).FirstOrDefaultAsync(i => i.BookId == id);

        return book;
    }

    public async Task<ApiDto> AddBookAsync(AddBookCommand model)
    {
        if (await _context.Books.AnyAsync(b => b.Name == model.Name))
            return null;

        var book = new Book
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Quantity = model.Quantity,
            Author = model.Author
        };

        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();

        return new ApiDto
        {
            Name = model.Name,
            Messege = "Book added!"
        };
    }

    public async Task<BookDto> DeleteBookAsync(Guid id)
    {
        if (await _context.CustomerBooks.AnyAsync(c => c.BookId == id))
            return null;

        Book book = await _context.Books.FirstOrDefaultAsync(i => i.Id == id);
        if (book is null)
            return null;

        await Task.Run(() => _context.Books.Remove(book));
        await _context.SaveChangesAsync();

        return new BookDto
        {
            Id = book.Id,
            Name = book.Name
        };
    }
}