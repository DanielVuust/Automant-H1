using System;
using System.Collections.Generic;
using System.Collections;

namespace Automanten
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();
            while (true)
            {
                
                Console.WriteLine("Velkommen til Automaten \n______________________________\n Indtast hvad du vil\n 1. Køb produkt\n 2. Admin menu ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    BuyProduct buyProduct = new BuyProduct();
                    buyProduct.BuyAProduct(vendingMachine);
                }
                else if (choice == "2")
                {
                    Admin admin = new Admin();
                    vendingMachine = admin.AdminMenu(vendingMachine);
                }
                else
                {
                    Console.WriteLine("Du har indtastet et ugyldigt tal ");
                    continue;
                }
            }
        }
    }
}
