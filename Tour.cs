using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TravellingSalesman
{
    class Tour
    {
        Ort[] orte;
        static Random zufall = new Random();

        private Tour()
        {

        }
        public Tour(List<Ort> orte)
        {
            List<Ort> orte0 = new List<Ort>();
            orte0.AddRange(orte);
            
            this.orte = new Ort[orte0.Count()];
            for (int i = 0; i < this.orte.Length; i++)
            {
                int z = zufall.Next(orte0.Count);
                this.orte[i] = orte0[z];
                orte0.RemoveAt(z);
            }

             
        }

        double gesamtstrecke = -1.0;
        public double berechneGesamtstrecke()
        {
            if (gesamtstrecke < 0.0)
            {
                double s = 0.0;
                for (int i = 0; i < orte.Length - 1; i++)
                {
                    double deltaX = orte[i + 1].X - orte[i].X;
                    double deltaY = orte[i + 1].Y - orte[i].Y;
                    s += Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
                }
                gesamtstrecke = s;
            }
            return gesamtstrecke;
        }

        internal void Zeichne(Canvas c, bool inRot)
        {
            Polyline p = new Polyline();
            if (inRot)
            {
                p.StrokeThickness = 10.0;
                p.Stroke = new SolidColorBrush(Color.FromArgb(50, 255, 0, 0));
            }
            else
                p.Stroke = new SolidColorBrush(Color.FromArgb(50, 0, 0, 255));
            for (int i = 0; i < orte.Length; i++)
            {
                p.Points.Add(new System.Windows.Point(orte[i].X * c.ActualWidth, orte[i].Y * c.ActualHeight));
            }
            c.Children.Add(p);
        }

        internal Tour Mutiere()
        {
            Tour t = new Tour();
            t.orte = (Ort[])orte.Clone();
            int z1 = zufall.Next(t.orte.Length);
            int z2 = zufall.Next(t.orte.Length);
            Ort ort = t.orte[z1];
            t.orte[z1] = t.orte[z2];
            t.orte[z2] = ort;

            return t;
        }
    }
}
