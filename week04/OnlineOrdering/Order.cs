using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    public class Order
    {
        private const double DomesticShippingCost = 5.0;
        private const double InternationalShippingCost = 35.0;

        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public Customer GetCustomer()
        {
            return _customer;
        }

        public void SetCustomer(Customer customer)
        {
            _customer = customer;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public double GetTotalPrice()
        {
            double productTotal = 0;

            foreach (Product product in _products)
            {
                productTotal += product.GetTotalCost();
            }

            double shippingCost = _customer.IsInUSA() ? DomesticShippingCost : InternationalShippingCost;

            return productTotal + shippingCost;
        }

        public string GetPackingLabel()
        {
            StringBuilder label = new StringBuilder();
            label.AppendLine("Packing Label");

            foreach (Product product in _products)
            {
                label.AppendLine(product.GetName() + " (ID: " + product.GetProductId() + ")");
            }

            return label.ToString();
        }

        public string GetShippingLabel()
        {
            StringBuilder label = new StringBuilder();
            label.AppendLine("Shipping Label");
            label.AppendLine(_customer.GetName());
            label.AppendLine(_customer.GetAddress().ToString());

            return label.ToString();
        }
    }
}
