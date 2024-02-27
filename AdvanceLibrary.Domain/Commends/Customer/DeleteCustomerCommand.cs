using AdvanceLibrary.Domain.Dtos.Customer;
using MediatR;

namespace AdvanceLibrary.Domain.Commends.Customer;
public record DeleteCustomerCommand(Guid Id) : IRequest<CustomerDto>;