using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public static class VendingMachineManager
    {
        public static StringBuilder ShowAllProducts()
        {
            StringBuilder productStringBuilder = new StringBuilder();
            //For each beverage in the static VendinMachine this runs.
            foreach (var beverage in VendingMachine.beverageStock)
            {
                string status;
                //If the quantity is 0 or below then the status is set to "out of stock" either its set to the quanitty.
                if (beverage.quantity <= 0)
                {
                    status = "UDSOLGT";
                }
                else
                {
                    status = beverage.quantity.ToString();
                }

                productStringBuilder.Append($" Produkt: {beverage.productName}\t\t Pris: {beverage.price}\t Produkt nummer: {beverage.productNumber}\t Status: {status} \n");
            }
            //Returns a StringBuilder to be displayed.
            return productStringBuilder;
        }
        public static int CurrentTotalMoneySum()
        {
            int totalSum = 0;
            //Foreach kind of money in the money dicornary gets its key and value added up.
            foreach (var money in VendingMachine.money)
            {
                totalSum += money.Key * money.Value;
            }
            return totalSum;
        }
        public static bool CheckCoin(int coin)
        {
            if (VendingMachine.money.ContainsKey(coin))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string GetCoinQuantity(int coin)
        {
            return VendingMachine.money.Values.ToString();
        }
    }
}
