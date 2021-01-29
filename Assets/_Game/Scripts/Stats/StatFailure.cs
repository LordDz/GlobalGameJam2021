using System.Collections;
using UnityEngine;

namespace ggj.Assets._Game.Scripts.Stats
{
    public static class StatFailure
    {
        /// <summary>
        /// Over 5 is success
        /// </summary>
        /// <param name="procentage"></param>
        /// <returns></returns>
        public static string GetFailureRate(int procentage)
        {
            switch (procentage)
            {
                case 0:
                    return "Extremely bad";
                case 1:
                    return "Extremely bad";
            case 2:
                    return "Extremely bad";
            case 3:
                    return "Extremely bad";
            case 4:
                    return "Extremely bad";
            case 5:
                    return "Extremely good";
            case 6:
                return "Extremely good";
            case 7:
                return "Extremely good";
            case 8:
                return "Extremely good";
            case 9:
                return "Extremely good";
            case 10:
                return "Extremely good";
            }
            return "ok";
        }
    }
}