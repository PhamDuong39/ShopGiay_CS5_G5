using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class PaymentMethods
    {
        public Guid Id { get; set; }
        public string NameMethod { get; set; }
        public int Status { get; set; }
        public virtual Bills Bills { get; set; } 
    }
}
