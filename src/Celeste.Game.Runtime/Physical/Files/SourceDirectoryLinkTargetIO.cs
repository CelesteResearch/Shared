using System;
using System.IO;
using System.Reflection;
using Celeste.Everest.Runtime.Startup;

namespace Celeste.Game.Runtime.Physical.Files
{
    public sealed class SourceDirectoryLinkTargetIO : IEverestInitializationSaveLinkIO
    {
        private Func<DirectoryInfo, string> getLinkTarget;

        public string GetDirectoryLinkTarget(DirectoryInfo directory)
        {
            if (directory == null) throw new ArgumentNullException(nameof(directory));
            if (getLinkTarget == null)
            {
                var getter = typeof(DirectoryInfo)
                    .GetProperty("LinkTarget", BindingFlags.Instance | BindingFlags.Public)
                    ?.GetGetMethod();
                if (getter == null)
                    throw new PlatformNotSupportedException(
                        "The selected file-system runtime does not expose the actual DirectoryInfo.LinkTarget operation.");
                getLinkTarget = (Func<DirectoryInfo, string>)getter.CreateDelegate(typeof(Func<DirectoryInfo, string>));
            }

            return getLinkTarget(directory);
        }
    }
}
