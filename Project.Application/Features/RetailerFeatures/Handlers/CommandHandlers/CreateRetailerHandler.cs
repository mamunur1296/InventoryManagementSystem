using AutoMapper;
using MediatR;
using Project.Application.Features.RetailerFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;
using Project.Domail.Entities;

namespace Project.Application.Features.RetailerFeatures.Handlers.CommandHandlers
{
    public class CreateRetailerHandler : IRequestHandler<CreateRetailerCommand, RetailerModel>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public CreateRetailerHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<RetailerModel> Handle(CreateRetailerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Retailer = _mapper.Map<Retailer>(request);
                await _unitOfWorkDb.retailerCommandRepository.AddAsync(Retailer);
                await _unitOfWorkDb.SaveAsync();
                var RetailerResponse = _mapper.Map<RetailerModel>(Retailer);
                return RetailerResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
