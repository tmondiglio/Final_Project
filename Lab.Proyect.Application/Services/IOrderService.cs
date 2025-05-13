using Lab.Project.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Project.Application.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateAsync(OrderDto dto);
        Task<List<OrderDto>> ListAsync();
    }
}
