using Celeste.Core.Scheduling;
using Celeste.Game.Diagnostics.Scenes;

namespace Celeste.Everest.Diagnostics.Scenes
{
    public sealed class EverestPreviewRecordingFactory : IOriginalPreviewRecordingFactory
    {
        public PreviewRecordingState CreatePreviewRecording(ISourceEngineContext engine, string filename)
        {
            return new EverestPreviewRecordingState(engine, filename);
        }
    }
}
