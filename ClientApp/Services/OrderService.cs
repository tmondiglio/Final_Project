using ClientApp.Dto;

namespace ClientApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:7082");  
        }

        public async Task<List<OrderDto>> GetOrdersAsync()
        {
            var result = await _client.GetFromJsonAsync<List<OrderDto>>("Order");
            return result ?? new List<OrderDto>();
        }

        public async Task CreateOrderAsync(List<OrderProductDto> products)
        {
            if (products == null || products.Count == 0)
                return;

            var orderRequest = new
            {
                CustomerId = 0,
                CustomerName = "Tomas",
                Items = products
            };

            await _client.PostAsJsonAsync("Order", orderRequest);
        }
    }
}
