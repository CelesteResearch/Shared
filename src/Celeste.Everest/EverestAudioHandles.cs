using Celeste.Game.Audio;
using System;
using Celeste.Simulation;

namespace Celeste.Everest
{
    // Everest 6580 patch_SFX.EventnameByHandle: raw event paths and the literal
    // "null" sentinel survive lookup; only the original reception typo is fixed.
    public static class EverestAudioHandles
    {
        private static Func<string, string> previous;
        private static bool installed;

        public static void Install()
        {
            if (installed) return;
            previous = OriginalAudioHandles.UnknownHandleResolver;
            OriginalAudioHandles.UnknownHandleResolver = ResolveUnknown;
            installed = true;
        }

        public static void Uninstall()
        {
            if (!installed) return;
            if (OriginalAudioHandles.UnknownHandleResolver == (Func<string, string>)ResolveUnknown)
                OriginalAudioHandles.UnknownHandleResolver = previous;
            previous = null;
            installed = false;
        }

        private static string ResolveUnknown(string handle)
            => handle == "env_amb_03_interior_main"
                ? OriginalAudioHandles.EventnameByHandle("env_amb_03_interior")
                : handle;
    }
}
