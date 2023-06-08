using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Data.Models
{
  public class Brands
  {
    public Guid Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Brand name is required.")]
    public string Name { get; set; }
    public List<ShoeDetails> ShoeDetails { get; set; }
  }
}
