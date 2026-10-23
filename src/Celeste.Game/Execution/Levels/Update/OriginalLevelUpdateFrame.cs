namespace Celeste.Game.Execution.Levels.Update
{
    public sealed class OriginalLevelUpdateFrame
    {
        // Engine's FreezeTimer/DashAssistFreeze suppress Scene.BeforeUpdate/Update/AfterUpdate entirely.
        // Everest 6580 separately dispatches FreezeFrameUpdate before FreezeTimer is decremented.
        // This is distinct from Level.Frozen, which still permits specially tagged entities and the wipe.
        public bool EngineSceneSuppressed;

        // TeleportTo may invoke Level.Update directly after LoadLevel's explicit
        // list commit. Scene.BeforeUpdate and Scene.AfterUpdate do not run there.
        public bool NestedLevelUpdate;
        public bool HasError;
        public bool Paused, Frozen, Transitioning, SkippingCutscene, HasRetryCorpse, HasOverlay;
        public float UnpauseTimer;
        public bool InputDisabled;
        public bool FrozenOrPaused => Frozen || Paused;
    }
}
