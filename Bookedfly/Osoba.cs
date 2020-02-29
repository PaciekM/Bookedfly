using System;
using System.Collections.Generic;
using System.Text;

namespace Bookedfly
{
    [Serializable()]
    public class Osoba : Klient
    {
        public String Imie { get; set; }
        public String Nazwisko { get; set; }
    }
}
