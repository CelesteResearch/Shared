using System.Collections.Generic;

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
