using Lab.Project.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Project.Application.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> ListAsync();
        Task<CustomerDto> GetByIdAsync(int id);
        Task<CustomerDto> CreateAsync(CustomerDto dto);
        Task<CustomerDto> UpdateAsync(CustomerDto dto);
        Task DeleteAsync(int id);
    }
}
