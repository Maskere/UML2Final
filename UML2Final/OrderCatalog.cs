using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class OrderCatalog
    {
        List<Order> Orders;
        CustomerCatalog Customers;
        PizzaCatalog Pizzas;
        Customer _customer;
        Pizza _pizza;
        public OrderCatalog()
        {
            Orders = new List<Order>(new Order[10]);
            _customer = new Customer("", 0);
            _pizza = new Pizza("", 0, 0);
        }
        public int Count
        {
            get { return Orders.Count; }
        }
        public Customer Customer { get { return _customer; } }
        public Pizza Pizza { get { return _pizza; } }
        public Order GetNewOrderFromExisting(Customer customer, Pizza pizza, int noOfPizzasInOrder, int orderId)
        {
            Order order = new Order(customer, pizza, noOfPizzasInOrder, orderId);
            if (Orders.Contains(order))
            {
                return null;
            }
            return order;
        }
        public Order GetNewOrder(Customer customer, Pizza pizza, int noOfPizzasInOrder, int orderId)
        {
            Order order = new Order(customer, pizza, noOfPizzasInOrder, orderId);
            return order;
        }
        public void AddAnOrderToTheList(Order order)
        {
            if (Orders.Contains(order)) { Console.WriteLine($"An order with id:{order.OrderID} already exist"); return; }
            Orders.Insert(order.OrderID, order);
        }
        public void DeleteAnOrder(int OrderId)
        {
            Orders.Insert(OrderId, new Order(new Customer("", 0), new Pizza("", 0, 0), 0, OrderId));
            Orders.RemoveAt(OrderId + 1);
        }
        public Order SeachForOrderById(int orderId)
        {
            Order findOrder = Orders[orderId];
            return findOrder;
        }
        public void UpdateOrder(int orderId)
        {
            Order updateOrder = new Order(Customers.GetNewCustomer("", 0), Pizzas.GetNewPizza("", 0, 0), 0, orderId);
            if (Orders.Contains(updateOrder))
            {
                updateOrder = null;
            }
            else
            {
                Orders.RemoveAt(updateOrder.OrderID);
                Orders.Insert(updateOrder.OrderID, updateOrder);
            }
        }
        //public Customer SearchCustomerByName(string customerName)
        //{
        //    foreach (Customer customer in Customers)
        //    {
        //        Console.WriteLine($"\nFind: customer by name \"{customerName}\":{0}", Customers.Find(x => x.CustomerName.Contains(customerName)));
        //    }
        //    return
        //}
        public void Clear()
        {
            Orders.Clear();
            Orders = new List<Order>(new Order[10]);
        }
        public void RemoveAt(int removeAt)
        {
            Orders.RemoveAt(removeAt);
        }
        public void PrintOrderList()
        {
            foreach (Order order in Orders)
            {
                if (order != null)
                {
                    order.CalculateTotalPrice();
                    Console.WriteLine($"| {order} | Total price: {order.TotalPrice} |");
                }
                else
                {
                    Console.WriteLine("   ...");
                }
            }
        }
    }
}