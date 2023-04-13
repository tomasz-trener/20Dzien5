using P01AplikacjaZawodnicy.Domain;
using P01AplikacjaZawodnicy.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P01AplikacjaZawodnicy
{
    public partial class FrmSzczegoly : Form
    {
        private Zawodnik wyswietlany;
        private ManagerZawodnikow mz;

        public FrmSzczegoly(Zawodnik zawodnik, ManagerZawodnikow mz)
        {
            InitializeComponent();
           
            wyswietlany = zawodnik;
            this.mz = mz;
            txtImie.Text = wyswietlany.Imie;
            txtNazwisko.Text = wyswietlany.Nazwisko;
            txtKraj.Text = wyswietlany.Kraj;
            dtpDataUr.Value = wyswietlany.DataUrodzenia;
            numWaga.Value = wyswietlany.Waga;
            numWzrost.Value = wyswietlany.Wzrost;
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            wyswietlany.Imie = txtImie.Text;
            wyswietlany.Nazwisko = txtNazwisko.Text;
            wyswietlany.Kraj = txtKraj.Text;
            wyswietlany.DataUrodzenia = dtpDataUr.Value;
            wyswietlany.Waga = Convert.ToInt32(numWaga.Value);
            wyswietlany.Wzrost = Convert.ToInt32(numWzrost.Value);

            mz.Edytuj(wyswietlany);
        }
    }
}
