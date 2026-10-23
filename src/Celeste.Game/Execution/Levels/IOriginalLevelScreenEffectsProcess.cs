namespace Celeste.Game.Execution.Levels
{
    public interface IOriginalLevelScreenEffectsProcess
    {
        LevelScreenEffectsBehavior LevelScreenEffectsBehavior { get; }
        bool AllowScreenFlash { get; }
        bool AllowGlitch { get; }
    }
}
