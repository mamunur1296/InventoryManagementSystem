namespace Project.Application.DTOs
{
    public class ProdReturnDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string ProdSizeId { get; set; }
        public string ProdValveId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
