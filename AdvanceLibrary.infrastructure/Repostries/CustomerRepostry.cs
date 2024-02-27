using AdvanceLibrary.Application.Contract;
using AdvanceLibrary.Domain.Commends.Customer;
using AdvanceLibrary.Domain.Dtos.Customer;
using AdvanceLibrary.Domain.Dtos.CustomerDto.Customer;
using AdvanceLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvanceLibrary.infrastructure.Repostries;
public class CustomerRepostry : BaseRepository<Customer>, ICustomerRepositry
{
    public CustomerRepostry(AppDbContext context) : base(context) { }

    public async Task<AddCustomerDto> AddCustomerAsync(AddCustomerCommand model)
    {
        if (await _context.Customers.AnyAsync(b => b.Name == model.CustomerName))
            return null;

        if (await _context.Customers.AnyAsync(b => b.Phone == model.customerPhone))
            return null;

        if (await _context.Customers.AnyAsync(b => b.Email == model.CustomerEmail))
            return null;

        var id = Guid.NewGuid();
        await _context.Customers.AddAsync(new Customer
        {
            Id = id,
            Name = model.CustomerName,
            Phone = model.customerPhone,
            Email = model.CustomerEmail,
            Address = model.customerAddress
        });

        await _context.SaveChangesAsync();

        return new AddCustomerDto
        {
            Messege = "Customer added",
            CustomerId = id,
            CustomerName = model.CustomerName,
        };
    }

    public async Task<CustomerDto> DeleteCustomerAsync(Guid id)
    {
        if (await _context.CustomerBooks.AnyAsync(c => c.CustomerId == id))
            return null;

        var customer = await _context.Customers.FindAsync(id);
        if (customer is null)
            return null;

        await Task.Run(() => _context.Remove(customer));
        await _context.SaveChangesAsync();

        return new CustomerDto
        {
            CustomerId = customer.Id,
            CustomerName = customer.Name,
            CustomerEmail = customer.Email
        };
    }

    public async Task<List<CustomerDto>> GetAllCustomerAsync()
    {
        return await _context.Customers.Select(i => new CustomerDto
        {
            CustomerId = i.Id,
            CustomerName = i.Name,
            CustomerEmail = i.Email
        }).ToListAsync();
    }

    public async Task<GetCustomerViewDto> GetCustomerDitailAsync(Guid id)
    {
        return await _context.Customers
            .Where(i => i.Id == id)
            .Select(i => new GetCustomerViewDto
            {
                CustomerId = i.Id,
                CustomerName = i.Name,
                CustomerEmail = i.Email,
                CustomerPhone = i.Phone,
                CustomerAddress = i.Address
            }).FirstOrDefaultAsync();
    }

    public async Task<GetCustomerViewDto> UpdateCustomerAsync(UpdateCustomerCommand model)
    {
        var customer = await _context.Customers.FindAsync(model.Id);
        if (customer is null)
            return null;

        if (model.Phone is not null)
            customer.Phone = model.Phone;

        else if (model.Address is not null)
            customer.Address = model.Address;

        else if (model.Name is not null)
            customer.Name = model.Name;

        else if (model.Email is not null)
            customer.Email = model.Email;

        else
            return null;

        await _context.SaveChangesAsync();

        return new GetCustomerViewDto
        {
            CustomerId = model.Id,
            CustomerName = customer.Name,
            CustomerEmail = customer.Email,
            CustomerPhone = customer.Phone,
            CustomerAddress = customer.Address
        };
    }
}
