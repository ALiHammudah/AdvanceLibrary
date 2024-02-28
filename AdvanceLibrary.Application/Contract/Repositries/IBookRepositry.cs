using AdvanceLibrary.Domain.Commends.Book;
using AdvanceLibrary.Domain.Dtos.Api;
using AdvanceLibrary.Domain.Dtos.Book;
using AdvanceLibrary.Domain.Entities;

namespace AdvanceLibrary.Application.Contract;
public interface IBookRepositry : IBaseRepositry<Book>
{
    Task<List<BookDto>> GetAllBookAsync();
    Task<BookDitailDto> FindBookAsync(Guid id);
    Task<ApiDto> AddBookAsync(AddBookCommand model);
    //Task<GetBookDto> Update(UpdateBookCommand model);
    Task<BookDto> DeleteBookAsync(Guid id);
}
