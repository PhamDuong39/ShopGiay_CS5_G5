namespace Data.Models;

public class Sales
{
    public int DiscountValue { get; set; }

    public DateTime EndDate { get; set; }

    public Guid Id { get; set; }

    public string SaleName { get; set; }

    public List<ShoeDetails> ShoeDetails { get; set; }

    public DateTime StartDate { get; set; }
}