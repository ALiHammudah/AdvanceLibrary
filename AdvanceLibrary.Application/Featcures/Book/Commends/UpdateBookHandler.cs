using AdvanceLibrary.Application.Contract.Repositries;
using AdvanceLibrary.Domain.Commends.Book;
using AdvanceLibrary.Domain.Dtos.Book;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.Book.Commends;
public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, UpdateBookDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateBookHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<UpdateBookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var allbook = await _unitOfWork.Books.GetAllAsync();
        if (request.BookName is not null)
        {
            if (allbook.Any(i => i.Name == request.BookName))
                return new UpdateBookDto { Messege = "اسم الكتاب موجود سابقا" };
        }
        else if (request.Quantity is not null)
        {
        }
        else if (request.AuthorName is null)
            return new UpdateBookDto { Messege = "يجب كتابة احد البيانات للتعديل" };

        var book = await _unitOfWork.Books.FindAsync(request.Id);

        book.Update(request);
        await _unitOfWork.SaveAsync();

        return new UpdateBookDto
        {
            Messege = "Book Updated",
            BookId = book.Id,
            BookName = book.Name,
            AuthorName = book.Author,
            Quantity = book.Quantity,
        };
    }
}