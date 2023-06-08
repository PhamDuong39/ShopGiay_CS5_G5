using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Data.Models
{
  public class Supplier
  {
    public Guid Id { get; set; }

    [StringLength(300, MinimumLength = 5, ErrorMessage = "Supplier Address must be between 5 and 300 characters long.")]
    public string Address { get; set; }
    public List<ShoeDetails> ShoeDetails { get; set; }
  }
}
