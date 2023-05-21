namespace Data.Models;

public class Categories
{
    public string CategoryName { get; set; }

    public Guid Id { get; set; }

    public List<ShoeDetails> ShoeDetails { get; set; }
}