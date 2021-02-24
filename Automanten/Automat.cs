using System;
using System.Collections.Generic;
using System.Text;

namespace Automanten
{
    public class Automat
    {
        private List<Produkt.Læskedrik> _lager = new List<Produkt.Læskedrik>(4) 
        {
            new Produkt.Læskedrik(1, 10){antal=10, produktNavn= "cola"},
            new Produkt.Læskedrik(2, 10){antal=1, produktNavn= "fanta"},
            new Produkt.Læskedrik(3, 10){antal=0, produktNavn= "faxekondi"},
            new Produkt.Læskedrik(4, 10){antal=2, produktNavn= "cola"}
        };
        public List<Produkt.Læskedrik> lager
        {
            get { return _lager; }
            set { _lager = value; }
        }
      

    }
}
