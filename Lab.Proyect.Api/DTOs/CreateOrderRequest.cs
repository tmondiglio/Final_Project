namespace Lab.Project.Api.DTOs
{
    public class CreateOrderRequest
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } 
        public List<CreateOrderItemRequest> Items { get; set; } 
    }

    public class CreateOrderItemRequest
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
