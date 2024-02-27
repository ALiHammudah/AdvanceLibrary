using System.ComponentModel.DataAnnotations;

namespace AdvanceLibrary.Domain.Entities;
public class Customer
{
    public Guid Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required, StringLength(100)]
    public string Phone { get; set; }

    [Required, StringLength(100)]
    public string Email { get; set; }

    [StringLength(100)]
    public string Address { get; set; }

    public List<CustomerBook> CustomerBooks { get; set; } = [];
}
