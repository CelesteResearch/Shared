using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace Celeste.Everest.Runtime
{
    public sealed class EverestFlagsProcess
    {
        public bool IsXNA => false;
        public bool IsFNA => true;
        public bool VanillaIsXNA { get; private set; }
        public bool VanillaIsFNA { get; private set; }
        public bool IsHeadless { get; internal set; }
        public bool IsMono => false;
        public bool AvoidRenderTargets => false;
        public bool PreferLazyLoading => false;
        public bool PreferThreadedGL => false;
        public bool SupportRuntimeMods => true;
        public bool SupportUpdatingEverest => true;

        public void Initialize(string pathGame)
        {
            string path = Path.Combine(pathGame, "orig", "Celeste.exe");
            if (!File.Exists(path))
                return;
            using FileStream peStream = File.OpenRead(path);
            using PEReader peReader = new PEReader(peStream);
            MetadataReader metaReader = peReader.GetMetadataReader();
            VanillaIsFNA = metaReader.AssemblyReferences.Any(handle =>
                metaReader.GetString(metaReader.GetAssemblyReference(handle).Name) == "FNA");
            VanillaIsXNA = !VanillaIsFNA;
        }
    }
}
