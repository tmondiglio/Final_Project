using AutoMapper;
using Lab.Project.Application.Dto;
using Lab.Project.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Project.Application.UsesCases.Product.Queris
{
    public class ListOrdersHandler : IRequestHandler<ListOrderQuery, ListOrderResponse>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public ListOrdersHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ListOrderResponse> Handle(ListOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetAllAsync();
            var mapped = _mapper.Map<List<OrderDto>>(orders);
            return new ListOrderResponse { Order = mapped };
        }
    }
}

