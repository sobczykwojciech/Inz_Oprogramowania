using System;

//obliczyć ile dni ma miesiąc

namespace Program1
{
    internal class IleDniMaMiesiac
    {
        public static int X(DateTime Y)
        {
            int M = Y.Month;
            int D = 0;

            if (M == 1 | M == 3 | M == 5 | M == 7 | M == 8 | M == 10 | M == 12)
            {
                D = 31;
            }
            else if (M == 4 | M == 6 | M == 9 | M == 11)
            {
                D = 30;
            }
            else if (M == 2)
            {
                if (Y.Year % 4 == 0 && Y.Year % 100 != 0 || Y.Year % 400 == 0)
                {
                    D = 29;
                }
                else
                {
                    D = 28;
                }
            }
            return D;
        }
    }
}