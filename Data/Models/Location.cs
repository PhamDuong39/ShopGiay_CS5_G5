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
        public string CityName { get; set; }
        public string Stage { get; set; }
    }
}
