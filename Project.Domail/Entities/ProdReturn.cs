using Project.Domail.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domail.Entities
{
    public class ProdReturn : BaseEntity
    {
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string ProdSizeId { get; set; }
        public string ProdValveId { get; set; }


        // Navigation property
        public virtual Product Product { get; set; }

    }
}
