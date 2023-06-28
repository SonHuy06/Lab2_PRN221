using Lab2.DataAccess.Models;

namespace Lab2.Business.DTO
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public ProductDTO ProductItem { get; set; }

        public CartItem()
        {

        }
    }
}
