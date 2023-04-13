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
    public partial class FrmStartowy : Form
    {
        ManagerZawodnikow mz = new ManagerZawodnikow();

        public FrmStartowy()
        {
            InitializeComponent();

            mz.WczytajZawodnikow();
            cbKraje.DataSource = mz.PodajKraje();
        }

        private void cbKraje_SelectedIndexChanged(object sender, EventArgs e)
        {
            Odswiez();
        }

        public void Odswiez()
        {
            string zaznaczonyKraj = (string)cbKraje.SelectedItem;

            if (zaznaczonyKraj != null)
            {
                lbDane.DataSource = mz.PodajZawodnikow(zaznaczonyKraj);
                lbDane.DisplayMember = "ImieNazwiskoKraj";

                double wzrost = mz.PodajSredniWzrost(zaznaczonyKraj);
                //lblSredniWzrost.Text = $"średni wzrost: {wzrost}";
                lblSredniWzrost.Text = string.Format("średni wzrost {0:0.00}", wzrost);
            }
        }

        private void btnSzczegoly_Click(object sender, EventArgs e)
        {
            Zawodnik zaznaczony = (Zawodnik)lbDane.SelectedItem;

            FrmSzczegoly frmSzczegoly = new FrmSzczegoly(zaznaczony,mz,this, TrybOkienka.Edycja);
            frmSzczegoly.Show();
           
        }

        private void btnUsunIPokaz_Click(object sender, EventArgs e)
        {
            Zawodnik zaznaczony = (Zawodnik)lbDane.SelectedItem;
            FrmSzczegoly frmSzczegoly = new FrmSzczegoly(zaznaczony,mz, this, TrybOkienka.Usuwanie);
            frmSzczegoly.Show();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            //  FrmSzczegoly frmSzczegoly = new FrmSzczegoly(null,mz,this);
            FrmSzczegoly frmSzczegoly = new FrmSzczegoly(mz, this, TrybOkienka.Dodawanie);
            frmSzczegoly.Show();
        }

     

        private void btnUsun_Click(object sender, EventArgs e)
        {
            Zawodnik zaznaczony = (Zawodnik)lbDane.SelectedItem;

            DialogResult dr= MessageBox.Show($"Czy napewno chcesz usunąć zawodnika {zaznaczony.ImieNazwiskoKraj} ?", "Usuwanie",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dr == DialogResult.Yes)
            {
                mz.Usun(zaznaczony.Id_zawodnika);
                Odswiez();
            }
           
        }

    
    }
}
