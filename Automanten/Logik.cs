using System;
using System.Collections.Generic;
using System.Text;

namespace Automanten
{
    public class Logik
    {
        public string AlleProdukter(Automat automat, int index)
        {
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
        public int AntalProdukter(Automat automat)
        {
            return automat.lager.Count;
        }
        public int NummerViaProduktNavn(Automat automat, string produktNavn)
        {
            return automat.lager.Find(lager => lager.produktNavn == produktNavn).produktNummer;
        }
        public string ProduktNavnViaProduktNummer(Automat automat, int produktNummer)
        {
            return automat.lager.Find(c => c.produktNummer == produktNummer).produktNavn;
        }
        public int TotalPrisViaNummer(Automat automat, int produktNummer, int antal)
        {
            return automat.lager.Find(lager => lager.produktNummer == produktNummer).pris * antal;
        }
        public bool TjekLager(Automat automat, int produktNummer, int antal)
        {
            return true;
        }
        public void ÆndreLager(Automat automat, int produktNummer, int antal)
        {
            Console.WriteLine(automat.lager.Find(produkt => produkt.produktNummer == produktNummer).antal);
            automat.lager.Find(produkt => produkt.produktNummer == produktNummer).antal = 1;
            Console.WriteLine(automat.lager.Find(produkt => produkt.produktNummer == produktNummer).antal);

        }
        
    }
}
