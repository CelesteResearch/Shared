using Celeste.Core.Scheduling;

namespace Celeste.Game.Diagnostics.Scenes
{
    public sealed class OriginalPreviewRecordingFactory : IOriginalPreviewRecordingFactory
    {
        public PreviewRecordingState CreatePreviewRecording(ISourceEngineContext engine, string filename)
        {
            return new(engine, filename);
        }
    }
}
