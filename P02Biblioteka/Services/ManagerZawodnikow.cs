using P02Biblioteka.Domain;
using P04PolaczenieZBaza;
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
            PolaczenieZBaza pzb = new PolaczenieZBaza();
            object[][] dane = pzb.WyslijPolecenieSQL("select * from zawodnicy");

            Zawodnik[] zawodnicy = new Zawodnik[dane.Length];
            for ( int i = 0; i < dane.Length; i++)
            {
                var w = dane[i];
                Zawodnik z = new Zawodnik();
                z.Id_zawodnika = (int)w[0];
                if (w[1] != DBNull.Value) // null w c# różni się od null w bazie danych 
                    z.Id_trenera = (int)w[1];

                z.Imie = (string)w[2];
                z.Nazwisko = (string)w[3];
                z.Kraj= (string)w[4];

                if (w[5] !=  DBNull.Value)
                    z.DataUrodzenia = (DateTime)w[5];
                if (w[6] != DBNull.Value)
                    z.Wzrost = (int)w[6];
                if (w[7] != DBNull.Value)
                    z.Waga = (int)w[7];

                zawodnicy[i] = z;
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

        public void Dodaj(Zawodnik w)
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();

            string szablon = "insert into zawodnicy values ({0},'{1}','{2}','{3}','{4}',{5},{6})";

            string sql= string.Format(szablon,
                w.Id_trenera == null ? "null" : w.Id_trenera.ToString(),
                w.Imie, w.Nazwisko, w.Kraj, w.DataUrodzenia.ToString("yyyyMMdd"), w.Wzrost, w.Waga);

            pzb.WyslijPolecenieSQL(sql);
            WczytajZawodnikow();
        }

        public void Test()
        {

        }
    }
}
