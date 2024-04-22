﻿namespace Project.Application.Models
{
    public class ProductSizeModels
    {
        public Guid Id { get; set; }
        public decimal Size { get; set; }
        public string? Unit { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
