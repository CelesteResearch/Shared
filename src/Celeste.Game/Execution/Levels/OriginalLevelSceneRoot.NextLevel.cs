using System.Numerics;
using Celeste.Core.Framework.Timing;
using Celeste.Game.Content.Maps;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private void NextLevel(Vector2 at, Vector2 direction)
        {
            Scheduler.OnEndOfFrame += () =>
            {
                var diagnostics = SourceFrameDiagnostics.Current;
                long started = 0;
                var measuring = diagnostics?.BeginTransitionEndOfFrame(out started) ?? false;
                try
                {
                    EngineContext.Effects.TimeRate = 1f;
                    EngineContext.Effects.Anxiety = 0f;
                    EngineContext.Effects.GameRate = 1f;
                    TransitionTo(((OriginalChapterMapData)Session.MapData).GetAt(at), direction);
                }
                finally
                {
                    if (measuring) diagnostics.EndTransitionEndOfFrame(started);
                }
            };
        }
    }
}
