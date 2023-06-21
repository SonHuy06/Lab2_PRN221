using Lab2.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.DataAccess.Managers
{
    public class ProductManager
    {
        NorthwindContext _context;

        public ProductManager(NorthwindContext context)
        {
            _context = context;
        }

        public List<Product> getListProduct()
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Supplier).ToList();
        }

        public List<Product> getListProduct(int pageIndex, int pageSize)
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public Product getProductById(int id)
        {
            Product product = _context.Products.Include(p => p.Category).Include(p => p.Supplier).FirstOrDefault(p => p.ProductId == id);
            return product;
        }

        public List<Product> getListProductByCateID(int pageIndex, int pageSize, int cateID)
        {
            return _context.Products.Where(p => p.CategoryId == cateID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Product> getListProductBySupID(int pageIndex, int pageSize, int supID)
        {
            return _context.Products.Where(p => p.SupplierId == supID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Product> getTotalProductByCateID(int cateID)
        {
            return _context.Products.Where(p => p.CategoryId == cateID).ToList();
        }

        public List<Product> getTotalProductBySupID(int supID)
        {
            return _context.Products.Where(p => p.SupplierId == supID).ToList();
        }
    }
}
