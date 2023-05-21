namespace Data.Models;

public class Sizes_ShoeDetails
{
    public Guid Id { get; set; }

    public Guid IdShoeDetails { get; set; }

    public Guid IdSize { get; set; }

    public virtual ShoeDetails ShoeDetails { get; set; }

    public virtual Sizes Sizes { get; set; }
}