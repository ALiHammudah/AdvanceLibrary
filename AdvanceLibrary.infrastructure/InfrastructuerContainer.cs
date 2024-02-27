using AdvanceLibrary.Application;
using AdvanceLibrary.Application.Contract;
using AdvanceLibrary.Domain.Auth;
using AdvanceLibrary.infrastructure.Repostries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AdvanceLibrary.infrastructure;
public static class InfrastructuerContainer
{
    public static IServiceCollection AddInfraServieces(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.Configure<JWT>(configuration.GetSection("JWT"));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
            };
        });

        services.AddApplicationServieces();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IBaseRepositry<>), typeof(BaseRepository<>));
        services.AddScoped(typeof(IBookRepositry), typeof(BookRepository));
        services.AddScoped(typeof(ICustomerRepositry), typeof(CustomerRepostry));
        services.AddScoped(typeof(IAuthServices), typeof(AuthServices));
        services.AddScoped<IPasswordHash, PasswordHash>();
        return services;
    }
}
