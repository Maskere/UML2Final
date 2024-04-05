using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Order
    {
        #region Instance Field
        private Pizza _pizzaName;
        private Customer _customerName;
        private int _numberOfPizzasInOrder;
        private int _orderID;
        private double _totalPrice;
        #endregion

        #region Constructor
        public Order(Customer CustomerName, Pizza PizzaName, int NumberOfPizzasInOrder, int OrderId)
        {
            _orderID = OrderId;
            _customerName = CustomerName;
            _pizzaName = PizzaName;
            _numberOfPizzasInOrder = NumberOfPizzasInOrder;
            _totalPrice = TotalPrice;
        }
        #endregion

        #region Properties
        public Pizza PizzaName
        {
            get { return _pizzaName; }
        }
        public Customer CustomerName
        {
            get { return _customerName; }
        }
        public int NumberOfPizzasInOrder
        {
            get { return _numberOfPizzasInOrder; }
            set { _numberOfPizzasInOrder = value; }
        }
        public double TotalPrice
        {
            get { return _totalPrice; }
        }
        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
        #endregion

        #region Methods
        public void CalculateTotalPrice()
        {
            _totalPrice = PizzaName.Price * _numberOfPizzasInOrder + 40;
        }
        public override string ToString()
        {
            return $"Order {OrderID}: {NumberOfPizzasInOrder} x {PizzaName} for {CustomerName}";
        }
        #endregion
    }
}