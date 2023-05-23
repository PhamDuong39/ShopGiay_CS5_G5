namespace Data.Models;

public class ShipAdressMethod
{
    public List<Bills> Bills { get; set; }

    public Guid Id { get; set; }

    public string NameAddress { get; set; }

    public int Price { get; set; }

    public int Status { get; set; }
}