using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.Ascension;
using Celeste.Game.Entities.BadelineBoosts;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Presentation.Backdrops.Blackhole;
using Celeste.Game.Profiles;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Rendering;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Collectibles.Strawberry;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Presentation.Backdrops.Parallax;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Stories.Farewell.FinalLaunch
{
    public sealed class FinalLaunchCutscene : OriginalCutsceneEntityState
    {
        private readonly RoomPlayerSession player;

        private readonly BadelineBoostState boost;

        private BirdNpcState bird;

        private float fadeToWhite;

        private Vector2 birdScreenPosition;

        private AscendStreaksState streaks;

        private Vector2 cameraWaveOffset;

        private Vector2 cameraOffset;

        private float timer;

        private SimulationCoroutine wave;
        private readonly ISourceEngineContext engine;

        private bool hasGolden;

        private readonly bool sayDialog;

        public FinalLaunchCutscene(ISourceEngineContext engine, RoomPlayerSession player, BadelineBoostState boost,
            bool sayDialog = true)
            : base(engine, false)
        {
            this.engine = engine;
            this.player = player;
            this.boost = boost;
            this.sayDialog = sayDialog;
            Depth = 10010;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput.SetMusic(null);
            ((ISourceScreenWipeEnvironment)engine).ProcessWipe.WipeColor = PackedColor.White;
            foreach (var follower in player.Leader.Followers)
                if (follower.Entity is ISourceStrawberryFollower { Golden: not false })
                {
                    hasGolden = true;
                    break;
                }

            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene()));
        }

        private IEnumerator Cutscene()
        {
            engine.Effects.TimeRate = 1f;
            boost.Active = false;
            yield return null;
            if (sayDialog)
                yield return TextboxState.Say("CH9_LAST_BOOST", engine);
            else
                yield return 0.152f;

            cameraOffset = new(0f, -20f);
            boost.Active = true;
            player.EnforceLevelBounds = false;
            yield return null;
            var blackholeBG = Level.Background.Get<BlackholeBackdropPresentation>();
            if (((IGameProfileEnvironment)engine).SourceProfile == GameProfile.Original ||
                blackholeBG != null)
            {
                blackholeBG.Direction = -2.5f;
                blackholeBG.SnapStrength(Level, BlackholeBackdropPresentation.Strengths.High);
                blackholeBG.CenterOffset.Y = 100f;
                blackholeBG.OffsetOffset.Y = -50f;
            }

            OwnedComponents.Add(wave = new(engine, WaveCamera()));
            OwnedComponents.Add(new SimulationCoroutine(engine, BirdRoutine(0.8f)));
            streaks = new(engine);
            Level.SourceScene.QueueSourceEntity(streaks);
            float p;
            for (p = 0f; p < 1f; p += engine.DeltaTime / 12f)
            {
                fadeToWhite = p;
                streaks.Alpha = p;
                foreach (var item in Level.Foreground.GetEach<ParallaxBackdropPresentation>(
                             "blackhole"))
                    item.FadeAlphaMultiplier = 1f - p;

                yield return null;
            }

            while (bird != null) yield return null;

            var wipe = new FadeWipePresentation(Level, false)
            {
                Duration = 4f,
            };
            ((ISourceScreenWipeEnvironment)engine).ProcessWipe.WipeColor = PackedColor.White;
            if (!hasGolden)
                ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput.SetMusic(
                    "event:/new_content/music/lvl10/granny_farewell");

            p = cameraOffset.Y;
            var to = 180;
            for (var p2 = 0f; p2 < 1f; p2 += engine.DeltaTime / 2f)
            {
                cameraOffset.Y =
                    p + (to - p) * ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackIn(p2);
                yield return null;
            }

            while (wipe.Percent < 1f) yield return null;

            EndCutscene(Level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            if (WasSkipped && boost != null && boost.Ch9FinalBoostSfx != null)
            {
                boost.Ch9FinalBoostSfx.Stop();
                boost.Ch9FinalBoostSfx.Release();
            }

            var nextLevelName = "end-granny";
            var nextLevelIntro = PlayerIntroType.Transition;
            if (hasGolden)
            {
                nextLevelName = "end-golden";
                nextLevelIntro = PlayerIntroType.Jump;
            }

            player.Active = true;
            player.Speed = Vector2.Zero;
            player.EnforceLevelBounds = true;
            player.Machine.State = 0;
            player.Dummy.Friction = true;
            player.Dummy.Gravity = true;
            player.Dummy.AutoAnimate = true;
            player.ForceCameraUpdate = false;
            engine.Effects.TimeRate = 1f;
            Level.SourceScene.OnEndOfFrame += delegate
            {
                Level.TeleportTo(player, nextLevelName, nextLevelIntro);
                if (hasGolden)
                {
                    if (Level.Wipe != null) Level.Wipe.Cancel();

                    Level.SnapColorGrade("golden");
                    new FadeWipePresentation(level, true).Duration = 2f;
                    ((ISourceScreenWipeEnvironment)engine).ProcessWipe.WipeColor = PackedColor.White;
                }
            };
        }

        private IEnumerator WaveCamera()
        {
            var timer = 0f;
            while (true)
            {
                cameraWaveOffset.X = (float)Math.Sin(timer) * 16f;
                cameraWaveOffset.Y = (float)Math.Sin(timer * 0.5f) * 16f + (float)Math.Sin(timer * 0.25f) * 8f;
                timer += engine.DeltaTime * 2f;
                yield return null;
            }
        }

        private IEnumerator BirdRoutine(float delay)
        {
            yield return delay;
            bird = BirdNpcState.Create(Level, Vector2.Zero, BirdNpcMode.None);
            Level.SourceScene.QueueSourceEntity(bird);
            bird.Sprite.Play("flyupIdle");
            var vector = new Vector2(320f, 180f) / 2f;
            var topCenter = new Vector2(vector.X, 0f);
            var vector2 = new Vector2(vector.X, 180f);
            var from = vector2 + new Vector2(40f, 40f);
            var to = vector + new Vector2(-32f, -24f);
            for (var t = 0f; t < 1f; t += engine.DeltaTime / 4f)
            {
                birdScreenPosition =
                    from + (to - from) * ((ISourceEasingEnvironment)engine).EasingArithmetic.BackOut(t);
                yield return null;
            }

            bird.Sprite.Play("flyupRoll");
            for (var t = 0f; t < 1f; t += engine.DeltaTime / 2f)
            {
                birdScreenPosition =
                    to + new Vector2(64f, 0f) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(t);
                yield return null;
            }

            to = birdScreenPosition;
            from = topCenter + new Vector2(-40f, -100f);
            var playedAnim = false;
            for (var t = 0f; t < 1f; t += engine.DeltaTime / 4f)
            {
                if (t >= 0.35f && !playedAnim)
                {
                    bird.Sprite.Play("flyupRoll");
                    playedAnim = true;
                }

                birdScreenPosition =
                    to + (from - to) * ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackIn(t);
                birdScreenPosition.X += t * 32f;
                yield return null;
            }

            bird.RemoveSelf();
            bird = null;
        }

        public override void Update()
        {
            base.Update();
            timer += engine.DeltaTime;
            if (bird != null)
            {
                bird.Position = Level.Camera.Position + birdScreenPosition;
                bird.Position = new(bird.Position.X + (float)Math.Sin(timer) * 4f, bird.Position.Y);
                bird.Position = new(bird.Position.X,
                    bird.Position.Y + (float)Math.Sin(timer * 0.1f) * 4f + (float)Math.Sin(timer * 0.25f) * 4f);
            }

            Level.CameraOffset = cameraOffset + cameraWaveOffset;
        }

        public override void Render(ISourceRenderContext context)
        {
            var camera = Level.Camera;
            SourcePrimitiveDrawing.Rect(context, this, camera.Position.X - 1f, camera.Position.Y - 1f, 322f, 322f,
                PackedColor.White * fadeToWhite);
        }
    }
}
