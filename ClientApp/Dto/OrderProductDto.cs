﻿namespace ClientApp.Dto
{
    public class OrderProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }     
        public decimal UnitPrice { get; set; }      
        public int Quantity { get; set; }
    }
}
