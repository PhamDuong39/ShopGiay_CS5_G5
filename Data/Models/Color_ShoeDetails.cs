namespace Data.Models;

public class Color_ShoeDetails
{
    public virtual Colors Colors { get; set; }

    public Guid Id { get; set; }

    public Guid IdColor { get; set; }

    public Guid IdShoeDetail { get; set; }

    public virtual ShoeDetails ShoeDetails { get; set; }
}