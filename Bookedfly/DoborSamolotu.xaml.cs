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
using System.Collections.ObjectModel;

namespace Bookedfly
{
    /// <summary>
    /// Logika interakcji dla klasy DoborSamolotu.xaml
    /// </summary>
    public partial class DoborSamolotu : Page
    {
        public DoborSamolotu()
        {
            InitializeComponent();
            this.DataContext = this;
            Trasy.ItemsSource = BOOKEDFLY.ListaTras;
            this.Title = "Dobór samolotu";
        }
        private void DobierzSamolot(object sender, RoutedEventArgs e)
        {
            
        }
        private void GenerujLot(object sender, RoutedEventArgs e)
        {
            try
            {
                Lot lot = new Lot();
                TextBox textBox = (TextBox)Godzina;
                string[] godzina = textBox.Text.Split(':');
                int godz, min;
                int dlugosc = textBox.Text.Length;
                if (dlugosc != 5)
                {
                    MessageBox.Show("Nieprawidłowy format godziny.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    godz = Int32.Parse(godzina[0]);
                    min = Int32.Parse(godzina[1]);
                    lot.dataLotu = new Data(Kalendarz.SelectedDate.Value.Year, Kalendarz.SelectedDate.Value.Month, Kalendarz.SelectedDate.Value.Day, godz, min);
                    lot.trasaLotu = BOOKEDFLY.ListaTras.ElementAt(Trasy.SelectedIndex);
                    if (lot.trasaLotu.odleglosc < 2000)
                        lot.samolot = (Krotkodystansowy)Wybrane.SelectedItem;
                    else
                        lot.samolot = (Dlugodystansowy)Wybrane.SelectedItem;
                    BOOKEDFLY.generujLot(lot);
                    MessageBox.Show("Pomyślnie wygenerowano lot.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(IndexOutOfRangeException) 
            {
                MessageBox.Show("Nieprawidłowy format godziny.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd w utworzeniu lotu.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DobierzTrase(object sender, RoutedEventArgs e)
        {
            try
            {
                Trasa wybrana = BOOKEDFLY.ListaTras.ElementAt(Trasy.SelectedIndex);
                if (wybrana.odleglosc < 2000)
                {
                    ObservableCollection<Krotkodystansowy> Samolotykrotko = BOOKEDFLY.dobierzSamolotyKrotko(wybrana.odleglosc);
                    Wybrane.ItemsSource = Samolotykrotko;
                }
                else
                {
                    ObservableCollection<Dlugodystansowy> Samolotydlugo = BOOKEDFLY.dobierzSamolotyDlugo(wybrana.odleglosc);
                    Wybrane.ItemsSource = Samolotydlugo;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd w wyborze trasy.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
