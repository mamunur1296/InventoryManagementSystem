﻿using Project.Domail.Entities;

namespace Project.Application.Models
{
    public class DeliveryAddressModels
    {
        public Guid Id { get; set; }
        public Guid ? UserId { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public string? DeactiveBy { get; set; }
        public bool? IsDefault { get; set; }
        public virtual User User { get; set; }
    }
}
