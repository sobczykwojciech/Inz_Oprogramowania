using System;
using System.Windows.Forms;
using Program1;

namespace Program1
{
    internal class CzyLiczba
    {
        public static bool CzyOK(string X, int Z)
        {
            bool Q = false;

            if (X == "")
            {
                MessageBox.Show("Brak liczby");  
            }
            else
            {
                if (Z == 1)
                {
                    Q = true;
                    try
                    {
                        double dane_ok = System.Convert.ToDouble(X);
                    }
                    catch
                    {
                        MessageBox.Show("Nieprawidłowe znaki");
                        Q = false;
                    }
                }
                else
                {
                    Q = true;
                    try
                    {
                        double dane_ok = System.Convert.ToInt32(X);
                    }
                    catch
                    {
                        MessageBox.Show("Nieprawidłowe znaki");
                        Q = false;

                    }
                } 
            }
            return Q;
        }
    }
}            