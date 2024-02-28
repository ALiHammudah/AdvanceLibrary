using AdvanceLibrary.Application.Contract.Serviese;
using AdvanceLibrary.Domain.Auth;
using AdvanceLibrary.Domain.Commends.User;
using AdvanceLibrary.Domain.Dtos.Auth;
using AdvanceLibrary.Domain.Entities;
using AdvanceLibrary.Domain.Queries.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdvanceLibrary.infrastructure.Repostries;
public class AuthServices : IAuthServices
{
    private readonly AppDbContext _context;
    private readonly JWT _jwt;
    private readonly IPasswordHash _passwordHash;
    public AuthServices(AppDbContext context, IPasswordHash passwordHash, IOptions<JWT> jwt)
    {
        _context = context;
        _jwt = jwt.Value;
        _passwordHash = passwordHash;
    }

    public async Task<AuthDto> RegisterAsync(RegistrationCommand models)
    {
        if (await _context.Users.SingleOrDefaultAsync(u => u.Email == models.Email) is not null)
            return new AuthDto { Message = "Email is already registred!" };

        if (await _context.Users.SingleOrDefaultAsync(u => u.Username == models.UserName) is not null)
            return new AuthDto { Message = "UserName is already registred!" };

        var Password = _passwordHash.Hash(models.Password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = models.FirstName,
            LastName = models.LastName,
            Email = models.Email,
            Username = models.UserName,
            Password = Password
        };

        var result = await _context.Users.AddAsync(user);

        var jwtSecurityToken = await CreateJwtToken(user);

        _context.SaveChanges();

        return new AuthDto
        {
            Message = "registration",
            Email = user.Email,
            IsAuthenticated = true,
            Username = user.Username,
            ExpiresOn = jwtSecurityToken.ValidTo,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
        };
    }

    public async Task<AuthDto> LoginAsync(LoginQuery model)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

        if (user is null || !_passwordHash.Verify(user.Password, model.Password))
            return new AuthDto { Message = "email or password is not correct" };

        var JwtToken = await CreateJwtToken(user);

        var authmodel = new AuthDto
        {
            IsAuthenticated = true,
            Username = user.Username,
            Email = user.Email,
            Token = new JwtSecurityTokenHandler().WriteToken(JwtToken),
            ExpiresOn = JwtToken.ValidTo,
        };


        return authmodel;
    }
    private async Task<JwtSecurityToken> CreateJwtToken(User user)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var Claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email,user.Email)
        };

        var jwtToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: Claims,
            expires: DateTime.Now.AddDays(_jwt.DurationInDays),
            signingCredentials: signingCredentials);

        return jwtToken;
    }

}
