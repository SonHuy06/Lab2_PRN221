using Lab2.DataAccess.Models;

namespace Lab2.Business.IRepository
{
    public interface IProductRepository
    {
        List<Product> getListProduct();
        List<Product> getListProduct(int pageIndex, int pageSize);

        Product getProductById(int id);

        List<Product> getListProductByCateID(int pageIndex, int pageSize, int cateID);

        List<Product> getListProductBySupID(int pageIndex, int pageSize, int supID);

        List<Product> getTotalProductByCateID(int cateID);
        List<Product> getTotalProductBySupID(int supID);
        
    }
}
