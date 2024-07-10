namespace Project.Application.DTOs
{
    public class ProductSizeDTO : BaseDTOs
    {

        public decimal Size { get; set; }
        public string? Unit { get; set; }
        public bool IsActive { get; set; }
    }
}
