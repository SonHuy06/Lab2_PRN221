using Lab2.Business.IRepository;
using Lab2.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages.Products
{
    public class DetailModel : PageModel
    {
        IProductRepository _productRepository;
        public Product Product { get; set; } = default!;
        public int Pid { get; set; }

        public DetailModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void OnGet(int pid)
        {
            var product = _productRepository.getProductById(pid);
            Product = product;
        }
    }
}
