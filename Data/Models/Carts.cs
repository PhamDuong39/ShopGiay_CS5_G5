namespace Data.Models;

public class Carts
{
    public List<CartDetails> CartDetails { get; set; }

    public Guid Id { get; set; }

    public Guid IdUser { get; set; }

    public virtual Users Users { get; set; }
}