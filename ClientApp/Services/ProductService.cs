using ClientApp.Dto;

namespace ClientApp.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<ProductsDto>> GetProductsAsync()
        {
            _client.BaseAddress = new Uri("https://localhost:7080");

            var response = await _client.GetFromJsonAsync<List<ProductsDto>>("Product");
            return response ?? new List<ProductsDto>();
        }
    }
}
