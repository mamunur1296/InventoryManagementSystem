using Project.Domail.Entities;


namespace Project.Application.DTOs
{
    public class ProductDiscuntDTO : BaseDTOs
    {


        public Guid ProductId { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidTill { get; set; }
        public Product Product { get; set; }
    }
}
