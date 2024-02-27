using AdvanceLibrary.Domain.Commends.User;
using AdvanceLibrary.Domain.Dtos.Auth;
using AdvanceLibrary.Domain.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceLibrary.Api.Controllers;
[ApiController]
[Route("Controller")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator) => _mediator = mediator;

    [HttpGet("login")]
    public async Task<ActionResult<AuthDto>> Login([FromQuery] LoginQuery request)
    {
        return await _mediator.Send(request);
    }

    [HttpPost("regestration")]
    public async Task<ActionResult<AuthDto>> Registration([FromQuery] RegistrationCommand request)
    {
        return await _mediator.Send(request);
    }
}
