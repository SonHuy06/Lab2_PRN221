using Lab2.Business.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Lab2.Pages.Carts
{
    public class CartModel : PageModel
    {
        string cart_name = "cart";
        public List<CartItem> cartList { get; set; }

        public void OnGet()
        {
            GetListCart();
        }

        private void GetListCart()
        {
            // Get the current cart from the cookie
            string cartJson = Request.Cookies[cart_name];
            if (cartJson != null)
            {
                // Convert from Json to object
                cartList = JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
            }
            else
            {
                cartList = new List<CartItem>();
            }
        }

        public IActionResult OnPostDeleteProductFromCart(int productId)
        {
            GetListCart();
            CartItem foundedCartItem = cartList.FirstOrDefault(x => x.ProductItem.ProductId == productId);

            if (foundedCartItem != null)
            {
                // handle remove cart item
                cartList.Remove(foundedCartItem);

                // config to ship property that cause infinite loop (ProductDTO reference -> CategoryDTO then CategoryDTO reference -> ProductDTO...)
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                // Convert from object to Json
                string updatedCartJson = JsonConvert.SerializeObject(cartList, settings);
                CookieOptions options = new CookieOptions
                {
                    // only access by http or https, not Javascript
                    HttpOnly = true,
                    Expires = DateTime.Now.AddDays(7)
                };
                Response.Cookies.Append(cart_name, updatedCartJson, options);

                string message = "Delete from cart successfully!";
                TempData["message"] = message;
            }
            else
            {
                string message = "Can not find the cart item you want to delete!";
                TempData["message"] = message;
            }

            return RedirectToPage("Cart");
        }
    }
}
