using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Entities.Triggers.Respawning;
using Celeste.Game.Entities.Triggers.Wind;
using Celeste.Game.Execution.Processes;
using Celeste.Physics.Collision;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Execution.Levels.Transitions
{
    public sealed class OriginalLevelTransitionSequence
    {
        private readonly OriginalLevelSceneRoot level;
        private readonly IOriginalLevelTransitionPolicy policy;

        public OriginalLevelTransitionSequence(OriginalLevelSceneRoot actualLevel,
            IOriginalLevelTransitionPolicy actualPolicy)
        {
            level = actualLevel ?? throw new ArgumentNullException(nameof(actualLevel));
            policy = actualPolicy ?? throw new ArgumentNullException(nameof(actualPolicy));
        }

        public OriginalLevelSceneRoot Level => level;
        public bool Active => level.TransitionCoroutine != null;

        public void Start(OriginalLevelRoomData next, Vector2 direction)
        {
            var diagnostics = global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current;
            long started = 0;
            bool measuring = diagnostics?.BeginTransitionStart(out started) ?? false;
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
            => level.TransitionCoroutine = new SimulationCoroutine(level.EngineContext, routine);

        public void Update()
            => level.TransitionCoroutine.Update();

        public IEnumerator CreateRoutine(OriginalLevelRoomData next, Vector2 direction)
            => policy.CreateRoutine(this, next, direction);

        public IEnumerator CreateOriginalRoutine(OriginalLevelRoomData next, Vector2 direction)
        {
            var entities = level.Scheduler.Entities;
            var components = level.Scheduler.Components;
            var players = entities.GetTrackedEntities(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

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

            level.PublishSourcePreviousBounds(level.Bounds);
            level.Session.Level = next.Name;
            level.Session.FirstLevel = false;
            level.Session.DeathsInCurrentLevel = 0;
            level.LoadLevel(PlayerIntroType.Transition);
            ((IOriginalGameplayProcess)level.EngineContext).AudioSession.ChannelOutput.SetAmbienceParam(
                "has_conveyors", entities.GetTrackedEntities("Celeste.WallBooster").Count > 0 ? 1 : 0);
            var transitionIn = CopyTransitionListeners();
            transitionIn.RemoveAll(component => transitionOut.Contains(component));
            ((global::Celeste.Core.Framework.GarbageCollection.ISourceGarbageCollectionEnvironment)
                level.EngineContext).GarbageCollectionPolicy.CollectOnTransition();
            float cameraAt = 0f;
            Vector2 cameraFrom = level.Camera.Position;
            Vector2 dirPad = direction * 4f;
            if (direction == Vector2.UnitY) dirPad = direction * 12f;
            Vector2 playerTo = player.Body.Position;
            while (direction.X != 0f && playerTo.Y >= (float)level.Bounds.Bottom) playerTo.Y -= 1f;
            for (; !level.IsInBounds(playerTo, dirPad); playerTo += direction)
            {
            }

            Vector2 cameraTo = level.GetFullCameraTargetAt(player, playerTo);
            Vector2 position = player.Body.Position;
            player.Body.Position = playerTo;
            foreach (object item in SourceSceneCollisionQueries.All((ISourceEntityCollider)player,
                         entities.GetTrackedEntities("Celeste.WindTrigger")))
            {
                if (!toRemove.Contains(item))
                {
                    level.WindController.SetPattern(((OriginalWindTrigger)item).Pattern);
                    break;
                }
            }

            level.WindController.SetStartPattern();
            player.Body.Position = position;
            foreach (var listener in transitionOut) listener.OnOutBegin?.Invoke();
            foreach (var listener in transitionIn) listener.OnInBegin?.Invoke();
            float lightingStart = level.Lighting.Alpha;
            float lightingEnd = level.DarkRoom
                ? level.Session.DarkRoomAlpha
                : level.BaseLightingAlpha + level.Session.LightingAlphaAdd;
            bool lightingWait = lightingStart >= level.Session.DarkRoomAlpha ||
                                lightingEnd >= level.Session.DarkRoomAlpha;
            if (lightingEnd > lightingStart && lightingWait)
            {
                ((IOriginalGameplayProcess)level.EngineContext).AudioSession.Play(
                    "event:/game/05_mirror_temple/room_lightlevel_down");
                while (level.Lighting.Alpha != lightingEnd)
                {
                    yield return null;
                    level.Lighting.Alpha = ScalarMath.Approach(level.Lighting.Alpha, lightingEnd,
                        2f * level.EngineContext.DeltaTime,
                        ((ISourceExtremaEnvironment)level.EngineContext).ExtremaArithmetic);
                }
            }

            bool cameraFinished = false;
            while (!player.TransitionTo(playerTo, direction) || cameraAt < 1f)
            {
                yield return null;
                if (cameraFinished) continue;
                cameraAt = ScalarMath.Approach(cameraAt, 1f,
                    level.EngineContext.DeltaTime / level.NextTransitionDuration,
                    ((ISourceExtremaEnvironment)level.EngineContext).ExtremaArithmetic);
                if (cameraAt > 0.9f) level.Camera.Position = cameraTo;
                else
                    level.Camera.Position = Vector2Interpolation.Lerp(cameraFrom, cameraTo,
                        ((ISourceEasingEnvironment)level.EngineContext).EasingArithmetic.CubeOut(cameraAt),
                        ((ISourceScalarEnvironment)level.EngineContext).ScalarArithmetic);
                if (!lightingWait && lightingStart < lightingEnd)
                    level.Lighting.Alpha = lightingStart + (lightingEnd - lightingStart) * cameraAt;
                foreach (var listener in transitionOut) listener.OnOut?.Invoke(cameraAt);
                foreach (var listener in transitionIn) listener.OnIn?.Invoke(cameraAt);
                if (cameraAt >= 1f) cameraFinished = true;
            }

            if (lightingEnd < lightingStart && lightingWait)
            {
                ((IOriginalGameplayProcess)level.EngineContext).AudioSession.Play(
                    "event:/game/05_mirror_temple/room_lightlevel_up");
                while (level.Lighting.Alpha != lightingEnd)
                {
                    yield return null;
                    level.Lighting.Alpha = ScalarMath.Approach(level.Lighting.Alpha, lightingEnd,
                        2f * level.EngineContext.DeltaTime,
                        ((ISourceExtremaEnvironment)level.EngineContext).ExtremaArithmetic);
                }
            }

            level.UnloadEntities(toRemove);
            level.Scheduler.CommitEntityListsForLevel();
            var bounds = level.Bounds;
            bounds.Inflate(16, 16);
            level.Particles.ClearRect(bounds, inside: false);
            level.ParticlesBG.ClearRect(bounds, inside: false);
            level.ParticlesFG.ClearRect(bounds, inside: false);
            var target = (OriginalRespawnTargetTrigger)SourceSceneCollisionQueries.First((ISourceEntityCollider)player,
                entities.GetTrackedEntities("Celeste.RespawnTargetTrigger"));
            Vector2 to = target?.Target ?? player.Body.Position;
            var currentRoom = (OriginalLevelRoomData)level.Session.LevelData;
            level.Session.RespawnPoint = Vector2Selection.ClosestTo(currentRoom.Spawns, to,
                ((ISourceVectorEnvironment)level.EngineContext).VectorArithmetic);
            player.OnTransition();
            foreach (var listener in transitionIn) listener.OnInEnd?.Invoke();
            if (currentRoom.DelayAltMusic)
                ((IOriginalGameplayProcess)level.EngineContext).AudioSession.ChannelOutput.SetAltMusic(
                    ((IOriginalSfxEnvironment)level.EngineContext).Sfx.EventnameByHandle(currentRoom.AltMusic));
            level.NextTransitionDuration = 0.65f;
            level.TransitionCoroutine = null;
        }

        private List<RoomTransitionListener> CopyTransitionListeners()
        {
            var components = level.Scheduler.Components.GetTrackedComponents("Celeste.TransitionListener");
            var result = new List<RoomTransitionListener>(components.Count);
            foreach (var entry in components)
                result.Add((RoomTransitionListener)entry);
            return result;
        }
    }
}
