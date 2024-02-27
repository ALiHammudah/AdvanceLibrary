using AdvanceLibrary.Domain.Dtos.Customer;
using MediatR;

namespace AdvanceLibrary.Domain.Commends.Customer;
public record UpdateCustomerCommand(
    Guid Id,
    string Name,
    string Phone,
    string Email,
    string Address
    ) : IRequest<GetCustomerViewDto>;
