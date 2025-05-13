using AutoMapper;
using Lab.Proyect.Application.Dto;
using Lab.Proyect.Application.UsesCases.Product.Queris;
using Lab.Proyect.Domain.Repositories;
using MediatR;

namespace Lab.Proyect.Application.UseCases.Product.Queries
{
    public class ListProductsHandler : IRequestHandler<ListProductQueries, ListProductResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ListProductsHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ListProductResponse> Handle(ListProductQueries request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync(); 

            var result = _mapper.Map<List<ProductDto>>(products);

            return new ListProductResponse
            {
                Products = result
            };
        }
    }
}
