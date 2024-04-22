﻿using MediatR;
using Project.Application.Models;

namespace Project.Application.Features.ProdReturnFeatures.Commands
{
    public class CreateProdReturnCommand : IRequest<ProdReturnModels>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string ProdSizeId { get; set; }
        public string ProdValveId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
