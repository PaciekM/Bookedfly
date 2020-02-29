using System;
using System.Collections.Generic;
using System.Text;

namespace Bookedfly
{
    [Serializable()]
    public class FirmaPos : Klient
    {
        public String Nazwa { get; set; }
        public double KRS { get; set; }
    }
}
