using System;
using System.IO;
using System.Text;
using System.Threading;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.ObjectFactories;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Persistence
{
    public abstract class
        EverestModuleBinarySaveData : global::Celeste.Everest.Modules.Persistence.EverestModuleSaveData
    {
        public abstract void Read(BinaryReader reader);
        public abstract void Write(BinaryWriter writer);
    }
}
