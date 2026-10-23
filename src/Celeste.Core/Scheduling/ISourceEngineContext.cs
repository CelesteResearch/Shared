namespace Celeste.Core.Scheduling
{
    // One actual Engine scope; scene roots retain this reference across their lifetimes.
    public interface ISourceEngineContext
    {
        global::Celeste.Core.Components.Timing.SourceAlarmPool AlarmPool { get; }
        SourceEngineEffectsState Effects { get; }
        SourceEngineFrameState Frame { get; }
        bool InputDisabled { get; set; }
        global::Celeste.Core.Pooling.SourceEntityPoolRegistry EntityPools { get; }
        float DeltaTime { get; }
        float RawDeltaTime { get; }
        global::Celeste.Core.Components.Animation.SourceTweenPool TweenPool { get; }
    }
}
