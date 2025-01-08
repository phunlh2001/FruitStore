﻿namespace FruitStore.Core.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
