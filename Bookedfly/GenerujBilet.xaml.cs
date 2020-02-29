using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bookedfly
{
    /// <summary>
    /// Logika interakcji dla klasy GenerujBilet.xaml
    /// </summary>
    public partial class GenerujBilet : Page
    {
        public GenerujBilet()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Title = "Generowanie puli biletów";
            Loty.ItemsSource = BOOKEDFLY.ListaLotow;
        }

        private void GenerujBilety(object sender, RoutedEventArgs e)
        {
            try
            {
                Lot lot = (Lot)Loty.SelectedItem;
                Bilet bilet = new Bilet();
                bilet.lot = lot;
                bilet.liczbaMiejsc = lot.samolot.IloscMiejsc;
                BOOKEDFLY.dodajBilet(bilet);
                MessageBox.Show("Pomyślnie wygenerowano pulę biletów.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd w wygenerowaniu biletów.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
