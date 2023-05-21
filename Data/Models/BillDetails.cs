namespace Data.Models;

public class BillDetails
{
    public virtual Bills Bills { get; set; }

    public Guid Id { get; set; }

    public Guid IdBill { get; set; }

    public Guid IdShoeDetail { get; set; }

    public int Price { get; set; }

    public int Quantity { get; set; }

    public virtual ShoeDetails ShoeDetails { get; set; }
}