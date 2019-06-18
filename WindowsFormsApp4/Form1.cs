using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Program1;
using WindowsFormsApp4;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.IO;


namespace Program1
{
    public partial class HarmonogramStandard : Form
    {
        public HarmonogramStandard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool TEST1 = CzyLiczba.CzyOK(WartKwotaKredytu.Text, 1);
            bool TEST2 = CzyLiczba.CzyOK(IloscRat.Text, 2);
            bool TEST3 = CzyLiczba.CzyOK(Oprocentowanie.Text, 1);


            if (TEST1 == true && TEST2 == true && TEST3 == true)
            {
                System.Data.DataTable Hm = new System.Data.DataTable();

                bool KalendarzRat;

                if (DlaRat.Checked)
                {
                    KalendarzRat = true;
                }
                else
                {
                    KalendarzRat = false;
                }

                DateTime DataUruchomieniaKredytu = new DateTime(DataKredytu.Value.Year, DataKredytu.Value.Month, DataKredytu.Value.Day);
                DateTime DataOstatniejRaty = new DateTime(DataRatyOst.Value.Year, DataRatyOst.Value.Month, DataRatyOst.Value.Day);

                double KwotaKredytu = Convert.ToDouble(WartKwotaKredytu.Text);
                double OprocentowanieWStosunkuRocznym = Convert.ToDouble(Oprocentowanie.Text) / 100;
                int IloscRatKredytu = Convert.ToInt32(IloscRat.Text);
                string RodzajRat = Convert.ToString(RodzajRatBox.SelectedItem);

                //MessageBox.Show(RodzajRat);

                if (RodzajRat == "Równe")
                {
                    this.Hm.DataSource = HarmonogramSplat.Rowna(KalendarzRat, DataUruchomieniaKredytu, DataOstatniejRaty, KwotaKredytu, IloscRatKredytu, OprocentowanieWStosunkuRocznym);
                }
                else if (RodzajRat == "Malejace")
                {
                    this.Hm.DataSource = HarmonogramSplat.Malejace(KalendarzRat, DataUruchomieniaKredytu, DataOstatniejRaty, KwotaKredytu, IloscRatKredytu, OprocentowanieWStosunkuRocznym);
                }
                else  // narazie znowu malejące ale pozniej pojawia sie nowe mozliwosci
                {
                    this.Hm.DataSource = HarmonogramSplat.Malejace(KalendarzRat, DataUruchomieniaKredytu, DataOstatniejRaty, KwotaKredytu, IloscRatKredytu, OprocentowanieWStosunkuRocznym);
                }
            }
        }

        private void DlaRat_CheckedChanged(object sender, EventArgs e)
        {
            if (IloscRat.Visible == false)
            {
                IloscRat.Visible = true;
                DataRatyOst.Visible = false;
                OpisDataOstRaty.Visible = false;
                OpisIloscRat.Visible = true;
            }
            else
            {
                IloscRat.Visible = false;
                DataRatyOst.Visible = true;
                OpisDataOstRaty.Visible = true;
                OpisIloscRat.Visible = false;
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            void Exportuj()
            {
                ExportDoExcel.ExportToExcel(Hm);
            }
            Thread X = new Thread(Exportuj);
            X.SetApartmentState(ApartmentState.STA);
            X.Start();
        }

        private void Import_Click(object sender, EventArgs e)
        {
            ImportZExcel.ImportFromExcel(Hm);
        }
    }
}

