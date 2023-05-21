namespace Data.Models;

public class ShipAddressMethods
{
    public List<Bills> Bills { get; set; }

    public Guid Id { get; set; }

    public string NameAddress { get; set; }

    public decimal Price { get; set; }

    public int Status { get; set; }
}