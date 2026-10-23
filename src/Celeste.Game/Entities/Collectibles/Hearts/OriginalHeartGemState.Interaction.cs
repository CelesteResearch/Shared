using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Gameplay.Enemies.AngryOshiro;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Holdables;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
    public partial class OriginalHeartGemState
    {
        private RoomPlayerSession FirstPlayer()
        {
            var players =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            return players.Count == 0 ? null : players[0] as RoomPlayerSession;
        }

        public void OnHoldable(HoldableState holdable)
        {
            var player = FirstPlayer();
            if (!collected && player != null && holdable.Dangerous(holdableCollider))
                Collect(player);
        }

        public void OnPlayer(RoomPlayerSession player)
        {
            if (collected || ((OriginalLevelSceneRoot)Scene).Frozen)
                return;
            if (player.DashAttacking)
            {
                Collect(player);
                return;
            }

            if (bounceSfxDelay <= 0f)
            {
                if (IsFake)
                    ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                        "event:/new_content/game/10_farewell/fakeheart_bounce", Position);
                else
                    ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                        "event:/game/general/crystalheart_bounce", Position);
                bounceSfxDelay = 0.1f;
            }

            player.PointBounce(Center);
            moveWiggler.Start();
            ScaleWiggler.Start();
            moveWiggleDir = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(
                Center - player.Center, Vector2.UnitY);
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
        }

        private void Collect(RoomPlayerSession player)
        {
            var oshiros = ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.AngryOshiro");
            var oshiro = oshiros.Count == 0 ? null : oshiros[0] as OriginalAngryOshiroState;
            oshiro?.StopControllingTime();
            var coroutine = new SimulationCoroutine(engine, CollectRoutine(player));
            coroutine.UseRawDeltaTime = true;
            OwnedComponents.Add(coroutine);
            collected = true;
            if (!removeCameraTriggers)
                return;
            RemoveSourceCameraOffsetTriggers();
        }
    }
}
