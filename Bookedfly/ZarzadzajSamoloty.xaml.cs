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
    /// Logika interakcji dla klasy ZarzadzajSamoloty.xaml
    /// </summary>
    public partial class ZarzadzajSamoloty : Page
    {
        public ZarzadzajSamoloty()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Title = "Zarządzanie samolotami";
            Dlugo.ItemsSource = BOOKEDFLY.Samolotydlugo;
            Krotko.ItemsSource = BOOKEDFLY.Samolotykrotko;
        }
        private void DodajSamolot(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox)Nazwa;
                TextBox textBox2 = (TextBox)Nazwa_firmy;
                TextBox textBox3 = (TextBox)Zasieg;
                TextBox textBox4 = (TextBox)Ilosc;
                if(String.IsNullOrEmpty(textBox.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
                {
                    MessageBox.Show("Pola są puste, nie można dodać samolotu.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string nazwa = textBox.Text;
                    string nazwa_firmy = textBox2.Text;
                    double odleglosc = Double.Parse(textBox3.Text);
                    int ilosc_miejsc = Int32.Parse(textBox4.Text);
                    if (odleglosc < 2000)
                    {
                        Krotkodystansowy samolot = new Krotkodystansowy(nazwa, nazwa_firmy, odleglosc, ilosc_miejsc);
                        BOOKEDFLY.dodajSamolotK(samolot);
                        MessageBox.Show("Dodano samolot krótkodystansowy.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        Dlugodystansowy samolot = new Dlugodystansowy(nazwa, nazwa_firmy, odleglosc, ilosc_miejsc);
                        BOOKEDFLY.dodajSamolotD(samolot);
                        MessageBox.Show("Dodano samolot długodystansowy.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Nieprawidłowa liczba w zasięgu lub ilości miejsc", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void usunDlugo(object sender, RoutedEventArgs e)
        {
            try
            {
                int selectedIndex = Dlugo.SelectedIndex;
                BOOKEDFLY.usunSamolotD(selectedIndex);
                MessageBox.Show("Usunięto samolot.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd w skasowaniu samolotu.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void usunKrotko(object sender, RoutedEventArgs e)
        {
            try
            {
                int selectedIndex = Krotko.SelectedIndex;
                BOOKEDFLY.usunSamolotK(selectedIndex);
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd w skasowaniu samolotu.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
