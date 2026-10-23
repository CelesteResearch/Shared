using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Simulation;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;

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

        public bool HeightDisplayPlayerAirborne(RoomPlayerSession player) => player.Scene != null && !player.OnGround();
    }
}
