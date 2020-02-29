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
    /// Logika interakcji dla klasy PrzegladBiletow.xaml
    /// </summary>
    public partial class PrzegladBiletow : Page
    {
        public PrzegladBiletow()
        {
            InitializeComponent();
            this.DataContext = this;
            Bilety.ItemsSource = BOOKEDFLY.pulaBiletow;
            this.Title = "Przegląd biletów";
        }

        private void UsunBilety(object sender, RoutedEventArgs e)
        {
            try
            {
                Bilet bilet = (Bilet)Bilety.SelectedItem;
                BOOKEDFLY.usunBilet(bilet);
                MessageBox.Show("Usunięto bilety.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd w skasowaniu biletów.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
