using System;
using System.IO;
using System.Text;
using System.Threading;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.ObjectFactories;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Persistence
{
    public interface IEverestModuleDataStorage
    {
        byte[] Read(string fileName);
        void Write(string fileName, byte[] data, bool flushToDisk);
    }
}
