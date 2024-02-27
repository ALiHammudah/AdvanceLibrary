using AdvanceLibrary.Domain.Commends.Book;
using AdvanceLibrary.Domain.Commends.Customer;
using AdvanceLibrary.Domain.Validator.Book;
using AdvanceLibrary.Domain.Validator.Customer;
using FluentValidation;

namespace AdvanceLibrary.Api;

public static class validatorContainer
{
    public static IServiceCollection AddValidatorServieces(this IServiceCollection services)
    {
        services.AddScoped<IValidator<AddBookCommand>, AddBookValitator>();
        services.AddScoped<IValidator<AddCustomerCommand>, AddCustomerValidator>();

        services.AddValidatorsFromAssemblyContaining<AddBookValitator>();
        services.AddValidatorsFromAssemblyContaining<AddCustomerValidator>();
        return services;
    }
}
