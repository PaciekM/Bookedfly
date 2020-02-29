using System;
using System.Collections.Generic;
using System.Text;

namespace Bookedfly
{
    [Serializable ()]
    class Lot
    {
        public Data dataLotu { get; set; }
        public Trasa trasaLotu { get; set; }
        public Samolot samolot { get; set; }
    }
}
