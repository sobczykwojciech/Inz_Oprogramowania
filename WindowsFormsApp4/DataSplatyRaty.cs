using System;
using System.Windows.Forms;
using Program1;

namespace Program1

// na podstawie:http://poradnik-informatyka.com/2016/04/20/sprawdzanie-wolnych-dni-pracy-c/ dodałem nowe dni wolne

{
    internal class DataSplatyRaty
    {
        public static bool IsDayOff(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday) return true;
            if (date.DayOfWeek == DayOfWeek.Sunday) return true;
            if (date.Month == 01 && date.Day == 01) return true; // Nowy Rok
            if (date.Month == 01 && date.Day == 06 && (date.Year >= 1952 && date.Year <= 1960 || date.Year >= 2011)) return true; // święto Trzech Króli 
            if (date.Month == 05 && date.Day == 01) return true; // święto Pracy
            if (date.Month == 05 && date.Day == 03 && (date.Year >= 1918 && date.Year <= 1950 || date.Year >= 1990)) return true; // Rocznica Konstycucji 3 Maja
            if (date.Month == 07 && date.Day == 22 && (date.Year >= 1945 && date.Year <= 1989)) return true; // Narodowe Święto Odrodzenia Polski
            if (date.Month == 08 && date.Day == 15 && (date.Year <= 1960 || date.Year >= 1989)) return true; // Wniebowzięcie Najświętszej Marii Panny, Święto Wojska Polskiego (rocznica “cudu nad Wisłą”)
            if (date.Month == 11 && date.Day == 01) return true; // Dzień Wszystkich Świętych
            if (date.Month == 11 && date.Day == 11 && (date.Year == 1937 || date.Year == 1938 || date.Year >= 1990)) return true; // Dzień Niepodległości
            if (date.Month == 11 && date.Day == 01 && date.Year == 2018) return true; // Święto 100=lecia Odzyskania Niepodległości
            if (date.Month == 12 && date.Day == 25) return true; // Boże Narodzenie
            if (date.Month == 12 && date.Day == 26) return true; // Boże Narodzenie
            int a = date.Year % 19;
            int b = date.Year % 4;
            int c = date.Year % 7;
            int d = (a * 19 + 24) % 30;
            int e = (2 * b + 4 * c + 6 * d + 5) % 7;
            if (d == 29 && e == 6) d -= 7;
            if (d == 28 && e == 6 && a > 10) d -= 7;
            DateTime Easter = new DateTime(date.Year, 3, 22).AddDays(d + e);
            if (date.AddDays(-1) == Easter) return true; // Wielkanoc (poniedziałek)
            if (date.AddDays(-60) == Easter) return true; // Boże Ciało
            return false;
        }

        public static DateTime NastepnyDzien(DateTime changeDate)
        {
            for (int i = 0; i < 14; i++)
            {
                if (DataSplatyRaty.IsDayOff(changeDate))
                {
                    changeDate = changeDate.AddDays(1);
                }
                else
                {
                    break;
                }
            }
            return changeDate;
        }
    }
}