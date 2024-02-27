using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AdvanceLibrary.Application;
public static class ApplicationContainer
{
    public static IServiceCollection AddApplicationServieces(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
