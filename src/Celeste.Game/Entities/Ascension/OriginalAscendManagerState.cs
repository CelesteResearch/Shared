using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Timing;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Audio;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Presentation.Effects.SpeedRings;
using Celeste.Game.Presentation.Hud.Height;
using Celeste.Game.Stories.Farewell.FreeBird;
using Celeste.Game.Stories.Summit.Ascension;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Entities;
using Celeste.Scene.Rendering;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Backdrops.Parallax;
using Celeste.Simulation.Presentation.Backdrops.Weather.Rain;
using Celeste.Simulation.Presentation.Backdrops.Weather.Snow;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Entities.Ascension
{
    public class OriginalAscendManagerState : SceneEntityState
    {
        public class Clouds : SceneEntityState
        {
            private class Particle
            {
                public Vector2 Position;

                public float Speed;

                public int Index;
            }

            public float Alpha;

            private readonly OriginalAscendManagerState manager;
            private readonly ISourceEngineContext engine;

            private readonly IReadOnlyList<AtlasEntry> textures;

            private readonly Particle[] particles = new Particle[10];

            private readonly PackedColor color;

            public Clouds(ISourceEngineContext engine, OriginalAscendManagerState manager) : base(
                ((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
            {
                this.engine = engine;
                this.manager = manager;
                if (manager == null || !manager.Dark)
                    color = SourceHexColor.HexToColor("b64a86");
                else
                    color = SourceHexColor.HexToColor("082644");

                Depth = -1000000;
                textures =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.Frames("scenery/launch/cloud");
                for (var i = 0; i < particles.Length; i++)
                    particles[i] = new()
                    {
                        Position = new(
                            SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 320f),
                            SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 900f)),
                        Speed = SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 400, 800),
                        Index = ((ISourceRandomEnvironment)engine).Random.Next(textures.Count),
                    };
            }

            public override void Update()
            {
                base.Update();
                for (var i = 0; i < particles.Length; i++)
                    particles[i].Position.Y += particles[i].Speed * engine.DeltaTime;
            }

            public override void Render(ISourceRenderContext context)
            {
                var num = (manager != null ? manager.Fade : 1f) * Alpha;
                var color = this.color * num;
                var position = (Scene as OriginalLevelSceneRoot).Camera.Position;
                for (var i = 0; i < particles.Length; i++)
                {
                    var position2 = particles[i].Position;
                    position2.Y = -360f + ScalarMath.Mod(position2.Y, 900f);
                    position2 += position;
                    var texture = textures[particles[i].Index];
                    var draw = new AtlasTextureDraw(texture, position2,
                        new Vector2(texture.FrameWidth, texture.FrameHeight) * .5f, color, Vector2.One);
                    ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, this);
                }
            }
        }

        private class Fader : SceneEntityState
        {
            public float Fade;

            private readonly OriginalAscendManagerState manager;
            private readonly ISourceEngineContext engine;

            public Fader(ISourceEngineContext engine, OriginalAscendManagerState manager) : base(
                ((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
            {
                this.engine = engine;
                this.manager = manager;
                Depth = -1000010;
            }

            public override void Render(ISourceRenderContext context)
            {
                if (!(Fade > 0f))
                    return;
                var position = (Scene as OriginalLevelSceneRoot).Camera.Position;
                SourcePrimitiveDrawing.Rect(context, this, position.X - 10f, position.Y - 10f, 340f, 200f,
                    (manager.Dark ? PackedColor.Black : PackedColor.White) * Fade);
            }
        }

        private const string BeginSwapFlag = "beginswap_";

        private const string BgSwapFlag = "bgswap_";

        private readonly ISourceEngineContext engine;
        public readonly bool Dark;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        internal float Fade => fade;
        public readonly bool Ch9Ending;

        private readonly bool introLaunch;

        private readonly int index;

        private readonly string cutscene;

        private OriginalLevelSceneRoot level;

        private float fade;

        private float scroll;

        private bool outTheTop;

        private readonly PackedColor background;

        private readonly string ambience;

        public OriginalAscendManagerState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = data.Position + offset;
            Tags = new(((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value);
            Depth = 8900;
            index = EntityAttributeReader.Int(data.Values, "index");
            cutscene = EntityAttributeReader.Attr(data.Values, "cutscene");
            introLaunch = EntityAttributeReader.Bool(data.Values, "intro_launch");
            Dark = EntityAttributeReader.Bool(data.Values, "dark");
            Ch9Ending = cutscene.Equals("CH9_FREE_BIRD", StringComparison.InvariantCultureIgnoreCase);
            ambience = EntityAttributeReader.Attr(data.Values, "ambience");
            background = Dark ? PackedColor.Black : SourceHexColor.HexToColor("75a0ab");
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = Scene as OriginalLevelSceneRoot;
            OwnedComponents.Add(new SimulationCoroutine(engine, Routine()));
        }

        private IEnumerator Routine()
        {
            var player =
                ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            while (player == null || player.Y > Y)
            {
                player =
                    ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(RoomPlayerSession).FullName);

                yield return null;
            }

            if (index == 9) yield return 1.6f;

            var entity = new AscendStreaksState(engine, this);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(entity);
            if (!Dark)
            {
                var entity2 = new Clouds(engine, this);
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(entity2);
            }

            level.Session.SetFlag("beginswap_" + index);
            player.Sprite.Play("launch");
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            player.Machine.State = 11;
            player.Dummy.Gravity = false;
            player.Dummy.AutoAnimate = false;
            if (!string.IsNullOrWhiteSpace(ambience))
            {
                if (ambience.Equals("null", StringComparison.InvariantCultureIgnoreCase))
                    ((IOriginalGameplayProcess)engine).AudioSession.SetAmbience(null);
                else
                    ((IOriginalGameplayProcess)engine).AudioSession.SetAmbience(
                        ((IOriginalSfxEnvironment)engine).Sfx.EventnameByHandle(ambience));
            }

            if (introLaunch)
            {
                FadeSnapTo(1f);
                level.Camera.Position = player.Center + new Vector2(-160f, -90f);
                yield return 2.3f;
            }
            else
            {
                yield return FadeTo(1f, Dark ? 2f : 0.8f);
                if (Ch9Ending)
                {
                    level.SourceScene.QueueSourceEntity(new OriginalFreeBirdEndingCutscene(engine));
                    while (true) yield return null;
                }

                if (!string.IsNullOrEmpty(cutscene))
                {
                    yield return 0.25f;
                    var cs = new OriginalSummitAscendCutscene(engine, index, cutscene, Dark);
                    level.SourceScene.QueueSourceEntity(cs);
                    yield return null;
                    while (cs.Running) yield return null;
                }
                else
                {
                    yield return 0.5f;
                }
            }

            level.CanRetry = false;
            player.Sprite.Play("launch");
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/summit_flytonext",
                player.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            yield return 0.25f;
            var from = player.Position;
            for (var p = 0f; p < 1f; p += engine.DeltaTime / 1f)
            {
                player.Position =
                    Vector2Interpolation.Lerp(from, from + new Vector2(0f, 60f),
                        ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(p),
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic) +
                    RandomShakeVector.Next(((ISourceRandomEnvironment)engine).Random);
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
                yield return null;
            }

            var fader = new Fader(engine, this);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(fader);
            if (((IOriginalAscendPolicyEnvironment)engine).AscendPolicy.ShouldRestorePlayerX(player))
                player.X = from.X;
            from = player.Position;
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(3, 2);
            for (var p = 0f; p < 1f; p += engine.DeltaTime / 0.5f)
            {
                var y = player.Y;
                player.Position = Vector2Interpolation.Lerp(from, from + new Vector2(0f, -160f),
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.SineIn(p),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                if (p == 0f || IntervalQueries.OnInterval(player.Y, y, 16f))
                {
                    var receiver = level;
                    var ring = engine.EntityPools.Create<OriginalSpeedRingState>();
                    receiver.SourceScene.QueueSourceEntity(ring.Init(player.Center,
                        Vector2Geometry.Angle(new(0f, -1f)), PackedColor.White));
                }

                if (p >= 0.5f)
                    fader.Fade = (p - 0.5f) * 2f;
                else
                    fader.Fade = 0f;

                yield return null;
            }

            level.CanRetry = true;
            outTheTop = true;
            player.Y = level.Bounds.Top;
            player.SummitLaunch(player.X);
            player.Dummy.Gravity = true;
            player.Dummy.AutoAnimate = true;
            level.Session.SetFlag("bgswap_" + index);
            level.NextTransitionDuration = 0.05f;
            if (introLaunch) level.SourceScene.QueueSourceEntity(new OriginalHeightDisplayState(engine, -1));
        }

        public override void Update()
        {
            scroll += engine.DeltaTime * 240f;
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, this, level.Camera.X - 10f, level.Camera.Y - 10f, 340f, 200f,
                background * Fade);
        }

        public override void Removed(object scene)
        {
            FadeSnapTo(0f);
            level.Session.SetFlag("bgswap_" + index, false);
            level.Session.SetFlag("beginswap_" + index, false);
            if (outTheTop)
            {
                ((ISourceScreenWipeEnvironment)engine).ProcessWipe.WipeColor =
                    Dark ? PackedColor.Black : PackedColor.White;
                if (introLaunch)
                    new MountainWipePresentation((ISourceRendererScene)Scene, true);
                else if (index == 0)
                    OriginalAreaScreenWipe.DoScreenWipe(((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetAreaById(1),
                        (ISourceRendererScene)Scene, true);
                else if (index == 1)
                    OriginalAreaScreenWipe.DoScreenWipe(((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetAreaById(2),
                        (ISourceRendererScene)Scene, true);
                else if (index == 2)
                    OriginalAreaScreenWipe.DoScreenWipe(((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetAreaById(3),
                        (ISourceRendererScene)Scene, true);
                else if (index == 3)
                    OriginalAreaScreenWipe.DoScreenWipe(((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetAreaById(4),
                        (ISourceRendererScene)Scene, true);
                else if (index == 4)
                    OriginalAreaScreenWipe.DoScreenWipe(((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetAreaById(5),
                        (ISourceRendererScene)Scene, true);
                else if (index == 5)
                    OriginalAreaScreenWipe.DoScreenWipe(((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetAreaById(7),
                        (ISourceRendererScene)Scene, true);
                else if (index >= 9)
                    OriginalAreaScreenWipe.DoScreenWipe(((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetAreaById(10),
                        (ISourceRendererScene)Scene, true);

                ((ISourceScreenWipeEnvironment)engine).ProcessWipe.WipeColor = PackedColor.Black;
            }

            base.Removed(scene);
        }

        private IEnumerator FadeTo(float target, float duration = 0.8f)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while ((fade = ScalarMath.Approach(Fade, target, engine.DeltaTime / duration,
                       ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)) != target)
            {
                FadeSnapTo(Fade);
                yield return null;
            }

            FadeSnapTo(target);
        }

        private void FadeSnapTo(float target)
        {
            fade = target;
            SetSnowAlpha(1f - Fade);
            SetBloom(Fade * 0.1f);
            if (!Dark) return;

            foreach (var item in level.Background.GetEach<ParallaxBackdropPresentation>())
                item.CameraOffset.Y -= 25f * target;

            foreach (var item2 in level.Foreground.GetEach<ParallaxBackdropPresentation>()) item2.Alpha = 1f - Fade;
        }

        private void SetBloom(float add)
        {
            level.Bloom.Base = ((IOriginalAreaKeyEnvironment)engine).AreaKeys
                .GetArea(((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session)).BloomBase + add;
        }

        private void SetSnowAlpha(float value)
        {
            var snow = level.Foreground.Get<SnowBackdropPresentation>();
            if (snow != null) snow.Alpha = value;

            var rainFG = level.Foreground.Get<RainBackdropPresentation>();
            if (rainFG != null) rainFG.Alpha = value;

            var windSnowFG = level.Foreground.Get<WindSnowBackdropPresentation>();
            if (windSnowFG != null) windSnowFG.Alpha = value;
        }
    }
}
