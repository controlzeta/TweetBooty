using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace TweetBooty
{
    public class Utilities
    {
        public static TwitterSearchResultType ResultType(int index)
        {
            switch (index)
            {
                case 0:
                    return TwitterSearchResultType.Mixed;
                case 1:
                    return TwitterSearchResultType.Recent;
                case 2:
                    return TwitterSearchResultType.Popular;
                default:
                    return TwitterSearchResultType.Mixed;
            }
        }

        private string ShortenedString(string linea, int medida)
        {
            if (linea.Length <= medida)
            {
                return linea;
            }
            string lineaCorta;
            int cuantos = linea.Length - medida;
            lineaCorta = linea.Remove(medida, cuantos);
            return lineaCorta;
        }
    }
}
