using System;
using System.Collections.Generic;
using System.Text;

namespace Automanten
{
    public class Logik
    {
        public string AlleProdukter(int index)
        {
            Automat automat = new Automat();
            string status;
            if (automat.lager[index].antal <= 0)
            {
                status = "UDSOLGT";
            }
            else
            {
                status = Convert.ToString(automat.lager[index].antal);
            }

            string produkt = $" Produkt: {automat.lager[index].produktNavn}\t\t Pris: {automat.lager[index].pris}\t Produkt nummer: {automat.lager[index].produktNummer}\t Status: {status}";
            return produkt;
        }
        public int AntalProdukter()
        {
            Automat automat = new Automat();
            return automat.lager.Count;
        }
        public int TotalPrisViaNavn(string produktNavn, int antal)
        {
            Automat automat = new Automat();
            return automat.lager.Find(lager => lager.produktNavn == produktNavn).pris * antal;
        }
        public int TotalPrisViaNummer(int produktNummer, int antal)
        {
            Automat automat = new Automat();
            return automat.lager.Find(lager => lager.produktNummer == produktNummer).pris * antal;
        }
    }
}
