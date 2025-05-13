using Lab.Proyect.Domain.Entities;
using Lab.Proyect.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab.Proyect.Application.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> ListAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<ProductDto> CreateAsync(ProductDto product);
        Task<ProductDto> UpdateAsync(ProductDto product);
        Task DeleteAsync(int id);
    }
}
