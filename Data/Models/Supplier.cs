namespace Data.Models;

public class Supplier
{
    public string Address { get; set; }

    public Guid Id { get; set; }

    public List<ShoeDetails> ShoeDetails { get; set; }
}