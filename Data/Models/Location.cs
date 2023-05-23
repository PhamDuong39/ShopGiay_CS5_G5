namespace Data.Models;

public class Location
{
    public string Address { get; set; } // Địa chỉ 

    public List<Bills> Bills { get; set; } // 1-n

    public string District { get; set; } // Huyện

    public Guid Id { get; set; }

    public string Stage { get; set; } // Tỉnh or Thành phố

    public string Street { get; set; } // Đường

    public string Ward { get; set; } // Xã
}