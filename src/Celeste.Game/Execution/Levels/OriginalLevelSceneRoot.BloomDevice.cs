namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void ApplyBloom()
        {
            Bloom.Apply(Buffers.Level, this);
        }
    }
}
