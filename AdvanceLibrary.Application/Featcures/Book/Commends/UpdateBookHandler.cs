using AdvanceLibrary.Domain.Commends.Book;
using AdvanceLibrary.Domain.Dtos.Book;
using FluentValidation;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.Book.Commends;
public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, UpdateBookDto>
{
    private readonly IValidator<UpdateBookCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateBookHandler(IUnitOfWork unitOfWork, IValidator<UpdateBookCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<UpdateBookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        if (!request.id.HasValue)
            return null;

        var allbook = await _unitOfWork.Books.GetAllAsync();
        if (request.BookName is not null)
        {
            if (allbook.Any(i => i.Name == request.BookName))
                return new UpdateBookDto { Messege = "اسم الكتاب موجود سابقا" };
        }
        else if (request.Quantity is not null)
        {
            var result = await _validator.ValidateAsync(request);
            if (result.Errors.Any())
                return new UpdateBookDto { Messege = result.Errors.FirstOrDefault().ToString() };
        }
        else if (request.AuthorName is null)
            return new UpdateBookDto { Messege = "يجب كتابة احد البيانات للتعديل" };

        var book = await _unitOfWork.Books.FindAsync(request.id.Value);

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