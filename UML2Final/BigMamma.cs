using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class BigMamma
    {
        #region Instance Field
        private PizzaCatalog _pizzaCatalog;
        private CustomerCatalog _customerCatalog;
        private OrderCatalog _orderCatalog;
        #endregion

        #region Constructor
        public BigMamma()
        {
            _pizzaCatalog = new PizzaCatalog();
            _customerCatalog = new CustomerCatalog();
            _orderCatalog = new OrderCatalog();
        }
        #endregion

        #region Properties
        public PizzaCatalog PizzaCatalog
        {
            get { return _pizzaCatalog; }
        }
        public CustomerCatalog CustomerCatalog 
        { 
            get { return _customerCatalog; } 
        }
        public OrderCatalog OrderCatalog 
        { 
            get { return _orderCatalog; } 
        }
        #endregion

        #region Methods
        public void Test()
        {
            Customer customer1 = new Customer("Miki", 1);
            CustomerCatalog.CreateACustomer(customer1);
            Customer customer2 = new Customer("Lucas", 2);
            CustomerCatalog.CreateACustomer(customer2);
            Customer customer3 = new Customer("Nikolaj", 3);
            CustomerCatalog.CreateACustomer(customer3);

            Pizza pizza1 = new Pizza("Margherita", 69, 1);
            PizzaCatalog.CreateAPizza(pizza1);
            Pizza pizza2 = new Pizza("Calzone", 80, 4);
            PizzaCatalog.CreateAPizza(pizza2);
            Pizza pizza3 = new Pizza("Italiana", 75, 8);
            PizzaCatalog.CreateAPizza(pizza3);

            Order order1 = new Order(customer1, pizza1, 4, 1);
            OrderCatalog.AddAnOrderToTheList(order1);
            Order order2 = new Order(customer2, pizza2, 1, 2);
            OrderCatalog.AddAnOrderToTheList(order2);
            Order order3 = new Order(customer3, pizza3, 2, 3);
            OrderCatalog.AddAnOrderToTheList(order3);

            order1.CalculateTotalPrice();
            Invoice invoice1 = new Invoice(order1);
            Console.Write(invoice1);
            new UserDialog(PizzaCatalog, CustomerCatalog, OrderCatalog).MainMenu();
        }
        public override string ToString()
        {
            return $"";
        }
        #endregion
    }
}