using System;
using System.Collections.Generic;
using System.Text;

namespace Automanten
{
    public abstract class Product
    {
        private string _productName;
        private int _productNumber;
        private int _price;
        private int _quantity;
        public string productName { 
            get { return _productName; } 
            set { _productName = value; } 
        }
        public int productNumber { 
            get { return _productNumber; } 
            set { _productNumber = value; } 
        }
        public int price
        {
            get { return _price; }
            set { _price = value; }
        }
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        
        public class Beverage : Product
        {
            public Beverage(int productNumber, int price)
            {
                this._productNumber = productNumber;
                this._price = price;
            }
        }
        public class Chips : Product
        {
            public Chips(int productNumber, int price)
            {
                this._productNumber = productNumber;
                this._price = price;
            }
        }
    }
}
