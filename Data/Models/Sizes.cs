using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
  public class Sizes
  {
    public Guid Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Size name is required.")]
    [Range(0, 50.0, ErrorMessage = "Size name must be between 0 and 50 characters long.")]
    public float SizeNumber { get; set; }
    public List<Sizes_ShoeDetails> Sizes_ShoeDetails { get; set; }
  }
}
