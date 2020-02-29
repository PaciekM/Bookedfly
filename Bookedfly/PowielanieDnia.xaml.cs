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
    /// Logika interakcji dla klasy PowielanieDnia.xaml
    /// </summary>
    public partial class PowielanieDnia : Page
    {
        public PowielanieDnia()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Title = "Powielanie dnia";
            Loty.ItemsSource = BOOKEDFLY.ListaLotow;
        }
        private void PowielDzien(object sender, RoutedEventArgs e)
        {
            try
            {
                Lot lot = (Lot)Loty.SelectedItem;
                Lot powielony = new Lot();
                int godzina = lot.dataLotu.godzina;
                int minuta = lot.dataLotu.minuta;
                powielony.samolot = lot.samolot;
                powielony.trasaLotu = lot.trasaLotu;
                powielony.dataLotu = new Data(Kalendarz.SelectedDate.Value.Year, Kalendarz.SelectedDate.Value.Month, Kalendarz.SelectedDate.Value.Day, godzina, minuta);
                BOOKEDFLY.generujLot(powielony);
                MessageBox.Show("Powielono dzień.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd w powieleniu dnia.","Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
