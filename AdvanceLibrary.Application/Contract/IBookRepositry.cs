using AdvanceLibrary.Domain.Commends.Book;
using AdvanceLibrary.Domain.Dtos.Book;
using AdvanceLibrary.Domain.Entities;

namespace AdvanceLibrary.Application.Contract;
public interface IBookRepositry : IBaseRepositry<Book>
{
    Task<List<GetBookDto>> GetAllBookAsync();
    Task<GetBookDto> FindBookAsync(Guid id);
    Task<AddBookDto> AddBookAsync(AddBookCommand model);
    //Task<GetBookDto> Update(UpdateBookCommand model);
    Task<BookDto> DeleteBookAsync(Guid id);
}
