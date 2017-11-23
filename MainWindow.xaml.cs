using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TravellingSalesman
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Zeichenfläche.Children.Clear();
            List<Ort> orte = new List<Ort>();
            for (int i = 0; i < 50; i++)
            {
                orte.Add(new Ort());

            }
            List<Tour> touren = new List<Tour>();
            for (int i = 0; i < 500; i++)
            {
                touren.Add(new Tour(orte));
            }

            // 20% sterben ab
            // Diese Plätze füllen mit Mutationen von vorhandenen.

            Random zufall = new Random();

            for (int i = 0; i < 100; i++)
            {
                touren = touren.OrderBy(x => x.berechneGesamtstrecke()).ToList();

                for (int j = 0; j < touren.Count / 5; j++)
                {
                    touren[touren.Count - 1 - j] = touren[zufall.Next(touren.Count * 4 / 5)].Mutiere();

                }
            }
            for (int i = 0; i < touren.Count; i++)
            {
                touren[i].Zeichne(Zeichenfläche, false);
            }
            touren.OrderBy(x => x.berechneGesamtstrecke()).First().Zeichne(Zeichenfläche, true);
        }
    }
}
