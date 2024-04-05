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
        private Order _order;
        private Customer _customer;
        private Pizza _pizza;
        private int _numberOfPizzasInOrder;
        private Invoice _invoice;
        private PizzaCatalog _pizzaCatalog;
        private CustomerCatalog _customerCatalog;
        private OrderCatalog _orderCatalog;
        public int OrderId { get; set; }
        #endregion

        #region Constructor
        public BigMamma()
        {
            _order = new Order(Customer, Pizza, NumberOfPizzasInOrder, OrderId);
            _customer = Customer;
            _numberOfPizzasInOrder = NumberOfPizzasInOrder;
            _invoice = Invoice;
            _pizzaCatalog = new PizzaCatalog();
            _customerCatalog = new CustomerCatalog();
            _orderCatalog = new OrderCatalog();
        }
        #endregion

        #region Properties
        public Order Order
        {
            get { return _order; }
        }
        public Customer Customer
        {
            get { return _customer; }
        }
        public Pizza Pizza
        {
            get { return _pizza; }
        }
        public int NumberOfPizzasInOrder
        {
            get { return _numberOfPizzasInOrder; }
        }
        public Invoice Invoice
        {
            get { return _invoice; }
        }
        public PizzaCatalog PizzaCatalog
        {
            get { return _pizzaCatalog; }
        }
        public CustomerCatalog CustomerCatalog { get { return _customerCatalog; } }
        public OrderCatalog OrderCatalog { get { return _orderCatalog; } }
        #endregion

        #region Methods
        //public void Start()
        //{
        //    Customer customer1 = new Customer("Miki");
        //    Pizza pizza1 = new Pizza("Vichinga", 80,12);
        //    MenuCatalog.CreateAPizza(pizza1);
        //    Order order1 = new Order(customer1, pizza1, 1);
        //    order1.CalculateTotalPrice();
        //    Invoice invoice1 = new Invoice(order1);
        //    Console.WriteLine(order1);
        //    Console.WriteLine(invoice1);
        //    Console.WriteLine();

        //    Customer customer2 = new Customer("Lucas");
        //    Pizza pizza2 = new Pizza("Calzone", 80,4);
        //    MenuCatalog.CreateAPizza(pizza2);
        //    Order order2 = new Order(customer2, pizza2, 3);
        //    order2.CalculateTotalPrice();
        //    Invoice invoice2 = new Invoice(order2);
        //    Console.WriteLine(order2);
        //    Console.WriteLine(invoice2);
        //    Console.WriteLine();

        //    Customer customer3 = new Customer("Nikolaj");
        //    Pizza pizza3 = new Pizza("Romana", 78,17);
        //    MenuCatalog.CreateAPizza(pizza3);
        //    Order order3 = new Order(customer3, pizza3, 1);
        //    order3.CalculateTotalPrice();
        //    Invoice invoice3 = new Invoice(order3);
        //    Console.WriteLine(order3);
        //    Console.WriteLine(invoice3);
        //    Console.WriteLine();
        //}
        public void Test()
        {
            Pizza pizza1 = new Pizza("Margherita", 69, 1);
            PizzaCatalog.CreateAPizza(pizza1);
            Pizza pizza2 = new Pizza("Calzone", 80, 4);
            PizzaCatalog.CreateAPizza(pizza2);
            Pizza pizza3 = new Pizza("Italiana", 75, 8);
            PizzaCatalog.CreateAPizza(pizza3);

            Customer customer1 = new Customer("Miki", 1);
            CustomerCatalog.CreateACustomer(customer1);
            Customer customer2 = new Customer("Lucas", 2);
            CustomerCatalog.CreateACustomer(customer2);
            Customer customer3 = new Customer("Nikolaj", 3);
            CustomerCatalog.CreateACustomer(customer3);

            Order order1 = new Order(customer1, pizza1, 2, 1);
            OrderCatalog.AddAnOrderToTheList(order1);

            new UserDialog(PizzaCatalog, CustomerCatalog, OrderCatalog).MainMenu();
        }
        public void Run()
        {

        }
        public override string ToString()
        {
            return $"";
        }
        //public void Run() 
        //{
        //    new UserDialog(_menuCatalog).Run();
        //}
        #endregion
    }
}