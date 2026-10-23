using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Effects;
using Celeste.Game.Presentation.Hud;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Input.Gameplay;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Backdrops.Stars;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Cutscenes
{
    public class CS06BossEndState : OriginalCutsceneEntityState
    {
        public const string Flag = "badeline_connection";
        private readonly RoomPlayerSession player;
        private readonly OriginalBadelineCryingState badeline;
        private float fade, pictureFade, pictureGlow;
        private AtlasEntry picture;
        private bool waitForKeyPress;
        private float timer;
        private ISourceAudioEventReference sfx;
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        public CS06BossEndState(RoomPlayerSession player, OriginalBadelineCryingState badeline,
            ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
            Tags = OriginalSceneTags.HUD;
            this.player = player;
            this.badeline = badeline;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private void ApplyAudio(OriginalLevelSceneRoot level)
        {
            OriginalAudioSession.Apply(level.Session.Audio, Process.AudioSession.ChannelOutput,
                Process.AudioApplyPolicy);
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            while (!player.OnGround()) yield return null;
            player.Data.Facing = 1;
            yield return 1f;
            var currentLevel = (OriginalLevelSceneRoot)Scene;
            currentLevel.Session.Audio.Music.Event = "event:/music/lvl6/badeline_acoustic";
            ApplyAudio(currentLevel);
            yield return TextboxState.Say("ch6_boss_ending", engine, StartMusic, PlayerHug,
                BadelineCalmDown);
            yield return .5f;
            while ((fade += engine.DeltaTime) < 1f) yield return null;
            picture = Graphics.PortraitsAtlas["hug1"];
            sfx = Process.AudioSession.Play("event:/game/06_reflection/hug_image_1");
            yield return PictureFade(1f);
            yield return WaitForPress();
            sfx = Process.AudioSession.Play("event:/game/06_reflection/hug_image_2");
            yield return PictureFade(0f, .5f);
            picture = Graphics.PortraitsAtlas["hug2"];
            yield return PictureFade(1f);
            yield return WaitForPress();
            sfx = Process.AudioSession.Play("event:/game/06_reflection/hug_image_3");
            while ((pictureGlow += engine.DeltaTime / 2f) < 1f) yield return null;
            yield return .2f;
            yield return PictureFade(0f, .5f);
            while ((fade -= engine.DeltaTime * 12f) > 0f) yield return null;
            level.Session.Audio.Music.Param("levelup", 1f);
            ApplyAudio(level);
            OwnedComponents.Add(new SimulationCoroutine(engine, badeline.TurnWhite(1f)));
            yield return .5f;
            player.Sprite.Play("idle");
            yield return .25f;
            yield return player.DummyWalkToExact((int)player.X - 8, true);
            OwnedComponents.Add(new SimulationCoroutine(engine, CenterCameraOnPlayer()));
            yield return badeline.Disperse();
            ((OriginalLevelSceneRoot)Scene).Session.SetFlag(Flag);
            level.Flash(PackedColor.White);
            level.Session.Inventory.Dashes = 2;
            badeline.RemoveSelf();
            yield return .1f;
            level.SourceScene.QueueSourceEntity(new LevelUpEffectState(player.Position, engine));
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 1);
            yield return 2f;
            yield return level.ZoomBack(.5f);
            EndCutscene(level);
        }

        private IEnumerator StartMusic()
        {
            var level = (OriginalLevelSceneRoot)Scene;
            level.Session.Audio.Music.Event = "event:/music/lvl6/badeline_acoustic";
            ApplyAudio(level);
            yield return .5f;
        }

        private IEnumerator PlayerHug()
        {
            OwnedComponents.Add(new SimulationCoroutine(engine,
                Level.ZoomTo(badeline.Center + new Vector2(0f, -24f) - Level.Camera.Position, 2f, .5f)));
            yield return .6f;
            yield return player.DummyWalkToExact((int)badeline.X - 10);
            player.Data.Facing = 1;
            yield return .25f;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("hug");
            yield return .5f;
        }

        private IEnumerator BadelineCalmDown()
        {
            Process.AudioSession.ChannelOutput.SetAmbienceParam("postboss", 0f);
            badeline.LoopingSfx.Param("end", 1f);
            yield return .5f;
            badeline.Sprite.Play("scaredTransition");
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 2);
            var background = Level.Background.Get<FinalBossStarfieldBackdropPresentation>();
            if (background != null)
                while (background.Alpha > 0f)
                {
                    background.Alpha -= engine.DeltaTime;
                    yield return null;
                }

            yield return 1.5f;
        }

        private IEnumerator CenterCameraOnPlayer()
        {
            yield return .5f;
            var from = Level.ZoomFocusPoint;
            var to = new Vector2(Level.Bounds.Left + 580, Level.Bounds.Top + 124) - Level.Camera.Position;
            for (var p = 0f; p < 1f; p += engine.DeltaTime)
            {
                Level.ZoomFocusPoint = from + (to - from) * Easing.SineInOut(p);
                yield return null;
            }
        }

        private IEnumerator PictureFade(float to, float duration = 1f)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while ((pictureFade = ScalarMath.Approach(pictureFade, to, engine.DeltaTime / duration,
                       ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)) != to) yield return null;
        }

        private IEnumerator WaitForPress()
        {
            waitForKeyPress = true;
            while (!((IGameInputEnvironment)engine).Input[GameAction.MenuConfirm].Pressed) yield return null;
            waitForKeyPress = false;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            if (WasSkipped && sfx != null) sfx.Stop();
            Process.AudioSession.ChannelOutput.SetAmbienceParam("postboss", 0f);
            level.ResetZoom();
            level.Session.Inventory.Dashes = 2;
            level.Session.Audio.Music.Event = "event:/music/lvl6/badeline_acoustic";
            if (WasSkipped) level.Session.Audio.Music.Param("levelup", 2f);
            ApplyAudio(level);
            if (WasSkipped)
                level.SourceScene.QueueSourceEntity(new LevelUpEffectState(player.Position, engine));
            player.Dummy.AutoAnimate = true;
            player.Machine.Locked = false;
            player.Machine.State = 0;
            var background = Level.Background.Get<FinalBossStarfieldBackdropPresentation>();
            if (background != null) background.Alpha = 0f;
            badeline.RemoveSelf();
            level.Session.SetFlag(Flag);
        }

        public override void Update()
        {
            timer += engine.DeltaTime;
            base.Update();
        }

        private void DrawCentered(ISourceRenderContext context, AtlasEntry texture, Vector2 at, PackedColor color,
            float scale = 1f)
        {
            var draw = new AtlasTextureDraw(texture, at, new Vector2(texture.FrameWidth, texture.FrameHeight) / 2f,
                color,
                Vector2.One * scale);
            ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, this);
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!(fade > 0f)) return;
            SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f,
                PackedColor.Black * Easing.CubeOut(fade) * .8f);
            if (picture != null && pictureFade > 0f)
            {
                var eased = Easing.CubeOut(pictureFade);
                Vector2 position = new(960f, 540f);
                var scale = 1f + (1f - eased) * .025f;
                DrawCentered(context, picture, position, PackedColor.White * Easing.CubeOut(pictureFade), scale);
                if (pictureGlow > 0f)
                {
                    DrawCentered(context, Graphics.PortraitsAtlas["hug-light2a"], position,
                        PackedColor.White * Easing.CubeOut(pictureFade * pictureGlow), scale);
                    DrawCentered(context, Graphics.PortraitsAtlas["hug-light2b"], position,
                        PackedColor.White * Easing.CubeOut(pictureFade * pictureGlow), scale);
                    DrawCentered(context, Graphics.PortraitsAtlas["hug-light2c"], position,
                        PackedColor.White * Easing.CubeOut(pictureFade * pictureGlow), scale);
                    OriginalHiresRendererBatch.EndRender(context);
                    OriginalHiresRendererBatch.BeginRender(context, SourceBlendState.Additive);
                    DrawCentered(context, Graphics.PortraitsAtlas["hug-light2a"], position,
                        PackedColor.White * Easing.CubeOut(pictureFade * pictureGlow), scale);
                    DrawCentered(context, Graphics.PortraitsAtlas["hug-light2b"], position,
                        PackedColor.White * Easing.CubeOut(pictureFade * pictureGlow), scale);
                    DrawCentered(context, Graphics.PortraitsAtlas["hug-light2c"], position,
                        PackedColor.White * Easing.CubeOut(pictureFade * pictureGlow), scale);
                    OriginalHiresRendererBatch.EndRender(context);
                    OriginalHiresRendererBatch.BeginRender(context);
                }

                if (waitForKeyPress)
                    DrawCentered(context, Graphics.GuiAtlas["textboxbutton"],
                        new(1520f, 880 + (timer % 1f < .25f ? 6 : 0)), PackedColor.White);
            }
        }
    }
}
