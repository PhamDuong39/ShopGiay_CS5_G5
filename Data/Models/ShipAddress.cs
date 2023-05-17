using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ShipAddress
    {
        public Guid Id { get; set; }
        public string NameAddress { get; set; }
        public virtual Bills Bills { get; set; }
    }
}
