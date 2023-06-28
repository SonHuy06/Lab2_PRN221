using Lab2.Business.IRepository;
using Lab2.DataAccess.Managers;
using Lab2.DataAccess.Models;
using Lab2.Business.DTO;
using AutoMapper;

namespace Lab2.Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        NorthwindContext _context;
        IMapper _mapper;
        public ProductRepository(NorthwindContext context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ProductDTO> getListProduct()
        {
            ProductManager pm = new ProductManager(_context);
            List<Product> products = pm.getListProduct();
            List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);

            return productDTOs;
        }

        public List<ProductDTO> getListProduct(int pageIndex, int pageSize)
        {
            ProductManager pm = new ProductManager(_context);
            List<Product> products = pm.getListProduct(pageIndex, pageSize);
            List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);
            return productDTOs;
        }

        //public List<Product> getListProductByCateID(int pageIndex, int pageSize, int cateID)
        //{
        //    ProductManager pm = new ProductManager(_context);
        //    return pm.getListProductByCateID(pageIndex, pageSize, cateID);
        //}

        //public List<Product> getListProductBySupAndCate(int pageIndex, int pageSize, int supID, int cateID)
        //{
        //    ProductManager pm = new ProductManager(_context);
        //    return pm.getListProductBySupAndCate(pageIndex, pageSize, supID, cateID);
        //}

        //public List<Product> getListProductBySupID(int pageIndex, int pageSize, int supID)
        //{
        //    ProductManager pm = new ProductManager(_context);
        //    return pm.getListProductBySupID(pageIndex, pageSize, supID);
        //}

        public ProductDTO getProductById(int id)
        {
            ProductManager pm = new ProductManager(_context);
            Product product = pm.getProductById(id);
            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        //public List<Product> getTotalProductByCateID(int cateID)
        //{
        //    ProductManager pm = new ProductManager(_context);
        //    return pm.getTotalProductByCateID(cateID);
        //}

        //public List<Product> getTotalProductBySupAndCate(int supID, int cateID)
        //{
        //    ProductManager pm = new ProductManager(_context);
        //    return pm.getTotalProductBySupAndCate(supID, cateID);
        //}

        //public List<Product> getTotalProductBySupID(int supID)
        //{
        //    ProductManager pm = new ProductManager(_context);
        //    return pm.getTotalProductBySupID(supID);
        //}

        public List<ProductDTO> getTotalsearchProduct(int? supID = null, int? cateID = null, string? sort = null, string? search = null)
        {
            ProductManager pm = new ProductManager(_context);
            List<Product> products = pm.getTotalSearch(supID, cateID, sort, search);
            List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);
            return productDTOs;
        }

        public List<ProductDTO> searchProduct(int pageIndex, int pageSize, int? supID = null, int? cateID = null, string? sort = null, string? search = null)
        {
            ProductManager pm = new ProductManager(_context);
            List<Product> products = pm.searchProduct(pageIndex, pageSize, supID, cateID, sort, search);
            List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);
            return productDTOs;
        }
    }
}
