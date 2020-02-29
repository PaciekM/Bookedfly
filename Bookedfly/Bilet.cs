using System;
using System.Collections.Generic;
using System.Text;

namespace Bookedfly
{
    [Serializable()]
    class Bilet
    {
        public Lot lot { get; set; }
        public int liczbaMiejsc { get; set; }
        public Osoba osoba { get; set; }
        public FirmaPos firma { get; set; }
        public int odejmijMiejsce(int l) //metoda redukująca liczbę dostępnych biletów
        {
            liczbaMiejsc -= l;
            return liczbaMiejsc;
        }
    }
}
