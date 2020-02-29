using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Bookedfly
{
    class Program
    {
        public static void wczytOsob() //metoda wczytująca osoby z pliku "Osoba.txt"
        {
            String line;
            StreamReader sr = new StreamReader("txt/Osoba.txt");
            while ((line = sr.ReadLine()) != null)
            {
                string[] wczytanie = line.Split(" ");
                Osoba osoba = new Osoba();
                String n1 = wczytanie[0];
                String naz1 = wczytanie[1];
                osoba.Imie = n1;
                osoba.Nazwisko = naz1;
                BOOKEDFLY.dodajOsobe(osoba);
            }
            sr.Close();
        }
        public static void wczytFirmy() //metoda wczytująca firmy z pliku "Firma.txt"
        {
            String line;
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = " ";
            StreamReader sr = new StreamReader("txt/Firma.txt");
            while ((line = sr.ReadLine()) != null)
            {
                string[] wczytanie = line.Split(" ");
                FirmaPos f = new FirmaPos();
                String no = wczytanie[0];
                double naz1 = double.Parse(wczytanie[1], nfi);
                f.Nazwa = no;
                f.KRS = naz1;
                BOOKEDFLY.dodajFirme(f);
            }
            sr.Close();
        }
        public static void wczytLotniska() //metoda wczytująca lotniska z pliku "Lotniska.txt"
        {
            String line;
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = " ";
            StreamReader sr = new StreamReader("txt/Lotniska.txt");
            while ((line = sr.ReadLine()) != null)
            {
                String[] wczytanie = line.Split(" ");
                String miasto = wczytanie[0];
                // Konwertuje String na double 
                String punk = wczytanie[1];
                double punkt = Convert.ToDouble(punk);
                Lotnisko l = new Lotnisko
                {
                    Miasto = miasto,
                    Wspl = punkt
                };
                BOOKEDFLY.dodajLotnisko(l);
            }
            sr.Close();
        }
        public static void wczytSamolotyKrotko() //metoda wczytująca samoloty krótkodystansowe z pliku "Skrotko.txt"
        {
            String line;
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = " ";
            StreamReader sr = new StreamReader("txt/SKrotko.txt");
            while ((line = sr.ReadLine()) != null)
            {
                string[] wczytanie = line.Split(" ");
                String nazwa = wczytanie[0];
                String firma = wczytanie[1];
                double zasieg = double.Parse(wczytanie[2], nfi);
                int miejsca = int.Parse(wczytanie[3], nfi);
                Krotkodystansowy kr = new Krotkodystansowy(nazwa, firma, zasieg, miejsca);
                BOOKEDFLY.dodajSamolotK(kr);
            }
            sr.Close();
        }
        static public void wczytSamolotyDlugo() //metoda wczytująca samoloty długodystansowe z pliku "SDlugo.txt"
        {
            String line;
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = " ";
            StreamReader sr = new StreamReader("txt/SDlugo.txt");
            while ((line = sr.ReadLine()) != null)
            {
                string[] wczytanie = line.Split(" ");
                String nazwa = wczytanie[0];
                String firma = wczytanie[1];
                double zasieg = double.Parse(wczytanie[2], nfi);
                int miejsca = int.Parse(wczytanie[3], nfi);
                Dlugodystansowy dl = new Dlugodystansowy(nazwa, firma, zasieg, miejsca);
                BOOKEDFLY.dodajSamolotD(dl);
            }
            sr.Close();
        }
        public static void wczytTrasy()
        {
            try
            {
                using (Stream stream = File.Open("bin/Trasy.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    List<Trasa> tempTrasa = (List<Trasa>)bin.Deserialize(stream);
                    foreach (Trasa t in tempTrasa)
                    {
                        BOOKEDFLY.dodajTrase(t);
                    }
                }
            }
            catch (IOException)
            {
            }
        }
        public static void wczytLoty()
        {
            try
            {
                using (Stream stream = File.Open("bin/Loty.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    List<Lot> tempLot = (List<Lot>)bin.Deserialize(stream);
                    foreach (Lot lot in tempLot)
                    {
                        BOOKEDFLY.generujLot(lot);
                    }
                }
            }
            catch (IOException)
            {
            }
        }
    
    public static void wczytBilety()
    {
        try
        {
            using (Stream stream = File.Open("bin/Bilety.bin", FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                List<Bilet> tempBilet = (List<Bilet>)bin.Deserialize(stream);
                foreach (Bilet bilet in tempBilet)
                {
                    BOOKEDFLY.dodajBilet(bilet);
                }
            }
        }
        catch (IOException)
        {
        }
    }

        public static void ZapiszLotniska()
        {
            using StreamWriter sw4 = new StreamWriter("txt/Lotniska.txt");
            foreach (Lotnisko LL in BOOKEDFLY.ListaLotnisk)
            {
                sw4.WriteLine("{0} {1} ", LL.Miasto, LL.Wspl);
            }
        }
        public static void ZapiszOsoby()
        {
            using StreamWriter sw = new StreamWriter("txt/Osoba.txt");
            foreach (Osoba Os in BOOKEDFLY.ListaOsob)
            {
                sw.WriteLine("{0} {1}", Os.Imie, Os.Nazwisko);
            }
        }
        public static void ZapiszFirmy()
        {
            using StreamWriter sw1 = new StreamWriter("txt/Firma.txt");
            foreach (FirmaPos F in BOOKEDFLY.ListaFirm)
            {
                sw1.WriteLine("{0} {1}", F.Nazwa, F.KRS);
            }
        }
        public static void ZapiszSamolotyDlugo()
        {
            using StreamWriter sw2 = new StreamWriter("txt/SDlugo.txt");
            foreach (Dlugodystansowy SK1 in BOOKEDFLY.Samolotydlugo)
            {
                sw2.WriteLine("{0} {1} {2} {3}", SK1.Nazwa, SK1.Firma, SK1.Odleglosc, SK1.IloscMiejsc);
            }
        }
        public static void ZapiszSamolotyKrotko()
        {
            using StreamWriter sw3 = new StreamWriter("txt/SKrotko.txt");
            foreach (Krotkodystansowy SD1 in BOOKEDFLY.Samolotykrotko)
            {
                sw3.WriteLine("{0} {1} {2} {3}", SD1.Nazwa, SD1.Firma, SD1.Odleglosc, SD1.IloscMiejsc);
            }
        }
        public static void ZapiszTrasy()
        {
            try
            {
                using (Stream stream = File.Open("bin/Trasy.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    List<Trasa> lista = new List<Trasa>();
                    foreach (Trasa t in BOOKEDFLY.ListaTras)
                    {
                        lista.Add(t);
                    }
                    bin.Serialize(stream, lista);
                }
            }
            catch (IOException)
            {

            }
        }
        public static void ZapiszLoty()
        {
            try
            {
                using (Stream stream = File.Open("bin/Loty.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    List<Lot> lista = new List<Lot>();
                    foreach (Lot lot in BOOKEDFLY.ListaLotow)
                    {
                        lista.Add(lot);
                    }
                    bin.Serialize(stream, lista);
                }
            }
            catch (IOException)
            {

            }
        }
        public static void ZapiszBilety()
        {
            try
            {
                using (Stream stream = File.Open("bin/Bilety.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    List<Bilet> lista = new List<Bilet>();
                    foreach (Bilet bilet in BOOKEDFLY.pulaBiletow)
                    {
                        lista.Add(bilet);
                    }
                    bin.Serialize(stream, lista);
                }
            }
            catch (IOException)
            {

            }
        }
    }
}
