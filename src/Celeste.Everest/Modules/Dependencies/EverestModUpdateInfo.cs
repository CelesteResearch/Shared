using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using YamlDotNet.Serialization;
using MAB.DotIgnore;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Dependencies
{
    public sealed class EverestModUpdateInfo
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public int LastUpdate { get; set; }
        public string URL { get; set; }
        public List<string> xxHash { get; set; }
        public string GameBananaType { get; set; }
        public int GameBananaId { get; set; }
    }
}
