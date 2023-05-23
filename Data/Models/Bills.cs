namespace Data.Models;

public class Bills
{
    public List<BillDetails> BillDetails { get; set; }

    public virtual Coupons Coupons { get; set; }

    public DateTime CreateDate { get; set; }

    public Guid Id { get; set; }

    public Guid IdCoupon { get; set; }

    public Guid IdLocation { get; set; }

    public Guid IdPaymentMethod { get; set; }

    public Guid IdShipAdressMethod { get; set; }

    public Guid IdUser { get; set; }

    public virtual Location Location { get; set; }

    public string Note { get; set; }

    public virtual PaymentMethods PaymentMethods { get; set; }

    public virtual ShipAdressMethod ShipAdressMethod { get; set; }

    public int Status { get; set; }

    public virtual Users Users { get; set; }
}