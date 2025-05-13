using ClientApp.Dto;

namespace ClientApp.Services
{
    public class OrderState
    {
        public List<OrderProductDto> SelectedProducts { get; private set; } = new List<OrderProductDto>();


        public void SetOrder(List<OrderProductDto> products)
        {
            SelectedProducts = products;
        }

        public void ClearOrder()
        {
            SelectedProducts.Clear();
        }
    }
}