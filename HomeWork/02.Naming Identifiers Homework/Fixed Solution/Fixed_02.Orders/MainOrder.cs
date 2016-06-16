namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class MainOrder
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var mapper = new DataMapper();
            var categories = mapper.GetAllCategories();
            var products = mapper.GetAllProducts();
            var orders = mapper.GetAllOrders();
            string lineSeperator = new string('-', 10);

            // Names of the 5 most expensive products
            var expensiveProducts = products
                .OrderByDescending(prod => prod.UnitPrice) //order by price
                .Take(5) //take 5 of them
                .Select(prod => prod.Name); //fetch the names

            Console.WriteLine(string.Join(Environment.NewLine, expensiveProducts));

            Console.WriteLine(lineSeperator);

            // Number of products in each category
            var listProducts = products
                .GroupBy(prod => prod.CategoryId) //group by categoryID
                .Select(selectBy => //get the Category Name and Count of products in each category (by category ID)
                new
                {
                    Category = categories.First(cat => cat.CategoryId == selectBy.Key).Name,
                    Count = selectBy.Count()
                })
                .ToList();

            foreach (var item in listProducts)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(lineSeperator);

            // The 5 top products (by order quantity)
            var topProducts = orders
                .GroupBy(o => o.ProductId) //group by Product ID
                .Select(selectBy => new //get the Product Name and Quantity
                {
                    Product = products.First(prod => prod.ProductId == selectBy.Key).Name,
                    Quantities = selectBy.Sum(total => total.Quantity)
                })
                .OrderByDescending(q => q.Quantities) //order by Quantity
                .Take(5); //take the top 5 of the ordered items

            foreach (var item in topProducts)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(lineSeperator);

            // The most profitable category
            var profitCategory = orders
                .GroupBy(product => product.ProductId) //group by ProductID
                .Select(selectProducts => new { //get the Product Category and Price per unit and quantity
                    catId = products.First(p => p.ProductId == selectProducts.Key).CategoryId,
                    price = products.First(p => p.ProductId == selectProducts.Key).UnitPrice,
                    quantity = selectProducts.Sum(p => p.Quantity) 
                })
                .GroupBy(category => category.catId) //group by CategoryID
                .Select(selectCategory => new { 
                    category_name = categories.First(c => c.CategoryId == selectCategory.Key).Name, //get the category name
                    total_quantity = selectCategory.Sum(top => top.quantity * top.price) //get the sum of each item*quantity in each category
                })
                .OrderByDescending(product => product.total_quantity) //order by the sum in each category
                .First(); //take the top element from the ordered categories list

            Console.WriteLine("{0}: {1}", profitCategory.category_name, profitCategory.total_quantity);
        }
    }
}
