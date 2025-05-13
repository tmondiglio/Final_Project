using AutoMapper;
using Lab.Project.Api.DTOs;
using Lab.Project.Application.Dto;
using Lab.Project.Application.Services;
using Lab.Project.Application.UsesCases.Product.Queris;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Proyect.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public CustomerController(ICustomerService service, IMapper mapper, ISender mediator)
        {
            _service = service;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new ListCustomerQueries();
            var result = await _mediator.Send(query);
            return Ok(result.Customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest request)
        {
            var dto = _mapper.Map<CustomerDto>(request);
            var created = await _service.CreateAsync(dto);
            return Ok(created);
        }
    }
}
