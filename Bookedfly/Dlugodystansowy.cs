using System;
using System.Collections.Generic;
using System.Text;

namespace Bookedfly
{
    [Serializable ()]
    class Dlugodystansowy : Samolot
    { 
        public Dlugodystansowy(String nazwa, String firma, double odleglosc, int IloscMiejsc) : base(nazwa, firma, odleglosc, IloscMiejsc)
        { }
    }
}
