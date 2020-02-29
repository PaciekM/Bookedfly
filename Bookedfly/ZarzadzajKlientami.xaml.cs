using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Bookedfly
{
    /// <summary>
    /// Logika interakcji dla klasy ZarzadzajOsoby.xaml
    /// </summary>
    public partial class ZarzadzajKlientami : Page
    {
        public ZarzadzajKlientami()
        {
            InitializeComponent();
            this.Title = "Zarządzanie klientami";
            this.DataContext = this;
            Osoby.ItemsSource = BOOKEDFLY.ListaOsob;
            Firmy.ItemsSource = BOOKEDFLY.ListaFirm;
        }

        private void DodajOsobe(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox)Imie;
                TextBox textBox2 = (TextBox)Nazwisko;
                if (String.IsNullOrEmpty(textBox.Text) || String.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Pola są puste, nie można dodać osoby.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string Oimie = textBox.Text;
                    string Onazwisko = textBox2.Text;
                    Osoba osoba = new Osoba
                    {
                        Imie = Oimie,
                        Nazwisko = Onazwisko
                    };
                    BOOKEDFLY.dodajOsobe(osoba);
                    MessageBox.Show("Dodano osobę.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nieprawidłowe dane.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DodajFirme(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox)Nazwa;
                TextBox textBox2 = (TextBox)KRS;
                if (String.IsNullOrEmpty(textBox.Text) || String.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Pola są puste, nie można dodać firmy.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string nazwa = textBox.Text;
                    int krs = Int32.Parse(textBox2.Text);
                    int dlugosc = (int)Math.Floor(Math.Log10(krs)) + 1;
                    if (dlugosc != 10)
                    {
                        MessageBox.Show("Numer KRS powinien być dziesięciocyfrowy.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        FirmaPos firma = new FirmaPos
                        {
                            Nazwa = nazwa,
                            KRS = krs
                        };
                        BOOKEDFLY.dodajFirme(firma);
                        MessageBox.Show("Dodano firmę.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nieprawidłowe dane.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UsunFirme(object sender, RoutedEventArgs e)
        {
            try
            {
                int selectedIndex = Firmy.SelectedIndex;
                BOOKEDFLY.usunFirme(selectedIndex);
                MessageBox.Show("Usunięto firmę.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd w skasowaniu firmy.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UsunOsobe(object sender, RoutedEventArgs e)
        {
            try
            {
                int selectedIndex = Osoby.SelectedIndex;
                BOOKEDFLY.usunOsobe(selectedIndex);
                MessageBox.Show("Usunięto osobę.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd w skasowaniu osoby.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
