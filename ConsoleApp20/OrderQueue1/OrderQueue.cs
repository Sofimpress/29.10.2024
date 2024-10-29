using ConsoleApp20.OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.OrderQueue
{
    public class OrderQueue : IOrderLogistics
    {
        private Queue<Order> _orders;
        private Stack<Order> _completedOrders;
        private Dictionary<int, string> _orderStatuses;

        public OrderQueue()
        {
            _orders = new Queue<Order>();
            _completedOrders = new Stack<Order>();
            _orderStatuses = new Dictionary<int, string>();
        }

        public void AddOrder(Order order)
        {
            _orders.Enqueue(order);
            _orderStatuses.Add(order.Id, "New");
        }

        public Order GetNextOrder()
        {
            if (_orders.Count == 0)
            {
                return null;
            }
            var order = _orders.Dequeue();
            _orderStatuses[order.Id] = "Processing";
            return order;
        }

        public void CompleteOrder(Order order)
        {
            _orderStatuses[order.Id] = "Completed";
            _completedOrders.Push(order);
        }

        public void ChangeOrderStatus(int orderId, string status)
        {
            if (_orderStatuses.ContainsKey(orderId))
            {
                _orderStatuses[orderId] = status;
            }
        }

        public List<Order> GetOrdersByStatus(string status)
        {
            List<Order> orders = new List<Order>();
            foreach (var order in _orderStatuses)
            {
                if (order.Value == status)
                {
                    if (_orders.Contains(new Order(order.Key, "")))
                    {
                        orders.Add(_orders.Dequeue());
                        _orders.Enqueue(new Order(order.Key, ""));
                    }
                    else if (_completedOrders.Contains(new Order(order.Key, "")))
                    {
                        orders.Add(_completedOrders.Pop());
                        _completedOrders.Push(new Order(order.Key, ""));
                    }
                }
            }
            return orders;
        }

        public List<Order> GetLastCompletedOrders(int count)
        {
            List<Order> lastCompletedOrders = new List<Order>();
            for (int i = 0; i < count && _completedOrders.Count > 0; i++)
            {
                lastCompletedOrders.Add(_completedOrders.Pop());
                _completedOrders.Push(lastCompletedOrders[i]);
            }
            return lastCompletedOrders;
        }

        public void ReturnOrder(Order order)
        {
            if (_completedOrders.Contains(order))
            {
                _completedOrders.Pop();
                _orderStatuses[order.Id] = "Returned";
            }
        }

        public void SortOrdersByTotalCost()
        {
            List<Order> sortedOrders = new List<Order>();
            while (_orders.Count > 0)
            {
                sortedOrders.Add(_orders.Dequeue());
            }
            sortedOrders.Sort((o1, o2) => o1.TotalCost.CompareTo(o2.TotalCost));
            foreach (var order in sortedOrders)
            {
                _orders.Enqueue(order);
            }
        }

        public void ProcessOrder(Order order)
        {
            _orderStatuses[order.Id] = "Processing";
        }

        public void UpdateProductAvailability(int productId, int quantity)
        {
        }
    }
}
