using System;
using System.IO;
using System.Text;
using System.Threading;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.ObjectFactories;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Persistence
{
    public abstract class EverestModuleSaveData
    {
        [YamlIgnore] public int Index { get; set; }
    }
}
