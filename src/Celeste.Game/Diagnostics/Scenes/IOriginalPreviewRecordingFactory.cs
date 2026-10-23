using Celeste.Core.Scheduling;

namespace Celeste.Game.Diagnostics.Scenes
{
    public interface IOriginalPreviewRecordingFactory
    {
        PreviewRecordingState CreatePreviewRecording(ISourceEngineContext engine, string filename);
    }
}
