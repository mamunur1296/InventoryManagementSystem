﻿using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.ProdReturnFeatures.Queries;
using Project.Domail.Abstractions;

namespace Project.Application.Features.ProdReturnFeatures.Handlers.QueryHandlers
{
    public class GetAllProdReturnHandler : IRequestHandler<GetAllProdReturnQuery, IEnumerable<ProdReturnDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllProdReturnHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProdReturnDTO>> Handle(GetAllProdReturnQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var prodReturnList = await _unitOfWorkDb.prodReturnQueryRepository.GetAllAsync();
                var productList = await _unitOfWorkDb.productQueryRepository.GetAllAsync();

                foreach (var prodreet in prodReturnList)
                {
                    prodreet.Product = productList.FirstOrDefault(x => x.Id == prodreet.ProductId);
                }
                var result = prodReturnList.Select(x => _mapper.Map<ProdReturnDTO>(x));
                
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
