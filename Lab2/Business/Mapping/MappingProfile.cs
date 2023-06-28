using Lab2.DataAccess.Models;
using Lab2.Business.DTO;

namespace Lab2.Business.Mapping
{
    public class MappingProfile:AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
        }
    }
}
