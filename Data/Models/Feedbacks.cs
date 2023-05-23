namespace Data.Models;

public class Feedbacks
{
    public Guid Id { get; set; }

    public Guid IdShoeDetail { get; set; }

    public Guid IdUser { get; set; }

    public string Note { get; set; }

    public int RatingStar { get; set; }

    public virtual ShoeDetails ShoeDetails { get; set; }

    public virtual Users Users { get; set; }
}