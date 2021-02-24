using System;
using System.Collections.Generic;
using System.Collections;

namespace Automanten
{
    class Program
    {
        private List<int> penge = new List<int>() { 1, 2, 5, 10, 20, 50 };


        static void Main(string[] args)
        {
            Automat automat = new Automat();
            while (true)
            {
                Program program = new Program();
                Console.WriteLine("Velkommen til Automaten \n______________________________\n Indtast hvad du vil\n 1. Køb produkt\n 2. Admin menu ");
                string valg = Console.ReadLine();
                if (valg == "1")
                {
                    program.KøbProdukt(automat);
                }
                else if (valg == "2")
                {

                }
                else
                {
                    Console.WriteLine("Du har indtastet et ugyldigt tal ");
                    continue;
                }
            }
        }
        private void KøbProdukt(Automat automat)
        {
            Logik logik = new Logik();
            int pris;
            Console.WriteLine("\nHvad vil du købe?\nSkriv enten produkt navnet eller produkt nummeret\n");
            VisProdukter(automat);
            string strValg = Console.ReadLine();
            int intValg;
            Console.WriteLine("Skriv hvor mange du vil købe");
            string strAntal = Console.ReadLine();
            int intAntal = Convert.ToInt32(strAntal);
            // Denne tjekker om det kunden har indtastet er et produkt nummer eller produkt navn fordi der er forskel hvad vi skal søge efter
            if (Int32.TryParse(strValg, out intValg))
            {
                pris = logik.TotalPrisViaNummer(automat, intValg, intAntal);
            }
            else
            {
                intValg = logik.NummerViaProduktNavn(automat, strValg);
                pris = logik.TotalPrisViaNummer(automat, intValg, intAntal);
            }
            Betal(pris);
            Console.WriteLine($"Du har nu købt {strAntal} styk {logik.ProduktNavnViaProduktNummer(automat, intValg)}");
            automat = logik.ÆndreLager(automat, intValg, intAntal);

        }
        private bool Betal(int pris)
        {
            Console.Write("Maskinen tager kun imod ");
            foreach (var p in penge)
            {
                Console.Write(p + " "); 
            }
            Console.WriteLine();
            Console.WriteLine("Skriv hvordan du betaler");
            int kundesPenge = 0;
            while (pris > 0)
            {
                Console.WriteLine($"Du skal betale {pris},00 kr");
                kundesPenge = Convert.ToInt32(Console.ReadLine());
                if (penge.Contains(kundesPenge))
                {
                    pris -= kundesPenge;
                }
                else
                {
                    Console.Write("Maskinen tager kun imod ");
                    foreach (var p in penge)
                    {
                        Console.Write(p + " ");
                    }
                    Console.WriteLine();
                    continue;
                }
            }
            if (pris <0)
            {
                Console.WriteLine($"Du får {pris *-1},00 kr tilbage");
            }
            return true;
        }
        private void VisProdukter(Automat automat)
        {
            Logik logik = new Logik();

            for (int i = 0; i < logik.AntalProdukter(automat); i++)
            Console.WriteLine(logik.AlleProdukter(automat, i));
        }
    }
}
