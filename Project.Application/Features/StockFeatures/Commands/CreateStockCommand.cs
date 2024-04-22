﻿using MediatR;
using Project.Application.Models;


namespace Project.Application.Features.StockFeatures.Commands
{
    public class CreateStockCommand : IRequest<StockModels>
    {
        public Guid ProductId { get; set; }
        public Guid TraderId { get; set; }
        public int Quantity { get; set; }
        public bool IsQC { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
