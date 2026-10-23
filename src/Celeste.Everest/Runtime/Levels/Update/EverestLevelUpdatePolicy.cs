using System;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Update;
using Celeste.Simulation;

namespace Celeste.Everest.Runtime.Levels.Update
{
    public sealed class EverestLevelUpdatePolicy : IOriginalLevelUpdatePolicy
    {
        private readonly EverestLevelUpdateEvents events;

        public EverestLevelUpdatePolicy(EverestLevelUpdateEvents actualProcessEvents)
        {
            events = actualProcessEvents ?? throw new ArgumentNullException(nameof(actualProcessEvents));
        }

        public void Update(OriginalLevelSceneRoot level)
        {
            events.BeforeUpdate(level);
            if (level.CheckForErrors())
            {
                events.AfterUpdate(level);
                return;
            }

            FixChaserStatesTimeStamp(level);
            level.UpdateOriginalGame();
            events.AfterUpdate(level);
        }

        private static void FixChaserStatesTimeStamp(OriginalLevelSceneRoot level)
        {
            if (level.AreaData.LevelSet != "Celeste" && level.UnpauseTimer > 0f)
            {
                var players =
                    level.Scheduler.Entities.GetTrackedEntities(typeof(global::Celeste.Simulation.RoomPlayerSession)
                        .FullName);
                var player = players.Count > 0 ? (RoomPlayerSession)players[0] : null;
                var states = player?.ChaserStates;
                if (states != null)
                {
                    float deltaTime = level.EngineContext.DeltaTime;
                    if (level.UnpauseTimer - level.EngineContext.RawDeltaTime <= 0f) deltaTime *= 2f;
                    for (int i = 0; i < states.Count; i++)
                    {
                        var state = states[i];
                        state.TimeStamp += deltaTime;
                        states[i] = state;
                    }
                }
            }
        }
    }
}
