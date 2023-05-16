using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Stage { get; set; } // T?nh or Thành ph?
        public string District { get; set; } // Huy?n
        public string Ward { get; set; } // Xã
        public string Street { get; set; } // ???ng
        public string Address { get; set; } // ??a ch? 
        public virtual Bills Bills { get; set; } // 1-1
    }
}
