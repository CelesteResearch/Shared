using System;
using System.IO;
using System.Text;
using System.Threading;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.ObjectFactories;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Persistence
{
    public interface IEverestModuleDataSerializer
    {
        void DeserializeInto(object target, Type type, byte[] data);
        byte[] Serialize(object value, Type type);
    }
}
