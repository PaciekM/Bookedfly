using System;
using System.Collections.Generic;
using System.Text;

namespace Bookedfly
{
    [Serializable ()]
    class Data
    {
        public int rok, miesiac, dzien, godzina, minuta;
        public Data(int r, int m, int d, int g, int min) //konstruktor parametrowy daty
        {
            rok = r;
            miesiac = m;
            dzien = d;
            godzina = g;
            minuta = min;
        }
        public override string ToString()
        {
            if(miesiac <10 && dzien>9)
            {
                return dzien + "/0" + miesiac + "/" + rok + " " + godzina + ":" + minuta;
            }
            else if(miesiac >9 && dzien < 10)
            {
                return "0"+dzien + "/" + miesiac + "/" + rok + " " + godzina + ":" + minuta;
            }
            else if(miesiac < 10 && dzien < 10)
            {
                return "0"+ dzien + "/0" + miesiac + "/" + rok + " " + godzina + ":" + minuta;
            }
            else
            {
                return dzien + "/" + miesiac + "/" + rok + " " + godzina + ":" + minuta;
            }
            
        }
    }
}
