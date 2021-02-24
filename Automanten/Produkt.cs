using System;
using System.Collections.Generic;
using System.Text;

namespace Automanten
{
    public class Produkt
    {
        private string _produktNavn;
        private int _produktNummer;
        private int _pris;
        private int _antal;
        public string produktNavn { 
            get { return _produktNavn; } 
            set { _produktNavn = value; } 
        }
        public int produktNummer { 
            get { return _produktNummer; } 
            set { _produktNummer = value; } 
        }
        public int pris
        {
            get { return _pris; }
            set { _pris = value; }
        }
        public int antal
        {
            get { return _antal; }
            set { _antal = value; }
        }
        
        public class Læskedrik : Produkt
        {
            public Læskedrik(int produktTal, int pris)
            {
                this._produktNummer = produktTal;
                this._pris = pris;
            }
        }
        public class Chips : Produkt
        {
            public Chips(int produktTal, int pris)
            {
                this._produktNummer = produktTal;
                this._pris = pris;
            }
        }
    }
}
