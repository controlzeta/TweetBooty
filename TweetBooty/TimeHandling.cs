using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetBooty
{
        public class TimeHandling
        {
            public Random rand = new Random();

            public DateTime getRandomTime()
            {
                return new DateTime().AddHours(rand.Next(0, 24));
            }

            public DateTime getRandomDate()
            {
                return new DateTime().AddDays(rand.Next(0, 31));
            }

            public string forDaysOfTheWeek(DateTime date)
            {
                switch (date.DayOfWeek.ToString())
                {
                    case "Sunday":
                        return "Hoy es domingo";
                    case "Monday":
                        return "Hoy es lunes";
                    case "Tuesday":
                        return "Hoy es martes";
                    case "Wednesday":
                        return "Hoy es miercoles";
                    case "Thursday":
                        return "Hoy es Jueves";
                    case "Friday":
                        return "Hoy es Viernes";
                    case "Saturday":
                        return "Hoy es Sabado";
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
                    return "Es de Madrugada";
                }
                if (time > morningStart && time <= morningEnd)
                {
                    return "Es de mañana";
                }
                if (time > afternoonStart && time <= afternoonEnd)
                {
                    return "Es de tarde";
                }
                if (time > nightStart && time <= nightEnd)
                {
                    return "Es de Noche ";
                }
                return "esta fuera de horario";

            }

        }
    }

