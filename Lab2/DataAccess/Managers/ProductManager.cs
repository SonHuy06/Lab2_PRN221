using Lab2.DataAccess.Models;
using Lab2.Pages;
using Microsoft.EntityFrameworkCore;
using System;

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

        public List<Product> getListProductBySupAndCate(int pageIndex, int pageSize, int supID, int cateID)
        {
            return _context.Products.Where(p => p.SupplierId == supID).Where(p => p.CategoryId == cateID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Product> getTotalProductBySupAndCate( int supID, int cateID)
        {
            return _context.Products.Where(p => p.SupplierId == supID).Where(p => p.CategoryId == cateID).ToList();
        }

        public List<Product> searchProduct(int pageIndex, int pageSize, int? supID = null, int? cateID = null)
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Product> getTotalSearch(int? supID = null, int? cateID = null)
        {
            return _context.Products.Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).ToList();
        }

        public List<Product> searchProduct(int pageIndex, int pageSize, int? supID = null, int? cateID = null, string? sort = null, string? search = null)
        {

            if (!String.IsNullOrEmpty(search))
            {
                if (!String.IsNullOrEmpty(sort))
                {
                    if (sort.Equals("asc"))
                    {
                        return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).Where(p => (p.ProductName.Contains(search))).OrderBy(p => p.UnitPrice).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                    }
                    else if (sort.Equals("desc"))
                    {
                        return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).Where(p => (p.ProductName.Contains(search))).OrderByDescending(p => p.UnitPrice).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                    }
                }


                return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).Where(p => (p.ProductName.Contains(search))).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                if (!String.IsNullOrEmpty(sort))
                {
                    if (sort.Equals("asc"))
                    {
                        return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).OrderBy(p => p.UnitPrice).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                    }
                    else if (sort.Equals("desc"))
                    {
                        return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).OrderByDescending(p => p.UnitPrice).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                    }
                }


                return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
           
        }

        public List<Product> getTotalSearch(int? supID = null, int? cateID = null, string? sort = null, string? search = null)
        {

            if (String.IsNullOrEmpty(search))
            {

                if (!String.IsNullOrEmpty(sort))
                {
                    if (sort.Equals("asc"))
                    {
                        return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).OrderBy(p => p.UnitPrice).ToList();
                    }
                    else if (sort.Equals("desc"))
                    {
                        return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).OrderByDescending(p => p.UnitPrice).ToList();
                    }
                }


                return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).ToList();

                
            }
            else
            {
                if (!String.IsNullOrEmpty(sort))
                {
                    if (sort.Equals("asc"))
                    {
                        return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).Where(p => (p.ProductName.Contains(search))).OrderBy(p => p.UnitPrice).ToList();
                    }
                    else if (sort.Equals("desc"))
                    {
                        return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).Where(p => (p.ProductName.Contains(search))).OrderByDescending(p => p.UnitPrice).ToList();
                    }
                }


                return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => (!supID.HasValue || p.SupplierId == supID) && (!cateID.HasValue || p.CategoryId == cateID)).Where(p => (p.ProductName.Contains(search))).ToList();
            }
            
        }

    }
}
