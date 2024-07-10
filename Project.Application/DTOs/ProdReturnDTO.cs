using Project.Domail.Entities;

namespace Project.Application.DTOs
{
    public class ProdReturnDTO : BaseDTOs
    {

        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public Guid ProdSizeId { get; set; }
        public Guid ProdValveId { get; set; }
        public virtual Product Product { get; set; }
    }
}
