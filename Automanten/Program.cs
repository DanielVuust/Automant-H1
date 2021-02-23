using System;

namespace Automanten
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Program program = new Program();
                Console.WriteLine("Velkommen til Automaten \n______________________________\n Indtast hvad du vil\n 1. Køb produkt\n 2. Admin menu ");
                string valg = Console.ReadLine();
                if (valg == "1")
                {
                    program.KøbProdukt();
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
        private void KøbProdukt()
        {
            Logik logik = new Logik();
            int Pris;
            Console.WriteLine("\nHvad vil du købe?\nSkriv enten produkt navnet eller produkt nummeret\n");
            VisProdukter();
            string strValg = Console.ReadLine();
            Console.WriteLine("Skriv hvor mange du vil købe");
            string strAntal = Console.ReadLine();
            // Denne tjekker om det kunden har indtastet er et produkt nummer eller produkt navn fordi der er forskel hvad vi skal søge efter
            if (Int32.TryParse(strValg, out int intValg))
            {
                int pris = logik.TotalPrisViaNummer(intValg, Convert.ToInt32(strAntal));
                Console.WriteLine($"Du skal betale {pris}");
            }
            else
            {
                int pris = logik.TotalPrisViaNavn(strValg, Convert.ToInt32(strAntal));
                Console.WriteLine($"Du skal betale {pris}");
            }
        }
        private void VisProdukter()
        {
            Logik logik = new Logik();

            for (int i = 0; i < logik.AntalProdukter(); i++)
            Console.WriteLine(logik.AlleProdukter(i));
        }
    }
}
