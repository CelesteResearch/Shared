using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Framework.GarbageCollection;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Game.Audio;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Entities.Triggers.Respawning;
using Celeste.Game.Entities.Triggers.Wind;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Execution.Levels.Transitions
{
    public sealed class OriginalLevelTransitionSequence
    {
        private readonly IOriginalLevelTransitionPolicy policy;

        public OriginalLevelTransitionSequence(OriginalLevelSceneRoot actualLevel,
            IOriginalLevelTransitionPolicy actualPolicy)
        {
            Level = actualLevel ?? throw new ArgumentNullException(nameof(actualLevel));
            policy = actualPolicy ?? throw new ArgumentNullException(nameof(actualPolicy));
        }

        public OriginalLevelSceneRoot Level { get; }

        public bool Active => Level.TransitionCoroutine != null;

        public void Start(OriginalLevelRoomData next, Vector2 direction)
        {
            var diagnostics = SourceFrameDiagnostics.Current;
            long started = 0;
            var measuring = diagnostics?.BeginTransitionStart(out started) ?? false;
            try
            {
                policy.Start(this, next, direction);
            }
            finally
            {
                if (measuring) diagnostics.EndTransitionStart(started);
            }
        }

        public void AssignRoutine(IEnumerator routine)
        {
            Level.TransitionCoroutine = new(Level.EngineContext, routine);
        }

        public void Update()
        {
            Level.TransitionCoroutine.Update();
        }

        public IEnumerator CreateRoutine(OriginalLevelRoomData next, Vector2 direction)
        {
            return policy.CreateRoutine(this, next, direction);
        }

        public IEnumerator CreateOriginalRoutine(OriginalLevelRoomData next, Vector2 direction)
        {
            var entities = Level.Scheduler.Entities;
            var components = Level.Scheduler.Components;
            var players = entities.GetTrackedEntities(typeof(RoomPlayerSession).FullName);

            var player = players.Count == 0 ? null : players[0] as RoomPlayerSession;
            var toRemove =
                entities.GetEntitiesExcludingTagMask(OriginalSceneTags.Persistent | OriginalSceneTags.Global);
            var transitionOut = CopyTransitionListeners();
            player.CleanUpPlayerTriggers();
            foreach (var entry in components.GetTrackedComponents("Celeste.SoundSource"))
            {
                var source = (SoundSourceComponentState)entry;
                if (source.DisposeOnTransition) source.Stop();
            }

            Level.PublishSourcePreviousBounds(Level.Bounds);
            Level.Session.Level = next.Name;
            Level.Session.FirstLevel = false;
            Level.Session.DeathsInCurrentLevel = 0;
            Level.LoadLevel(PlayerIntroType.Transition);
            ((IOriginalGameplayProcess)Level.EngineContext).AudioSession.ChannelOutput.SetAmbienceParam(
                "has_conveyors", entities.GetTrackedEntities("Celeste.WallBooster").Count > 0 ? 1 : 0);
            var transitionIn = CopyTransitionListeners();
            transitionIn.RemoveAll(component => transitionOut.Contains(component));
            ((ISourceGarbageCollectionEnvironment)
                Level.EngineContext).GarbageCollectionPolicy.CollectOnTransition();
            var cameraAt = 0f;
            var cameraFrom = Level.Camera.Position;
            var dirPad = direction * 4f;
            if (direction == Vector2.UnitY) dirPad = direction * 12f;
            var playerTo = player.Body.Position;
            while (direction.X != 0f && playerTo.Y >= Level.Bounds.Bottom) playerTo.Y -= 1f;
            for (; !Level.IsInBounds(playerTo, dirPad); playerTo += direction)
            {
            }

            var cameraTo = Level.GetFullCameraTargetAt(player, playerTo);
            var position = player.Body.Position;
            player.Body.Position = playerTo;
            foreach (var item in SourceSceneCollisionQueries.All(player,
                         entities.GetTrackedEntities("Celeste.WindTrigger")))
                if (!toRemove.Contains(item))
                {
                    Level.WindController.SetPattern(((OriginalWindTrigger)item).Pattern);
                    break;
                }

            Level.WindController.SetStartPattern();
            player.Body.Position = position;
            foreach (var listener in transitionOut) listener.OnOutBegin?.Invoke();
            foreach (var listener in transitionIn) listener.OnInBegin?.Invoke();
            var lightingStart = Level.Lighting.Alpha;
            var lightingEnd = Level.DarkRoom
                ? Level.Session.DarkRoomAlpha
                : Level.BaseLightingAlpha + Level.Session.LightingAlphaAdd;
            var lightingWait = lightingStart >= Level.Session.DarkRoomAlpha ||
                               lightingEnd >= Level.Session.DarkRoomAlpha;
            if (lightingEnd > lightingStart && lightingWait)
            {
                ((IOriginalGameplayProcess)Level.EngineContext).AudioSession.Play(
                    "event:/game/05_mirror_temple/room_lightlevel_down");
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                while (Level.Lighting.Alpha != lightingEnd)
                {
                    yield return null;
                    Level.Lighting.Alpha = ScalarMath.Approach(Level.Lighting.Alpha, lightingEnd,
                        2f * Level.EngineContext.DeltaTime,
                        ((ISourceExtremaEnvironment)Level.EngineContext).ExtremaArithmetic);
                }
            }

            var cameraFinished = false;
            while (!player.TransitionTo(playerTo, direction) || cameraAt < 1f)
            {
                yield return null;
                if (cameraFinished) continue;
                cameraAt = ScalarMath.Approach(cameraAt, 1f,
                    Level.EngineContext.DeltaTime / Level.NextTransitionDuration,
                    ((ISourceExtremaEnvironment)Level.EngineContext).ExtremaArithmetic);
                if (cameraAt > 0.9f) Level.Camera.Position = cameraTo;
                else
                    Level.Camera.Position = Vector2Interpolation.Lerp(cameraFrom, cameraTo,
                        ((ISourceEasingEnvironment)Level.EngineContext).EasingArithmetic.CubeOut(cameraAt),
                        ((ISourceScalarEnvironment)Level.EngineContext).ScalarArithmetic);
                if (!lightingWait && lightingStart < lightingEnd)
                    Level.Lighting.Alpha = lightingStart + (lightingEnd - lightingStart) * cameraAt;
                foreach (var listener in transitionOut) listener.OnOut?.Invoke(cameraAt);
                foreach (var listener in transitionIn) listener.OnIn?.Invoke(cameraAt);
                if (cameraAt >= 1f) cameraFinished = true;
            }

            if (lightingEnd < lightingStart && lightingWait)
            {
                ((IOriginalGameplayProcess)Level.EngineContext).AudioSession.Play(
                    "event:/game/05_mirror_temple/room_lightlevel_up");
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                while (Level.Lighting.Alpha != lightingEnd)
                {
                    yield return null;
                    Level.Lighting.Alpha = ScalarMath.Approach(Level.Lighting.Alpha, lightingEnd,
                        2f * Level.EngineContext.DeltaTime,
                        ((ISourceExtremaEnvironment)Level.EngineContext).ExtremaArithmetic);
                }
            }

            Level.UnloadEntities(toRemove);
            Level.Scheduler.CommitEntityListsForLevel();
            var bounds = Level.Bounds;
            bounds.Inflate(16, 16);
            Level.Particles.ClearRect(bounds, false);
            Level.ParticlesBG.ClearRect(bounds, false);
            Level.ParticlesFG.ClearRect(bounds, false);
            var target = (OriginalRespawnTargetTrigger)SourceSceneCollisionQueries.First(player,
                entities.GetTrackedEntities("Celeste.RespawnTargetTrigger"));
            var to = target?.Target ?? player.Body.Position;
            var currentRoom = (OriginalLevelRoomData)Level.Session.LevelData;
            Level.Session.RespawnPoint = Vector2Selection.ClosestTo(currentRoom.Spawns, to,
                ((ISourceVectorEnvironment)Level.EngineContext).VectorArithmetic);
            player.OnTransition();
            foreach (var listener in transitionIn) listener.OnInEnd?.Invoke();
            if (currentRoom.DelayAltMusic)
                ((IOriginalGameplayProcess)Level.EngineContext).AudioSession.ChannelOutput.SetAltMusic(
                    ((IOriginalSfxEnvironment)Level.EngineContext).Sfx.EventnameByHandle(currentRoom.AltMusic));
            Level.NextTransitionDuration = 0.65f;
            Level.TransitionCoroutine = null;
        }

        private List<RoomTransitionListener> CopyTransitionListeners()
        {
            var components = Level.Scheduler.Components.GetTrackedComponents("Celeste.TransitionListener");
            var result = new List<RoomTransitionListener>(components.Count);
            foreach (var entry in components)
                result.Add((RoomTransitionListener)entry);
            return result;
        }
    }
}
