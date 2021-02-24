using System;
using System.Collections.Generic;
using System.Text;

namespace Automanten
{
    public class VendingMachine
    {
        private List<Product.Beverage> _stock = new List<Product.Beverage>(4) 
        {
            new Product.Beverage(1, 10){quantity=10, productName= "Cola"},
            new Product.Beverage(2, 10){quantity=1, productName= "Danta"},
            new Product.Beverage(3, 10){quantity=0, productName= "Faxekondi"},
            new Product.Beverage(4, 10){quantity=2, productName= "Vand"}
        };
        //Dette er listen over hvilke kroner/selder automaten godtager 

        //Brude ændres til en dictionary 
        private Dictionary<int, int> _money = new Dictionary<int, int>() { {1, 10}, { 2, 10 }, { 5, 10 }, { 10, 10 }, { 20, 10 }, { 50, 1 }};
        public Dictionary<int, int> money
        {
            get { return _money; }
            set { _money = value; }
        }
        public List<Product.Beverage> stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
      

    }
}
