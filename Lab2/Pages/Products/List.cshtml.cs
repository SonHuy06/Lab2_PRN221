using Lab2.Business.IRepository;
using Lab2.DataAccess.Managers;
using Lab2.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages.Products
{
    public class ListModel : PageModel
    {
        IProductRepository _productRepository;
        public List<Product> allProducts { get; set; }
        public List<Product> productsPaging { get; set; }
        public List<Product> productsGroupByCateID { get; set; }
        public List<Product> productsGroupBySupID { get; set; }
        public int? CateID { get; set; }
        public int SupID { get; set; }

        public int pageNo { get; set; }
        public int pageSize { get; set; }

        public int totalProducts { get; set; }

        public ListModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        private void GetData(int p, int s)
        {

            productsPaging = _productRepository.getListProduct(p, s);
            totalProducts = _productRepository.getListProduct().Count;
        }

        public void onPost()
        {
           

        }

        public void OnGet(int p = 1, int s = 3, int? cateID = null, int? supID = null)
        {

            if (cateID.HasValue)
            {
                productsPaging = _productRepository.getListProductByCateID(p, s, (int)cateID);
                totalProducts = _productRepository.getTotalProductByCateID((int)cateID).Count;
                CateID = cateID.Value;
            }
            else if (supID.HasValue)
            {
                productsPaging = _productRepository.getListProductBySupID(p, s, (int)supID);
                totalProducts = _productRepository.getTotalProductBySupID((int)supID).Count;
                SupID = supID.Value;

            }

            if (!cateID.HasValue && !supID.HasValue)
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
