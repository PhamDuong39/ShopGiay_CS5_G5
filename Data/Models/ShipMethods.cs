using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ShipMethods
    {
        public Guid Id { get; set; }
        public string NameAddress { get; set; }
        public int Status { get; set; }
        public Decimal Price { get; set; }
        public List<Bills> Bills { get; set; }
    }
}
