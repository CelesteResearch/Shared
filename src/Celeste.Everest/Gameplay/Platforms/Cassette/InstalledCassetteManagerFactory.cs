using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Gameplay.Platforms.Cassette;

namespace Celeste.Everest.Gameplay.Platforms.Cassette
{
    public sealed class InstalledCassetteManagerFactory : IOriginalCassetteManagerFactory
    {
        private readonly ISourceEngineContext engine;
        private readonly IRumbleSession rumble;

        public InstalledCassetteManagerFactory(ISourceEngineContext engine, IRumbleSession rumble)
        {
            this.engine = engine;
            this.rumble = rumble;
        }

        public OriginalCassetteBlockManagerState Create() => new InstalledCassetteBlockManagerState(engine, rumble);
    }
}
