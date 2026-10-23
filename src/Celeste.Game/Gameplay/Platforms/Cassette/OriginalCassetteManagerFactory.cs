using Celeste.Input.Gameplay.Feedback;
using Celeste.Core.Scheduling;
using Celeste.Game.Gameplay.Platforms.Cassette;

namespace Celeste.Game.Gameplay.Platforms.Cassette
{
    public sealed class OriginalCassetteManagerFactory : IOriginalCassetteManagerFactory
    {
        private readonly ISourceEngineContext engine;
        private readonly IRumbleSession rumble;

        public OriginalCassetteManagerFactory(ISourceEngineContext engine, IRumbleSession rumble)
        {
            this.engine = engine;
            this.rumble = rumble;
        }

        public OriginalCassetteBlockManagerState Create() => new OriginalCassetteBlockManagerState(engine, rumble);
    }
}
