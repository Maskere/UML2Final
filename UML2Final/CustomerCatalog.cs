using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class CustomerCatalog
    {
        List<Customer> Customers;
        public CustomerCatalog()
        {
            Customers = new List<Customer>(new Customer[10]);
        }
        public int Count
        {
            get { return Customers.Count; }
        }
        public Customer GetNewCustomer(string customerName, int customerId)
        {
            Customer customer = new Customer(customerName, customerId);
            if (Customers[customerId] != null) { return null; }
            return customer;
        }
        public void CreateACustomer(Customer customer)
        {
            Customers.Insert(customer.CustomerId, customer);
        }
        public void DeleteACustomer(int CustomerId)
        {
            Customers.Insert(CustomerId, new Customer("", CustomerId));
            Customers.RemoveAt(CustomerId + 1);
        }
        public Customer SeachForCustomerById(int customerId)
        {
            Customer findCustomer = Customers[customerId];
            return findCustomer;
        }
        public void UpdateCustomer(Customer updatedCustomer)
        {
            if (Customers.Contains(updatedCustomer))
            {
                updatedCustomer = null;
            }
            else
            {
                Customers.RemoveAt(updatedCustomer.CustomerId);
                Customers.Insert(updatedCustomer.CustomerId, updatedCustomer);
            }
        }
        public Customer SearchCustomerByName(string customerName)
        {
            
            foreach (Customer customer in Customers) 
            {
                if (customer != null)
                {
                    for (int i = 0; i < Customers.Count; i++) { Customer findCustomer = new Customer(customerName, i); ; if (string.Equals(customer.CustomerName, findCustomer.CustomerName)) return customer; }
                }
            }
            return null;
        }
        public void Clear()
        {
            Customers.Clear();
            Customers = new List<Customer>(new Customer[10]);
        }
        public void RemoveAt(int removeAt)
        {
            Customers.RemoveAt(removeAt);
        }
        public void PrintCustomerList()
        {
            foreach (Customer customer in Customers)
            {
                if (customer != null)
                {
                    Console.WriteLine($"| {customer} |");
                }
                else
                {
                    Console.WriteLine("   ...");
                }
            }
        }
    }
}