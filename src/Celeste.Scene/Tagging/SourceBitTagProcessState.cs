using System;
using System.Collections.Generic;

namespace Celeste.Scene.Tagging
{
    public class SourceBitTagProcessState
    {
        public int TotalTags = 0;
        public SourceBitTag[] ByID = new SourceBitTag[32];

        private Dictionary<string, SourceBitTag> byName =
            new Dictionary<string, SourceBitTag>(StringComparer.OrdinalIgnoreCase);

        public SourceBitTag Get(string name) => byName[name];

        internal void PublishName(string name, SourceBitTag actualTag) => byName[name] = actualTag;
    }
}
