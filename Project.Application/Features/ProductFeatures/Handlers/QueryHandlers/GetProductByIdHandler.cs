using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.ProductFeatures.Queries;
using Project.Domail.Abstractions;


namespace Project.Application.Features.ProductFeatures.Handlers.QueryHandlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
  
        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWorkDb.productQueryRepository.GetByIdAsync(request.id);
            var newData = _mapper.Map<ProductDTO>(data);
            return newData;
        }
    }
}
