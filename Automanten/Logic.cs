using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    static class Logic
    {
        public static int NummerViaProduktNavn(string productName)
        {
            //Returns the productNumber using the productName as a search.
            return VendingMachine.beverageStock.Find(lager => lager.productName == productName).productNumber;
        }
        public static string ProductNameViaProductNumber(int productNumber)
        {
            //Returns the productName using the productNumber as a search.
            return VendingMachine.beverageStock.Find(c => c.productNumber == productNumber).productName;
        }
        public static int TotalPriceViaProductNumber(int productNumber, int quantity)
        {
            //Returns the total price for the purchase using the priductNumber as a search.
            return VendingMachine.beverageStock.Find(lager => lager.productNumber == productNumber).price * quantity;
        }
        public static bool CheckStock(int productNumber, int quantity)
        {
            //This will be able to check if there is enough stock to complete the purchase. 
            return true;
        }
        public static void ChangeStock(int productNumber, int quantity)
        {
            //Changes the stock of a specific product using the productNumber as a search.
            VendingMachine.beverageStock.Find(produkt => produkt.productNumber == productNumber).quantity -= quantity;
        }
        public static StringBuilder ShowAllProducts()
        {
            //Returns the StringBuilder in the VendingMachineManager.ShowAllProducts()
            return VendingMachineManager.ShowAllProducts();
        }
        public static StringBuilder CurrentMoney()
        {
            StringBuilder currentMoney = new StringBuilder();

            foreach (var money in VendingMachine.money)
            {
                currentMoney.Append($"{money.Value} styk af {money.Key}kr \t");
            }
            return currentMoney;
        }
        public static int CurrentTotalMoneySum()
        {
            return VendingMachineManager.CurrentTotalMoneySum();
        }
        public static void ChangeProductPriceViaProductNumber(int productNumber, int newProductPrice)
        {
            VendingMachine.beverageStock.Find(stock => stock.productNumber == productNumber).price = newProductPrice;
        }
        public static bool CheckCoin(int coin)
        {
            return VendingMachineManager.CheckCoin(coin);
        }
        public static void ChangeMoneyStock(int coin, string coinQuantityToRemove)
        {

            int intCoinQuantityToRemove = Convert.ToInt32(coinQuantityToRemove);
            VendingMachineManager.ChangeMoneyStock(coin, intCoinQuantityToRemove);
        }
    }
}
