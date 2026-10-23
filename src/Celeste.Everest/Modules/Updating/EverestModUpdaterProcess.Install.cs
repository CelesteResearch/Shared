using System.IO;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Sources;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Dependencies;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Modules.Updating
{
    public partial class EverestModUpdaterProcess
    {
        public void InstallModUpdate(EverestModUpdateInfo update, EverestModuleMetadata mod, string zipPath)
        {
            foreach (var content in
                     ((IEverestContentRegistryEnvironment)engine).SourceContentRegistry.Mods)
                if (content.GetType() == typeof(ZipContentSource) &&
                    (content as ZipContentSource).Path == mod.PathArchive)
                {
                    var zip = content as ZipContentSource;
                    var closing =
                        ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("ModUpdaterHelper",
                            EverestLogLevel.Verbose);
                    if (closing.ShouldLog) closing.Write("Closing mod .zip: " + zip.Path);
                    zip.Dispose();
                }

            var deleting =
                ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("ModUpdaterHelper",
                    EverestLogLevel.Verbose);
            if (deleting.ShouldLog) deleting.Write("Deleting mod .zip: " + mod.PathArchive);
            File.Delete(mod.PathArchive);
            var moving =
                ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("ModUpdaterHelper",
                    EverestLogLevel.Verbose);
            if (moving.ShouldLog) moving.Write("Moving " + zipPath + " to " + mod.PathArchive);
            File.Move(zipPath, mod.PathArchive);
        }
    }
}
