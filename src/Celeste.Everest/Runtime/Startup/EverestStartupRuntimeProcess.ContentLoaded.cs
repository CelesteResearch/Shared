namespace Celeste.Everest.Runtime.Startup
{
    public sealed partial class EverestStartupRuntimeProcess
    {
        public bool IsContentLoaded => ContentLoaded;
        public void MarkSourceContentLoaded() => ContentLoaded = true;
    }
}
