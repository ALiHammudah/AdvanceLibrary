﻿using AdvanceLibrary.Application.Contract.Repositries;
using AdvanceLibrary.Domain.Dtos.Book;
using AdvanceLibrary.Domain.Queries.Book;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.Book.Queries;
public class GetBookDetailHandler : IRequestHandler<GetBookDetailQuery, BookDitailDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetBookDetailHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<BookDitailDto> Handle(GetBookDetailQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Books.FindBookAsync(request.id);
    }
}
