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
    /// Logika interakcji dla klasy WyswietlLoty.xaml
    /// </summary>
    public partial class WyswietlLoty : Page
    {
        public WyswietlLoty()
        {
            InitializeComponent();
            this.DataContext = this;
            Loty.ItemsSource = BOOKEDFLY.ListaLotow;
        }

        private void UsunLot(object sender, RoutedEventArgs e)
        {
            try
            {
                Lot lot = (Lot)Loty.SelectedItem;
                BOOKEDFLY.usunLot(lot);
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd w skasowaniu lotu.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
