using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Components.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Controls.Source;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Physics.Collision.Shapes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Stories.Temple
{
    using Celeste.Game.Gameplay.Collectibles.Strawberries;
    using Celeste.Game.Execution.Startup;
    using Celeste.Core.Audio;

    public class MirrorPortalCutscene : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;

        private static OriginalGameGraphicsResources Graphics(ISourceEngineContext e)
            => (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)e).GameGraphics;

        private ISourceRenderContext Context => ((ISourceRenderEnvironment)engine).CurrentContext;

        private class Fader : SceneEntityState
        {
            private readonly ISourceEngineContext engine;

            private static OriginalGameGraphicsResources Graphics(ISourceEngineContext e)
                => (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)e).GameGraphics;

            private ISourceRenderContext Context => ((ISourceRenderEnvironment)engine).CurrentContext;

            public float Target;

            public bool Ended;

            private float fade;

            public Fader(ISourceEngineContext engine) : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
            {
                this.engine = engine;
                base.Depth = -1000000;
            }

            public override void Update()
            {
                fade = ScalarMath.Approach(fade, Target, engine.DeltaTime * 0.5f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (Target <= 0f && fade <= 0f && Ended)
                {
                    RemoveSelf();
                }

                base.Update();
            }

            public override void Render(ISourceRenderContext context)
            {
                var camera = (base.Scene as OriginalLevelSceneRoot).Camera;
                if (fade > 0f)
                {
                    SourcePrimitiveDrawing.Rect(context, this, camera.X - 10f, camera.Y - 10f, 340f, 200f,
                        PackedColor.Black * fade);
                }

                RoomPlayerSession entity =
                    ((OriginalLevelSceneRoot)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
                if (entity != null && !entity.OnGround(2))
                {
                    entity.Render(context);
                }
            }
        }

        private RoomPlayerSession player;

        private TempleMirrorPortalState portal;

        private Fader fader;

        private SoundSourceComponentState sfx;

        public MirrorPortalCutscene(RoomPlayerSession player, TempleMirrorPortalState portal,
            ISourceEngineContext engine) :
            base(engine)
        {
            this.engine = engine;
            this.player = player;
            this.portal = portal;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            Add(new SimulationCoroutine(engine, Cutscene(level)));
            level.Scheduler.QueueSourceEntity(fader = new Fader(engine));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            player.Data.Dashes = 1;
            if (level.Session.Mode == 0)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.SetMusic(null);
            }
            else
            {
                Add(new SimulationCoroutine(engine, MusicFadeOutBSide()));
            }

            Add(sfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            sfx.Position = portal.Center;
            sfx.Play("event:/music/lvl5/mirror_cutscene");
            Add(new SimulationCoroutine(engine, CenterCamera()));
            yield return player.DummyWalkToExact((int)portal.X);
            yield return 0.25f;
            yield return player.DummyWalkToExact((int)portal.X - 16);
            yield return 0.5f;
            yield return player.DummyWalkToExact((int)portal.X + 16);
            yield return 0.25f;
            player.Data.Facing = -1;
            yield return 0.25f;
            yield return player.DummyWalkToExact((int)portal.X);
            yield return 0.1f;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("lookUp");
            yield return 1f;
            player.Dummy.AutoAnimate = true;
            portal.Activate();
            Add(new SimulationCoroutine(engine, level.ZoomTo(new Vector2(160f, 90f), 3f, 12f)));
            yield return 0.25f;
            player.Appearance.ForceStrongWindHair.X = -1f;
            yield return player.DummyWalkToExact((int)player.X + 12, walkBackwards: true);
            yield return 0.5f;
            player.Data.Facing = 1;
            player.Dummy.AutoAnimate = false;
            player.Dummy.Gravity = false;
            player.Sprite.Play("runWind");
            while (player.Sprite.Rate > 0f)
            {
                player.MoveH(player.Sprite.Rate * 10f * engine.DeltaTime);
                player.MoveV((0f - (1f - player.Sprite.Rate)) * 6f * engine.DeltaTime);
                player.Sprite.Rate -= engine.DeltaTime * 0.15f;
                yield return null;
            }

            yield return 0.5f;
            player.Sprite.Play("fallFast");
            player.Sprite.Rate = 1f;
            Vector2 target = portal.Center + new Vector2(0f, 8f);
            Vector2 from = player.Position;
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 2f)
            {
                player.Position =
                    from + (target - from) * ((ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut(p);
                yield return null;
            }

            player.Appearance.ForceStrongWindHair.X = 0f;
            fader.Target = 1f;
            yield return 2f;
            player.Sprite.Play("sleep");
            yield return 1f;
            yield return level.ZoomBack(1f);
            if (level.Session.Mode == 0)
            {
                level.Session.ColorGrade = "templevoid";
                for (float p = 0f; p < 1f; p += engine.DeltaTime)
                {
                    engine.Effects.Glitch = p * 0.05f;
                    level.ScreenPadding = 32f * p;
                    yield return null;
                }
            }

            while ((portal.DistortionFade -= engine.DeltaTime * 2f) > 0f)
            {
                yield return null;
            }

            EndCutscene(level);
        }

        private IEnumerator CenterCamera()
        {
            var camera = Level.Camera;
            Vector2 target = portal.Center - new Vector2(160f, 90f);
            while (((ISourceVectorEnvironment)engine).VectorArithmetic.Length(camera.Position - target) > 1f)
            {
                camera.Position += (target - camera.Position) *
                                   (1f - (float)Math.Pow(0.009999999776482582, engine.DeltaTime));
                yield return null;
            }
        }

        private IEnumerator MusicFadeOutBSide()
        {
            for (float p = 1f; p > 0f; p -= engine.DeltaTime)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.SetMusicParam("fade", p);
                yield return null;
            }

            ((IOriginalGameplayProcess)engine).AudioSession.SetMusicParam("fade", 0f);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            level.OnEndOfFrame += delegate
            {
                if (fader != null && !WasSkipped)
                {
                    fader.Tags = ((IOriginalGameTagsEnvironment)engine).Tags.Global.Value;
                    fader.Target = 0f;
                    fader.Ended = true;
                }

                OriginalStrawberryTransfer.StoreStrawberries(player.Leader);
                level.SourceScene.RemoveEntity(player);
                level.UnloadLevel();
                level.Session.Dreaming = true;
                level.Session.Keys.Clear();
                if (level.Session.Mode == 0)
                {
                    level.Session.Level = "void";
                    level.Session.RespawnPoint = level.GetSpawnPoint(new Vector2(level.Bounds.Left, level.Bounds.Top));
                    level.LoadLevel(Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.TempleMirrorVoid);
                }
                else
                {
                    level.Session.Level = "c-00";
                    level.Session.RespawnPoint = level.GetSpawnPoint(new Vector2(level.Bounds.Left, level.Bounds.Top));
                    level.LoadLevel(Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.WakeUp);
                    ((IOriginalGameplayProcess)engine).AudioSession.SetMusicParam("fade", 1f);
                }

                OriginalStrawberryTransfer.RestoreStrawberries(level.SourceScene.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName)
                    .Leader);
                level.Camera.Y -= 8f;
                if (!WasSkipped && level.Wipe != null)
                {
                    level.Wipe.Cancel();
                }

                if (fader != null)
                {
                    fader.RemoveTag(((IOriginalGameTagsEnvironment)engine).Tags.Global.Value);
                }
            };
        }
    }
}
