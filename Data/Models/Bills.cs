namespace Data.Models;

public class Bills
{
    public List<BillDetails> BillDetails { get; set; }

    public virtual Coupons Coupons { get; set; }

    public DateTime CreateDate { get; set; }

    public Guid Id { get; set; }

    public Guid IdUser { get; set; }

    public Guid IdVoucher { get; set; }

    public virtual Location Location { get; set; }

    public string Note { get; set; }

    public virtual PaymentMethods PaymentMethods { get; set; }

    public virtual ShipAddressMethods ShipAdressMethod { get; set; }

    public int Status { get; set; }

    public virtual Users Users { get; set; }
}