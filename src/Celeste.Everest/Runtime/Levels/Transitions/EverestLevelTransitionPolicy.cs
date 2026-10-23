using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Everest.Runtime.Levels.Update;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Levels.Transitions;
using Celeste.Simulation;

namespace Celeste.Everest.Runtime.Levels.Transitions
{
    public sealed class EverestLevelTransitionPolicy : IOriginalLevelTransitionPolicy
    {
        private readonly EverestLevelUpdateEvents events;
        private readonly IEverestLevelTransitionSettings settings;
        private readonly IOriginalLevelLoaderFactory loaders;

        public EverestLevelTransitionPolicy(EverestLevelUpdateEvents actualEvents,
            IEverestLevelTransitionSettings actualSettings, IOriginalLevelLoaderFactory actualLoaders)
        {
            events = actualEvents ?? throw new ArgumentNullException(nameof(actualEvents));
            settings = actualSettings ?? throw new ArgumentNullException(nameof(actualSettings));
            loaders = actualLoaders ?? throw new ArgumentNullException(nameof(actualLoaders));
        }

        public IEnumerator CreateRoutine(OriginalLevelTransitionSequence sequence, OriginalLevelRoomData next,
            Vector2 direction)
            => new TransitionRoutine(sequence, next, direction, this);

        public void Start(OriginalLevelTransitionSequence sequence, OriginalLevelRoomData next, Vector2 direction)
        {
            var level = sequence.Level;
            level.Session.CoreMode = level.CoreMode;
            sequence.AssignRoutine(sequence.CreateRoutine(next, direction));
            var diagnostics = global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current;
            long started = 0;
            bool measuring = diagnostics?.BeginTransitionEvents(out started) ?? false;
            try
            {
                events.TransitionTo(level, next, direction);
            }
            finally
            {
                if (measuring) diagnostics.EndTransitionEvents(started);
            }
        }

        private sealed class TransitionRoutine : IEnumerator<object>
        {
            private readonly OriginalLevelTransitionSequence sequence;
            private readonly OriginalLevelRoomData next;
            private readonly Vector2 direction;
            private readonly EverestLevelTransitionPolicy policy;
            private int state;
            private object current;
            private RoomPlayerSession player;
            private IEnumerator original;
            private Vector2 playerPosition;
            private TimeSpan playerStuck;

            public TransitionRoutine(OriginalLevelTransitionSequence sequence, OriginalLevelRoomData next,
                Vector2 direction, EverestLevelTransitionPolicy policy)
            {
                this.sequence = sequence;
                this.next = next;
                this.direction = direction;
                this.policy = policy;
            }

            public object Current => current;
            public void Reset() => throw new NotSupportedException();

            public void Dispose()
            {
                player = null;
                original = null;
                state = -2;
            }

            public bool MoveNext()
            {
                var level = sequence.Level;
                int previousState = state;
                if (previousState < 0 || previousState > 3) return false;
                state = -1;
                if (previousState == 0)
                {
                    var players =
                        level.Scheduler.Entities.GetTrackedEntities(typeof(global::Celeste.Simulation.RoomPlayerSession)
                            .FullName);

                    player = players.Count == 0 ? null : players[0] as RoomPlayerSession;
                    if (player == null)
                    {
                        level.EngineContext.Frame.Scenes.NextScene =
                            policy.loaders.CreateLevelLoader(level.Session, level.Session.RespawnPoint);
                        return false;
                    }

                    original = sequence.CreateOriginalRoutine(next, direction);
                    if (level.AreaData.LevelSet == "Celeste" || policy.settings.DisableAntiSoftlock)
                        previousState = 1;
                    else
                    {
                        players = level.Scheduler.Entities.GetTrackedEntities(
                            typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                        player = players.Count == 0 ? null : players[0] as RoomPlayerSession;
                        if (player == null) previousState = 2;
                        else
                        {
                            playerPosition = player.Body.Position;
                            playerStuck = TimeSpan.FromTicks(level.Session.Time);
                            previousState = 3;
                        }
                    }
                }

                if (!original.MoveNext()) return false;
                if (previousState == 3)
                {
                    if (playerPosition != player.Body.Position) playerStuck = TimeSpan.FromTicks(level.Session.Time);
                    playerPosition = player.Body.Position;
                    if ((TimeSpan.FromTicks(level.Session.Time) - playerStuck).TotalSeconds >= 5d)
                    {
                        level.Session.Level = next.Name;
                        level.Session.RespawnPoint = Vector2Selection.ClosestTo(
                            ((OriginalLevelRoomData)level.Session.LevelData).Spawns, player.Body.Position,
                            ((ISourceVectorEnvironment)level.EngineContext).VectorArithmetic);
                        level.EngineContext.Frame.Scenes.NextScene =
                            policy.loaders.CreateLevelLoader(level.Session, level.Session.RespawnPoint);
                        return false;
                    }
                }

                current = original.Current;
                state = previousState;
                return true;
            }
        }
    }
}
