using System.IO;

namespace Celeste.Everest.Modules.Persistence
{
    public abstract class EverestModuleBinarySession : EverestModuleSession
    {
        public abstract void Read(BinaryReader reader);
        public abstract void Write(BinaryWriter writer);
    }
}
