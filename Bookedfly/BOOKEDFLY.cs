using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bookedfly
{
    [Serializable()]
    class BOOKEDFLY
    {
        [field: NonSerializedAttribute()]
        public event EventHandler BrazierCuttoffChanged;
        public static ObservableCollection<Lotnisko> ListaLotnisk = new ObservableCollection<Lotnisko>(); //lista lotnisk
        public static ObservableCollection <Osoba> ListaOsob = new ObservableCollection<Osoba>(); //lista osób
        public static ObservableCollection<FirmaPos> ListaFirm = new ObservableCollection<FirmaPos>(); //lista firm
        public static ObservableCollection<Dlugodystansowy> Samolotydlugo = new ObservableCollection<Dlugodystansowy>(); //lista samolotów długodystansowych
        public static ObservableCollection<Krotkodystansowy> Samolotykrotko = new ObservableCollection<Krotkodystansowy>(); //lista samolotów krótkodystansowych
        public static ObservableCollection<Lot> ListaLotow = new ObservableCollection<Lot>(); //lista lotów
        public static ObservableCollection<Trasa> ListaTras = new ObservableCollection<Trasa>(); //lista tras
        public static ObservableCollection<Bilet> pulaBiletow = new ObservableCollection<Bilet>(); //lista z pulą biletów
        
        public static ObservableCollection<Krotkodystansowy> dobierzSamolotyKrotko(double odleglosc)
        {
            ObservableCollection<Krotkodystansowy> wybrane = new ObservableCollection<Krotkodystansowy>();
            foreach (Krotkodystansowy kr in Samolotykrotko)
            {
                if(kr.Odleglosc >= odleglosc)
                {
                    wybrane.Add(kr);
                }
            }
            return wybrane;
        }
        public static ObservableCollection<Dlugodystansowy> dobierzSamolotyDlugo(double odleglosc)
        {
            ObservableCollection<Dlugodystansowy> wybrane = new ObservableCollection<Dlugodystansowy>();
            foreach (Dlugodystansowy dl in Samolotydlugo)
            {
                if (dl.Odleglosc >= odleglosc)
                {
                    wybrane.Add(dl);
                }
            }
            return wybrane;
        }
        public static void dodajLotnisko(Lotnisko l) //metoda dodająca lotnisko
        {
            ListaLotnisk.Add(l);
        }
        public static void usunLotnisko(int l) //metoda usuwająca lotnisko
        {
            ListaLotnisk.RemoveAt(l);
        }
        public static void dodajOsobe(Osoba oo) //metoda dodająca osobę
        {
            ListaOsob.Add(oo);
        }
        public static void usunOsobe(int l) //metoda usuwająca osobę
        {
            ListaOsob.RemoveAt(l);
        }
        public static void dodajFirme(FirmaPos ff) //metoda dodająca firmę
        {
            ListaFirm.Add(ff);
        }
        public static void usunFirme(int l) //metoda usuwająca firmę
        {
            ListaFirm.RemoveAt(l);
        }
        public static void dodajTrase(Trasa t) //metoda dodająca trasę
        {
            ListaTras.Add(t);
        }
        public static void usunTrase(int t) //metoda usuwająca trasę
        {
            ListaTras.RemoveAt(t);
        }
        public static void dodajSamolotD(Dlugodystansowy s) //metoda dodająca samoloty długodystansowe
        {
            Samolotydlugo.Add(s);
        }
        public static void usunSamolotD(int s) //metoda usuwająca samoloty długodystansowe
        {
            Samolotydlugo.RemoveAt(s);
        }  
        public static void dodajSamolotK(Krotkodystansowy s) //metoda dodająca samoloty krótkodystansowe
        {
            Samolotykrotko.Add(s);
        }
        public static void usunSamolotK(int s) //metoda usuwająca samoloty krótkodystansowe
        {
            Samolotykrotko.RemoveAt(s);
        }
 
        public static void generujLot(Lot l) //metoda generująca lot
        {
            ListaLotow.Add(l);
        }
        public static void usunLot(Lot l) //metoda generująca lot
        {
            ListaLotow.Remove(l);
        }
        public Lot powielanieDzien(Data d, Lot l) //metoda powielająca dany dzień z dniem wybranym z listy
        {
            Lot nowy = new Lot();
            //nowy.getData(d);
            //nowy.getSamolot(l.samolot);
            //nowy.getTrasa(l.trasaLotu);
            return nowy;
        }      
        public static void dodajBilet(Bilet b) //metoda dodająca bilet
        {
            pulaBiletow.Add(b);
        }
        public static void usunBilet(Bilet b)
        {
            pulaBiletow.Remove(b);
        }
    }
}
