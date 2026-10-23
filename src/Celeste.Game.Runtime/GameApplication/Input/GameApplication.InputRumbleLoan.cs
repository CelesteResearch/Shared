using Celeste.Input.Gameplay.Feedback;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceRumbleEnvironment
    {
        public IRumbleSession RumbleSession => InputSource;
    }
}
