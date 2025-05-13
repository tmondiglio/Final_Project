using Microsoft.AspNetCore.Mvc;
using Lab.Proyect.Application.Dto;
using AutoMapper;
using MediatR;
using Lab.Proyect.Api.DTOs;
using Lab.Proyect.Application.Services;
using Lab.Proyect.Application.UsesCases.Product.Queris;



namespace Lab.Proyect.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public ProductController(IProductService service, IMapper mapper, ISender mediator)
        {
            _service = service;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new ListProductQueries();
            var result = await _mediator.Send(query);
            return Ok(result.Products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductRequest request)
        {
            var productDTO = _mapper.Map<ProductDto>(request);
            await _service.CreateAsync(productDTO);
            return Ok(productDTO);
        }
    }
}
