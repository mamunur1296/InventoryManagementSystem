using AutoMapper;
using MediatR;
using Project.Application.Features.ProdReturnFeatures.Commands;
using Project.Application.Models;
using Project.Domail.Abstractions;

namespace Project.Application.Features.ProdReturnFeatures.Handlers.CommandHandlers
{
    public class UpdateProdReturnHandler : IRequestHandler<UpdateProdReturnCommand, ProdReturnModels>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public UpdateProdReturnHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }


        public async Task<ProdReturnModels> Handle(UpdateProdReturnCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWorkDb.prodReturnQueryRepository.GetByIdAsync(request.Id);
            if (data == null) return default;
            else
            {
                data.CreatedBy = request.CreatedBy;
            }
            await _unitOfWorkDb.prodReturnCommandRepository.UpdateAsync(data);
            await _unitOfWorkDb.SaveAsync();
            var customerRes = _mapper.Map<ProdReturnModels>(data);
            return customerRes;
        }
    }
}