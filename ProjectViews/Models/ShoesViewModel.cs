using Data.Models;
namespace ProjectViews.Models
{
    public class ShoesViewModel
    {
        public ShoeDetails ShoesDetails { get; set; }
        public Supplier Suppliers { get; set; }
        public Brands Brands { get; set; }
        public Sales Sales { get; set; }
        public Categories Categories { get; set; }
        public List<Sizes_ShoeDetails> SizesList { get; set; }
        public List<Color_ShoeDetails> ColorsList { get; set; }
        public List<Images> ImagesList { get; set; }
        public List<Descriptions> DescriptionsList { get; set; }
    }
}
