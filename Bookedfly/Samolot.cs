using System;
using System.Collections.Generic;
using System.Text;

namespace Bookedfly
{
    [Serializable()]
    public class Samolot
    {
        public String Nazwa { get; set; }
        public String Firma { get; set; }
        public double Odleglosc { get; set; }
        public int IloscMiejsc { get; set; }
        public Samolot(String naz, String fir, double odl, int im) //konstruktor parametrowy samolotu
        {
            Nazwa = naz;
            Firma = fir;
            Odleglosc = odl;
            IloscMiejsc = im;
        }
    }
}
