using System.IO;
using Celeste.Everest.Content.Sources;

namespace Celeste.Everest.Content.Assets
{
    public class AssemblyContentAsset : EverestContentAsset
    {
        public readonly string ResourceName;

        public AssemblyContentAsset(AssemblyContentSource source, string resourceName) : base(source)
            => ResourceName = resourceName;

        protected override void Open(out Stream stream, out bool isSection)
        {
            stream = ((AssemblyContentSource)Source).OpenResource(ResourceName);
            isSection = false;
        }
    }
}
