using System;
using Celeste.Game.Execution.Areas;
using Celeste.Everest.Content.Maps.Metadata;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed partial class EverestArea : OriginalAreaData
    {
        public string SID;
        private WeakReference levelSetSID;
        private string levelSet;
        public EverestMapMetadata Metadata;

        protected override string GetSID() => SID;

        public override string LevelSet
        {
            get
            {
                string sid = SID;
                if (ReferenceEquals(sid, levelSetSID?.Target)) return levelSet;
                levelSetSID = new WeakReference(sid);
                if (string.IsNullOrEmpty(sid)) return levelSet = "Celeste";
                int separator = sid.LastIndexOf('/');
                if (separator == -1) return levelSet = "";
                return levelSet = sid.Substring(0, separator);
            }
        }

        public EverestCassetteModifier CassetteModifier => Metadata?.CassetteModifier;
    }
}
