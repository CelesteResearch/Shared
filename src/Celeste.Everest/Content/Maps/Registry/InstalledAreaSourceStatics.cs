using System.Collections.Generic;
using System.Text.RegularExpressions;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed class InstalledAreaSourceStatics
    {
        internal InstalledAreaSourceStatics()
        {
        }

        public EverestMapWipeProcess MapWipes { get; private set; } = null!;
        private Regex ParseNameRegex = null!;
        private Dictionary<string, Match> ParseNameCache = null!;
        private Dictionary<string, OriginalAreaMode> ParseNameModes = null!;

        internal void InitializeInstalledSourceStatics(IEverestFakeEntryAssemblyEnvironment process)
        {
            MapWipes = new(process);
            ParseNameRegex = new(
                "^(?:(?<order>\\d+)(?<side>[ABCHX]?)\\-)?(?<name>.+?)(?:\\-(?<sideAlt>[ABCHX]?))?$",
                RegexOptions.Compiled);
            ParseNameCache = new();
            ParseNameModes = new()
            {
                { "A", OriginalAreaMode.Normal },
                { "B", OriginalAreaMode.BSide },
                { "H", OriginalAreaMode.BSide },
                { "C", OriginalAreaMode.CSide },
                { "X", OriginalAreaMode.CSide },
            };
        }

        public void ParseName(string sid, out int? order, out OriginalAreaMode side, out string name)
        {
            var num = sid.Replace('\\', '/').LastIndexOf('/');
            if (num != -1) sid = sid.Substring(num + 1);

            if (sid.EndsWith(".bin")) sid = sid.Substring(0, sid.Length - 4);

            if (!ParseNameCache.TryGetValue(sid, out var value))
                value = ParseNameCache[sid] = ParseNameRegex.Match(sid);

            var text = value.Groups["order"].Value;
            var text2 = value.Groups["side"].Value;
            if (string.IsNullOrEmpty(text2)) text2 = value.Groups["sideAlt"].Value;

            var text3 = value.Groups["name"].Value;
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text3) && string.IsNullOrEmpty(text2) &&
                ParseNameModes.ContainsKey(text3))
            {
                text2 = text3;
                text3 = text;
                text = null;
            }

            if (int.TryParse(text, out var result))
                order = result;
            else
                order = null;

            if (!ParseNameModes.TryGetValue(text2, out side)) side = OriginalAreaMode.Normal;

            name = text3;
        }
    }
}
