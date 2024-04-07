using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class UserDialog
    {
        PizzaCatalog PizzaCatalog;
        CustomerCatalog CustomerCatalog;
        OrderCatalog OrderCatalog;
        string InvalidPizzaID = "Invalid pizza ID";
        public UserDialog(PizzaCatalog menuCatalog, CustomerCatalog customerCatalog, OrderCatalog orderCatalog)
        {
            PizzaCatalog = menuCatalog;
            CustomerCatalog = customerCatalog;
            OrderCatalog = orderCatalog;
        }
        public int MainMenuChoiceMethod(List<string> menuItems)
        {
            foreach (string mainMenuChoice in menuItems)
            {
                Console.WriteLine(mainMenuChoice);
            }

            Console.WriteLine("Enter option#: ");
            string mainMenuInput = Console.ReadKey().KeyChar.ToString();

            try
            {
                int mainMenuResult = Int32.Parse(mainMenuInput);
                return mainMenuResult;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{mainMenuInput}'");
            }
            return -1;
        }
        public int PizzaSettingChoiceMethod(List<string> pizzaSettingItems)
        {
            Console.WriteLine();
            foreach (string pizzaSettingChoice in pizzaSettingItems)
            {
                Console.WriteLine(pizzaSettingChoice);
            }
            Console.WriteLine("Enter option#: ");
            string pizzaSettingInput = Console.ReadKey().KeyChar.ToString();
            try
            {
                int mainMenuResult = Int32.Parse(pizzaSettingInput);
                return mainMenuResult;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{pizzaSettingInput}'");
            }
            return -1;
        }
        public int CustomerSettingChoiceMethod(List<string> CustomerSettingItems)
        {
            Console.WriteLine();
            foreach (string CustomerSettingChoice in CustomerSettingItems)
            {
                Console.WriteLine(CustomerSettingChoice);
            }
            Console.WriteLine("Enter option#: ");
            string CustomerSettingInput = Console.ReadKey().KeyChar.ToString();
            try
            {
                int CustomerSettingResult = Int32.Parse(CustomerSettingInput);
                return CustomerSettingResult;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{CustomerSettingInput}'");
            }
            return -1;
        }
        public int OrderSettingChoiceMethod(List<string> OrderSettingItems)
        {
            Console.WriteLine();
            foreach (string OrderSettingChoice in OrderSettingItems)
            {
                Console.WriteLine(OrderSettingChoice);
            }
            Console.WriteLine("Enter option#: ");
            string OrderSettingInput = Console.ReadKey().KeyChar.ToString();
            try
            {
                int OrderSettingResult = Int32.Parse(OrderSettingInput);
                return OrderSettingResult;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{OrderSettingInput}'");
            }
            return -1;
        }
        public void MainMenu()
        {
            bool MainMenuProceed = true;
            List<string> mainMenuList = new List<string>()
            {
                "0. Quit",
                "1. Pizza settings",
                "2. Customer settings",
                "3. Order settings"
            };
            while (MainMenuProceed)
            {
                Console.WriteLine("Main menu");
                int MainMenuChoice = MainMenuChoiceMethod(mainMenuList);
                Console.Clear();
                switch (MainMenuChoice)
                {
                    case 0:
                        MainMenuProceed = false;
                        Console.WriteLine("Quitting...");
                        break;
                    case 1:
                        PizzaSetting();
                        break;
                    case 2:
                        CustomerSetting();
                        break;
                    case 3:
                        OrderSetting();
                        break;
                }
            }
        }
        public void PizzaSetting()
        {
            bool PizzaSettingProceed = true;
            List<string> pizzaSettingList = new List<string>()
            {
                "0. Back to the main menu",
                "1. Create a Pizza",
                "2. Delete a pizza",
                "3. Update a pizza",
                "4. Search for a pizza",
                "5. Clear the list of pizzas",
                "6. Print the list of pizzas",
            };
            while (PizzaSettingProceed)
            {
                Console.WriteLine("Pizza settings");
                int PizzaSettingChoice = PizzaSettingChoiceMethod(pizzaSettingList);
                Console.Clear();
                switch (PizzaSettingChoice)
                {
                    case 0:
                        PizzaSettingProceed = false;
                        break;
                    case 1:
                        Console.WriteLine("Enter a name: ");
                        string pizzaNameCreateString = Console.ReadLine();
                        if (pizzaNameCreateString.Any(char.IsDigit))
                        {
                            Console.WriteLine("Invalid name");
                        }
                        else
                        {
                            Console.WriteLine("Enter a price: ");
                            string pizzaPriceString = "";
                            int pizzaPrice = 0;
                            try
                            {
                                do
                                {
                                    pizzaPriceString = Console.ReadLine();
                                    pizzaPrice = int.Parse(pizzaPriceString);
                                    if (pizzaPrice < 70)
                                    {
                                        Console.WriteLine("Price too low. Minimum 70kr.");
                                    }
                                }
                                while (pizzaPrice < 70);
                            }
                            catch (FormatException e) { Console.WriteLine($"Unable to parse '{pizzaPrice}' - Message: {e.Message}"); }
                            if (pizzaPrice > 0)
                            {
                                Console.WriteLine("Enter an ID: ");
                                string pizzaIdString = "";
                                int pizzaId = 0;
                                try
                                {
                                    pizzaIdString = Console.ReadLine();
                                    pizzaId = int.Parse(pizzaIdString);
                                }
                                catch (FormatException e) { Console.WriteLine($"Unable to parse '{pizzaId}' - Message: {e.Message}"); }
                                if (pizzaId <= 0) { Console.WriteLine("Invalid pizza ID"); PizzaSetting(); }
                                Pizza pizzaCreate = PizzaCatalog.GetNewPizza(pizzaNameCreateString, pizzaPrice, pizzaId);
                                if (pizzaCreate == null)
                                {
                                    Console.WriteLine("A pizza with that id already exists\nDo you with to overwrite?\ny/n");
                                    string overWriteAnswer = Console.ReadLine();
                                    if (overWriteAnswer == "y") { PizzaCatalog.UpdatePizza(new Pizza(pizzaNameCreateString, pizzaPrice, pizzaId)); Console.WriteLine($"Pizza was overwritten"); }
                                    else { Console.WriteLine("Pizza was NOT overwritten"); }
                                }
                                else
                                {
                                    PizzaCatalog.RemoveAt(pizzaCreate.PizzaId);
                                    PizzaCatalog.CreateAPizza(pizzaCreate);
                                    Console.WriteLine($"You created {pizzaCreate.Name} with id: {pizzaCreate.PizzaId} and price: {pizzaCreate.Price}");
                                }
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Which pizza would you like to delete from the list?");
                        PizzaCatalog.PrintMenu();
                        string pizzaDeleteString = "";
                        int pizzaDeleteResult = 0;
                        try
                        {
                            pizzaDeleteString = Console.ReadLine();
                            pizzaDeleteResult = int.Parse(pizzaDeleteString);
                        }
                        catch (FormatException e) { Console.WriteLine($"Unable to parse '{pizzaDeleteString}' - Message: {e.Message}"); }
                        if (pizzaDeleteResult <= 0) { Console.WriteLine(InvalidPizzaID); return; }
                        Console.WriteLine($"Are you sure you want to delete pizza {pizzaDeleteResult} from the list?\ny/n");
                        string deleteAnswer = Console.ReadLine();
                        if (deleteAnswer == "y")
                        {
                            PizzaCatalog.DeleteAPizza(pizzaDeleteResult);
                            Console.WriteLine($"You deleted pizza {pizzaDeleteResult} from the list");
                        }
                        else
                        {
                            Console.WriteLine($"You did not delete {pizzaDeleteResult} from the list");
                        }
                        break;
                    case 3:
                        PizzaCatalog.PrintMenu();
                        Console.WriteLine("Which pizza would you like to update?\nEnter number: ");
                        string choosePizzaString = "";
                        int choosePizza = 0;
                        try { choosePizzaString = Console.ReadLine(); choosePizza = int.Parse(choosePizzaString); }
                        catch (FormatException e) { Console.WriteLine($"Unable to parse '{choosePizzaString}' - Message: {e.Message}"); }
                        if (choosePizza <= 0) { Console.WriteLine(InvalidPizzaID); return; }
                        if (PizzaCatalog.SearchForPizzaById(choosePizza) != null)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the new pizza name: ");
                            string pizzaName = Console.ReadLine();
                            Pizza updatePizza = new Pizza(pizzaName, PizzaCatalog.SearchForPizzaById(choosePizza).Price, choosePizza);
                            PizzaCatalog.UpdatePizza(updatePizza);
                            Console.WriteLine($"Pizza {choosePizza} is now updated to {pizzaName}");
                            Console.WriteLine("Would you like to update the price too?\ny/n");
                            string updatePizzaAnswer = Console.ReadLine();
                            if (updatePizzaAnswer == "y")
                            {
                                Console.WriteLine("Enter a new price");
                                string newPriceString = "";
                                int newPrice = 0;
                                try
                                {
                                    do
                                    {
                                        newPriceString = Console.ReadLine();
                                        newPrice = int.Parse(newPriceString);
                                        if (newPrice < 70)
                                        {
                                            Console.WriteLine("Price too low. Minimum 70kr.");
                                        }
                                        else
                                        {
                                            PizzaCatalog.SearchForPizzaById(choosePizza).Price = newPrice;
                                            Console.WriteLine($"Pizza {choosePizza} is now updated to {updatePizza}");
                                        }
                                    }
                                    while (newPrice < 70);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine($"Unable to parse '{newPriceString}'\nPrice is unchanged.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Pizza {choosePizza} updated to {pizzaName} with unchanged price");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pizza does not exist");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Find a pizza by its pizzaID: ");
                        string findPizzaByIdString = "";
                        int findPizzaById = 0;
                        try { findPizzaByIdString = Console.ReadLine(); findPizzaById = int.Parse(findPizzaByIdString); }
                        catch (FormatException e) { Console.WriteLine($"Unable to parse '{findPizzaByIdString}'\n{InvalidPizzaID}"); }
                        if (findPizzaById > 0)
                        {
                            if (PizzaCatalog.SearchForPizzaById(findPizzaById) == null) { Console.WriteLine(InvalidPizzaID); }
                            Console.WriteLine(PizzaCatalog.SearchForPizzaById(findPizzaById));
                        }
                        break;
                    case 5:
                        Console.WriteLine("Are you sure you want to clear the list of pizzas?\ny/n");
                        string answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            PizzaCatalog.Clear();
                            Console.WriteLine("You cleared the list of pizzas\n");
                        }
                        else
                        {
                            Console.WriteLine("You did not clear the list of pizzas");
                        }
                        break;
                    case 6:
                        if (PizzaCatalog.Count > 1)
                        {
                            PizzaCatalog.PrintMenu();
                        }
                        else
                        {
                            Console.WriteLine("The pizza list is empty");
                        }
                        break;
                }
            }

        }
        public void CustomerSetting()
        {
            bool CustomerSettingProceed = true;
            List<string> CustomerSettingList = new List<string>()
            {
                "0. Back to the main menu",
                "1. Create a Customer",
                "2. Delete a Customer",
                "3. Update a Customer",
                "4. Search for a Customer",
                "5. Clear the list of Customers",
                "6. Print the list of Customers",
            };
            while (CustomerSettingProceed)
            {
                Console.WriteLine("Customer settings");
                int CustomerSettingChoice = CustomerSettingChoiceMethod(CustomerSettingList);
                Console.Clear();
                switch (CustomerSettingChoice)
                {
                    case 0:
                        CustomerSettingProceed = false;
                        break;
                    case 1:
                        Console.WriteLine("Enter a name: ");
                        string inputCustomerNameString = Console.ReadLine();
                        Console.WriteLine("Enter an id number: ");
                        string inputCustomerIdString = Console.ReadLine();
                        int inputCustomerId = int.Parse(inputCustomerIdString);
                        Customer customerCreate = CustomerCatalog.GetNewCustomer(inputCustomerNameString, inputCustomerId);
                        if (customerCreate == null)
                        {
                            Console.WriteLine($"Customer with that id already exists");
                        }
                        else
                        {
                            CustomerCatalog.RemoveAt(customerCreate.CustomerId);
                            CustomerCatalog.CreateACustomer(customerCreate);
                            Console.WriteLine($"You created {customerCreate.CustomerName} with id: {customerCreate.CustomerId}");
                        }
                        break;
                    case 2:
                        CustomerCatalog.PrintCustomerList();
                        Console.WriteLine("Which customer would you like to delete from the list?\nEnter a number: ");
                        string customerDelete = Console.ReadLine();
                        int deleteResult = int.Parse(customerDelete);
                        Console.WriteLine($"Are you sure you want to delete customer {deleteResult} from the list?\ny/n");
                        string deleteAnswer = Console.ReadLine();
                        if (deleteAnswer == "y")
                        {
                            CustomerCatalog.DeleteACustomer(deleteResult);
                            Console.WriteLine($"You deleted customer {deleteResult} from the list");
                        }
                        else
                        {
                            Console.WriteLine($"You did not delete customer {deleteResult} from the list");
                        }
                        break;
                    case 3:
                        CustomerCatalog.PrintCustomerList();
                        Console.WriteLine("Which customer would you like to update?\nEnter number: ");
                        string chooseCustomerString = Console.ReadLine();
                        int chooseCustomer = int.Parse(chooseCustomerString);
                        if (CustomerCatalog.SeachForCustomerById(chooseCustomer) != null)
                        {
                            Console.WriteLine("Enter the new customer name: ");
                            string customerName = Console.ReadLine();
                            Customer updateCustomer = new Customer(customerName, chooseCustomer);
                            CustomerCatalog.UpdateCustomer(updateCustomer);
                            Console.WriteLine($"You updated customer {chooseCustomer}. Customer {chooseCustomer} is now {customerName}");
                        }
                        else
                        {
                            Console.WriteLine("Customer does not exist");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Find a customer by a name: ");
                        string findCustomerByNameString = Console.ReadLine();
                        CustomerCatalog.SearchCustomerByName(findCustomerByNameString);
                        
                        break;
                    case 5:
                        Console.WriteLine("Are you sure you want to clear the list of customers?\ny/n");
                        string answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            CustomerCatalog.Clear();
                            Console.WriteLine("You cleared the list of customers\n");
                        }
                        else
                        {
                            Console.WriteLine("You did not clear the list of customers");
                        }
                        break;
                    case 6:
                        CustomerCatalog.PrintCustomerList();
                        break;
                }
            }
        }
        public void OrderSetting()
        {
            bool OrderSettingProceed = true;
            List<string> OrderSettingList = new List<string>()
            {
                "0. Back to the main menu",
                "1. Create an order from existing customer and existing pizza",
                "2. Create an order from existing customer and new pizza",
                "3. Create an order with new customer and existing pizza",
                "4. Create an order with new customer and new pizza",
                "5. Delete an order",
                "6. Update an order",
                "7. Search for an order by ID",
                "8. Clear the list of orders",
                "9. Print the list of orders",
                "10. Add extra toppings to the pizza"
            };
            while (OrderSettingProceed)
            {
                Console.WriteLine("Order settings");
                int OrderSettingChoice = OrderSettingChoiceMethod(OrderSettingList);
                Console.Clear();
                switch (OrderSettingChoice)
                {
                    case 0:
                        OrderSettingProceed = false;
                        break;
                    case 1:
                        //Create an order from existing customer and pizza
                        CustomerCatalog.PrintCustomerList();
                        Console.WriteLine("Enter customer ID: ");
                        string customerToOrderString1 = "";
                        int customerToOrderInt1 = 0;
                        try { customerToOrderString1 = Console.ReadLine(); customerToOrderInt1 = int.Parse(customerToOrderString1); } catch (FormatException e) { Console.WriteLine(e.Message); }
                        if (CustomerCatalog.SeachForCustomerById(customerToOrderInt1) != null)
                        {
                            Console.Clear();
                            PizzaCatalog.PrintMenu();
                            Console.WriteLine("Enter pizza ID: ");
                            string pizzaToOrderString = "";
                            int pizzaToOrderInt = 0;
                            try { pizzaToOrderString = Console.ReadLine(); pizzaToOrderInt = int.Parse(pizzaToOrderString); } catch (FormatException e) { Console.WriteLine(e.Message); }
                            if (PizzaCatalog.SearchForPizzaById(pizzaToOrderInt) != null)
                            {
                                Console.WriteLine("Enter number of pizzas: ");
                                string noOfPizzasString = "";
                                int noOfPizzasInt = 0;
                                try { noOfPizzasString = Console.ReadLine(); noOfPizzasInt = int.Parse(noOfPizzasString); } catch (FormatException e) { Console.WriteLine(e.Message); }
                                if (noOfPizzasInt != null && noOfPizzasInt > 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter order ID: ");
                                    string orderIdString = "";
                                    int orderId = 0;
                                    try { orderIdString = Console.ReadLine(); orderId = int.Parse(orderIdString); } catch (FormatException e) { Console.WriteLine(e.Message); }
                                    if (orderId != null)
                                    {
                                        OrderCatalog.SeachForOrderById(orderId);
                                        if (OrderCatalog.SeachForOrderById(orderId) != null)
                                        {
                                            Console.WriteLine($"You are about to overrite a existing order. \nAre you sure you want to overwrite {OrderCatalog.SeachForOrderById(orderId)}?\ny/n");
                                            string overrideString = Console.ReadLine();
                                            if (overrideString == "y")
                                            {
                                                OrderCatalog.RemoveAt(orderId);
                                                OrderCatalog.AddAnOrderToTheList(OrderCatalog.GetNewOrderFromExisting(CustomerCatalog.SeachForCustomerById(customerToOrderInt1), PizzaCatalog.SearchForPizzaById(pizzaToOrderInt), noOfPizzasInt, orderId));
                                                Console.WriteLine($"\nThe order was overwritten with {OrderCatalog.SeachForOrderById(orderId)}\n");
                                            }
                                            else 
                                            {
                                                do
                                                {
                                                    Console.WriteLine("Enter order ID: ");
                                                    string orderIdStringAgain = "";
                                                    int orderIdAgain = 0; try { orderIdStringAgain = Console.ReadLine(); orderIdAgain = int.Parse(orderIdStringAgain); } catch (FormatException e) { Console.WriteLine(e.Message); }
                                                    if (OrderCatalog.SeachForOrderById(orderIdAgain) == null)
                                                    {
                                                        OrderCatalog.RemoveAt(orderIdAgain);
                                                        OrderCatalog.AddAnOrderToTheList(OrderCatalog.GetNewOrderFromExisting(CustomerCatalog.SeachForCustomerById(customerToOrderInt1), PizzaCatalog.SearchForPizzaById(pizzaToOrderInt), noOfPizzasInt, orderIdAgain));
                                                        Console.WriteLine($"\n{OrderCatalog.SeachForOrderById(orderIdAgain)} was created\n"); return;
                                                    }
                                                } while (OrderCatalog.SeachForOrderById(orderId) != null);
                                            }
                                        }
                                        else { OrderCatalog.AddAnOrderToTheList(OrderCatalog.GetNewOrderFromExisting(CustomerCatalog.SeachForCustomerById(customerToOrderInt1), PizzaCatalog.SearchForPizzaById(pizzaToOrderInt), noOfPizzasInt, orderId)); Console.WriteLine($"You created a new order"); }
                                    }
                                    else { Console.Clear(); Console.WriteLine("Input is invalid"); }
                                }
                                else { Console.Clear(); Console.WriteLine("Input is invalid"); }
                            }
                            else { Console.Clear(); Console.WriteLine($"There are no pizza with ID {pizzaToOrderInt}"); }
                        }
                        else { Console.Clear(); Console.WriteLine($"There are no customer with ID {customerToOrderInt1}"); }
                        break;
                    case 2:
                        //"2. Create an order from existing customer and new pizza"
                        CustomerCatalog.PrintCustomerList();
                        Console.WriteLine("Enter customer ID: ");
                        string customerToOrderString2 = "";
                        int customerToOrderInt2 = 0;
                        try { customerToOrderString2 = Console.ReadLine(); customerToOrderInt2 = int.Parse(customerToOrderString2);} 
                        catch (FormatException e) { Console.WriteLine(e.Message); }
                        if (CustomerCatalog.SeachForCustomerById(customerToOrderInt2) != null)
                        {
                            //create new pizza
                            Console.Clear();
                            Console.WriteLine("Enter a pizza ID for the new pizza: ");
                            string pizzaToOrderString = "";
                            int pizzaToOrderInt = 0;
                            try { pizzaToOrderString = Console.ReadLine(); pizzaToOrderInt = int.Parse(pizzaToOrderString); } catch (FormatException e) { Console.WriteLine(e.Message); throw; }
                            if (PizzaCatalog.SearchForPizzaById(pizzaToOrderInt) == null)
                            {
                                Console.WriteLine("Enter a name for the new pizza: ");
                                string pizzaNameCreateString = Console.ReadLine();
                                if (pizzaNameCreateString.Any(char.IsDigit)){Console.WriteLine("Invalid name");}
                                else
                                {
                                    Console.WriteLine("Enter a price for the new pizza: ");
                                    string pizzaPriceString = "";
                                    int pizzaPrice = 0;
                                    try
                                    {
                                        do
                                        {
                                            pizzaPriceString = Console.ReadLine();
                                            pizzaPrice = int.Parse(pizzaPriceString);
                                            if (pizzaPrice < 70)
                                            {
                                                Console.WriteLine("Price too low. Minimum 70kr.");
                                            }
                                        }
                                        while (pizzaPrice < 70);
                                    }
                                    catch (FormatException e) { Console.WriteLine($"Unable to parse '{pizzaPrice}' - Message: {e.Message}"); }
                                    Pizza pizzaCreate = PizzaCatalog.GetNewPizza(pizzaNameCreateString, pizzaPrice, pizzaToOrderInt);
                                    PizzaCatalog.RemoveAt(pizzaCreate.PizzaId);
                                    PizzaCatalog.CreateAPizza(pizzaCreate);
                                    Console.WriteLine($"You created {pizzaCreate.Name} with id: {pizzaCreate.PizzaId} and price: {pizzaCreate.Price}");
                                }
                                Console.WriteLine("Enter number of pizzas: ");
                                string noOfPizzasString = "";
                                int noOfPizzasInt = 0;
                                try { noOfPizzasString = Console.ReadLine(); noOfPizzasInt = int.Parse(noOfPizzasString); } catch (FormatException e) { Console.WriteLine(e.Message); }
                                if (noOfPizzasInt != null && noOfPizzasInt > 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter order ID: ");
                                    string orderIdString = "";
                                    int orderId = 0;
                                    try { orderIdString = Console.ReadLine(); orderId = int.Parse(orderIdString); } catch (FormatException e) { Console.WriteLine(e.Message); }
                                    if (orderId != null)
                                    {
                                        OrderCatalog.SeachForOrderById(orderId);
                                        if (OrderCatalog.SeachForOrderById(orderId) != null)
                                        {
                                            Console.WriteLine($"You are about to overrite a existing order. \nAre you sure you want to overwrite {OrderCatalog.SeachForOrderById(orderId)}?\ny/n");
                                            string overrideString = Console.ReadLine();
                                            if (overrideString == "y")
                                            {
                                                OrderCatalog.RemoveAt(orderId);
                                                OrderCatalog.AddAnOrderToTheList(OrderCatalog.GetNewOrderFromExisting(CustomerCatalog.SeachForCustomerById(customerToOrderInt2), PizzaCatalog.SearchForPizzaById(pizzaToOrderInt), noOfPizzasInt, orderId));
                                                Console.WriteLine($"\nThe order was overwritten with {OrderCatalog.SeachForOrderById(orderId)}\n");
                                            }
                                            else 
                                            {
                                                do
                                                {
                                                    Console.WriteLine("Enter order ID: ");
                                                    string orderIdStringAgain = "";
                                                    int orderIdAgain = 0; try { orderIdStringAgain = Console.ReadLine(); orderIdAgain = int.Parse(orderIdStringAgain); } catch (FormatException e) { Console.WriteLine(e.Message); }
                                                    if (OrderCatalog.SeachForOrderById(orderIdAgain) == null)
                                                    {
                                                        OrderCatalog.RemoveAt(orderIdAgain);
                                                        OrderCatalog.AddAnOrderToTheList(OrderCatalog.GetNewOrderFromExisting(CustomerCatalog.SeachForCustomerById(customerToOrderInt2), PizzaCatalog.SearchForPizzaById(pizzaToOrderInt), noOfPizzasInt, orderIdAgain));
                                                        Console.WriteLine($"\n{OrderCatalog.SeachForOrderById(orderIdAgain)} was created\n"); return;
                                                    }
                                                } while (OrderCatalog.SeachForOrderById(orderId) != null);
                                            }
                                        }
                                        else { OrderCatalog.AddAnOrderToTheList(OrderCatalog.GetNewOrderFromExisting(CustomerCatalog.SeachForCustomerById(customerToOrderInt2), PizzaCatalog.SearchForPizzaById(pizzaToOrderInt), noOfPizzasInt, orderId)); Console.WriteLine($"You created a new order"); }
                                    }
                                    else { Console.Clear(); Console.WriteLine("Input is invalid"); }
                                }
                                else { Console.Clear(); Console.WriteLine("Input is invalid"); }
                            }
                            else { Console.Clear(); Console.WriteLine($"Pizza with ID {pizzaToOrderInt} already exists"); }
                        }
                        else { Console.Clear(); Console.WriteLine($"There are no customer with ID {customerToOrderInt2}"); }
                        break;
                    case 3:
                        //Create an order from new customer and existing pizza
                        Console.WriteLine("Enter customer ID for the new customer: ");
                        string customerToOrderString3 = "";
                        int customerToOrderInt3 = 0;
                        try { customerToOrderString3 = Console.ReadLine(); customerToOrderInt3 = int.Parse(customerToOrderString3); } catch (FormatException e) { Console.WriteLine(e.Message); }
                        if (CustomerCatalog.SeachForCustomerById(customerToOrderInt3) == null)
                        {
                            Console.WriteLine("Enter a name for the new customer: ");
                            string inputCustomerNameString = Console.ReadLine();
                            Customer customerCreate = CustomerCatalog.GetNewCustomer(inputCustomerNameString, customerToOrderInt3);
                            CustomerCatalog.RemoveAt(customerCreate.CustomerId);
                            CustomerCatalog.CreateACustomer(customerCreate);
                            Console.WriteLine($"You created customer '{customerCreate.CustomerName}' with id: {customerCreate.CustomerId}");
                            Console.ReadKey();
                            Console.Clear();
                            PizzaCatalog.PrintMenu();
                            Console.WriteLine("Enter pizza ID to add to the order: ");
                            string pizzaToOrderString = "";
                            int pizzaToOrderInt = 0;
                            try { pizzaToOrderString = Console.ReadLine(); pizzaToOrderInt = int.Parse(pizzaToOrderString); } catch (FormatException e) { Console.WriteLine(e.Message); }
                            if (PizzaCatalog.SearchForPizzaById(pizzaToOrderInt) != null)
                            {
                                Console.WriteLine("Enter number of pizzas: ");
                                string noOfPizzasString = "";
                                int noOfPizzasInt = 0;
                                try { noOfPizzasString = Console.ReadLine(); noOfPizzasInt = int.Parse(noOfPizzasString); } catch (FormatException e) { Console.WriteLine(e.Message); }
                                if (noOfPizzasInt != null && noOfPizzasInt > 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter order ID: ");
                                    string orderIdString = "";
                                    int orderId = 0;
                                        try { orderIdString = Console.ReadLine(); orderId = int.Parse(orderIdString); } catch (FormatException e) { Console.WriteLine(e.Message); }
                                        if (orderId != null)
                                        {
                                            OrderCatalog.SeachForOrderById(orderId);
                                            if (OrderCatalog.SeachForOrderById(orderId) != null)
                                            {
                                                Console.WriteLine($"You are about to overrite a existing order. \nAre you sure you want to overwrite {OrderCatalog.SeachForOrderById(orderId)}?\ny/n");
                                                string overrideString = Console.ReadLine();
                                                if (overrideString == "y")
                                                {
                                                    OrderCatalog.RemoveAt(orderId);
                                                    OrderCatalog.AddAnOrderToTheList(OrderCatalog.GetNewOrderFromExisting(CustomerCatalog.SeachForCustomerById(customerToOrderInt3), PizzaCatalog.SearchForPizzaById(pizzaToOrderInt), noOfPizzasInt, orderId));
                                                    Console.WriteLine($"\nThe order was overwritten with {OrderCatalog.SeachForOrderById(orderId)}\n");
                                                }
                                                else 
                                                {
                                                    do
                                                    {
                                                        Console.WriteLine("Enter order ID: ");
                                                        string orderIdStringAgain = "";
                                                        int orderIdAgain = 0; try { orderIdStringAgain = Console.ReadLine(); orderIdAgain = int.Parse(orderIdStringAgain); } catch (FormatException e) { Console.WriteLine(e.Message); }
                                                    if (OrderCatalog.SeachForOrderById(orderIdAgain) == null)
                                                    {
                                                        OrderCatalog.RemoveAt(orderIdAgain);
                                                        OrderCatalog.AddAnOrderToTheList(OrderCatalog.GetNewOrderFromExisting(CustomerCatalog.SeachForCustomerById(customerToOrderInt3), PizzaCatalog.SearchForPizzaById(pizzaToOrderInt), noOfPizzasInt, orderIdAgain));
                                                        Console.WriteLine($"\n{OrderCatalog.SeachForOrderById(orderIdAgain)} was created\n"); return;
                                                    } 
                                                } while (OrderCatalog.SeachForOrderById(orderId) != null);
                                                }
                                            }
                                            else { OrderCatalog.AddAnOrderToTheList(OrderCatalog.GetNewOrderFromExisting(CustomerCatalog.SeachForCustomerById(customerToOrderInt3), PizzaCatalog.SearchForPizzaById(pizzaToOrderInt), noOfPizzasInt, orderId)); Console.WriteLine($"You created a new order"); }
                                        }
                                        else { Console.Clear(); Console.WriteLine("Input is invalid"); }
                                }
                                else { Console.Clear(); Console.WriteLine("Input is invalid"); }
                            }
                            else { Console.Clear(); Console.WriteLine($"There are no pizza with ID {pizzaToOrderInt}"); }
                        }
                        else { Console.Clear(); Console.WriteLine($"A customer with ID {customerToOrderInt3} already exists"); }
                        break;
                    case 4:
                        //"4. Create an order with new customer and new pizza"

                        break;
                    case 5:
                        OrderCatalog.PrintOrderList();
                        Console.WriteLine("Which order would you like to delete?\nEnter a number: ");
                        string deleteOrderString = Console.ReadLine();
                        int deleteOrder = int.Parse(deleteOrderString);
                        OrderCatalog.DeleteAnOrder(deleteOrder);
                        Console.WriteLine($"You deleted order {deleteOrder} from the list");
                        break;
                    case 6:
                        OrderCatalog.PrintOrderList();
                        Console.WriteLine("Which order would you like to update?\nEnter a number: ");
                        string updateOrderString = Console.ReadLine();
                        int updateOrder = int.Parse(updateOrderString);
                        OrderCatalog.UpdateOrder(updateOrder);
                        Console.WriteLine($"You updated order {updateOrder}");
                        break;
                    case 7:
                        //"7. Search for an order by ID"
                        Console.WriteLine("Seach for an order by ID.\nEnter an ID: ");
                        string searchForOrderByIdString = Console.ReadLine();
                        int searchForOrderById = int.Parse(searchForOrderByIdString);
                        Console.WriteLine(OrderCatalog.SeachForOrderById(searchForOrderById));
                        break;
                    case 8:
                        Console.WriteLine("Are you sure you want to clear the list of orders?\ny/n");
                        string answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            OrderCatalog.Clear();
                            Console.WriteLine("You cleared the list of orders");
                        }
                        else
                        {
                            Console.WriteLine("You did not clear the list of orders");
                        }
                        break;
                    case 9:
                        OrderCatalog.PrintOrderList();
                        break;
                    case 10:

                        break;
                }
            }
        }
    }
}