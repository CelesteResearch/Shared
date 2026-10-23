using Celeste.Core.Display;
using Celeste.Core.Randomness;
using Celeste.Simulation.Gameplay.Tutorial.Replay;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Graphics.Animation.Replay;
using Celeste.Game.Gameplay.Effects.Slashes;
using Celeste.Game.Presentation.Effects.SpeedRings;
using System;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Input.Gameplay;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Text;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Nodes;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Simulation.UI.Menus.Completion;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Threading;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Audio.Fmod.Events;

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

        private int tag;

        private Vector2 dashDirection0;

        private Vector2 dashDirection1;

        public PlayerPlaybackState Playback { get; private set; }

        public OriginalWaveDashPlaybackTutorial(ISourceEngineContext engine, string name, Vector2 offset,
            Vector2 dashDirection0, Vector2 dashDirection1)
        {
            this.engine = engine;
            List<CharacterReplayFrame> timeline = ((ISourcePlaybackTimelineEnvironment)engine).PlaybackTimelines[name];
            Playback = new PlayerPlaybackState(engine, offset, PlayerSpriteMode.MadelineNoBackpack, timeline,
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
                    if (firstDash)
                    {
                        launchedDelay = 0.15f;
                    }

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
                    if (dashTrailCounter > 0)
                    {
                        dashTrailTimer = 0.1f;
                    }
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
                float prevVal = launchedTimer;
                launchedTimer += engine.DeltaTime;
                if (launchedTimer >= 0.5f)
                {
                    launched = false;
                    launchedTimer = 0f;
                }
                else if (Celeste.Core.Timing.IntervalQueries.OnInterval(launchedTimer, prevVal, 0.15f))
                {
                    OriginalSpeedRingState speedRing = engine.EntityPools.Create<OriginalSpeedRingState>()
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
            Matrix4x4 transformMatrix = SourceMatrixMath.Multiply(SourceMatrixMath.CreateScale(4f),
                SourceMatrixMath.CreateTranslation(position.X, position.Y, 0f));
            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, null, null, null, transformMatrix);
            foreach (SceneEntityState entity in ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.Entities
                     .GetTrackedEntities(
                         typeof(global::Celeste.Simulation.Presentation.Effects.Trails.Lifecycle.TrailSnapshotState)))
            {
                if (entity.Tags == tag)
                {
                    entity.Render(context);
                }
            }

            foreach (SceneEntityState entity2 in ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.Entities
                     .GetTrackedEntities("Celeste.SlashFx"))
            {
                if (entity2.Tags == tag && entity2.Visible)
                {
                    entity2.Render(context);
                }
            }

            foreach (SceneEntityState entity3 in ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.Entities
                     .GetTrackedEntities("Celeste.SpeedRing"))
            {
                if (entity3.Tags == tag)
                {
                    entity3.Render(context);
                }
            }

            if (Playback.Visible && hasUpdated)
            {
                Playback.Render(context);
            }

            if (OnRender != null)
            {
                OnRender(context);
            }

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
