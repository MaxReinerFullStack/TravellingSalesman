using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    class Ort
    {
        double x, y;

        static int zuletztVergebeneSeriennummer;
        string name;
        static Random zufall = new Random();
        public double X { get { return x;  } }

        public double Y { get { return y; } }
        public Ort()
        {
            
            x = zufall.NextDouble();
            y = zufall.NextDouble();
            zuletztVergebeneSeriennummer++;
            name = "Ort Nr. " + zuletztVergebeneSeriennummer;

        }
    }
}
