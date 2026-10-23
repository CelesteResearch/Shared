namespace Celeste.Everest.Runtime.Startup
{
    public static class SourceFnaMainArguments
    {
        public static void Parse(string[] args, bool isHeadless, ISourceFnaMainArgumentEnvironment environment)
        {
            environment.SetSourceFnaEnvironmentVariable("FNA_AUDIO_DISABLE_SOUND", "1");
            for (var i = 0; i < args.Length; i++)
                if (!isHeadless && args[i] == "--graphics" && i < args.Length - 1)
                {
                    environment.SetSourceFnaEnvironmentVariable("FNA3D_FORCE_DRIVER", args[i + 1]);
                    i++;
                }

            if (isHeadless) environment.SetSourceFnaEnvironmentVariable("FNA3D_FORCE_DRIVER", "Headless");
        }
    }
}
