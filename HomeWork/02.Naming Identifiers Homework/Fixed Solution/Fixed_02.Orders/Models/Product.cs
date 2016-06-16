﻿namespace Orders.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }
    }
}