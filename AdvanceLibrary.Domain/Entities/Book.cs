using AdvanceLibrary.Domain.Commends.Book;
using System.ComponentModel.DataAnnotations;

namespace AdvanceLibrary.Domain.Entities;
public class Book
{
    public Book() { }
    public Guid Id { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public string Author { get; set; }
    public List<CustomerBook> CustomerBooks { get; set; } = [];

    public void Update(UpdateBookCommand request)
    {
        if (!string.IsNullOrWhiteSpace(request.BookName)) Name = request.BookName;
        if (request.Quantity.HasValue) Quantity = request.Quantity.Value;
        if (!string.IsNullOrWhiteSpace(request.AuthorName)) Author = request.AuthorName;
    }
}
