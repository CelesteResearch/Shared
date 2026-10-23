using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Pooling;

namespace Celeste.Core.Scheduling
{
    // One actual Engine scope; scene roots retain this reference across their lifetimes.
    public interface ISourceEngineContext
    {
        SourceAlarmPool AlarmPool { get; }
        SourceEngineEffectsState Effects { get; }
        SourceEngineFrameState Frame { get; }
        bool InputDisabled { get; set; }
        SourceEntityPoolRegistry EntityPools { get; }
        float DeltaTime { get; }
        float RawDeltaTime { get; }
        SourceTweenPool TweenPool { get; }
    }
}
