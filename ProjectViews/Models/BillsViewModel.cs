using Data.Models;
namespace ProjectViews.Models
{
    public class BillsViewModel
    {
        public Bills bill { get; set; }
        public List<BillDetails> lstBillDT { get; set; }
        private int _sumPrice;

        public int sumPrice
        {
            get
            {
                _sumPrice = lstBillDT.Sum(bill => bill.Quantity * bill.Price);
                return _sumPrice;
            }
            set
            {
                _sumPrice = value;
            }
        }
    }
}
