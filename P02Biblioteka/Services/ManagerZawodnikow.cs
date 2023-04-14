using P02Biblioteka.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace P02Biblioteka.Services
{
    public class ManagerZawodnikow
    {
        private List<Zawodnik> zawodnicyCache;
        private const string url = "C:\\dane\\zawodnicy.txt";

        public void Edytuj(Zawodnik edytowany)
        {
            for (int i = 0; i < zawodnicyCache.Count; i++)
                if (zawodnicyCache[i].Id_zawodnika == edytowany.Id_zawodnika)
                    zawodnicyCache[i] = edytowany;

            Zapisz();
        }

        public void Zapisz()
        {
            const string naglowek = "id_zawodnika;id_trenera;imie;nazwisko;kraj;data urodzenia;wzrost;waga";

            string szablon = "{0};{1};{2};{3};{4};{5};{6};{7}";

            StringBuilder sb = new StringBuilder(naglowek + Environment.NewLine);
            foreach (var z in zawodnicyCache)
            {
                string wiersz = string.Format(szablon,
                    z.Id_zawodnika, z.Id_trenera, z.Imie, z.Nazwisko, z.Kraj, z.DataUrodzenia.ToString("yyyy-MM-dd"), z.Wzrost, z.Waga);
                sb.AppendLine(wiersz);
            }
            File.WriteAllText(url, sb.ToString(), Encoding.UTF8);
        }

        public Zawodnik[] WczytajZawodnikow()
        {
            WebClient wc = new WebClient();
            string dane = wc.DownloadString(url);

            string[] wiersze = dane.Split(new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            Zawodnik[] zawodnicy = new Zawodnik[wiersze.Length - 1];

            for (int i = 1; i < wiersze.Length; i++)
            {
                string[] komorki = wiersze[i].Split(';');
                Zawodnik z = new Zawodnik();
                z.Id_zawodnika = Convert.ToInt32(komorki[0]);


                if (!string.IsNullOrEmpty(komorki[1]))
                    z.Id_trenera = Convert.ToInt32(komorki[1]);

                z.Imie = komorki[2];
                z.Nazwisko = komorki[3];
                z.Kraj = komorki[4];
                z.DataUrodzenia = Convert.ToDateTime(komorki[5]);
                z.Wzrost = Convert.ToInt32(komorki[6]);
                z.Waga = Convert.ToInt32(komorki[7]);
                zawodnicy[i - 1] = z;
            }

            zawodnicyCache = zawodnicy.ToList();
            return zawodnicy;

        } 

        public string[] PodajKraje()
        {
            // Zawodnik[] zawodnicy = WczytajZawodnikow();

            if (zawodnicyCache == null)
                throw new Exception("Najpierw wczytaj zawodnikow");

            List<string> kraje = new List<string>();

            foreach (var z in zawodnicyCache)
                if (!kraje.Contains(z.Kraj))
                    kraje.Add(z.Kraj);

            return kraje.ToArray();
        }

        public Zawodnik[] PodajZawodnikow(string kraj)
        {
            List<Zawodnik> zawodnicy = new List<Zawodnik>();

            foreach (var z in zawodnicyCache)
                if (z.Kraj == kraj)
                    zawodnicy.Add(z);

            return zawodnicy.ToArray();
        }

        public double PodajSredniWzrost(string kraj)
        {
            Zawodnik[] zawodnicy = PodajZawodnikow(kraj);

            double suma = 0;
            foreach (var z in zawodnicy)
                suma += z.Wzrost;

            return suma / zawodnicy.Length;
        }

        public void Usun(int id_zawodnika)
        {
            Zawodnik doUsunieca = null;
            foreach (var z in zawodnicyCache)
                if (z.Id_zawodnika == id_zawodnika)
                {
                    doUsunieca = z;
                    break;
                }

            zawodnicyCache.Remove(doUsunieca);
            Zapisz();
        }

        public void Dodaj(Zawodnik wyswietlany)
        {
            int maksId = 0;
            foreach (var z in zawodnicyCache)
                if (z.Id_zawodnika > maksId)
                    maksId = z.Id_zawodnika;

            wyswietlany.Id_zawodnika = maksId + 1;

            zawodnicyCache.Add(wyswietlany);
            Zapisz();
        }

        public void Test()
        {

        }
    }
}
