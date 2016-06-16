using Orders.Models;

namespace Orders
{
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class DataMapper
    {
        private string categoriesFileName;
        private string productsFileName;
        private string ordersFileName;

        public DataMapper(string categoryFileName = "../../Data/categories.txt", 
                          string productsFileName = "../../Data/products.txt", 
                          string ordersFileName = "../../Data /orders.txt")
        {
            categoriesFileName = categoryFileName;
            this.productsFileName = productsFileName;
            this.ordersFileName = ordersFileName;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var cat = readFileLines(categoriesFileName, true);
            return cat
                .Select(c => c.Split(','))
                .Select(c => new Category
                {
                    CategoryId = int.Parse(c[0]),
                    Name = c[1],
                    Description = c[2]
                });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var prod = readFileLines(productsFileName, true);
            return prod
                .Select(p => p.Split(','))
                .Select(p => new Product
                {
                    ProductId = int.Parse(p[0]),
                    Name = p[1],
                    CategoryId = int.Parse(p[2]),
                    UnitPrice = decimal.Parse(p[3]),
                    UnitsInStock = int.Parse(p[4]),
                });
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var ord = readFileLines(ordersFileName, true);
            return ord
                .Select(p => p.Split(','))
                .Select(p => new Order
                {
                    OrderId = int.Parse(p[0]),
                    ProductId = int.Parse(p[1]),
                    Quantity = int.Parse(p[2]),
                    Discount = decimal.Parse(p[3]),
                });
        }

        private List<string> readFileLines(string filename, bool hasHeader)
        {
            var result = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                string currentLine;
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                while ((currentLine = reader.ReadLine()) != null)
                {
                    result.Add(currentLine);
                }
            }
            return result;
        }
    }
}
