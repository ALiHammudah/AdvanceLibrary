using AdvanceLibrary.Domain.Commends.Book;
using FluentValidation;

namespace AdvanceLibrary.Domain.Validator.Book;
public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookValidator()
    {
        RuleFor(r => r.BookName)
            .Length(4, 100).WithMessage("يجب كتابة الاسم بشكل صحيح");

        RuleFor(r => r.Quantity)
            .InclusiveBetween(1, 10).WithMessage("يجب ان تكون الكمية بين واحد وعشرة");

        RuleFor(r => r.AuthorName)
            .Length(4, 100).WithMessage("يجب كتابة اسم الكاتب بشكل صحيح");
    }
}