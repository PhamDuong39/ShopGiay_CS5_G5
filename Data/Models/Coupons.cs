namespace Data.Models;

public class Coupons
{
    public List<Bills> Bills { get; set; }

    public int DiscountValue { get; set; }

    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public DateTime TimeEnd { get; set; }

    public DateTime TimeStart { get; set; }

    public string VoucherName { get; set; }
}