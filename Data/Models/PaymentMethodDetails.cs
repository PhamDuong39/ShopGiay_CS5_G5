using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class PaymentMethodDetails
    {
        public Guid Id { get; set; }
        public Guid IdPaymentMethod { get; set; }
        public Guid IdUser { get; set; }
        public int Status { get; set; }
        public virtual PaymentMethods PaymentMethods { get; set; }
        public virtual Users Users { get; set; } // 1 user có nhiều phương thức thanh toán
    }
}
