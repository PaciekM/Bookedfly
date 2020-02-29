using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bookedfly
{
    [Serializable ()]
    public class Lotnisko
    {
        public String Miasto
        {
            get;set;
        }
    
        public double Wspl { get; set; }

    }
}
