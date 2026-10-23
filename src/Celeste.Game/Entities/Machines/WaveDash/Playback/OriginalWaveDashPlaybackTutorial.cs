using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Core.Timing;
using Celeste.Game.Gameplay.Effects.Slashes;
using Celeste.Game.Presentation.Effects.SpeedRings;
using Celeste.Graphics.Animation.Replay;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Tutorial.Replay;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;

namespace Celeste.Game.Entities.Machines.WaveDash.Playback
{
    public class OriginalWaveDashPlaybackTutorial
    {
        private readonly ISourceEngineContext engine;
        public Action<ISourceRenderContext> OnRender;

        private bool hasUpdated;

        private float dashTrailTimer;

        private int dashTrailCounter;

        private bool dashing;

        private bool firstDash = true;

        private bool launched;

        private float launchedDelay;

        private float launchedTimer;

        private readonly int tag;

        private readonly Vector2 dashDirection0;

        private readonly Vector2 dashDirection1;

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public PlayerPlaybackState Playback { get; private set; }

        public OriginalWaveDashPlaybackTutorial(ISourceEngineContext engine, string name, Vector2 offset,
            Vector2 dashDirection0, Vector2 dashDirection1)
        {
            this.engine = engine;
            var timeline = ((ISourcePlaybackTimelineEnvironment)engine).PlaybackTimelines[name];
            Playback = new(engine, offset, PlayerSpriteMode.MadelineNoBackpack, timeline,
                (IPlayerPlaybackAudio)engine);
            tag = ((ISourceRandomEnvironment)engine).Random.Next();
            this.dashDirection0 = dashDirection0;
            this.dashDirection1 = dashDirection1;
        }

        public void Update()
        {
            Playback.Update();
            Playback.Hair.AfterUpdate();
            if (Playback.Sprite.CurrentAnimationID == "dash" && Playback.Sprite.CurrentAnimationFrame == 0)
            {
                if (!dashing)
                {
                    dashing = true;
                    ((ISourceFreezeEnvironment)engine).Freeze(0.05f);
                    OriginalSlashFxState.Burst(engine, Playback.Center,
                        Vector2Geometry.Angle(firstDash ? dashDirection0 : dashDirection1)).Tags = tag;
                    dashTrailTimer = 0.1f;
                    dashTrailCounter = 2;
                    CreateTrail();
                    if (firstDash) launchedDelay = 0.15f;

                    firstDash = !firstDash;
                }
            }
            else
            {
                dashing = false;
            }

            if (dashTrailTimer > 0f)
            {
                dashTrailTimer -= engine.DeltaTime;
                if (dashTrailTimer <= 0f)
                {
                    CreateTrail();
                    dashTrailCounter--;
                    if (dashTrailCounter > 0) dashTrailTimer = 0.1f;
                }
            }

            if (launchedDelay > 0f)
            {
                launchedDelay -= engine.DeltaTime;
                if (launchedDelay <= 0f)
                {
                    launched = true;
                    launchedTimer = 0f;
                }
            }

            if (launched)
            {
                var prevVal = launchedTimer;
                launchedTimer += engine.DeltaTime;
                if (launchedTimer >= 0.5f)
                {
                    launched = false;
                    launchedTimer = 0f;
                }
                else if (IntervalQueries.OnInterval(launchedTimer, prevVal, 0.15f))
                {
                    var speedRing = engine.EntityPools.Create<OriginalSpeedRingState>()
                        .Init(Playback.Center,
                            Vector2Geometry.Angle(SourceVector2Math.Subtract(Playback.Position, Playback.LastPosition)),
                            PackedColor.White);
                    speedRing.Tags = tag;
                    ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.QueueSourceEntity(speedRing);
                }
            }

            hasUpdated = true;
        }

        public void Render(ISourceRenderContext context, Vector2 position, float scale)
        {
            var transformMatrix = SourceMatrixMath.Multiply(SourceMatrixMath.CreateScale(4f),
                SourceMatrixMath.CreateTranslation(position.X, position.Y, 0f));
            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, null, null, null, transformMatrix);
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (SceneEntityState entity in ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.Entities
                     .GetTrackedEntities(
                         typeof(TrailSnapshotState)))
                if (entity.Tags == tag)
                    entity.Render(context);

            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (SceneEntityState entity2 in ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.Entities
                     .GetTrackedEntities("Celeste.SlashFx"))
                if (entity2.Tags == tag && entity2.Visible)
                    entity2.Render(context);

            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (SceneEntityState entity3 in ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.Entities
                     .GetTrackedEntities("Celeste.SpeedRing"))
                if (entity3.Tags == tag)
                    entity3.Render(context);

            if (Playback.Visible && hasUpdated) Playback.Render(context);

            if (OnRender != null) OnRender(context);

            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
        }

        private void CreateTrail()
        {
            TrailManagerState.Add(engine, (ISourceRenderEnvironment)engine, Playback.Position, Playback.Sprite,
                Playback.Hair, Playback.Sprite.Scale, PlayerHairAppearance.UsedHairColor, 0).Tags = tag;
        }
    }
}
