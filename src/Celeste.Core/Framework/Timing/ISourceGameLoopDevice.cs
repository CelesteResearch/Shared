namespace Celeste.Core.Framework.Timing
{
    public interface ISourceGameLoopDevice
    {
        bool NeedsPlatformMainLoop();
        void RunPlatformMainLoop(SourceGameRunLoop actualLoop);
    }
}
