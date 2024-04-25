using AutoMapper;
using MediatR;
using Project.Application.Features.RetailerFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;

namespace Project.Application.Features.RetailerFeatures.Handlers.CommandHandlers
{
    public class UpdateRetailerHandler : IRequestHandler<UpdateRetailerCommand, RetailerModel>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public UpdateRetailerHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<RetailerModel> Handle(UpdateRetailerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var retailer = await _unitOfWorkDb.retailerQueryRepository.GetByIdAsync(request.Id);
                if (retailer == null) return default;
                else
                {
                    retailer.BIN = request.BIN;
                    retailer.Name = request.Name;
                    retailer.ContactPerNum = request.ContactPerNum;
                    retailer.ContactNumber = request.ContactNumber;
                    retailer.ContactPerNum = request.ContactPerNum;
                    retailer.DeactiveBy = request.DeactiveBy;
                }
                await _unitOfWorkDb.retailerCommandRepository.UpdateAsync(retailer);
                await _unitOfWorkDb.SaveAsync();
                var retailerRes = _mapper.Map<RetailerModel>(retailer);
                return retailerRes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
