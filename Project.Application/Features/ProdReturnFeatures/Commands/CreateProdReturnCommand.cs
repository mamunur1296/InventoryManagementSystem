﻿using MediatR;
using Project.Application.Models;
using Project.Domail.Entities;

namespace Project.Application.Features.ProdReturnFeatures.Commands
{
    public class CreateProdReturnCommand : IRequest<ProdReturnModels>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public Guid ProdSizeId { get; set; }
        public Guid ProdValveId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
       
    }
}
