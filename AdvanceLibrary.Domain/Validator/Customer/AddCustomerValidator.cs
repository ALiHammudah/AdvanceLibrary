using AdvanceLibrary.Domain.Commends.Customer;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AdvanceLibrary.Domain.Validator.Customer;
public class AddCustomerValidator : AbstractValidator<AddCustomerCommand>
{
    [Obsolete]
    public AddCustomerValidator()
    {
        RuleFor(r => r.CustomerName)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("لا يجب ان يكون اسم العميل فارغا ")
            .Length(5, 50).WithMessage("يجب ان يكون اسم العميل صحيحا ");

        RuleFor(r => r.customerPhone)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("لا يجب ان يكون رقم الهاتف فارغا ")
            .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
            .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("PhoneNumber not valid");

        RuleFor(r => r.CustomerEmail)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("لا يجب ان يكون البريد اللكتروني فارغا ")
            .EmailAddress().WithMessage("يجب كتابة البريد بشكل صحيح");
    }
}
