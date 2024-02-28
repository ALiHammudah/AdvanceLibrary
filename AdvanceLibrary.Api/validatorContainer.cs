using AdvanceLibrary.Domain.Commends.Book;
using AdvanceLibrary.Domain.Commends.Customer;
using AdvanceLibrary.Domain.Validator.Book;
using AdvanceLibrary.Domain.Validator.Customer;
using FluentValidation;
using System.Reflection;

namespace AdvanceLibrary.Api;

public static class validatorContainer
{
    public static IServiceCollection AddValidatorServieces(this IServiceCollection services)
    {
        services.AddScoped<IValidator<AddBookCommand>, AddBookValitator>();
        services.AddScoped<IValidator<AddCustomerCommand>, AddCustomerValidator>();
        services.AddScoped<IValidator<UpdateBookCommand>, UpdateBookValidator>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
