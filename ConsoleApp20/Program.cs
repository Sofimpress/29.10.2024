using ConsoleApp20.NotificationSystem1;
using ConsoleApp20.OrderQueue;
using ConsoleApp20.Product1;
using ConsoleApp20.StandartOrder1;

namespace ConsoleApp20
{

namespace OrderSystem
    {
        public class Order
        {
            private int _id;
            private string _customerName;
            private List<Product> _products;
            private decimal _totalCost;

            public Order(int id, string customerName)
            {
                _id = id;
                _customerName = customerName;
                _products = new List<Product>();
                _totalCost = 0;
            }

            public int Id
            {
                get { return _id; }
            }

            public string CustomerName
            {
                get { return _customerName; }
            }

            public List<Product> Products
            {
                get { return _products; }
            }

            public decimal TotalCost
            {
                get { return _totalCost; }
            }

            public void AddProduct(Product product)
            {
                _products.Add(product);
                _totalCost += product.Price;
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {

            }
        }
    }
}