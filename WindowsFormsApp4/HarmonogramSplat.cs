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

namespace Program1
{
    internal class HarmonogramSplat
    {
        //----------RATY-MALEJACE--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static DataTable Malejace(bool kalendarzRat, DateTime dataUruchomieniaKredytu,
                                         DateTime dataOstatniejRaty, double kwotaKredytu, int iloscRatKapitalowych,
                                         double oprocentowanieWStosunkuRocznym)
        {
            DataTable Hm = new DataTable();

            DateTime dataPierwszejRaty = new DateTime(dataUruchomieniaKredytu.Year,
            dataUruchomieniaKredytu.Month, DateTime.DaysInMonth(dataUruchomieniaKredytu.Year,
            dataUruchomieniaKredytu.Month)); // data pierwszej raty to koniec pierwszego miesiąca funkcjonowania kredytu, niezależnie od daty spłaty pierwszej raty kapitałowej

            DateTime dataPierwszejRatyKapitalowej;  //arbitralnie przyjąłem, że jeżeli kredyt będzie uruchomiony do 10 dnia miesiaca to rata kapitałowa płatna w bieżacym miesiącu

            if (dataUruchomieniaKredytu.Day <= 10)
            {
                dataPierwszejRatyKapitalowej = new DateTime(dataUruchomieniaKredytu.Year, dataUruchomieniaKredytu.Month, DateTime.DaysInMonth(dataUruchomieniaKredytu.Year, dataUruchomieniaKredytu.Month));
            }
            else
            {
                if (dataUruchomieniaKredytu.Month == 12)
                {
                    dataPierwszejRatyKapitalowej = new DateTime(dataUruchomieniaKredytu.AddYears(1).Year, 1 , 31);
                }
                else
                {
                    dataPierwszejRatyKapitalowej = new DateTime(dataUruchomieniaKredytu.Year, dataUruchomieniaKredytu.AddMonths(1).Month, DateTime.DaysInMonth(dataUruchomieniaKredytu.Year, dataUruchomieniaKredytu.Month));
                }
            }

            DateTime dataSplaty = dataPierwszejRaty;

            int iloscRatKapitalowychWHarmonogramie;
            int iloscOkresowNaliczaniaOdsetek;

            if (kalendarzRat == true)
            {
                if (dataUruchomieniaKredytu.Day <= 10)
                {
                    iloscRatKapitalowychWHarmonogramie = iloscRatKapitalowych;
                    iloscOkresowNaliczaniaOdsetek = iloscRatKapitalowychWHarmonogramie;
                }
                else
                {
                    iloscRatKapitalowychWHarmonogramie = iloscRatKapitalowych - 1;
                    iloscOkresowNaliczaniaOdsetek = iloscRatKapitalowychWHarmonogramie + 1;
                }  
            }
            else
            {
                iloscRatKapitalowychWHarmonogramie = (12 * (dataOstatniejRaty.Year - dataPierwszejRatyKapitalowej.Year) + 1 - dataPierwszejRatyKapitalowej.Month + dataOstatniejRaty.Month);
                iloscOkresowNaliczaniaOdsetek = (12 * (dataOstatniejRaty.Year - dataUruchomieniaKredytu.Year) + 1 - dataUruchomieniaKredytu.Month + dataOstatniejRaty.Month);
            }

            Hm.Columns.Add("Nr");
            Hm.Columns.Add("Data Platności");
            Hm.Columns.Add("Saldo");
            Hm.Columns.Add("Kapital");
            Hm.Columns.Add("Odsetki");
            Hm.Columns.Add("Rata");

            double saldo = kwotaKredytu;
            double oprocentowanieDzienne = oprocentowanieWStosunkuRocznym / 365;
            double odsetkiZaDzien = saldo * oprocentowanieDzienne;
            double rataKapitalowa = Math.Round(kwotaKredytu / iloscRatKapitalowychWHarmonogramie, 2);
            double pierwszaRataWyrownujaca = kwotaKredytu - Math.Round(rataKapitalowa * (iloscRatKapitalowychWHarmonogramie - 1),2);

            int iloscDniWMiesiacu = DateTime.DaysInMonth(dataPierwszejRaty.Year, dataPierwszejRaty.Month);
            int dzienRozpoczeciaNaliczaniaOdsetek = dataUruchomieniaKredytu.Day;
            int dzienZakonczeniaNaliczaniaOdsetek = dataPierwszejRaty.Day;
            int iloscDniNaliczaniaOdsetek = dzienZakonczeniaNaliczaniaOdsetek - dzienRozpoczeciaNaliczaniaOdsetek;

            double sumaOdsetek = 0;

            double schowekRatyKapitalowej = rataKapitalowa; // to pole przechowa kwotę raty na później - poniewaz pierwsza rata jest wyrównująca

            rataKapitalowa = pierwszaRataWyrownujaca;

            double SumaRatKapitalowych = 0;  // do weryfikacji czy kwota sie zgadza

            for (int Nr = 1; Nr <= iloscOkresowNaliczaniaOdsetek; Nr++)
            {
                if (dataSplaty < dataPierwszejRatyKapitalowej) // odsetki platne zawsze na koniec miesiąca
                {
                    rataKapitalowa = 0;
                }
                else if (dataSplaty == dataPierwszejRatyKapitalowej) // pierwsza rata wyrównująca
                {
                    rataKapitalowa = pierwszaRataWyrownujaca;
                }

                dataSplaty = DataSplatyRaty.NastepnyDzien(dataSplaty);

                if (kalendarzRat == false && dataSplaty >= dataOstatniejRaty) // harmonogram nie może wykroczyć poza okres spłaty kredytu
                {
                    dataSplaty = dataOstatniejRaty;
                    rataKapitalowa = saldo;
                    dataSplaty = DataSplatyRaty.NastepnyDzien(dataSplaty);
                }

                double OdsetkiZaOkres = Math.Round(iloscDniNaliczaniaOdsetek * oprocentowanieDzienne * saldo, 2);

                double KwotaRaty = rataKapitalowa + OdsetkiZaOkres;

                if (Nr == iloscOkresowNaliczaniaOdsetek)
                {
                    rataKapitalowa = saldo;
                }

                Hm.Rows.Add(new object[]
                {
                Nr,
                dataSplaty.ToString("D", CultureInfo.CreateSpecificCulture("pl-PL")),
                saldo.ToString("0.00") + " zł",
                rataKapitalowa.ToString("0.00") + " zł",
                OdsetkiZaOkres.ToString("0.00") + " zł",
                KwotaRaty.ToString("0.00") + " zł"
                });

                SumaRatKapitalowych = SumaRatKapitalowych + rataKapitalowa;

                saldo = saldo - rataKapitalowa;
                rataKapitalowa = schowekRatyKapitalowej;

                if (dataSplaty.Day > 10)
                {
                    dataSplaty = new DateTime(dataSplaty.AddMonths(1).Year, dataSplaty.AddMonths(1).Month, DateTime.DaysInMonth(dataSplaty.AddMonths(1).Year, dataSplaty.AddMonths(1).Month));
                }
                else
                {
                    dataSplaty = new DateTime(dataSplaty.Year, dataSplaty.Month, DateTime.DaysInMonth(dataSplaty.Year, dataSplaty.Month));
                }

                iloscDniNaliczaniaOdsetek = DateTime.DaysInMonth(dataSplaty.Year, dataSplaty.Month);

                OdsetkiZaOkres = saldo * iloscDniNaliczaniaOdsetek * oprocentowanieDzienne;

                sumaOdsetek = sumaOdsetek + OdsetkiZaOkres;

            }
            
            return Hm;
        }

