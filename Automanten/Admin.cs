using System;
using System.Collections.Generic;
using System.Text;

namespace Automanten
{
    public class Admin
    {
        public VendingMachine AdminMenu(VendingMachine vendingMachine)
        {
            Console.WriteLine("\n\n Admin Menu \n__________________________________");
            Console.WriteLine(" 1. Genopfylde vare \n 2. Hente penge \n 3. Justere prisen på vare");

            int intChoice = Convert.ToInt32(Console.ReadLine());
            switch (intChoice)
            {
                case (1):
                    VendingMachineRefill(vendingMachine);
                    break;
                case (2):
                    CollectMoney(vendingMachine);
                    break;
                case (3):
                    AdjustPrice(vendingMachine);
                    break;
                default:
                    Console.WriteLine("Du har givet et ugyldigt tal");
                    break;
            }
            return vendingMachine;


        }
        private VendingMachine VendingMachineRefill(VendingMachine vendingMachine)
        {
            ShowProducts(vendingMachine);
            Console.WriteLine("Skriv produkt nummeret på det produkt du vil genopfylde");

            int intChoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hvor mange vil du fylde på");
            int intQuantity = Convert.ToInt32(Console.ReadLine());
            vendingMachine.stock.Find(stock => stock.productNumber == intChoice).quantity += intQuantity; 
            return vendingMachine;
        }
        private VendingMachine CollectMoney(VendingMachine vendingMachine)
        {

            return vendingMachine;
        }
        private VendingMachine AdjustPrice(VendingMachine vendingMachine)
        {
            ShowProducts(vendingMachine);
            Console.WriteLine("Skriv produkt nummeret på det produkt du vil justere prisen på ");
            int productNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Skriv hvad den nye pris skal være");
            int newProductNumber = Convert.ToInt32(Console.ReadLine());
            vendingMachine.stock.Find(stock => stock.productNumber == productNumber).price = newProductNumber;
            return vendingMachine;
        }
        private void ShowProducts(VendingMachine vendingMachine)
        {
            Logic logik = new Logic();

            for (int i = 0; i < logik.ProductQuantity(vendingMachine); i++)
                Console.WriteLine(logik.AllProducts(vendingMachine, i));
        }
    }
}
