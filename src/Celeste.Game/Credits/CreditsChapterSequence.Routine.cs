using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Game.Credits.Triggers;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Hud.Speedrun;
using Celeste.Game.Presentation.Hud.Strawberries;
using Celeste.Game.Presentation.Hud.Statistics;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Scene.Construction;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Presentation.Backdrops.Weather.Petals;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Game.Credits.Backdrops;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsChapterSequence
    {
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        private IEnumerator Routine()
        {
            Level.Background.Backdrops.Add(fillbg = new CreditsFillBackdrop());
            Level.Completed = true;
            ((ISourceScene)Level).SourceScene.Entities.FindFirst<SpeedrunTimerState>()?.RemoveSelf();
            ((ISourceScene)Level).SourceScene.Entities.FindFirst<TotalStrawberriesDisplayState>()?.RemoveSelf();
            ((ISourceScene)Level).SourceScene.Entities.FindFirst<GameplayStatsState>()?.RemoveSelf();
            yield return null;
            Level.Wipe.Cancel();
            yield return 0.5f;
            float alignment = 1f;
            if (Process.SaveContext.CurrentSave != null && Process.SaveContext.CurrentSave.Assists.MirrorMode)
            {
                alignment = 0f;
            }

            credits = new CreditsPresentation(engine, alignment, 0.6f, haveTitle: false, havePolaroids: true);
            credits.AllowInput = false;
            yield return 3f;
            SetBgFade(0f);
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(0f)));
            yield return SetupLevel();
            yield return WaitForPlayer();
            yield return FadeTo(1f);
            yield return 1f;
            SetBgFade(0.1f);
            yield return NextLevel("credits-dashes");
            yield return SetupLevel();
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(0f)));
            yield return WaitForPlayer();
            yield return FadeTo(1f);
            yield return 1f;
            SetBgFade(0.2f);
            yield return NextLevel("credits-walking");
            yield return SetupLevel();
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(0f)));
            yield return 5.8f;
            badelineAutoFloat = false;
            yield return 0.5f;
            badeline.Sprite.Scale.X = 1f;
            yield return 0.5f;
            autoWalk = false;
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            player.Data.Facing = 1;
            yield return 1.5f;
            badeline.Sprite.Scale.X = -1f;
            yield return 1f;
            badeline.Sprite.Scale.X = -1f;
            badelineAutoWalk = true;
            badelineWalkApproachFrom = badeline.Position;
            OwnedComponents.Add(new SimulationCoroutine(engine, BadelineApproachWalking()));
            yield return 0.7f;
            autoWalk = true;
            player.Data.Facing = -1;
            yield return WaitForPlayer();
            yield return FadeTo(1f);
            yield return 1f;
            SetBgFade(0.3f);
            yield return NextLevel("credits-tree");
            yield return SetupLevel();
            PetalsBackdropPresentation petals = new PetalsBackdropPresentation(engine);
            Level.Foreground.Backdrops.Add(petals);
            autoUpdateCamera = false;
            Vector2 target = Level.Camera.Position + new Vector2(-220f, 32f);
            Level.Camera.Position += new Vector2(-100f, 0f);
            badelineWalkApproach = 1f;
            badelineAutoFloat = false;
            badelineAutoWalk = true;
            badeline.Floatness = 0f;
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(0f)));
            OwnedComponents.Add(new SimulationCoroutine(engine,
                OriginalCutsceneEntityState.CameraTo(engine, target, 12f, Easing.Linear)));
            yield return 3.5f;
            badeline.Sprite.Play("idle");
            badelineAutoWalk = false;
            yield return 0.25f;
            autoWalk = false;
            player.Sprite.Play("idle");
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            player.Dummy.AutoAnimate = false;
            player.Data.Facing = 1;
            yield return 0.5f;
            player.Sprite.Play("sitDown");
            yield return 4f;
            badeline.Sprite.Play("laugh");
            yield return 1.75f;
            yield return FadeTo(1f);
            Level.Foreground.Backdrops.Remove(petals);
            yield return 1f;
            SetBgFade(0.4f);
            yield return NextLevel("credits-clouds");
            yield return SetupLevel();
            autoWalk = false;
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            autoUpdateCamera = false;
            player.ForceCameraUpdate = false;
            badeline.Visible = false;
            RoomPlayerSession other = null;
            foreach (var tracked in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CreditsTrigger"))
            {
                var entity2 = (CreditsTriggerState)tracked;
                if (entity2.Event == "BadelineOffset")
                {
                    other = ((ISourcePlayerConstructionScene)Scene).CreatePlayer(entity2.Position,
                        PlayerSpriteMode.Badeline);
                    other.OverrideHairColor = PlayerHairAppearance.NormalBadelineHairColor;
                    yield return null;
                    other.Machine.State = 11;
                    other.Data.Facing = -1;
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(other);
                }
            }

            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(0f)));
            Level.Camera.Position += new Vector2(0f, -100f);
            Vector2 target2 = Level.Camera.Position + new Vector2(0f, 160f);
            OwnedComponents.Add(new SimulationCoroutine(engine,
                OriginalCutsceneEntityState.CameraTo(engine, target2, 12f, Easing.Linear)));
            float playerHighJump = 0f;
            float baddyHighJump = 0f;
            for (float p = 0f; p < 10f; p += engine.Frame.DeltaTime)
            {
                if (((p > 3f && p < 6f) || p > 9f) && player.Data.Motion.Normal.Speed.Y < 0f && player.OnGround(4))
                {
                    playerHighJump = 0.25f;
                }

                if (p > 5f && p < 8f && other.Data.Motion.Normal.Speed.Y < 0f && other.OnGround(4))
                {
                    baddyHighJump = 0.25f;
                }

                if (playerHighJump > 0f)
                {
                    playerHighJump -= engine.Frame.DeltaTime;
                    player.Data.Motion.Normal.Speed.Y = -200f;
                }

                if (baddyHighJump > 0f)
                {
                    baddyHighJump -= engine.Frame.DeltaTime;
                    other.Data.Motion.Normal.Speed.Y = -200f;
                }

                yield return null;
            }

            yield return FadeTo(1f);
            yield return 1f;
            SetBgFade(0.5f);
            yield return NextLevel("credits-resort");
            yield return SetupLevel();
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(0f)));
            badelineWalkApproach = 1f;
            badelineAutoFloat = false;
            badelineAutoWalk = true;
            badeline.Floatness = 0f;
            Vector2 vector = Vector2.Zero;
            foreach (CreditsTriggerState item in
                     ((ISourceScene)Scene).SourceScene.Entities.FindAll<CreditsTriggerState>())
            {
                if (item.Event == "Oshiro")
                {
                    vector = item.Position;
                }
            }

            OriginalNpcState oshiro = new OriginalNpcState(engine, vector + new Vector2(0f, 4f));
            oshiro.OwnedComponents.Add(oshiro.Sprite = new OshiroSpriteState(engine, 1));
            oshiro.MoveAnim = "sweeping";
            oshiro.IdleAnim = "sweeping";
            oshiro.Sprite.Play("sweeping");
            oshiro.Maxspeed = 10f;
            oshiro.Depth = -60;
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(oshiro);
            OwnedComponents.Add(new SimulationCoroutine(engine, DustyRoutine(oshiro)));
            yield return 4.8f;
            Vector2 oshiroTarget = oshiro.Position + new Vector2(116f, 0f);
            SimulationCoroutine oshiroRoutine = new SimulationCoroutine(engine, oshiro.MoveTo(oshiroTarget));
            OwnedComponents.Add(oshiroRoutine);
            yield return 2f;
            autoUpdateCamera = false;
            yield return OriginalCutsceneEntityState.CameraTo(engine,
                new Vector2(Level.Bounds.Left + 64, Level.Bounds.Top),
                2f);
            yield return 5f;
            BirdNpcState bird =
                BirdNpcState.Create(Level, oshiro.Position + new Vector2(280f, -160f), BirdNpcMode.None);
            bird.Depth = 10010;
            bird.Light.Visible = false;
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(bird);
            bird.Facing = -1;
            bird.Sprite.Play("fall");
            Vector2 from = bird.Position;
            Vector2 to = oshiroTarget + new Vector2(50f, -12f);
            baddyHighJump = 0f;
            while (baddyHighJump < 1f)
            {
                bird.Position = from + (to - from) * Easing.QuadOut(baddyHighJump);
                if (baddyHighJump > 0.5f)
                {
                    bird.Sprite.Play("fly");
                    bird.Depth = -1000000;
                    bird.Light.Visible = true;
                }

                baddyHighJump += engine.Frame.DeltaTime * 0.5f;
                yield return null;
            }

            bird.Position = to;
            oshiroRoutine.RemoveSelf();
            oshiro.Sprite.Play("putBroomAway");
            oshiro.Sprite.OnFrameChange = delegate
            {
                if (oshiro.Sprite.CurrentAnimationFrame == 10)
                {
                    SceneEntityState entity =
                        new SceneEntityState(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                            oshiro.Position)
                        {
                            Depth = oshiro.Depth + 1
                        };
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(entity);
                    entity.OwnedComponents.Add(
                        new SpriteImage(
                            ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["characters/oshiro/broom"])
                        {
                            Origin = oshiro.Sprite.Origin
                        });
                    oshiro.Sprite.OnFrameChange = null;
                }
            };
            bird.Sprite.Play("idle");
            yield return 0.5f;
            bird.Sprite.Play("croak");
            yield return 0.6f;
            oshiro.Maxspeed = 40f;
            oshiro.MoveAnim = "move";
            oshiro.IdleAnim = "idle";
            yield return oshiro.MoveTo(oshiroTarget + new Vector2(14f, 0f));
            yield return 2f;
            OwnedComponents.Add(new SimulationCoroutine(engine, bird.StartleAndFlyAway()));
            yield return 0.75f;
            bird.Light.Visible = false;
            bird.Depth = 10010;
            oshiro.Sprite.Scale.X = -1f;
            yield return FadeTo(1f);
            yield return 1f;
            SetBgFade(0.6f);
            yield return NextLevel("credits-wallslide");
            yield return SetupLevel();
            badelineAutoFloat = false;
            badeline.Floatness = 0f;
            badeline.Sprite.Play("idle");
            badeline.Sprite.Scale.X = 1f;
            foreach (var tracked in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CreditsTrigger"))
            {
                var entity3 = (CreditsTriggerState)tracked;
                if (entity3.Event == "BadelineOffset")
                {
                    badeline.Position = entity3.Position + new Vector2(8f, 16f);
                }
            }

            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(0f)));
            OwnedComponents.Add(new SimulationCoroutine(engine, WaitForPlayer()));
            while (player.X > badeline.X - 16f)
            {
                yield return null;
            }

            badeline.Sprite.Scale.X = -1f;
            yield return 0.1f;
            badelineAutoWalk = true;
            badelineWalkApproachFrom = badeline.Position;
            badelineWalkApproach = 0f;
            badeline.Sprite.Play("walk");
            while (badelineWalkApproach != 1f)
            {
                badelineWalkApproach =
                    ScalarMath.Approach(badelineWalkApproach, 1f, engine.Frame.DeltaTime * 4f, Extrema);
                yield return null;
            }

            while (player.X > (float)(Level.Bounds.X + 160))
            {
                yield return null;
            }

            yield return FadeTo(1f);
            yield return 1f;
            SetBgFade(0.7f);
            yield return NextLevel("credits-payphone");
            yield return SetupLevel();
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            player.Data.Facing = -1;
            autoWalk = false;
            badeline.Sprite.Play("idle");
            badeline.Floatness = 0f;
            badeline.Y = player.Y;
            badeline.Sprite.Scale.X = 1f;
            badelineAutoFloat = false;
            autoUpdateCamera = false;
            Level.Camera.X += 100f;
            Vector2 target3 = Level.Camera.Position + new Vector2(-200f, 0f);
            OwnedComponents.Add(new SimulationCoroutine(engine,
                OriginalCutsceneEntityState.CameraTo(engine, target3, 14f, Easing.Linear)));
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(0f)));
            yield return 1.5f;
            badeline.Sprite.Scale.X = -1f;
            yield return 0.5f;
            OwnedComponents.Add(new SimulationCoroutine(engine,
                badeline.FloatTo(badeline.Position + new Vector2(16f, -12f), -1, faceDirection: false)));
            yield return 0.5f;
            player.Data.Facing = 1;
            yield return 1.5f;
            oshiroTarget = badeline.Position;
            to = player.Center;
            OwnedComponents.Add(new SimulationCoroutine(engine, BadelineAround(oshiroTarget, to, badeline)));
            yield return 0.5f;
            OwnedComponents.Add(new SimulationCoroutine(engine, BadelineAround(oshiroTarget, to)));
            yield return 0.5f;
            OwnedComponents.Add(new SimulationCoroutine(engine, BadelineAround(oshiroTarget, to)));
            yield return 3f;
            badeline.Sprite.Play("laugh");
            yield return 0.5f;
            player.Data.Facing = -1;
            yield return 0.5f;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("sitDown");
            yield return 3f;
            yield return FadeTo(1f);
            yield return 1f;
            SetBgFade(0.8f);
            yield return NextLevel("credits-city");
            yield return SetupLevel();
            BirdNpcState birdNPC = ((ISourceScene)Scene).SourceScene.Entities.FindFirst<BirdNpcState>();
            if (birdNPC != null)
            {
                birdNPC.Facing = 1;
            }

            badelineWalkApproach = 1f;
            badelineAutoFloat = false;
            badelineAutoWalk = true;
            badeline.Floatness = 0f;
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(0f)));
            yield return WaitForPlayer();
            yield return FadeTo(1f);
            yield return 1f;
            SetBgFade(0f);
            yield return NextLevel("credits-prologue");
            yield return SetupLevel();
            badelineWalkApproach = 1f;
            badelineAutoFloat = false;
            badelineAutoWalk = true;
            badeline.Floatness = 0f;
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeTo(0f)));
            yield return WaitForPlayer();
            yield return FadeTo(1f);
            while (credits.BottomTimer < 2f)
            {
                yield return null;
            }

            if (!gotoEpilogue)
            {
                snow = new HiresSnowState(engine);
                snow.Alpha = 0f;
                snow.AttachAlphaTo = new FadeWipePresentation(Level, wipeIn: false, delegate { EndCutscene(Level); });
                Level.Renderers.Add(Level.HiresSnow = snow);
            }
            else
            {
                new FadeWipePresentation(Level, wipeIn: false, delegate { EndCutscene(Level); });
            }
        }
    }
}
