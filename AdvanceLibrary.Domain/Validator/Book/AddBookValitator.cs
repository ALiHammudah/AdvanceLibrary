using AdvanceLibrary.Domain.Commends.Book;
using FluentValidation;

namespace AdvanceLibrary.Domain.Validator.Book;

public class AddBookValitator : AbstractValidator<AddBookCommand>
{
    [Obsolete]
    public AddBookValitator()
    {
        RuleFor(r => r.Name)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("اسم الكتاب لايجب ان يكون فارغا")
            .Length(4, 100).WithMessage("يجب كتابة الاسم بشكل صحيح");

        RuleFor(r => r.Quantity)
            .InclusiveBetween(1, 10).WithMessage("يجب ان تكون الكمية بين عشرة و واحد");

        RuleFor(r => r.Author)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("لا يجب ان يكون اسم الكاتب فارغا")
            .Length(4, 100).WithMessage("يجب كتابة اسم الكاتب بشكل صحيح");
    }
}