using Project.Domail.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domail.Entities
{
    public class DeliveryAddress : BaseEntity
    {

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public string ? Address { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public string? DeactiveBy { get; set; }
        public bool? IsDefault { get; set; }

        // Navigation property
        public virtual User User { get; set; }

    }
}
