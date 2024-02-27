using AdvanceLibrary.Domain.Dtos.Library;
using MediatR;

namespace AdvanceLibrary.Domain.Queries.CustomerBook;
public record GetBorrowedCustomerQuery(string CustomerName) : IRequest<BorrowedCustomerDto>;