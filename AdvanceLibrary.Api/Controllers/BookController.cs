using AdvanceLibrary.Domain.Commends.Book;
using AdvanceLibrary.Domain.Dtos.Book;
using AdvanceLibrary.Domain.Queries.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceLibrary.Api.Controllers;

[ApiController]
[Route("Controller")]
public class BookController : Controller
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("all_books")]
    public async Task<ActionResult<List<GetBookDto>>> GetAllBook()
    {
        return Ok(await _mediator.Send(new GetAllBookQuery()));
    }

    [HttpGet("all_books_by_id/{id}")]
    public async Task<ActionResult<List<GetBookDto>>> FindBookAsync(Guid id)
    {
        return Ok(await _mediator.Send(new GetBookDetailQuery(id)));
    }


    [HttpPost("add_book")]
    public async Task<ActionResult<BookDto>> AddBookAsync([FromQuery] AddBookCommand request)
    {
        return Ok(await _mediator.Send(request));
    }


    [HttpPut("update_book/")]
    public async Task<ActionResult<GetBookDto>> UpdateBookAsync([FromQuery] UpdateBookCommand request)
    {
        return Ok(await _mediator.Send(request));
    }


    [HttpDelete("delete_book/{id}")]
    public async Task<ActionResult<BookDto>> DeleteBookAsync(Guid id)
    {
        return Ok(await _mediator.Send(new DeleteBookCommand(id)));
    }
}