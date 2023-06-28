namespace Lab2.Business.DTO
{
    public class SupplierDTO
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; } = null!;
        public virtual ICollection<ProductDTO> Products { get; set; }
    }
}
