using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logika interakcji dla klasy ZarzadzajLotnisko.xaml
    /// </summary>
    public partial class ZarzadzajLotnisko : Page
    {
        public ZarzadzajLotnisko()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Title = "Zarządzanie lotniskami";
            Lotniska.ItemsSource = BOOKEDFLY.ListaLotnisk;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox)Miasto;
                TextBox textBox2 = (TextBox)Wspl;
                if (String.IsNullOrEmpty(textBox.Text) || String.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Pola są puste, nie można dodać lotniska.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string miasto = textBox.Text;
                    double wspl = Double.Parse(textBox2.Text);
                    Lotnisko l = new Lotnisko
                    {
                        Miasto = miasto,
                        Wspl = wspl
                    };
                    BOOKEDFLY.dodajLotnisko(l);
                    MessageBox.Show("Dodano lotnisko.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Nieprawidłowe współrzędne ", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int selectedIndex = Lotniska.SelectedIndex;
                BOOKEDFLY.usunLotnisko(selectedIndex);
                MessageBox.Show("Usunięto lotnisko.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd w skasowaniu lotniska.", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private int sortColumn = -1;
    }
}
