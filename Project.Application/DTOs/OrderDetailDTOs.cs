

using Project.Domail.Entities;

namespace Project.Application.DTOs
{
    public class OrderDetailDTOs 
    {

        public string OrderID { get; set; }
        public string ProductID { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

    }
}
