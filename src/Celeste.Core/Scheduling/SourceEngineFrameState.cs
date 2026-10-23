using System;

namespace Celeste.Core.Scheduling
{
    public sealed class SourceEngineFrameState
    {
        public readonly SourceEngineEffectsState Effects;
        public readonly SourceEngineSceneState Scenes = new SourceEngineSceneState();
        public ulong FrameCounter;
        public float RawDeltaTime;
        public float DeltaTime;
        public bool FrozenThisFrame;
        public bool SceneUpdatedThisFrame;

        public SourceEngineFrameState(SourceEngineEffectsState effects)
        {
            Effects = effects ?? throw new ArgumentNullException(nameof(effects));
        }
    }
}
