using ConsoleApp20.Product1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.ProductCatalog
{
    public class ProductCatalog
    {
        private Dictionary<int, Product1.Product> _products;

        public ProductCatalog()
        {
            _products = new Dictionary<int, Product1.Product>();
        }

        public void AddProduct(Product1.Product product)
        {
            _products.Add(product.Id, product);
        }

        public void RemoveProduct(int productId)
        {
            _products.Remove(productId);
        }

        public Product1.Product GetProduct(int productId)
        {
            if (_products.ContainsKey(productId))
            {
                return _products[productId];
            }
            return null;
        }
    }
}