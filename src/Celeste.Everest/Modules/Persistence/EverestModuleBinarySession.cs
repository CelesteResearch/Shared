using System;
using System.IO;
using System.Text;
using System.Threading;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.ObjectFactories;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Persistence
{
    public abstract class EverestModuleBinarySession : global::Celeste.Everest.Modules.Persistence.EverestModuleSession
    {
        public abstract void Read(BinaryReader reader);
        public abstract void Write(BinaryWriter writer);
    }
}
