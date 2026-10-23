using Celeste.Scene.Tracking;
using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Audio;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Controls.Source;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Animation;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;

namespace Celeste.Game.Gameplay.Platforms.Clouds
{
    public static class BouncingCloudMotion
    {
        public static void Update<TState>(TState state) where TState : struct, IBouncingCloudState
        {
            state.Scale.X = ScalarMath.Approach(state.Scale.X, 1f, 1f * state.Engine.DeltaTime,
                ((ISourceExtremaEnvironment)state.Engine).ExtremaArithmetic);
            state.Scale.Y = ScalarMath.Approach(state.Scale.Y, 1f, 1f * state.Engine.DeltaTime,
                ((ISourceExtremaEnvironment)state.Engine).ExtremaArithmetic);
            state.Timer += state.Engine.DeltaTime;
            if (state.Platform.GetPlayerRider() != null)
            {
                state.Sprite.Position = Vector2.Zero;
            }
            else
            {
                state.Sprite.Position = ((ISourceVectorEnvironment)state.Engine).VectorArithmetic.Approach(
                    state.Sprite.Position,
                    new Vector2(0f, (float)Math.Sin(state.Timer * 2f)), state.Engine.DeltaTime * 4f);
            }

            if (state.RespawnTimer > 0f)
            {
                state.RespawnTimer -= state.Engine.DeltaTime;
                if (state.RespawnTimer <= 0f)
                {
                    state.Waiting = true;
                    state.Platform.Y = state.StartY;
                    state.Speed = 0f;
                    state.Scale = Vector2.One;
                    state.Platform.Collidable = true;
                    state.Sprite.Play("spawn");
                    state.Sound.Play("event:/game/04_cliffside/cloud_pink_reappear");
                }

                return;
            }

            if (state.Waiting)
            {
                RoomPlayerSession playerRider = state.Platform.GetPlayerRider();
                if (playerRider != null && playerRider.Data.Motion.Normal.Speed.Y >= 0f)
                {
                    state.CanRumble = true;
                    state.Speed = 180f;
                    state.Scale = new Vector2(1.3f, 0.7f);
                    state.Waiting = false;
                    if (state.Pink)
                    {
                        ((ISourceSpatialAudioEnvironment)state.Engine).SpatialAudio.Play(
                            "event:/game/04_cliffside/cloud_pink_boost", state.Platform.Position);
                    }
                    else
                    {
                        ((ISourceSpatialAudioEnvironment)state.Engine).SpatialAudio.Play(
                            "event:/game/04_cliffside/cloud_blue_boost", state.Platform.Position);
                    }
                }

                return;
            }

            if (state.Returning)
            {
                state.Speed = ScalarMath.Approach(state.Speed, 180f, 600f * state.Engine.DeltaTime,
                    ((ISourceExtremaEnvironment)state.Engine).ExtremaArithmetic);
                state.Platform.MoveTowardsY(state.StartY, state.Speed * state.Engine.DeltaTime);
                if (state.Platform.ExactPosition.Y == state.StartY)
                {
                    state.Returning = false;
                    state.Waiting = true;
                    state.Speed = 0f;
                }

                return;
            }

            if (state.ShouldFade)
            {
                state.BeginFade(false);
            }

            if (state.Speed < 0f && state.CanRumble)
            {
                state.CanRumble = false;
                if (state.Platform.HasPlayerRider())
                {
                    ((IOriginalGameInputProcessEnvironment)state.Engine).InputSource.Rumble(RumbleStrength.Medium,
                        RumbleLength.Medium);
                }
            }

            if (state.Speed < 0f &&
                ((ISourceScene)state.Platform.Scene).SourceScene.Clock.OnInterval(0.02f, state.Engine))
            {
                ((OriginalLevelSceneRoot)state.Platform.Scene).ParticlesBG.Emit(state.ParticleType, 1,
                    SourceVector2Math.Add(state.Platform.Position, new Vector2(0f, 2f)),
                    new Vector2(state.Platform.Collider.Width / 2f, 1f),
                    (float)Math.PI / 2f);
            }

            if (state.SquashWhileRising && state.Speed < 0f)
            {
                state.Sprite.Scale.Y = ScalarMath.Approach(state.Sprite.Scale.Y, 0f, state.Engine.DeltaTime * 4f,
                    ((ISourceExtremaEnvironment)state.Engine).ExtremaArithmetic);
            }

            if (state.Platform.Y >= state.StartY)
            {
                state.Speed -= 1200f * state.Engine.DeltaTime;
            }
            else
            {
                state.Speed += 1200f * state.Engine.DeltaTime;
                if (state.Speed >= -100f)
                {
                    RoomPlayerSession playerRider2 = state.Platform.GetPlayerRider();
                    if (playerRider2 != null && playerRider2.Data.Motion.Normal.Speed.Y >= 0f)
                    {
                        playerRider2.Data.Motion.Normal.Speed.Y = -200f;
                    }

                    if (state.Fragile)
                    {
                        state.BeginFade(true);
                    }
                    else
                    {
                        state.Scale = new Vector2(0.7f, 1.3f);
                        state.Returning = true;
                    }
                }
            }

            float num = state.Speed;
            if (num < 0f)
            {
                num = -220f;
            }

            state.Platform.MoveV(state.Speed * state.Engine.DeltaTime, num);
        }
    }
}
