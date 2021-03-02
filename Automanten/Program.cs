using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                //This is the vending machine menu.
                Console.WriteLine("Velkommen til Automaten \n______________________________\n Indtast hvad du vil\n 1. Køb produkt\n 2. Admin menu \n 3. Vis produkter ");
                Program program = new Program();
                //Here the user can choose what he want to do whit the vending machine.
                switch (Console.ReadLine())
                {
                    case "1":
                        program.BuyAProduct();
                        break;
                    case "2":
                        program.AdminMenu();
                        break;
                    case "3":
                        Console.WriteLine(Logic.ShowAllProducts());
                        break;
                    default:
                        Console.WriteLine("Du har indtastet et ugyldigt tal");
                        continue;
                }
            }
        }
        private void BuyAProduct()
        {
            int price;

            Console.WriteLine(Logic.ShowAllProducts());

            Console.WriteLine("\nHvad vil du købe?\nSkriv enten produkt navnet eller produkt nummeret\n");
            string strChoice = Console.ReadLine();
           
            Console.WriteLine("Skriv hvor mange du vil købe");
            string strQuantity = Console.ReadLine();

            int intQuantity = Convert.ToInt32(strQuantity);

            //If a product name has been inputted then a function is called to get its product number.
            if (!Int32.TryParse(strChoice, out int intChoice))
            {
                intChoice = Logic.NummerViaProduktNavn(strChoice);
            }
            //Gets the price of the products the customer wants 
            price = Logic.TotalPriceViaProductNumber(intChoice, intQuantity);

            Pay(price);

            string productName = Logic.ProductNameViaProductNumber(intChoice);
            Console.WriteLine($"Du har nu købt {strQuantity} styk {productName}");
            Logic.ChangeStock(intChoice, intQuantity);

        }
        private void AdminMenu()
        {
            Console.WriteLine("\n\n Admin Menu \n__________________________________");
            Console.WriteLine(" 1. Genopfylde vare \n 2. Hente penge \n 3. Justere prisen på vare");

            int intChoice = Convert.ToInt32(Console.ReadLine());
            switch (intChoice)
            {
                case (1):
                    VendingMachineRefill();
                    break;
                case (2):
                    CollectMoney();
                    break;
                case (3):
                    AdjustPrice();
                    break;
                default:
                    Console.WriteLine("Du har givet et ugyldigt tal");
                    break;
            }
        }
        private void Pay(int price)
        {
            int buyersMoney = 0;
            Console.Write("Maskinen tager kun imod ");
            foreach (int p in VendingMachine.money.Keys)
            {
                Console.Write(p + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Skriv hvordan du betaler");

            // This needs to be a function in the logic class 
            do
            {
                Console.WriteLine($"Du skal betale {price},00 kr");
                buyersMoney = Convert.ToInt32(Console.ReadLine());
                if (Logic.CheckCoin(buyersMoney))
                {
                    price -= buyersMoney;
                }
                else
                {
                    Console.Write("Maskinen tager kun imod ");
                    foreach (var p in VendingMachine.money.Keys)
                    {
                        Console.Write(p + " ");
                    }
                    Console.WriteLine();
                    continue;
                }
            } while (price >= 0);

            if (price < 0)
            {
                Console.WriteLine($"Du får {price * -1},00 kr tilbage");
            }
        }
        private void VendingMachineRefill()
        {

            Logic.ShowAllProducts();
            Console.WriteLine("Skriv produkt nummeret på det produkt du vil genopfylde");

            int intChoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hvor mange vil du fylde på");
            int intQuantity = Convert.ToInt32(Console.ReadLine());
            VendingMachine.beverageStock.Find(stock => stock.productNumber == intChoice).quantity += intQuantity;

        }
        private void CollectMoney()
        {
            
            
            StringBuilder currentMoney = new StringBuilder();
            currentMoney = Logic.CurrentMoney();
            Console.WriteLine($"Maskinen indenholder lige nu {Logic.CurrentTotalMoneySum()},00 kr");
            Console.WriteLine(currentMoney);

            while (true)
            {
                Console.WriteLine("Skriv hvilken slags mønt du vil fjerne");
                int coinChoice = Convert.ToInt32(Console.ReadLine());
                if (!Logic.CheckCoin(coinChoice))
                {
                    Console.WriteLine("Maskinen indholder ikke den slags mønt");
                    continue;
                }
                Console.WriteLine("Hvor mange af den slags vil du fjerne?");

                Console.WriteLine(Logic.ChangeMoneyStock(coinChoice, Console.ReadLine()));
                
            }
        }
        private void AdjustPrice()
        {
            Logic.ShowAllProducts();
            Console.WriteLine("Skriv produkt nummeret på det produkt du vil justere prisen på ");
            int productNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Skriv hvad den nye pris skal være");
            int newProductPrice = Convert.ToInt32(Console.ReadLine());

            //Finds the price of the product number being specified and changes it to the new 
            Logic.ChangeProductPriceViaProductNumber(productNumber, newProductPrice);

        }

    }
}
