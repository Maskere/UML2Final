using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Customer
    {
        #region Instance Field
        private string _customerName;
        private string _email;
        private string _phoneNumber;
        private int _customerId;
        #endregion

        #region Constructor
        public Customer(string Name, int CustomerId)
        {
            _customerName = Name;
            _phoneNumber = PhoneNumber;
            _email = Email;
            _customerId = CustomerId;
        }
        #endregion

        #region Properties
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{CustomerName}";
        }
        #endregion
    }
}