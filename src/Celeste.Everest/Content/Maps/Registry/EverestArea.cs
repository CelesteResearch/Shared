using System;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed partial class EverestArea : OriginalAreaData
    {
        public string SID;
        private WeakReference levelSetSID;
        private string levelSet;
        public EverestMapMetadata Metadata;

        protected override string GetSID()
        {
            return SID;
        }

        public override string LevelSet
        {
            get
            {
                var sid = SID;
                if (ReferenceEquals(sid, levelSetSID?.Target)) return levelSet;
                levelSetSID = new(sid);
                if (string.IsNullOrEmpty(sid)) return levelSet = "Celeste";
                var separator = sid.LastIndexOf('/');
                if (separator == -1) return levelSet = "";
                return levelSet = sid.Substring(0, separator);
            }
        }

        public EverestCassetteModifier CassetteModifier => Metadata?.CassetteModifier;
    }
}
