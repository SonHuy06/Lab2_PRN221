using Lab2.DataAccess.Models;
using Lab2.Business.DTO;

namespace Lab2.Business.IRepository
{
    public interface IProductRepository
    {
        List<ProductDTO> getListProduct();
        List<ProductDTO> getListProduct(int pageIndex, int pageSize);

        ProductDTO getProductById(int id);

        //List<Product> getListProductByCateID(int pageIndex, int pageSize, int cateID);

        //List<Product> getListProductBySupID(int pageIndex, int pageSize, int supID);

        //List<Product> getTotalProductByCateID(int cateID);
        //List<Product> getTotalProductBySupID(int supID);

        //List<Product> getListProductBySupAndCate(int pageIndex, int pageSize, int supID, int cateID);
        //List<Product> getTotalProductBySupAndCate(int supID, int cateID);

        //List<ProductDTO> searchProduct(int pageIndex, int pageSize, int? supID = null, int? cateID = null);

        //List<ProductDTO> getTotalsearchProduct(int? supID = null, int? cateID = null);

        List<ProductDTO> searchProduct(int pageIndex, int pageSize, int? supID = null, int? cateID = null, string? sort = null, string? search = null);

        List<ProductDTO> getTotalsearchProduct(int? supID = null, int? cateID = null, string? sort = null, string? search = null);

    }
}
