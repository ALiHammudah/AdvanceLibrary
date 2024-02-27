namespace AdvanceLibrary.Domain.Dtos.Customer;
public class GetCustomerViewDto
{
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerAddress { get; set; }
}
