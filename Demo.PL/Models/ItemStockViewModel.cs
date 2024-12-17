using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class ItemStockViewModel
    {
        [Required(ErrorMessage = "This Is Required")]
        public int StoreId { get; set; }

        [Required(ErrorMessage = "This Is Required")]
        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
