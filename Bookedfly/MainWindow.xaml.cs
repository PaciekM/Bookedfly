using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bookedfly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Serializable]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Program.wczytLotniska();
            Program.wczytSamolotyDlugo();
            Program.wczytSamolotyKrotko();
            Program.wczytOsob();
            Program.wczytFirmy();
            Program.wczytTrasy();
            Program.wczytLoty();
            Program.wczytBilety();
            this.Title = "BOOKEDFLY";
            UpdateLayout();
        }
        public void ZarzadzajLotnisko(object sender, RoutedEventArgs e)
        {
            Dodawanie.Content = new ZarzadzajLotnisko();
        }
        public void ZarzadzajSamoloty(object sender, RoutedEventArgs e)
        {
            Dodawanie.Content = new ZarzadzajSamoloty();
        }
        public void ZarzadzajKlientami(object sender, RoutedEventArgs e)
        {
            Dodawanie.Content = new ZarzadzajKlientami();
        }
        private void ZarzadzajTrasami(object sender, RoutedEventArgs e)
        {
            Dodawanie.Content = new ZarzadzajTrasami();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Program.ZapiszLotniska();
            Program.ZapiszOsoby();
            Program.ZapiszFirmy();
            Program.ZapiszSamolotyDlugo();
            Program.ZapiszSamolotyKrotko();
            Program.ZapiszTrasy();
            Program.ZapiszLoty();
            Program.ZapiszBilety();
        }
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            imgLoadingImage.Position = new TimeSpan(0, 0, 1);
            imgLoadingImage.Play();
        }
        private void DoborSamolotu(object sender, RoutedEventArgs e)
        {
            Dodawanie.Content = new DoborSamolotu();
        }
        private void WyswietlLoty(object sender, RoutedEventArgs e)
        {
            Dodawanie.Content = new WyswietlLoty();
        }
        private void PowielanieDnia(object sender, RoutedEventArgs e)
        {
            Dodawanie.Content = new PowielanieDnia();
        }
        private void GenerujBilet(object sender, RoutedEventArgs e)
        {
            Dodawanie.Content = new GenerujBilet();
        }
        private void PrzegladBiletow(object sender, RoutedEventArgs e)
        {
            Dodawanie.Content = new PrzegladBiletow();
        }
        private void SprzedajBilet(object sender, RoutedEventArgs e)
        {
            Dodawanie.Content = new SprzedajBilet();
        }
    }
}
