﻿namespace DeskMarket.Models
{
    public class CartModelView
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
