namespace Data.Models;

public class Images
{
    public Guid Id { get; set; }

    public Guid IdShoeDetail { get; set; }

    public string ImageSource { get; set; }

    public virtual ShoeDetails ShoeDetails { get; set; }
}