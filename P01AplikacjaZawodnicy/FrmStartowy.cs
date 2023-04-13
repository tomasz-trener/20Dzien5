﻿using P01AplikacjaZawodnicy.Domain;
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

            FrmSzczegoly frmSzczegoly = new FrmSzczegoly(zaznaczony,mz);
            frmSzczegoly.Show();
        }
    }
}
