using System.ComponentModel.DataAnnotations;
namespace Data.Models
{
  public class Colors
  {
    public Guid Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Color name is required.")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "Color name must be between 5 and 30 characters long.")]
    public string ColorName { get; set; }
    public List<Color_ShoeDetails> Color_ShoeDetails { get; set; }
  }
}
