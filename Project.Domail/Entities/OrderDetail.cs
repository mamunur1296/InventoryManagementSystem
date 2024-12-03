using Microsoft.EntityFrameworkCore;
using Project.Domail.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domail.Entities
{
    public class OrderDetail : BaseEntity
    {
        
        public Guid ? OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order? Order { get; set; }
        public Guid ? ReturnProductId { get; set; }
        public Guid ? ProductID { get; set; }
        public Product? Product { get; set; }
        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        [Precision(18, 2)]
        public decimal ?Discount { get; set; }

    }
}
