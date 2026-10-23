using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Dependencies;
using Celeste.Everest.Modules.Settings;

namespace Celeste.Everest.Modules.Updating
{
    public partial class EverestModUpdaterProcess
    {
        public void VerifyChecksum(EverestModUpdateInfo update, string filePath)
        {
            var actual = BitConverter.ToString(EverestChecksums.GetChecksum(filePath)).Replace("-", "")
                .ToLowerInvariant();
            var expected = update.xxHash[0];
            var message =
                ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("ModUpdaterHelper",
                    EverestLogLevel.Verbose);
            if (message.ShouldLog)
                message.Write("Verifying checksum: actual hash is " + actual + ", expected hash is " + expected);
            if (expected != actual) throw new IOException("Checksum error: expected " + expected + ", got " + actual);
        }

        public IEnumerable GetAllMirrorUrls(string url)
        {
            return getAllMirrorUrls(url);
        }

        private IEnumerable<string> getAllMirrorUrls(string url)
        {
            var gbid = 0u;
            if ((url.StartsWith("http://gamebanana.com/dl/") &&
                 !uint.TryParse(url.Substring("http://gamebanana.com/dl/".Length), out gbid)) ||
                (url.StartsWith("https://gamebanana.com/dl/") &&
                 !uint.TryParse(url.Substring("https://gamebanana.com/dl/".Length), out gbid)) ||
                (url.StartsWith("http://gamebanana.com/mmdl/") &&
                 !uint.TryParse(url.Substring("http://gamebanana.com/mmdl/".Length), out gbid)) ||
                (url.StartsWith("https://gamebanana.com/mmdl/") &&
                 !uint.TryParse(url.Substring("https://gamebanana.com/mmdl/".Length), out gbid)))
                gbid = 0u;

            if (gbid == 0)
            {
                yield return url;
                yield break;
            }

            var array =
                ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.MirrorPreferences.Split(',');
            for (var i = 0; i < array.Length; i++)
                switch (array[i])
                {
                    case "gb":
                        yield return url;
                        break;
                    case "jade":
                        yield return $"https://celestemodupdater.0x0a.de/banana-mirror/{gbid}.zip";
                        break;
                    case "wegfan":
                        yield return $"https://celeste.weg.fan/api/v2/download/gamebanana-files/{gbid}";
                        break;
                    case "otobot":
                        yield return $"https://banana-mirror-mods.celestemods.com/{gbid}.zip";
                        break;
                    case "risingsunlight":
                        yield return $"https://library.risingsunlight.dev/celeste/mods/{gbid}.zip";
                        break;
                }
        }
    }
}
