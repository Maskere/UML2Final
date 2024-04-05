using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Invoice
    {
        private Order _order;
        public Invoice(Order Order)
        {
            _order = Order;
        }
        public Order Order
        {
            get { return _order; }
        }
        public override string ToString()
        {
            return $"The invoice for order {Order.OrderID}: {Order.TotalPrice} kr.";
        }
    }
}