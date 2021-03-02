using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    //This class is static so i can use it in every other class and don't need to declare it.
    static class VendingMachine
    {
        //This is the List for every beverage in the vending machine.
        public static List<Product.Beverage> beverageStock = new List<Product.Beverage>(4) 
        {
            new Product.Beverage(1, 10){quantity=10, productName= "Cola"},
            new Product.Beverage(2, 10){quantity=1, productName= "Fanta"},
            new Product.Beverage(3, 10){quantity=0, productName= "Faxekondi"},
            new Product.Beverage(4, 10){quantity=2, productName= "Vand"}
        };
        //This is a dictionary that displays what kinda of money the vending machine accepts
        //The key is what type of money and the value is how many of that kind of money is in the machine.
        public static Dictionary<int, int> money = new Dictionary<int, int>() { {1, 10}, { 2, 10 }, { 5, 10 }, { 10, 10 }, { 20, 10 }};
    }
}
