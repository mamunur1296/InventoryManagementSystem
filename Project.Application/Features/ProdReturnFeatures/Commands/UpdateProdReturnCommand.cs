﻿using MediatR;
using Project.Application.Models;

namespace Project.Application.Features.ProdReturnFeatures.Commands
{
    public class UpdateProdReturnCommand : IRequest<ProdReturnModels>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public Guid ProdSizeId { get; set; }
        public Guid ProdValveId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
