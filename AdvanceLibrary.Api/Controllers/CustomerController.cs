using AdvanceLibrary.Domain.Commends.Customer;
using AdvanceLibrary.Domain.Dtos.Customer;
using AdvanceLibrary.Domain.Queries.Customer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceLibrary.Api.Controllers;

[ApiController]
[Route("Controller")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator) => _mediator = mediator;


    [HttpGet("all_customer")]
    public async Task<ActionResult<List<CustomerDto>>> GetAllCustomer()
    {
        return Ok(await _mediator.Send(new GetAllCustomerQuery()));
    }


    [HttpGet("find_customer_by_id/{id}")]
    public async Task<ActionResult<List<GetCustomerViewDto>>> GetAllCustomer(Guid id)
    {
        return Ok(await _mediator.Send(new GetCustomerditailQuery(id)));
    }

    [Authorize]
    [HttpPost("add_customer")]
    public async Task<ActionResult<CustomerDto>> AddCustomerAsync([FromQuery] AddCustomerCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [Authorize]
    [HttpPut("update_customer/{id}")]
    public async Task<ActionResult<GetCustomerViewDto>> UpdateCustomerAsync([FromQuery] UpdateCustomerCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [Authorize]
    [HttpDelete("delete_customer/{id}")]
    public async Task<ActionResult<CustomerDto>> DeleteCustomerAsync(Guid id)
    {
        return Ok(await _mediator.Send(new DeleteCustomerCommand(id)));
    }
}
