using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Data.Models
{
  public class Categories
  {
    public Guid Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Category name is required.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Category name must be between 5 and 100 characters long.")]
    public string CategoryName { get; set; }
    public List<ShoeDetails> ShoeDetails { get; set; }
  }
}