        //----------RATY-ROWNE--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static DataTable Rowna(bool kalendarzRat, DateTime dataUruchomieniaKredytu,
                                         DateTime dataOstatniejRaty, double kwotaKredytu, int iloscRatKredytu,
                                         double oprocentowanieWStosunkuRocznym)
        { 
        DataTable Hm = new DataTable();

        DateTime dataPierwszejRaty = new DateTime(dataUruchomieniaKredytu.Year,
        dataUruchomieniaKredytu.Month, DateTime.DaysInMonth(dataUruchomieniaKredytu.Year,
        dataUruchomieniaKredytu.Month)); // data pierwszej raty to koniec pierwszego miesiąca funkcjonowania kredytu, niezależnie od daty spłaty pierwszej raty kapitałowej

        DateTime dataPierwszejRatyKapitalowej;  //arbitralnie przyjąłem, że jeżeli kredyt będzie uruchomiony do 10 dnia miesiaca to 1 rata kapitałowa płatna w tym samym miesiącu

            if (dataUruchomieniaKredytu.Day <= 10)
            {
                dataPierwszejRatyKapitalowej = new DateTime(dataUruchomieniaKredytu.Year, dataUruchomieniaKredytu.Month, DateTime.DaysInMonth(dataUruchomieniaKredytu.Year, dataUruchomieniaKredytu.Month));
            }
            else
            {
                if (dataUruchomieniaKredytu.Month == 12)
                {
                    dataPierwszejRatyKapitalowej = new DateTime(dataUruchomieniaKredytu.AddYears(1).Year, 1, 31);
                }
                else
                {
                    dataPierwszejRatyKapitalowej = new DateTime(dataUruchomieniaKredytu.Year, dataUruchomieniaKredytu.AddMonths(1).Month, DateTime.DaysInMonth(dataUruchomieniaKredytu.Year, dataUruchomieniaKredytu.Month));
                }
            }

            DateTime dataSplaty = dataPierwszejRaty;

        int iloscRatKapitalowychWHarmonogramie;
        int iloscOkresowNaliczaniaOdsetek;

            if (kalendarzRat == true)
            {
                if (dataUruchomieniaKredytu.Day <= 10)
                {
                    iloscRatKapitalowychWHarmonogramie = iloscRatKredytu;
                    iloscOkresowNaliczaniaOdsetek = iloscRatKapitalowychWHarmonogramie;
                }
                else
                {
                    iloscRatKapitalowychWHarmonogramie = iloscRatKredytu - 1;
                    iloscOkresowNaliczaniaOdsetek = iloscRatKapitalowychWHarmonogramie + 1;
                }  
            }
            else
            {
                iloscRatKapitalowychWHarmonogramie = (12 * (dataOstatniejRaty.Year - dataPierwszejRatyKapitalowej.Year) + 1 - dataPierwszejRatyKapitalowej.Month + dataOstatniejRaty.Month);
                iloscOkresowNaliczaniaOdsetek = (12 * (dataOstatniejRaty.Year - dataUruchomieniaKredytu.Year) + 1 - dataUruchomieniaKredytu.Month + dataOstatniejRaty.Month);
            }

            Hm.Columns.Add("Nr");
            Hm.Columns.Add("Data Platności");
            Hm.Columns.Add("Saldo");
            Hm.Columns.Add("Kapital");
            Hm.Columns.Add("Odsetki");
            Hm.Columns.Add("Rata Razem");

            double saldo = kwotaKredytu;
            double oprocentowanieDzienne = oprocentowanieWStosunkuRocznym / 365;
            
            int iloscDniWMiesiacu = DateTime.DaysInMonth(dataPierwszejRaty.Year, dataPierwszejRaty.Month);
            int dzienRozpoczeciaNaliczaniaOdsetek = dataUruchomieniaKredytu.Day;
            int dzienZakonczeniaNaliczaniaOdsetek = dataPierwszejRaty.Day;
            int iloscDniNaliczaniaOdsetek = dzienZakonczeniaNaliczaniaOdsetek - dzienRozpoczeciaNaliczaniaOdsetek;

            double SumaRatKapitalowych = 0;  // do weryfikacji czy kwota sie zgadza

            for (int Nr = 1; Nr <= iloscOkresowNaliczaniaOdsetek; Nr++)
            {
      
                double OdsetkiZaOkres = Math.Round(saldo * (oprocentowanieDzienne * iloscDniNaliczaniaOdsetek), 2);
                double RownaRataCzescKapitalowa;

                RownaRataCzescKapitalowa = Math.Round((kwotaKredytu * oprocentowanieWStosunkuRocznym / 12) / (1 - Math.Pow(1 + (oprocentowanieWStosunkuRocznym / 12), (-iloscRatKapitalowychWHarmonogramie))) - OdsetkiZaOkres, 2);

                if (dataSplaty<dataPierwszejRatyKapitalowej) // odsetki platne zawsze na koniec miesiąca
                {
                    RownaRataCzescKapitalowa = 0;
                }
                
                dataSplaty = DataSplatyRaty.NastepnyDzien(dataSplaty);

                if (kalendarzRat == false && dataSplaty >= dataOstatniejRaty) // harmonogram nie może wykroczyć poza okres spłaty kredytu
                {
                    dataSplaty = dataOstatniejRaty;
                    RownaRataCzescKapitalowa = saldo;
                    dataSplaty = DataSplatyRaty.NastepnyDzien(dataSplaty);
                }

                double KwotaRaty = RownaRataCzescKapitalowa + OdsetkiZaOkres;

                if(Nr == iloscOkresowNaliczaniaOdsetek)
                {
                    RownaRataCzescKapitalowa = saldo;
                }

                Hm.Rows.Add(new object[]
                {
                Nr,
                dataSplaty.ToString("D", CultureInfo.CreateSpecificCulture("pl-PL")),
                saldo.ToString("0.00") + " zł",
                RownaRataCzescKapitalowa.ToString("0.00") + " zł",
                OdsetkiZaOkres.ToString("0.00") + " zł",
                KwotaRaty.ToString("0.00") + " zł"
                });

                saldo = saldo - KwotaRaty + OdsetkiZaOkres;

                if (dataSplaty.Day > 10)
                {
                    dataSplaty = new DateTime(dataSplaty.AddMonths(1).Year, dataSplaty.AddMonths(1).Month, DateTime.DaysInMonth(dataSplaty.AddMonths(1).Year, dataSplaty.AddMonths(1).Month));
                }
                else
                {
                    dataSplaty = new DateTime(dataSplaty.Year, dataSplaty.Month, DateTime.DaysInMonth(dataSplaty.Year, dataSplaty.Month));
                }

                iloscDniNaliczaniaOdsetek = DateTime.DaysInMonth(dataSplaty.Year, dataSplaty.Month);

                SumaRatKapitalowych = SumaRatKapitalowych + RownaRataCzescKapitalowa;
    
            }

            return Hm;
        }
    }
}