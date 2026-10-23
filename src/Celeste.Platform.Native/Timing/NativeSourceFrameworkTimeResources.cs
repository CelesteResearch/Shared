using System.Globalization;
using System.Resources;
using Celeste.Core.Framework.Time;

namespace Celeste.Platform.Native.Timing
{
    public sealed class NativeSourceFrameworkTimeResources : ISourceFrameworkTimeResources
    {
        private readonly ResourceManager resources;

        public NativeSourceFrameworkTimeResources(string actualFrameworkResourceDirectory)
        {
            resources = ResourceManager.CreateFileBasedResourceManager(
                "mscorlib", actualFrameworkResourceDirectory, null);
        }

        public string GetResourceString(string name)
            => resources.GetString(name, CultureInfo.CurrentUICulture);
    }
}
