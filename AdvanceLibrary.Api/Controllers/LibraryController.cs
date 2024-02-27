using AdvanceLibrary.Domain.Commends.CustomerBook;
using AdvanceLibrary.Domain.Dtos.Library;
using AdvanceLibrary.Domain.Queries.CustomerBook;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceLibrary.Api.Controllers;

[ApiController]
[Route("Controller")]
public class LibraryController : ControllerBase
{
    private readonly IMediator _mediator;
    public LibraryController(IMediator mediator) => _mediator = mediator;

    [HttpGet("all_borrowed_book")]
    public async Task<ActionResult<List<BorrowedBookDto>>> GetAllBorrowedAsync()
    {
        return await _mediator.Send(new GetAllBorrowedQuery());
    }

    [HttpGet("borrowed_book_byBookName/{BookName}")]
    public async Task<ActionResult<BorrowedBookDto>> GetBorrowedBookByBookNameAsync(string BookName)
    {
        return await _mediator.Send(new GetBorrowedBookQuery(BookName));
    }

    [HttpGet("borrowed_book_byCustomerName/{CustomerName}")]
    public async Task<ActionResult<BorrowedCustomerDto>> GetBorrowedBookByCustomerNameAsync(string CustomerName)
    {
        return await _mediator.Send(new GetBorrowedCustomerQuery(CustomerName));
    }

    [Authorize]
    [HttpPost("borrow_book/{BookName},{CustomerName}")]
    public async Task<ActionResult<string>> BorrowBookasync(string BookName, string CustomerName)
    {
        return await _mediator.Send(new BorrowBookCommand(BookName, CustomerName));
    }

    [Authorize]
    [HttpPost("receive_book")]
    public async Task<ActionResult<string>> ReceiveBookasync([FromQuery] ReceiveBookCommand request)
    {
        return await _mediator.Send(request);
    }
}