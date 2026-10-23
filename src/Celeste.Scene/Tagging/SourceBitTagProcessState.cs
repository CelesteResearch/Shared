using System;
using System.Collections.Generic;

namespace Celeste.Scene.Tagging
{
    public class SourceBitTagProcessState
    {
        public int TotalTags = 0;
        public SourceBitTag[] ByID = new SourceBitTag[32];

        private readonly Dictionary<string, SourceBitTag> byName = new(StringComparer.OrdinalIgnoreCase);

        public SourceBitTag Get(string name)
        {
            return byName[name];
        }

        internal void PublishName(string name, SourceBitTag actualTag)
        {
            byName[name] = actualTag;
        }
    }
}
