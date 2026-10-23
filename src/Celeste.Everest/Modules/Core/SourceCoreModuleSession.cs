using System.Collections.Generic;
using Celeste.Everest.Modules.Persistence;

namespace Celeste.Everest.Modules.Core
{
    public class SourceCoreModuleSession : EverestModuleSession
    {
        public int WhateverElseCount { get; set; } = 1337;
        public HashSet<string> AttachedDecals { get; set; } = [];
    }
}
