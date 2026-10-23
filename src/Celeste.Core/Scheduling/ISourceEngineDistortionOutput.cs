namespace Celeste.Core.Scheduling
{
    public interface ISourceEngineDistortionOutput
    {
        ISourceDistortionParameter AnxietyOrigin { get; }
        ISourceDistortionParameter Anxiety { get; }
        ISourceDistortionParameter GameRate { get; }
        ISourceDistortionParameter WaterSine { get; }
        ISourceDistortionParameter WaterCameraY { get; }
        ISourceDistortionParameter WaterAlpha { get; }
        bool DisableFlashes { get; }
    }
}
