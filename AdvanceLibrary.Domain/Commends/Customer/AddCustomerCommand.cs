using AdvanceLibrary.Domain.Dtos.CustomerDto.Customer;
using MediatR;

namespace AdvanceLibrary.Domain.Commends.Customer;
public record AddCustomerCommand(string CustomerName,
    string CustomerEmail,
    string customerPhone,
    string customerAddress
    ) : IRequest<AddCustomerDto>;
