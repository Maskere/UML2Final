using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class PizzaCatalog
    {
        List<Pizza> Pizzas;
        int _id;
        public PizzaCatalog()
        {
            Pizzas = new List<Pizza>(new Pizza[10]);
        }
        public int Count
        {
            get { return Pizzas.Count; }
        }
        public Pizza GetNewPizza(string pizzaName, int pizzaPrice, int pizzaId)
        {
            Pizza pizza = new Pizza(pizzaName, pizzaPrice, pizzaId);
            if (Pizzas[pizzaId] != null)
                return null;
            return pizza;
        }
        public void UpdatePizza(Pizza updatePizza)
        {
            if (Pizzas.Contains(updatePizza))
            {
                updatePizza = null;
            }
            else
            {
                Pizzas.RemoveAt(updatePizza.PizzaId);
                Pizzas.Insert(updatePizza.PizzaId, updatePizza);
            }
        }
        public void CreateAPizza(Pizza pizza)
        {
            Pizzas.Insert(pizza.PizzaId, pizza);
        }
        public void DeleteAPizza(int pizzaId)
        {
            Pizzas.Insert(pizzaId, new Pizza("", 0, 0));
            Pizzas.RemoveAt(pizzaId + 1);
        }
        public Pizza SearchForPizzaById(int pizzaId)
        {
            Pizza findPizza = Pizzas[pizzaId];
            return findPizza;
        }
        public void Clear()
        {
            Pizzas.Clear();
            Pizzas = new List<Pizza>(new Pizza[10]);
        }
        public void RemoveAt(int removeAt)
        {
            Pizzas.RemoveAt(removeAt);
        }
        public void PrintMenu()
        {
            foreach (Pizza pizza in Pizzas)
            {
                if (pizza != null)
                {
                    Console.WriteLine($"| {pizza} |");
                }
                else
                {
                    Console.WriteLine("   ...");
                }
            }
        }
    }
}