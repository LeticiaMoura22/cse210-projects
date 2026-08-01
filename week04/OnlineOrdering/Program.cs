using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Order 1: domestic customer (USA), 3 products
            Address address1 = new Address("123 Maple Street", "Columbus", "OH", "USA");
            Customer customer1 = new Customer("Jordan Reyes", address1);
            Order order1 = new Order(customer1);

            order1.AddProduct(new Product("Wireless Mouse", "P-1001", 24.99, 1));
            order1.AddProduct(new Product("USB-C Cable", "P-1002", 9.99, 3));
            order1.AddProduct(new Product("Laptop Stand", "P-1003", 39.99, 1));

            // Order 2: international customer (not USA), 2 products
            Address address2 = new Address("48 Baker Lane", "Manchester", "England", "United Kingdom");
            Customer customer2 = new Customer("Alice Whitfield", address2);
            Order order2 = new Order(customer2);

            order2.AddProduct(new Product("Mechanical Keyboard", "P-2001", 89.99, 1));
            order2.AddProduct(new Product("Desk Lamp", "P-2002", 19.99, 2));

            Order[] orders = { order1, order2 };

            foreach (Order order in orders)
            {
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine("Total Price: " + order.GetTotalPrice().ToString("C"));
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine();
            }
        }
    }
}
