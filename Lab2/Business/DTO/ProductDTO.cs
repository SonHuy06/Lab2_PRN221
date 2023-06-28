namespace Lab2.Business.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public string? QuantityPerUnit { get; set; }
        public short? UnitsOnOrder { get; set; }

        public virtual CategoryDTO? Category { get; set; }
        public virtual SupplierDTO? Supplier { get; set; }
    }
}
