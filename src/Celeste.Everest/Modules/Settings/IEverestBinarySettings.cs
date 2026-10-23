using System.IO;

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
