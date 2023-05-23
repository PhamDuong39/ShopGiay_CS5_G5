namespace Data.Models;

public class PaymentMethods
{
    public List<Bills> Bills { get; set; }

    public Guid Id { get; set; }

    public string NameMethod { get; set; }

    public int Status { get; set; }
}