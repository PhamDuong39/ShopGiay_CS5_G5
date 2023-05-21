namespace Data.Models;

public class Sizes
{
    public Guid Id { get; set; }

    public float SizeNumber { get; set; }

    public List<Sizes_ShoeDetails> Sizes_ShoeDetails { get; set; }
}