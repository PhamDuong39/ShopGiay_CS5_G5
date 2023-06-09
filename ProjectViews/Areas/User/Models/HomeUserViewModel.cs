using Data.Models;

namespace ProjectViews.Areas.User.Models
{
    public class HomeUserViewModel
    {
        public List<ShoeDetails> bestSellers { get; set; }
        public List<ShoeDetails> newArrivals { get; set; }
        public List<ShoeDetails> bestDiscounts { get; set; }
    }
}
