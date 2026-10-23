using System;

namespace Celeste.Game.Entities.Protocols
{
    [Flags]
    public enum OriginalSceneEntityTags
    {
        None = 0,
        PauseUpdate = 1,
        FrozenUpdate = 2,
        TransitionUpdate = 4,
        HUD = 8,
        Persistent = 16,
        Global = 32,
        SubHUD = 64,
        FreezeFrameUpdate = 128,
    }
}
