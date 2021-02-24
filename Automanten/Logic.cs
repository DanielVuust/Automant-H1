using System;
using System.Collections.Generic;
using System.Text;

namespace Automanten
{
    public class Logic
    {
        public string AllProducts(VendingMachine vendingMachine, int index)
        {
            string status;
            if (vendingMachine.stock[index].quantity <= 0)
            {
                status = "UDSOLGT";
            }
            else
            {
                status = Convert.ToString(vendingMachine.stock[index].quantity);
            }

            string product = $" Produkt: {vendingMachine.stock[index].productName}\t\t Pris: {vendingMachine.stock[index].price}\t Produkt nummer: {vendingMachine.stock[index].productNumber}\t Status: {status}";
            return product;
        }
        public int ProductQuantity(VendingMachine vendingMachine)
        {
            return vendingMachine.stock.Count;
        }
        public int NummerViaProduktNavn(VendingMachine vendingMachine, string productName)
        {
            return vendingMachine.stock.Find(lager => lager.productName == productName).productNumber;
        }
        public string ProductNameViaProductNumber(VendingMachine vendingMachine, int productNumber)
        {
            return vendingMachine.stock.Find(c => c.productNumber == productNumber).productName;
        }
        public int TotalPriceViaProductNumber(VendingMachine vendingMachine, int productNumber, int quantity)
        {
            return vendingMachine.stock.Find(lager => lager.productNumber == productNumber).price * quantity;
        }
        public bool TjekLager(VendingMachine vendingMachine, int productNumber, int quantity)
        {
            return true;
        }
        public VendingMachine ÆndreLager(VendingMachine vendingMachine, int productNumber, int quantity)
        {

            Console.WriteLine(vendingMachine.stock.Find(produkt => produkt.productNumber == productNumber).quantity);
            vendingMachine.stock.Find(produkt => produkt.productNumber == productNumber).quantity -= quantity;
            Console.WriteLine(vendingMachine.stock.Find(produkt => produkt.productNumber == productNumber).quantity);
            return vendingMachine;
        }
        
    }
}
