using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Celeste.Game.Launch
{
    // Presets use the same fields as command-line launches. Parsing never mutates
    // the supplied preset; absent options preserve its selected values.
    [Serializable]
    public sealed class GameLaunchOptions
    {
        public GameLaunchView View = GameLaunchView.Normal;

        public string Map, Room, Language, Postcard, Checkpoint;
        public int Area = -1;

        private static readonly string[] NormalMaps =
        [
            "0-Intro", "1-ForsakenCity", "2-OldSite", "3-CelestialResort", "4-GoldenRidge",
            "5-MirrorTemple", "6-Reflection", "7-Summit", "8-Epilogue", "9-Core", "LostLevels",
        ];

        private static readonly string[] Languages =
        [
            "brazilian", "english", "french", "german", "italian", "japanese", "korean", "russian", "schinese",
            "spanish",
        ];

        private static readonly Dictionary<string, int> Maps = MakeMaps();

        private static Dictionary<string, int> MakeMaps()
        {
            var result = new Dictionary<string, int>(StringComparer.Ordinal);
            for (var area = 0; area < NormalMaps.Length; area++)
            {
                var map = NormalMaps[area];
                result.Add(map, area);
                if ((area >= 1 && area <= 7) || area == 9)
                {
                    var hyphen = map.IndexOf('-');
                    result.Add(map.Insert(hyphen, "H"), area);
                    result.Add(map.Insert(hyphen, "X"), area);
                }
            }

            return result;
        }

        public string ResolvedMap => Map ?? NormalMaps[ResolvedArea];
        public int ResolvedArea => Area >= 0 ? Area : Map != null && Maps.TryGetValue(Map, out var area) ? area : 0;
        public string ResolvedPostcard => Postcard ?? "csides";

        public GameLaunchOptions Clone()
        {
            return (GameLaunchOptions)MemberwiseClone();
        }

        public static GameLaunchOptions Parse(IEnumerable<string> arguments,
            GameLaunchOptions defaults = null)
        {
            if (arguments == null) throw new ArgumentNullException(nameof(arguments));
            var result = defaults?.Clone() ?? new GameLaunchOptions();
            var supplied = new Dictionary<string, string>(StringComparer.Ordinal);
            using (var iterator = arguments.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    var argument = iterator.Current;
                    if (argument == null || !argument.StartsWith("--celeste-", StringComparison.Ordinal)) continue;
                    var equals = argument.IndexOf('=');
                    var option = equals < 0 ? argument : argument.Substring(0, equals);
                    switch (option)
                    {
                        case "--celeste-view":
                        case "--celeste-map":
                        case "--celeste-room":
                        case "--celeste-area":
                        case "--celeste-language":
                        case "--celeste-postcard":
                        case "--celeste-checkpoint": break;
                        default: throw Error("Unknown option '" + option + "'.");
                    }

                    string value;
                    if (equals >= 0)
                    {
                        value = argument.Substring(equals + 1);
                    }
                    else
                    {
                        if (!iterator.MoveNext() || iterator.Current == null ||
                            iterator.Current.StartsWith("-", StringComparison.Ordinal))
                            throw Error("Missing value for " + option + ".");
                        value = iterator.Current;
                    }

                    if (string.IsNullOrWhiteSpace(value)) throw Error("Missing value for " + option + ".");
                    if (supplied.TryGetValue(option, out var previous) && previous != value)
                        throw Error("Conflicting values for " + option + ": '" + previous + "' and '" + value + "'.");
                    supplied[option] = value;
                    switch (option)
                    {
                        case "--celeste-view":
                            switch (value)
                            {
                                case "normal":
                                    result.View = GameLaunchView.Normal; break;
                                case "level":
                                    result.View = GameLaunchView.Level; break;
                                case "overworld":
                                    result.View = GameLaunchView.Overworld; break;
                                case "postcard":
                                    result.View = GameLaunchView.Postcard; break;
                                default:
                                    throw Error("Invalid --celeste-view '" + value +
                                                "'; expected normal, level, overworld or postcard.");
                            }

                            break;
                        case "--celeste-map": result.Map = value; break;
                        case "--celeste-room": result.Room = value; break;
                        case "--celeste-language": result.Language = value; break;
                        case "--celeste-checkpoint": result.Checkpoint = value; break;
                        case "--celeste-postcard": result.Postcard = value; break;
                        case "--celeste-area":
                            if (!int.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out var area) ||
                                area < 0 || area > 10)
                                throw Error("Invalid --celeste-area '" + value +
                                            "'; expected an integer from 0 to 10.");
                            result.Area = area;
                            break;
                    }
                }
            }

            result.Validate();
            return result;
        }

        public void Validate()
        {
            // Unity serializes unset string fields as empty strings. They remain
            // unspecified in presets; explicit empty CLI values fail before here.
            Map = Unset(Map);
            Room = Unset(Room);
            Language = Unset(Language);
            Postcard = Unset(Postcard);
            Checkpoint = Unset(Checkpoint);
            if (!Enum.IsDefined(typeof(GameLaunchView), View))
                throw Error("Invalid launch view '" + View + "'.");
            if (Area < -1 || Area > 10) throw Error("Area must be unspecified (-1) or from 0 to 10.");
            // A level launch may name an Everest-registered map. Its existence is checked
            // against the active content provider by ValidateContent, not this vanilla table.
            if (Map != null && !Maps.ContainsKey(Map) &&
                View != GameLaunchView.Level)
                throw Error("Unknown --celeste-map '" + Map + "'; use the original map ID without .bin.");
            if (Language != null && !Languages.Contains(Language, StringComparer.Ordinal))
                throw Error("Unknown --celeste-language '" + Language + "'; expected " + string.Join(", ", Languages) +
                            ".");
            if (Postcard != null && Postcard != "csides" && Postcard != "variants")
                throw Error("Invalid --celeste-postcard; expected csides or variants.");
            if (Room != null && string.IsNullOrWhiteSpace(Room)) throw Error("Room cannot be empty.");
            if (Checkpoint != null && string.IsNullOrWhiteSpace(Checkpoint)) throw Error("Checkpoint cannot be empty.");
            if (View != GameLaunchView.Level &&
                (Map != null || Room != null || Checkpoint != null))
                throw Error(
                    "--celeste-map, --celeste-room and --celeste-checkpoint require --celeste-view=level; the selected view is " +
                    View + ".");
            if (Postcard != null && View != GameLaunchView.Postcard)
                throw Error("--celeste-postcard requires --celeste-view=postcard.");
            if (Area != -1 && View != GameLaunchView.Level &&
                View != GameLaunchView.Overworld)
                throw Error("--celeste-area requires --celeste-view=level or overworld.");
            if (Map != null && Area >= 0)
            {
                if (!Maps.TryGetValue(Map, out var mapArea))
                    throw Error("--celeste-area cannot be combined with a registered map ID; select the map by name.");
                if (mapArea != Area)
                    throw Error("Conflicting --celeste-map '" + Map + "' (area " + mapArea + ") and --celeste-area=" +
                                Area + ".");
            }
        }

        // Room validation is supplied by the content loader, keeping launch parsing
        // independent of files, scene construction and Unity resources.
        public void ValidateContent(Func<string, IEnumerable<string>> roomsForMap)
        {
            Validate();
            if (View != GameLaunchView.Level) return;
            if (roomsForMap == null) throw new ArgumentNullException(nameof(roomsForMap));
            var rooms = roomsForMap(ResolvedMap);
            if (rooms == null) throw Error("Map content is unavailable for '" + ResolvedMap + "'.");
            var names = rooms.Select(RuntimeRoomName).ToArray();
            if (Room != null && !names.Contains(RuntimeRoomName(Room), StringComparer.Ordinal))
                throw Error("Unknown --celeste-room '" + Room + "' in map '" + ResolvedMap + "'.");
            if (Checkpoint != null && !names.Contains(RuntimeRoomName(Checkpoint), StringComparer.Ordinal))
                throw Error("Unknown --celeste-checkpoint '" + Checkpoint + "' in map '" + ResolvedMap + "'.");
        }

        public static string RuntimeRoomName(string room)
        {
            return room != null && room.StartsWith("lvl_", StringComparison.Ordinal) ? room.Substring(4) : room;
        }

        private static string Unset(string value)
        {
            return value == "" ? null : value;
        }

        private static ArgumentException Error(string message)
        {
            return new("Celeste launch: " + message);
        }
    }
}
