using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Pizza
    {
        #region Instance Field
        private int _price;
        private string _name;
        private int _pizzaId;
        #endregion

        #region Constructor
        public Pizza(string Name, int Price, int pizzaId)
        {
            _name = Name;
            _price = Price;
            _pizzaId = pizzaId;
        }
        #endregion

        #region Properties
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int PizzaId
        {
            get { return _pizzaId; }
            set { _pizzaId = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{PizzaId} {Name} - Price:{Price}";
        }
        #endregion
    }
}