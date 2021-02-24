using System;

namespace Automanten {
    public class BuyProduct
    {
        public void BuyAProduct(VendingMachine vendingMachine)
        {
            Logic logic = new Logic();
            int price;
            Console.WriteLine("\nHvad vil du købe?\nSkriv enten produkt navnet eller produkt nummeret\n");
            ShowProduct(vendingMachine);
            string strChoice = Console.ReadLine();
            int intChoice;
            Console.WriteLine("Skriv hvor mange du vil købe");
            string strQuantity = Console.ReadLine();
            int intQuantity = Convert.ToInt32(strQuantity);
            // Denne tjekker om det kunden har indtastet er et produkt nummer eller produkt navn fordi der er forskel hvad vi skal søge efter
            if (Int32.TryParse(strChoice, out intChoice))
            {
                price = logic.TotalPriceViaProductNumber(vendingMachine, intChoice, intQuantity);
            }
            else
            {
                intChoice = logic.NummerViaProduktNavn(vendingMachine, strChoice);
                price = logic.TotalPriceViaProductNumber(vendingMachine, intChoice, intQuantity);
            }
            Pay(vendingMachine, price);
            string produktNavn = logic.ProductNameViaProductNumber(vendingMachine, intChoice);
            Console.WriteLine($"Du har nu købt {strQuantity} styk {produktNavn}");
            vendingMachine = logic.ÆndreLager(vendingMachine, intChoice, intQuantity);
            Console.WriteLine($"Du har nu fået din {produktNavn}");

        }
        private bool Pay(VendingMachine VendingMachine, int price)
        {
            Console.Write("Maskinen tager kun imod ");
            foreach (var p in VendingMachine.money)
            {
                Console.Write(p + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Skriv hvordan du betaler");
            int buyersMoney = 0;
            while (price > 0)
            {
                Console.WriteLine($"Du skal betale {price},00 kr");
                buyersMoney = Convert.ToInt32(Console.ReadLine());
                if (VendingMachine.money.ContainsValue(buyersMoney))
                {
                    price -= buyersMoney;
                }
                else
                {
                    Console.Write("Maskinen tager kun imod ");
                    foreach (var p in VendingMachine.money)
                    {
                        Console.Write(p + " ");
                    }
                    Console.WriteLine();
                    continue;
                }
            }
            if (price < 0)
            {
                Console.WriteLine($"Du får {price * -1},00 kr tilbage");
            }
            return true;
        }
        private void ShowProduct(VendingMachine vendingMachine)
        {
            Logic logic = new Logic();

            for (int i = 0; i < logic.ProductQuantity(vendingMachine); i++)
                Console.WriteLine(logic.AllProducts(vendingMachine, i));
        }
    }
}
