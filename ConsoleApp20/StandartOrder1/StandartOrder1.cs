using ConsoleApp20.OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.StandartOrder1
{
    public class StandartOrder : Order
    {
        public StandartOrder(int id, string customerName) : base(id, customerName)
        {
        }
    }
}