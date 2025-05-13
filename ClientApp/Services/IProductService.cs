using ClientApp.Dto;

namespace ClientApp.Services
{
    public interface IProductService
    {
        Task<List<ProductsDto>> GetProductsAsync();
    }
}
