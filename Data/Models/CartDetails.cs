namespace Data.Models;

public class CartDetails
{
    public virtual Carts Carts { get; set; }

    public Guid Id { get; set; }

    public Guid IdCart { get; set; }

    public Guid IdShoeDetail { get; set; }

    public int Quantity { get; set; }

    public virtual ShoeDetails ShoeDetails { get; set; }
}