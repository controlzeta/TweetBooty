using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetBooty
{
    public class TimeHandling
    {
        public Random rand = new Random();
        public static string[] Monday = { "#LunesDeOjos", "#FelizLunes", "#MirrorMonday","#LunesIntratable", "#LunesEnTanguita", "#LunesDeLenceria", "#LunesSensual" };
        public static string[] Tuesday = { "#MartesDeTetas", "#MartesDeBellas", "#MartesDeCulos", "#TuesdayMotivation" };
        public static string[] Wednesday = { "#MiercolesDeNalgas", "#FelizMiercoles", "#MiercolesDeCulitos", "#MiercolesDeSexo" };
        public static string[] Thursday = { "#ThursdayMotivation", "#JuevesDePiernalgotas", "#JuevesDeSexoSalvaje", "#JuevesDeCulosPerfectos", "#JuevesDeEspaldas" };
        public static string[] Friday = { "#ViernesDePrincesasPerversas", "#ViernesDeTacones", "#ViernesDeSeductoras", "#ViernesDeSexo" };
        public static string[] Saturday = { "#SabadoDeSeduccion", "#SabadosSensuales", "#SabadoDePutas", "#SabadoEnLaNoche" };
        public static string[] Sunday = { "#SluttySunday", "#DomingoCachondo", "#FelizDomingo", "#DomingoSensual" };

        public static string[] Dawn = { "Ya deberia estar dormida pero", "En la madrugada me dan ganas de", "#DeMadrugada" };
        public static string[] Morning = { "#BuenosDías", "#DesayunoSaludable", "#HoraDeIrAlGym" };
        public static string[] Afternoon = { "#BuenasTardes", "Es hora de comer", "Se me antojo" };
        public static string[] Night = { "Ya es hora de coger", "#BuenasNoches", "#EsDeNocheY" };

        public DateTime getRandomTime()
        {
            return new DateTime().AddHours(rand.Next(0, 24));
        }

        public DateTime getRandomDate()
        {
            return new DateTime().AddDays(rand.Next(0, 31));
        }

        public string getRandomString(string[] hashArray)
        {
            int index = rand.Next(0, hashArray.Length);
            return hashArray[index];
        }

        public string forDaysOfTheWeek(DateTime date)
        {
            switch (date.DayOfWeek.ToString())
            {
                case "Sunday":
                    return getRandomString(Sunday);
                case "Monday":
                    return getRandomString(Monday);
                case "Tuesday":
                    return getRandomString(Tuesday);
                case "Wednesday":
                    return getRandomString(Wednesday);
                case "Thursday":
                    return getRandomString(Thursday);
                case "Friday":
                    return getRandomString(Friday);
                case "Saturday":
                    return getRandomString(Saturday);
            }
            return "";
        }

        public string forTimeOfTheDay(DateTime Time)
        {
            TimeSpan time = new TimeSpan();
            time = Time.TimeOfDay;
            TimeSpan dawnStart = TimeSpan.Parse("00:01"); // 00:01 AM
            TimeSpan dawnEnd = TimeSpan.Parse("04:59");   // 04:59 AM
            TimeSpan morningStart = TimeSpan.Parse("05:01"); // 05:01 AM
            TimeSpan morningEnd = TimeSpan.Parse("12:00");   // 12:00 PM
            TimeSpan afternoonStart = TimeSpan.Parse("12:01"); // 12:01 PM
            TimeSpan afternoonEnd = TimeSpan.Parse("19:00");   // 07:00 PM
            TimeSpan nightStart = TimeSpan.Parse("19:01"); // 07:01 PM
            TimeSpan nightEnd = TimeSpan.Parse("23:59");   // 11:59 PM
            if (time > dawnStart && time <= dawnEnd)
            {
                return getRandomString(Dawn);
            }
            if (time > morningStart && time <= morningEnd)
            {
                return getRandomString(Morning);
            }
            if (time > afternoonStart && time <= afternoonEnd)
            {
                return getRandomString(Afternoon);
            }
            if (time > nightStart && time <= nightEnd)
            {
                return getRandomString(Night);
            }
            return "";

        }
    }

}