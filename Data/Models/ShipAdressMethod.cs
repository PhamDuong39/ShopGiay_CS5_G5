using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ShipAdressMethod
    {
        public Guid Id { get; set; }
        public string NameAddress { get; set; }
        public int Status { get; set; }
        public Decimal Price { get; set; }
        public virtual Bills Bills { get; set; }
    }
}
