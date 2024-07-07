using System.ComponentModel.DataAnnotations;

namespace Project.Domail.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime ?  CreationDate { get; set; }
        public DateTime ? UpdateDate { get;  set; }
        public string ? CreatedBy { get; set; }
        public string ? UpdatedBy { get; set; }
       
    }
}
