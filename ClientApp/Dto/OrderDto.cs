namespace ClientApp.Dto
{
    public class OrderDto
    {
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
