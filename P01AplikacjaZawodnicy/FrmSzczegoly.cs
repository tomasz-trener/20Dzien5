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

    public enum TrybOkienka
    {
        Dodawanie,
        Edycja,
        Usuwanie
    }
    public partial class FrmSzczegoly : Form
    {
   
        private Zawodnik wyswietlany;
        private ManagerZawodnikow mz;
        private FrmStartowy frmStartowy;
        private TrybOkienka trybOkienka;
        //private TrybOkienka trybOkienka => wyswietlany == null ? TrybOkienka.Dodawanie : TrybOkienka.Edycja;
        // private TrybOkienka trybOkienka
        //{
        //    get
        //    {
        //        if (wyswietlany==null)
        //        {
        //            return TrybOkienka.Dodawanie;
        //        }
        //        else
        //        {
        //            return TrybOkienka.Edycja;
        //        }
        //    }
        //}

        //tryb dodawania nowego zawodnika
        public FrmSzczegoly(ManagerZawodnikow mz, FrmStartowy frmStartowy, TrybOkienka trybOkienka)
        {
            InitializeComponent();

            this.trybOkienka = trybOkienka;
            this.mz = mz;
            this.frmStartowy = frmStartowy;

            if (trybOkienka == TrybOkienka.Edycja || trybOkienka == TrybOkienka.Dodawanie)
            {
                btnZapisz.Visible = true;
            }

            if (trybOkienka == TrybOkienka.Usuwanie)
            {
                btnUsun.Visible = true;

                //txtImie.Enabled = false;
                //txtNazwisko.Enabled = false;
                //txtKraj.Enabled = false;
                //....
                foreach (Control c in pnlKontrolkiDoEdycji.Controls)
                    if(!(c is Label))
                        c.Enabled = false;
                
            }

        }

        // tryb edycji lub usuwania
        public FrmSzczegoly(Zawodnik zawodnik, ManagerZawodnikow mz, FrmStartowy frmStartowy, TrybOkienka trybOkienka) : this(mz,frmStartowy, trybOkienka)
        {
            wyswietlany = zawodnik;
            txtImie.Text = wyswietlany.Imie;
            txtNazwisko.Text = wyswietlany.Nazwisko;
            txtKraj.Text = wyswietlany.Kraj;
            dtpDataUr.Value = wyswietlany.DataUrodzenia;
            numWaga.Value = wyswietlany.Waga;
            numWzrost.Value = wyswietlany.Wzrost;
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {    
            if (trybOkienka == TrybOkienka.Edycja)
            {
                zczytajDaneZkontrolek();
                mz.Edytuj(wyswietlany);
            }
            else if (trybOkienka == TrybOkienka.Dodawanie)
            {
                wyswietlany = new Zawodnik();
                zczytajDaneZkontrolek();
                mz.Dodaj(wyswietlany);
            }
               
            
            frmStartowy.Odswiez();
            this.Close();
        }

        private void zczytajDaneZkontrolek()
        {
            wyswietlany.Imie = txtImie.Text;
            wyswietlany.Nazwisko = txtNazwisko.Text;
            wyswietlany.Kraj = txtKraj.Text;
            wyswietlany.DataUrodzenia = dtpDataUr.Value;
            wyswietlany.Waga = Convert.ToInt32(numWaga.Value);
            wyswietlany.Wzrost = Convert.ToInt32(numWzrost.Value);
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Czy napewno chcesz usunąć zawodnika {wyswietlany.ImieNazwiskoKraj} ?", "Usuwanie",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                mz.Usun(wyswietlany.Id_zawodnika);
                frmStartowy.Odswiez();
                this.Close();
            }
        }
    }
}
