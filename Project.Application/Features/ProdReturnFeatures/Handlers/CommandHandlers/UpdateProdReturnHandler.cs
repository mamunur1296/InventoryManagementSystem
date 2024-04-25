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
            try
            {
                var prodReturn = await _unitOfWorkDb.prodReturnQueryRepository.GetByIdAsync(request.Id);
                if (prodReturn == null) return default;
                else
                {
                    prodReturn.CreatedBy = request.CreatedBy;
                }
                await _unitOfWorkDb.prodReturnCommandRepository.UpdateAsync(prodReturn);
                await _unitOfWorkDb.SaveAsync();
                var prodReturnRes = _mapper.Map<ProdReturnModels>(prodReturn);
                return prodReturnRes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}