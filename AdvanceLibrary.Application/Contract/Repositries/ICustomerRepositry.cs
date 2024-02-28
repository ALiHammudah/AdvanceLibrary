using AdvanceLibrary.Domain.Commends.Customer;
using AdvanceLibrary.Domain.Dtos.Customer;
using AdvanceLibrary.Domain.Dtos.CustomerDto.Customer;
using AdvanceLibrary.Domain.Entities;

namespace AdvanceLibrary.Application.Contract;
public interface ICustomerRepositry : IBaseRepositry<Customer>
{
    Task<List<CustomerDto>> GetAllCustomerAsync();
    Task<GetCustomerViewDto> GetCustomerDitailAsync(Guid id);
    Task<AddCustomerDto> AddCustomerAsync(AddCustomerCommand model);
    Task<CustomerDto> DeleteCustomerAsync(Guid id);
    Task<GetCustomerViewDto> UpdateCustomerAsync(UpdateCustomerCommand model);
}
