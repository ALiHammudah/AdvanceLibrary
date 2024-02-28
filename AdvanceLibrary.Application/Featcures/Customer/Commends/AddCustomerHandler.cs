using AdvanceLibrary.Application.Contract.Repositries;
using AdvanceLibrary.Domain.Commends.Customer;
using AdvanceLibrary.Domain.Dtos.CustomerDto.Customer;
using FluentValidation;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.Customer.Commends;
public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, AddCustomerDto>
{
    private readonly IValidator<AddCustomerCommand> _valitator;
    private readonly IUnitOfWork _unitOfWork;
    public AddCustomerHandler(IUnitOfWork unitOfWork, IValidator<AddCustomerCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _valitator = validator;
    }
    public async Task<AddCustomerDto> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var result = await _valitator.ValidateAsync(request);
        if (result.Errors.Any())
            return new AddCustomerDto
            {
                Messege = result.Errors.FirstOrDefault().ToString(),
            };

        return await _unitOfWork.Customer.AddCustomerAsync(request);
    }
}
