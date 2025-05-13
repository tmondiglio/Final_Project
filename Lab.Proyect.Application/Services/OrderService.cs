using AutoMapper;
using Lab.Project.Application.Dto;
using Lab.Project.Domain.Entities;
using Lab.Project.Domain.Repositories;
using Lab.Proyect.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Project.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateAsync(OrderDto dto)
        {
           
            foreach (var item in dto.Items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product == null || product.Stock < item.Quantity)
                    throw new InvalidOperationException($"Stock insuficiente para el producto {item.ProductName}");

                product.Stock -= item.Quantity;
                await _productRepository.UpdateAsync(product);
            }

       
            dto.TotalAmount = dto.Items.Sum(i => i.UnitPrice * i.Quantity);
            dto.Date = DateTime.UtcNow;

     
            var entity = _mapper.Map<Order>(dto);
            await _orderRepository.AddAsync(entity);

            return _mapper.Map<OrderDto>(entity);
        }

        public async Task<List<OrderDto>> ListAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
