using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
  public class Images
  {
    public Guid Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Shoes is required.")]
    public Guid IdShoeDetail { get; set; }

    [StringLength(1000, MinimumLength = 1, ErrorMessage = "Image source must be between 1 and 1000 characters long.")]
    public string ImageSource { get; set; }
    public virtual ShoeDetails ShoeDetails { get; set; }
  }
}
