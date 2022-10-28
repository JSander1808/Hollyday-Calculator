using System;
using System.Collections.Generic;

namespace Feiertagsberechnung
{
    class Program
    {

        public static List<Feiertage> feiertage = new List<Feiertage>();
        static void Main(string[] args)
        {
            init();
            Console.WriteLine(getstate(States.SACHSENANHALT,2023));
        }

        public static String date(String date, int year)
        {
            int tempdate;
            if(Int32.TryParse(date,out tempdate))
            {
                DateTime oldtime = GetEasterSunday(year);
                DateTime newtime = oldtime.AddDays(tempdate);
                return String.Format("{0}.{1}.{2}", newtime.Day, newtime.Month, year);
            }
            else
            {
                return date+"."+year;
            }
        }

        public static String getstate(String state,int year)
        {
            String result = null;
            for(int i = 0; i < feiertage.Count; i++)
            {
                String temp = null;
                for(int e = 0; e < feiertage[i].getStates().Length; e++)
                {
                    if (feiertage[i].getStates()[e].Equals(state))
                    {
                        temp += date(feiertage[i].getDate(), year)+":"+feiertage[i].getFeiertag();
                        result += temp + "\n";
                        break;
                    }
                }
            }
            return result;
        }

        public static String getfeiertag(String feiertag, int year)
        {
            for(int i = 0; i < feiertage.Count; i++)
            {
                if (feiertage[i].getFeiertag().Equals(feiertag))
                {
                    String temp = null;
                    for(int e = 0; e < feiertage[i].getStates().Length; e++)
                    {
                        temp += feiertage[i].getStates()[e]+"  ";
                    }
                    String data = date(feiertage[i].getDate(),year)+": "+temp;
                    return data;
                }
            }
            return null;
        }

        public static void init()
        {
            String[] allstates = { States.BAYERN, States.BADENWÜRTEMBERG, States.BERLIN, States.BRANDENBURG, States.BREMEN, States.HAMBURG, States.HESSEN, States.MECKLENBURGVORPOMMERN, States.NIEDERSACHSEN, States.NORDRHEINWESTFALEN, States.RHEINLANDPFALZ, States.SAARLAND, States.SACHSEN, States.SACHSENANHALT, States.SCHLESWIGHOLSTEIN, States.THÜRINGEN };
            feiertage.Add(new Feiertage(Feiertage.NEUJAHR,"01.01",allstates));
            feiertage.Add(new Feiertage(Feiertage.HEILIGEDREIKÖNIGE,"06.01",new[] { States.BADENWÜRTEMBERG,States.BAYERN,States.SACHSENANHALT}));
            feiertage.Add(new Feiertage(Feiertage.FRAUENTAG,"08.03",new[] { States.BERLIN}));
            feiertage.Add(new Feiertage(Feiertage.KARFREITAG,"-2",allstates));
            feiertage.Add(new Feiertage(Feiertage.OSTERSONNTAG,"0",allstates));
            feiertage.Add(new Feiertage(Feiertage.OSTERMONTAG,"1",allstates));
            feiertage.Add(new Feiertage(Feiertage.TAGDERARBEIT,"01.05",allstates));
            feiertage.Add(new Feiertage(Feiertage.CHRISTIHIMMELFAHRT,"39",allstates));
            feiertage.Add(new Feiertage(Feiertage.PFINGSTSONNTAG,"49",allstates));
            feiertage.Add(new Feiertage(Feiertage.PFINGSTMONTAG,"50",allstates));
            feiertage.Add(new Feiertage(Feiertage.WELTKINDERTAG,"20.09",new[] { States.THÜRINGEN}));
            feiertage.Add(new Feiertage(Feiertage.FROHNLEICHNAM,"60",new[] { States.BADENWÜRTEMBERG,States.BAYERN,States.HESSEN,States.NORDRHEINWESTFALEN,States.RHEINLANDPFALZ,States.SAARLAND}));
            feiertage.Add(new Feiertage(Feiertage.MARIAHIMMELFAHRT,"15.08",new[] { States.SAARLAND}));
            feiertage.Add(new Feiertage(Feiertage.REFORNATIONSTAG,"31.10",new[] { States.BRANDENBURG,States.HAMBURG,States.BREMEN,States.MECKLENBURGVORPOMMERN,States.NIEDERSACHSEN,States.SACHSEN,States.SACHSENANHALT,States.SCHLESWIGHOLSTEIN,States.THÜRINGEN}));
            feiertage.Add(new Feiertage(Feiertage.TAGDERDEUTSCHENEINHEIT, "03.10", allstates));
            feiertage.Add(new Feiertage(Feiertage.ALLERHEILIGEN,"01.11",new[] { States.BADENWÜRTEMBERG,States.BAYERN,States.NORDRHEINWESTFALEN,States.RHEINLANDPFALZ,States.SAARLAND}));
            feiertage.Add(new Feiertage(Feiertage.ERSTERWEIHNACHTSFEIERTAG,"25.12",allstates));
            feiertage.Add(new Feiertage(Feiertage.ZWEITERWEIHNACHTSFEIERTAG,"26.12",allstates));
        }

        private static DateTime GetEasterSunday(int year)
        {
            int c = year / 100;
            int n = year - 19 * (year / 19);
            int k = (c - 17) / 25;
            int i = c - c / 4 - ((c - k) / 3) + 19 * n + 15;
            i = i - 30 * (i / 30);
            i = i - (i / 28) * ((1 - (i / 28)) * (29 / (i + 1)) * ((21 - n) / 11));
            int j = year + (year / 4) + i + 2 - c + (c / 4);
            j = j - 7 * (j / 7);
            int l = i - j;

            int easterMonth = 3 + ((l + 40) / 44);
            int easterDay = l + 28 - 31 * (easterMonth / 4);

            return Convert.ToDateTime(string.Format("{0}.{1}.{2}", easterDay, easterMonth, year));
        }
    }
}
