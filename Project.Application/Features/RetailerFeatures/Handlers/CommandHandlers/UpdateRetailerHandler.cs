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
            var data = await _unitOfWorkDb.retailerQueryRepository.GetByIdAsync(request.Id);
            if (data == null) return default;
            else
            {
                data.BIN=request.BIN;
                data.Name=request.Name;
                data.ContactPerNum=request.ContactPerNum;
                data.ContactNumber=request.ContactNumber;
                data.ContactPerNum = request.ContactPerNum;
                data.DeactiveBy=request.DeactiveBy;
            }
            await _unitOfWorkDb.retailerCommandRepository.UpdateAsync(data);
            await _unitOfWorkDb.SaveAsync();
            var customerRes = _mapper.Map<RetailerModel>(data);
            return customerRes;
        }
    }
}
