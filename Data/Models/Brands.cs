namespace Data.Models;

public class Brands
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<ShoeDetails> ShoeDetails { get; set; }
}