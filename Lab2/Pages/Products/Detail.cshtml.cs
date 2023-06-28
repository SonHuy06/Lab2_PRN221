using Lab2.Business.IRepository;
using Lab2.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab2.Business.DTO;
using Lab2.Business.Services;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Lab2.Pages.Products
{
    public class DetailModel : PageModel
    {
        string cart_name = "cart";
        IProductRepository _productRepository;
        private readonly CartService _cartService;
        public ProductDTO Product { get; set; } = default!;
        public int Pid { get; set; }

        public DetailModel(IProductRepository productRepository, CartService cartService)
        {
            _productRepository = productRepository;
            _cartService = cartService;
        }
        public void OnGet(int pid)
        {
            var product = _productRepository.getProductById(pid);
            Product = product;
            string message = TempData.Peek("message") as string;
        }

        public IActionResult OnPostAddToCart(int productId)
        {
            int quantity = Int32.Parse(Request.Form["quantity"]);
            ProductDTO p = _productRepository.getProductById(productId);

            // Get the current cart from the cookie
            List<CartItem> cart;
            string cartJson = Request.Cookies[cart_name];
            if (cartJson != null)
            {
                // Convert from Json to object
                cart = JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
            }
            else
            {
                cart = new List<CartItem>();
            }

            // Check if the cart item already exists in the cart
            CartItem existingCartItem = cart.FirstOrDefault(p => p.ProductItem.ProductId == productId);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
            }
            else
            {
                ProductDTO product = new ProductDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Category = p.Category,
                    CategoryId = p.CategoryId,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock
                };

                CartItem newCartItem = new CartItem
                {
                    Quantity = quantity,
                    ProductItem = product
                };

                // add cart item to Cart
                cart.Add(newCartItem);
            }

            // config to skip property that cause infinite loop (ProductDTO reference -> CategoryDTO then CategoryDTO reference -> ProductDTO...)
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            // Convert from object to Json
            string updatedCartJson = JsonConvert.SerializeObject(cart, settings);
            CookieOptions options = new CookieOptions
            {
                // only access by http or https, not Javascript
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7)
            };
            Response.Cookies.Append(cart_name, updatedCartJson, options);

            string message = "Add to cart successfully!";
            TempData["message"] = message;

            var returnUrl = Request.Headers["Referer"].ToString();
            return Redirect(returnUrl);
        }
    }
}
