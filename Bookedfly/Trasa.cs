using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bookedfly
{
    [Serializable ()]
    public class Trasa
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        public double odleglosc { get; set; }
        public double czas { get; set; }
        public double start { get; set; }
        public double meta { get; set; }
        public Lotnisko lotStart { get; set; }
        public Lotnisko lotMeta { get; set; }
        public Trasa(Lotnisko st, Lotnisko mt) //konstruktor trasy
        {
            lotStart = st;
            lotMeta = mt;
        }
        public double liczOdleglosc(double s, double m) //metoda licząca odleglość, zwracająca przemnożoną przez współczynnik odpowiednią odleglość
        {
            start = s;
            meta = m;
            if (start > meta)
            {
                odleglosc = start - meta;
                return odleglosc *= 800;
            }
            if (meta > start)
            {
                odleglosc = meta - start;
                return odleglosc *= 800;
            }
            else
            {
                return 0;
            }
        }
        public double liczCzas(double odl) //metoda licząca czas, korzystająca z odległości
        {
            czas = odl / 400;
            return czas;
        }
    }
}
