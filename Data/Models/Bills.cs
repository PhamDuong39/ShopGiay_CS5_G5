using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Bills
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public Guid IdVoucher { get; set; }
        public List<BillDetails> BillDetails { get; set; }
        public virtual Coupons Coupons { get; set; }
        public virtual Users Users { get; set; }

        public virtual PaymentMethods PaymentMethods { get; set; }

        public virtual ShipAdressMethod ShipAdressMethod { get; set; }
        public virtual Location Location { get; set; }
    }
}
