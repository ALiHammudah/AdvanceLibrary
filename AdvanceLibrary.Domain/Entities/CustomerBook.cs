namespace AdvanceLibrary.Domain.Entities;
public class CustomerBook
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid CustomerId { get; set; }
    public Book Book { get; set; }
    public Customer Customer { get; set; }
}
