using Lab2.Business.IRepository;
using Lab2.DataAccess.Managers;
using Lab2.DataAccess.Models;

namespace Lab2.Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        NorthwindContext _context;
        public ProductRepository(NorthwindContext context)
        {
            _context = context;
        }
        public List<Product> getListProduct()
        {
            ProductManager pm = new ProductManager(_context);
            return pm.getListProduct();
        }

        public List<Product> getListProduct(int pageIndex, int pageSize)
        {
            ProductManager pm = new ProductManager(_context);
            return pm.getListProduct(pageIndex, pageSize);
        }

        public List<Product> getListProductByCateID(int pageIndex, int pageSize, int cateID)
        {
            ProductManager pm = new ProductManager(_context);
            return pm.getListProductByCateID(pageIndex, pageSize, cateID);
        }

        public List<Product> getListProductBySupID(int pageIndex, int pageSize, int supID)
        {
            ProductManager pm = new ProductManager(_context);
            return pm.getListProductBySupID(pageIndex, pageSize, supID);
        }

        public Product getProductById(int id)
        {
            ProductManager pm = new ProductManager(_context);
            Product product = pm.getProductById(id);
            return product;
        }

        public List<Product> getTotalProductByCateID(int cateID)
        {
            ProductManager pm = new ProductManager(_context);
            return pm.getTotalProductByCateID(cateID);
        }

        public List<Product> getTotalProductBySupID(int supID)
        {
            ProductManager pm = new ProductManager(_context);
            return pm.getTotalProductBySupID(supID);
        }
    }
}
