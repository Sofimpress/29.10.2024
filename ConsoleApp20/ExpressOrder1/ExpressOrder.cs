using ConsoleApp20.OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.ExpressOrder1
{
    public class ExpressOrder : Order
    {
        public ExpressOrder(int id, string customerName) : base(id, customerName)
        {
        }
    }
}
