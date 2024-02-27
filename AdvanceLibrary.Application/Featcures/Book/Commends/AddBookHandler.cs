using AdvanceLibrary.Domain.Commends.Book;
using AdvanceLibrary.Domain.Dtos.Book;
using FluentValidation;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.Book.Commends;
public class AddBookHandler : IRequestHandler<AddBookCommand, AddBookDto>
{
    private readonly IValidator<AddBookCommand> _valitator;
    private readonly IUnitOfWork _unitOfWork;
    public AddBookHandler(IUnitOfWork unitOfWork, IValidator<AddBookCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _valitator = validator;
    }

    public async Task<AddBookDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var result = await _valitator.ValidateAsync(request);
        if (result.Errors.Any())
            return new AddBookDto
            {
                Messege = result.Errors.FirstOrDefault().ToString(),
            };

        return await _unitOfWork.Books.AddBookAsync(request);
    }
}