using AdvanceLibrary.Domain.Commends.Book;
using FluentValidation;

namespace AdvanceLibrary.Domain.Validator.Book;
public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookValidator()
    {
        RuleFor(r => r.Quantity)
            .InclusiveBetween(1, 10).WithMessage("يجب ان تكون الكمية بين واحد وعشرة");
    }
}
