using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using Lab.Project.Api.DTOs;
using Lab.Project.Application.Dto;
using Lab.Project.Application.Services;
using Lab.Project.Application.UsesCases.Product.Queris;

namespace Lab.Proyect.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public OrderController(IOrderService service, IMapper mapper, ISender mediator)
        {
            _service = service;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new ListOrderQuery();
            var result = await _mediator.Send(query);
            return Ok(result.Order);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderRequest request)
        {
            var orderDto = _mapper.Map<OrderDto>(request);
            var created = await _service.CreateAsync(orderDto);
            return Ok(created);
        }
    }
}
