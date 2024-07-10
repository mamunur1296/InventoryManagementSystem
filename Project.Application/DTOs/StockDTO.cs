

using Project.Domail.Entities;

namespace Project.Application.DTOs
{
    public class StockDTO : BaseDTOs
    {
        public Guid ProductId { get; set; }
        public Guid TraderId { get; set; }
        public int Quantity { get; set; }
        public bool IsQC { get; set; }
        public bool IsActive { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Trader? Trader { get; set; }
    }
}
