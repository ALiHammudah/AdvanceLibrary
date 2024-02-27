namespace AdvanceLibrary.Domain.Dtos.Book;
public class UpdateBookDto
{
    public string Messege { get; set; }
    public Guid BookId { get; set; }
    public string BookName { get; set; }
    public int Quantity { get; set; }
    public string AuthorName { get; set; }
}
