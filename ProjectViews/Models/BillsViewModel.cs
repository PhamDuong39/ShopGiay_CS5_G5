using Data.Models;
namespace ProjectViews.Models
{
    public class BillsViewModel
    {
        public Bills bill { get; set; }
        public List<BillDetails> lstBillDT { get; set; }
        public int sumPrice { get; set; }
    }
}
