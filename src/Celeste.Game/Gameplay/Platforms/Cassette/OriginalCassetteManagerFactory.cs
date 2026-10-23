using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay.Feedback;

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

        public OriginalCassetteBlockManagerState Create()
        {
            return new(engine, rumble);
        }
    }
}
