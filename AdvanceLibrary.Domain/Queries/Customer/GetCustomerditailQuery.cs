using AdvanceLibrary.Domain.Dtos.Customer;
using MediatR;

namespace AdvanceLibrary.Domain.Queries.Customer;
public record GetCustomerditailQuery(Guid id) : IRequest<GetCustomerViewDto>;