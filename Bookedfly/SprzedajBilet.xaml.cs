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
    /// Logika interakcji dla klasy SprzedajBilet.xaml
    /// </summary>
    public partial class SprzedajBilet : Page
    {
        public SprzedajBilet()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Title = "Sprzedaj bilet";
            Bilety.ItemsSource = BOOKEDFLY.pulaBiletow;
            Osoby.ItemsSource = BOOKEDFLY.ListaOsob;
            Firmy.ItemsSource = BOOKEDFLY.ListaFirm;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Osoby.ItemsSource);
                view.Filter = OsobaFilter;
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(Firmy.ItemsSource);
            view2.Filter = FirmaFilter;

        }
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Osoby.ItemsSource).Refresh();
        }
        private void txtFilter_TextChanged2(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Firmy.ItemsSource).Refresh();
        }
        private bool OsobaFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Osoba).Nazwisko.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private bool FirmaFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter2.Text))
                return true;
            else
                return ((item as FirmaPos).Nazwa.IndexOf(txtFilter2.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void ustawWidzialnoscOsoby(System.Windows.Visibility s)
        {
            Osoby.Visibility = s;
            filtrujOsoby.Visibility = s;
            txtFilter.Visibility = s;
            PytanieIle.Visibility = s;
            ile.Visibility = s;
            SprzedajPrzycisk.Visibility = s;
            Niema.Visibility = s;
            Dodaj.Visibility = s;
        }
        private void ustawWidzialnoscFirmy(System.Windows.Visibility s)
        {
            filtrujFirmy.Visibility = s;
            PytanieIle.Visibility = s;
            txtFilter2.Visibility = s;
            PytanieIle.Visibility = s;
            ile.Visibility = s;
            SprzedajPrzycisk.Visibility = s;
            NiemaF.Visibility = s;
            DodajF.Visibility = s;
        }
        private void Potwierdz(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)osoba.IsChecked)
                {
                    Firmy.Visibility = System.Windows.Visibility.Hidden;
                    ustawWidzialnoscFirmy(Visibility.Hidden);
                    ustawWidzialnoscOsoby(Visibility.Visible);

                }
                else if ((bool)firma.IsChecked)
                {
                    Firmy.Visibility = System.Windows.Visibility.Visible;
                    ustawWidzialnoscOsoby(Visibility.Hidden);
                    ustawWidzialnoscFirmy(Visibility.Visible);
                }
                else
                {
                    MessageBox.Show("Nie zaznaczono podmiotu kupującego", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd w sprzedaży biletu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Sprzedaj(object sender, RoutedEventArgs e)
        {
            try
            {
                Bilet bilet = (Bilet)Bilety.SelectedItem;
                int index = Bilety.SelectedIndex;
                TextBox textBox = (TextBox)ile;
                int liczba = Int32.Parse(textBox.Text);
                if (liczba <= bilet.liczbaMiejsc)
                {
                    bilet.odejmijMiejsce(liczba);
                    if(bilet.liczbaMiejsc == 0)
                    {
                        BOOKEDFLY.usunBilet(bilet);
                        CollectionViewSource.GetDefaultView(Bilety.ItemsSource).Refresh();
                    }
                    if (bilet.liczbaMiejsc < 0)
                    {
                        MessageBox.Show("Błąd w sprzedaży biletu.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        BOOKEDFLY.pulaBiletow[index] = bilet;
                        MessageBox.Show("Sprzedano " + liczba + " biletów.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                        CollectionViewSource.GetDefaultView(Bilety.ItemsSource).Refresh();
                    }
                }
                else { MessageBox.Show("Błąd w sprzedaży biletu.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning); }
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd w sprzedaży biletu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DodajKlienta(object sender, MouseButtonEventArgs e)
        {
            ZarzadzajKlientami zk = new ZarzadzajKlientami();
            NavigationService.Navigate(zk);
        }

    }
}
