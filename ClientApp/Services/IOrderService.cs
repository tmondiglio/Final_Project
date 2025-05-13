using ClientApp.Dto;

namespace ClientApp.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(List<OrderProductDto> products);
        Task<List<OrderDto>> GetOrdersAsync();
    }
}