using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
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
    /// Logika interakcji dla klasy ZarzadzajTrasami.xaml
    /// </summary>
    public partial class ZarzadzajTrasami : Page
    {
        public ZarzadzajTrasami()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Title = "Zarządzanie trasami";
            Miasto1.ItemsSource = BOOKEDFLY.ListaLotnisk;
            Miasto2.ItemsSource = BOOKEDFLY.ListaLotnisk;
            Trasy.ItemsSource = BOOKEDFLY.ListaTras;
        }

        private void DodajTrase(object sender, RoutedEventArgs e)
        {
            try
            {
                int indexM1 = Miasto1.SelectedIndex;
                int indexM2 = Miasto2.SelectedIndex;
                Lotnisko SLotnisko = BOOKEDFLY.ListaLotnisk.ElementAt(indexM1);
                Lotnisko KLotnisko = BOOKEDFLY.ListaLotnisk.ElementAt(indexM2);
                Trasa trasas = new Trasa(SLotnisko, KLotnisko);
                trasas.odleglosc = Math.Round(trasas.liczOdleglosc(SLotnisko.Wspl, KLotnisko.Wspl));
                trasas.czas = trasas.liczCzas(trasas.odleglosc);
                if (SLotnisko == KLotnisko)
                {
                    MessageBox.Show("Nie można utworzyć trasy. Zaznaczono dwa te same miasta.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if(BOOKEDFLY.ListaTras.IndexOf(new Trasa(SLotnisko,KLotnisko))>0)
                {
                    MessageBox.Show("Nie można utworzyć trasy. Trasa już istnieje.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    Trasa trasa = new Trasa(SLotnisko, KLotnisko);
                    trasa.odleglosc = Math.Round(trasa.liczOdleglosc(SLotnisko.Wspl, KLotnisko.Wspl));
                    trasa.czas = trasa.liczCzas(trasa.odleglosc);
                    BOOKEDFLY.dodajTrase(trasa);
                    MessageBox.Show("Dodano trasę.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd w utworzeniu trasy. Nie zaznaczono miast.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void usunTrase(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = Trasy.SelectedIndex;
                BOOKEDFLY.usunTrase(index);
                MessageBox.Show("Usunięto trasę.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd w skasowaniu trasy.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
