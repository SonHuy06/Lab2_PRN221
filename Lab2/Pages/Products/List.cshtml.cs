using Lab2.Business.IRepository;
using Lab2.Business.DTO;
using Lab2.DataAccess.Managers;
using Lab2.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages.Products
{
    public class ListModel : PageModel
    {
        IProductRepository _productRepository;
        public List<ProductDTO> allProducts { get; set; }
        public List<ProductDTO> productsPaging { get; set; }
        public List<ProductDTO> productsGroupByCateID { get; set; }
        public List<ProductDTO> productsGroupBySupID { get; set; }
        public int SelectedCategoryId { get; set; }
        public int? CateID { get; set; }
        public int? SupID { get; set; }

       

        public int pageNo { get; set; }
        public int pageSize { get; set; }

        public int totalProducts { get; set; }

        public ListModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        private void GetData(int p, int s)
        {


        }

        public void onPost()
        {
           

        }

        public void OnGet(int p = 1, int s = 9, int? cateID = null, int? supID = null, string? price = null, string? search = "")
        {

            if (cateID.HasValue || supID.HasValue || !String.IsNullOrEmpty(price) || !String.IsNullOrEmpty(search))
            {
                productsPaging = _productRepository.searchProduct(p, s, (int?)supID, (int?)cateID, price, search);
                totalProducts = _productRepository.getTotalsearchProduct((int?)supID, (int?)cateID, price, search).Count;
                

            }


           

            if (!cateID.HasValue && !supID.HasValue && String.IsNullOrEmpty(price) && String.IsNullOrEmpty(search))
            {
                productsPaging = _productRepository.getListProduct(p, s);
                totalProducts = _productRepository.getListProduct().Count;
            }

            allProducts = _productRepository.getListProduct();



            pageSize = s;
            pageNo = p;
            productsGroupByCateID = _productRepository.getListProduct().GroupBy(item => item.CategoryId).Select(group => group.First()).ToList();
            productsGroupBySupID = _productRepository.getListProduct().GroupBy(item => item.SupplierId).Select(group => group.First()).ToList();

        }
    }
}
