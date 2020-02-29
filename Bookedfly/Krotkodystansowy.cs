using System;
using System.Collections.Generic;
using System.Text;

namespace Bookedfly
{
    [Serializable()]
    public class Krotkodystansowy : Samolot
    {
        public Krotkodystansowy(String nazwa, String firma, double odleglosc, int IloscMiejsc) : base(nazwa, firma, odleglosc, IloscMiejsc) //konstruktor parametrowy samolotu krótkodystansowego
        {

        }
    }
}
