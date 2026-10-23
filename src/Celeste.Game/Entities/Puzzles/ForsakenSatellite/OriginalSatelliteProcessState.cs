using System.Collections.Generic;

namespace Celeste.Game.Entities.Puzzles.ForsakenSatellite
{
    public sealed class OriginalSatelliteProcessState
    {
        public readonly string[] Code = ["U", "L", "DR", "UR", "L", "UL"];
        public readonly string[] ReflectionCode = ["U", "L", "DR", "UR", "L", "UL"];
        public readonly List<string> UniqueCodes = [];

        public readonly Dictionary<string, string> Sounds = new()
        {
            { "U", "event:/game/01_forsaken_city/console_white" },
            { "L", "event:/game/01_forsaken_city/console_purple" },
            { "DR", "event:/game/01_forsaken_city/console_blue" },
            { "UR", "event:/game/01_forsaken_city/console_red" },
            { "UL", "event:/game/01_forsaken_city/console_yellow" },
        };
    }
}
