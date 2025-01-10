﻿namespace FruitStore.Web.Models
{
    public class ProductResponse
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
    }
}