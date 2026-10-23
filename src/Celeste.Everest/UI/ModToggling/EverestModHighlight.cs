using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Numerics;
using Celeste.Simulation.Rendering;
using YamlDotNet.Serialization;
using Celeste.Everest;

namespace Celeste.Everest.UI.ModToggling
{
    public enum EverestModHighlight
    {
        Normal,
        Required,
        FavoriteDependency,
        Favorite
    }
}
