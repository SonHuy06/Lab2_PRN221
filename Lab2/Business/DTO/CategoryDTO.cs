namespace Lab2.Business.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<ProductDTO> Products { get; set; }
    }
}
