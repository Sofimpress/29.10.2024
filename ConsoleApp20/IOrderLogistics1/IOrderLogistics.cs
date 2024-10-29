using ConsoleApp20.OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.IOrderLogistics
{
    public interface IOrderLogistics
    {
        void ProcessOrder(Order order);
        void UpdateProductAvailability(int productId, int quantity);
    }
}
