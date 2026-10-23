using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Ascension
{
    public sealed class EverestAscendPolicy : IOriginalAscendPolicy
    {
        private readonly ISourceEngineContext engine;

        public EverestAscendPolicy(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public bool ShouldRestorePlayerX(RoomPlayerSession player)
        {
            return ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetLevelSet(
                ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(
                    (engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot).Session)) != "Celeste";
        }

        public bool HeightDisplayPlayerAirborne(RoomPlayerSession player)
        {
            return player.Scene != null && !player.OnGround();
        }
    }
}
