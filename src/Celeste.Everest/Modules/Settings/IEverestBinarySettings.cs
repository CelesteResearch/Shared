using System;
using System.IO;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.ObjectFactories;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Settings
{
    // Matches EverestModuleBinarySettings without depending on the original Celeste ABI.
    // The caller owns the live settings instance for the entire module lifetime.
    public interface IEverestBinarySettings
    {
        void Read(BinaryReader reader);
        void Write(BinaryWriter writer);
    }
}
