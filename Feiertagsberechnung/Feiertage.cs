using System;
using System.Collections.Generic;
using System.Text;

namespace Feiertagsberechnung
{
    class Feiertage
    {

        public static readonly String NEUJAHR = "Neujahr";
        public static readonly String HEILIGEDREIKÖNIGE = "Heilige Drei Könige";
        public static readonly String KARFREITAG = "Karfreitag";
        public static readonly String OSTERSONNTAG = "Ostersonntag";
        public static readonly String OSTERMONTAG = "Ostermontag";
        public static readonly String TAGDERARBEIT = "Tag der Arbeit";
        public static readonly String CHRISTIHIMMELFAHRT = "Christi Himmelfahrt";
        public static readonly String PFINGSTSONNTAG = "Pfingst Sonntag";
        public static readonly String PFINGSTMONTAG = "Pfingst Montag";
        public static readonly String FROHNLEICHNAM = "Frohnleichnam";
        public static readonly String MARIAHIMMELFAHRT = "Maria Himmelfahrt";
        public static readonly String TAGDERDEUTSCHENEINHEIT = "Tag der Deutschen Einheit";
        public static readonly String ALLERHEILIGEN = "Allerheiligen";
        public static readonly String ERSTERWEIHNACHTSFEIERTAG = "1. Weihnachtsfeiertag";
        public static readonly String ZWEITERWEIHNACHTSFEIERTAG = "2. Weihnachtsfeiertag";
        public static readonly String REFORNATIONSTAG = "Reformationstag";
        public static readonly String FRAUENTAG = "Frauentag";
        public static readonly String WELTKINDERTAG = "Weltkindertag";

        private String Feiertag;
        private String Date;
        private String[] State;
        public Feiertage(String Feiertag, String Date, String[] State)
        {
            this.Feiertag = Feiertag;
            this.Date = Date;
            this.State = State;
        }

        public String getDate()
        {
            return Date;
        }

        public String[] getStates()
        {
            return State;
        }

        public String getFeiertag()
        {
            return Feiertag;
        }
    }
}
