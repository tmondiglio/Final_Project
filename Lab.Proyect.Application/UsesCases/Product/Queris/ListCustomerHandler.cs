using AutoMapper;
using Lab.Project.Application.Dto;
using Lab.Project.Application.UsesCases.Product.Queris;
using Lab.Project.Domain.Repositories;
using Lab.Proyect.Application.Dto;
using Lab.Proyect.Domain.Repositories;
using MediatR;

namespace Lab.Proyect.Application.UseCases.Customer.Queries
{
    public class ListCustomersHandler : IRequestHandler<ListCustomerQueries, ListCustomersResponse>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public ListCustomersHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ListCustomersResponse> Handle(ListCustomerQueries request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAllAsync();
            var mapped = _mapper.Map<List<CustomerDto>>(list);
            return new ListCustomersResponse { Customer = mapped };
        }
    }
}
