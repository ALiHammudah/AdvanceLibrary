using AdvanceLibrary.Domain.Commends.Book;
using AdvanceLibrary.Domain.Dtos.Api;
using AdvanceLibrary.Domain.Dtos.Book;
using AdvanceLibrary.Domain.Queries.Book;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceLibrary.Api.Controllers;

[ApiController]
[Route("Controller")]
public class BookController : Controller
{
    private readonly IValidator<AddBookCommand> _validator;
    private readonly IMediator _mediator;

    public BookController(IMediator mediator, IValidator<AddBookCommand> validator)
    {
        _mediator = mediator;
        _validator = validator;
    }

    [HttpGet("all_books")]
    public async Task<ActionResult<List<BookDitailDto>>> GetAllBook()
    {
        return Ok(await _mediator.Send(new GetAllBookQuery()));
    }

    [HttpGet("all_books_by_id/{id}")]
    public async Task<ActionResult<List<BookDitailDto>>> FindBookAsync(Guid id)
    {
        return Ok(await _mediator.Send(new GetBookDetailQuery(id)));
    }

    [HttpPost("add_book")]
    public async Task<ActionResult<ApiDto>> AddBookAsync([FromQuery] AddBookCommand request)
    {
        var result = await _validator.ValidateAsync(request);
        var errors = new List<string>();
        if (result.Errors.Any())
        {
            foreach (var error in result.Errors)
            {
                errors.Add($"{error.PropertyName} : {error.ErrorMessage}");
            }
            return BadRequest(errors);
        }

        return Ok(await _mediator.Send(request));
    }

    [HttpPut("update_book/")]
    public async Task<ActionResult<BookDitailDto>> UpdateBookAsync([FromQuery] UpdateBookCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpDelete("delete_book/{id}")]
    public async Task<ActionResult<BookDto>> DeleteBookAsync(Guid id)
    {
        return Ok(await _mediator.Send(new DeleteBookCommand(id)));
    }
}