using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetBooty
{
    public class HandlingString
    {
        public string oldString = "Estamos en Querétaro sin hacer nada";

        public string[] states = { "Aguascalientes", "Baja California", "Baja California Sur", "Campeche", "Chiapas", "Chihuahua", "Coahuila", "Colima", 
                             "Distrito Federal", "Durango", "Estado de México", "Guanajuato", "Guerrero", "Hidalgo", "Jalisco", "Michoacán", "Morelos",
                              "Nayarit", "Nuevo León", "Oaxaca", "Puebla", "Querétaro", "Quintana Roo", "San Luis Potosí", "Sinaloa", "Sonora", 
                              "Tabasco", "Tamaulipas", "Tlaxcala", "Veracruz", "Yucatán", "Zacatecas"};

        public int[] intArr = new int[3];

        public Random rand = new Random();

        public int[] findState(string oldString)
        {
            oldString = RemoveDiacritics(oldString);
            int i = 0;
            foreach (var e in states)
            {
                i++;
                if (oldString.ToUpper().Contains(RemoveDiacritics(e.ToUpper())))
                {
                    int start = oldString.ToUpper().IndexOf(RemoveDiacritics(e.ToUpper()));
                    int end = start + e.Length;
                    Console.WriteLine("keyword: " + RemoveDiacritics(e.ToUpper()) + " Found it! at: " + start + " - " + end);
                    Console.WriteLine(oldString.Substring(start, e.Length));
                    Console.WriteLine(i);
                    intArr = new int[] { start, e.Length, i };
                    return intArr;
                }
            }
            return null;
        }

        public string ChangeState(string oldString)
        {
            string[] myStates = (string[])states.Clone();
            string newString = "";
            if (findState(oldString) != null)
            {
                string getOff = oldString.Substring(intArr[0], intArr[1]);
                string estado = myStates[intArr[2]];
                newString = oldString.Replace(getOff, getRandomState(estado, myStates));

            }
            return newString;
        }

        public string getRandomState(string current, string[] states)
        {
            string state = "";
            do
            {
                state = states[rand.Next(0, states.Length)];

            } while (current == state);
            return state;
        }

        static string RemoveDiacritics(string text)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                                              UnicodeCategory.NonSpacingMark)
              ).Normalize(NormalizationForm.FormC);
        }

    }
}
