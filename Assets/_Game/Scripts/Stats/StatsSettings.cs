using System.Collections;
using UnityEngine;

namespace ggj.Assets._Game.Scripts.Stats
{
    public static class StatsSettings
    {
        public static Color GetMoodColor(StatMood mood)
        {
            switch (mood)
            {
                case StatMood.strength:
                    return Color.red;
                case StatMood.agility:
                    return Color.green;
                case StatMood.intelligence:
                    return Color.blue;
                case StatMood.energy:
                    return Color.cyan;
                case StatMood.happiness:
                    return Color.magenta;
            }
            return Color.yellow;
        }

    }
}