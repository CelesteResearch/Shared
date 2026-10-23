using Celeste.Core.Display;
using Celeste.Simulation.Gameplay.Actors.Debris;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Scene.Components.Oscillation;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Audio;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Entities.ReflectionTentacles;
using Celeste.Game.Entities.Hazards.Spinners.Crystal;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Backdrops.NorthernLights;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Graphics.Display;

namespace Celeste.Game.Entities.StarJump.Cutscenes
{
    public class CS06StarJumpEndState : OriginalCutsceneEntityState
    {
        public const string Flag = "plateau_2";

        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private bool waiting = true;

        private bool shaking;

        private OriginalNpcState theo;

        private RoomPlayerSession player;

        private OriginalBonfireState bonfire;

        private BadelineDummyPresentation badeline;

        private OriginalPlateauState plateau;

        private OriginalBreathingMinigameState breathing;

        private List<OriginalReflectionTentaclesState> tentacles = new List<OriginalReflectionTentaclesState>();

        private Vector2 playerStart;

        private Vector2 cameraStart;

        private float anxietyFade;

        private SineWaveState anxietySine;

        private float anxietyJitter;

        private bool hidingNorthingLights;

        private bool charactersSpinning;

        private float maddySine;

        private float maddySineTarget;

        private float maddySineAnchorY;

        private SoundSourceComponentState shakingLoopSfx;

        private bool baddyCircling;

        private OriginalBreathingRumblerState rumbler;

        private int tentacleIndex;

        public CS06StarJumpEndState(OriginalNpcState theo, RoomPlayerSession player, Vector2 playerStart,
            Vector2 cameraStart, ISourceEngineContext engine)
            : base(engine)
        {
            this.engine = engine;
            base.Depth = 10100;
            this.theo = theo;
            this.player = player;
            this.playerStart = playerStart;
            this.cameraStart = cameraStart;
            OwnedComponents.Add(anxietySine = new SineWaveState(engine, 0.3f));
        }

        public override void Added(object scene)
        {
            Level = scene as OriginalLevelSceneRoot;
            bonfire = ((OriginalLevelSceneRoot)scene).Scheduler.Entities.FindFirst<OriginalBonfireState>();
            plateau = ((OriginalLevelSceneRoot)scene).Scheduler.Entities.FindFirst<OriginalPlateauState>();
        }

        public override void Update()
        {
            base.Update();
            if (waiting && player.Y <= (float)(Level.Bounds.Top + 160))
            {
                waiting = false;
                Start();
            }

            if (shaking)
            {
                Level.Shake(0.2f);
            }

            if (Level != null && Level.OnInterval(0.1f))
            {
                anxietyJitter = SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -0.1f, 0.1f);
            }

            engine.Frame.Effects.Anxiety = anxietyFade *
                                           ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(0f,
                                               0f + anxietyJitter + anxietySine.Value * 0.6f);
            maddySine = ScalarMath.Approach(maddySine, maddySineTarget, 12f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (maddySine > 0f)
            {
                player.Y = maddySineAnchorY + (float)Math.Sin(Level.TimeActive * 2f) * 3f * maddySine;
            }
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            level.Scheduler.Entities.FindFirst<OriginalStarJumpControllerState>()?.RemoveSelf();
            foreach (OriginalStarJumpBlockState item in level.Scheduler.Entities.FindAll<OriginalStarJumpBlockState>())
            {
                item.Collidable = false;
            }

            int center = level.Bounds.X + 160;
            Vector2 cutsceneCenter = new Vector2(center, level.Bounds.Top + 150);
            NorthernLightsBackdropPresentation bg = level.Background.Get<NorthernLightsBackdropPresentation>();
            level.CameraOffset.Y = -30f;
            OwnedComponents.Add(new SimulationCoroutine(engine,
                OriginalCutsceneEntityState.CameraTo(engine, cutsceneCenter + new Vector2(-160f, -70f), 1.5f,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut)));
            OwnedComponents.Add(new SimulationCoroutine(engine,
                OriginalCutsceneEntityState.CameraTo(engine, cutsceneCenter + new Vector2(-160f, -120f), 2f,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut, 1.5f)));
            SourceTweenState.Set(engine.TweenPool, OwnedComponents, SourceTweenState.TweenMode.Oneshot, 3f,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut,
                delegate(SourceTweenState t) { bg.OffsetY = t.Eased * 32f; });
            if (player.Machine.State == 19)
            {
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
            }

            player.Data.Dashes = 0;
            player.Machine.State = 11;
            player.Dummy.Gravity = false;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("fallSlow");
            player.Data.Dashes = 1;
            player.Data.Motion.Normal.Speed = new Vector2(0f, -80f);
            player.Data.Facing = 1;
            player.ForceCameraUpdate = false;
            while (((ISourceVectorEnvironment)engine).VectorArithmetic.Length(player.Data.Motion.Normal.Speed) > 0f ||
                   player.Position != cutsceneCenter)
            {
                player.Data.Motion.Normal.Speed =
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.Approach(player.Data.Motion.Normal.Speed,
                        Vector2.Zero, 200f * engine.DeltaTime);
                player.Position =
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.Approach(player.Position, cutsceneCenter,
                        64f * engine.DeltaTime);
                yield return null;
            }

            player.Sprite.Play("spin");
            yield return 3.5f;
            player.Data.Facing = 1;
            level.Scheduler.QueueSourceEntity(badeline = BadelineDummyPresentation.Create(level, player.Position));
            level.Displacement.AddBurst(player.Position, 0.5f, 8f, 48f, 0.5f);
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 1);
            player.CreateSplitParticles();
            Process.AudioSession.Play("event:/char/badeline/maddy_split");
            badeline.Sprite.Scale.X = -1f;
            Vector2 start = player.Position;
            Vector2 target = cutsceneCenter + new Vector2(-30f, 0f);
            maddySineAnchorY = cutsceneCenter.Y;
            for (float p = 0f; p <= 1f; p += 2f * engine.DeltaTime)
            {
                yield return null;
                if (p > 1f)
                {
                    p = 1f;
                }

                player.Position = Vector2Math.Lerp(start, target,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                badeline.Position = new Vector2((float)center + ((float)center - player.X), player.Y);
            }

            charactersSpinning = true;
            OwnedComponents.Add(new SimulationCoroutine(engine, SpinCharacters()));
            SetMusicLayer(2);
            yield return 1f;
            yield return TextboxState.Say("ch6_dreaming", engine, TentaclesAppear, TentaclesGrab, FeatherMinigame,
                EndFeatherMinigame, StartCirclingPlayer);
            Process.AudioSession.Play("event:/game/06_reflection/badeline_pull_whooshdown");
            OwnedComponents.Add(new SimulationCoroutine(engine, BadelineFlyDown()));
            yield return 0.7f;
            foreach (OriginalFlyFeatherState item2 in level.Scheduler.Entities.FindAll<OriginalFlyFeatherState>())
            {
                item2.RemoveSelf();
            }

            foreach (OriginalStarJumpBlockState item3 in level.Scheduler.Entities.FindAll<OriginalStarJumpBlockState>())
            {
                item3.RemoveSelf();
            }

            foreach (SourceJumpThruEntityState item4 in level.Scheduler.Entities.FindAll<SourceJumpThruEntityState>())
            {
                item4.RemoveSelf();
            }

            level.Shake();
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 0);
            level.CameraOffset.Y = 0f;
            player.Sprite.Play("tentacle_pull");
            player.Data.Motion.Normal.Speed.Y = 160f;
            OriginalFallEffectsState.Show(engine, visible: true);
            for (float p = 0f; p < 1f; p += engine.DeltaTime / 3f)
            {
                player.Data.Motion.Normal.Speed.Y += engine.DeltaTime * 100f;
                if (player.X < (float)(level.Bounds.X + 32))
                {
                    player.X = level.Bounds.X + 32;
                }

                if (player.X > (float)(level.Bounds.Right - 32))
                {
                    player.X = level.Bounds.Right - 32;
                }

                if (p > 0.7f)
                {
                    level.CameraOffset.Y -= 100f * engine.DeltaTime;
                }

                foreach (OriginalReflectionTentaclesState tentacle in tentacles)
                {
                    tentacle.Nodes[0] = new Vector2(level.Bounds.Center.X, player.Y + 300f);
                    tentacle.Nodes[1] = new Vector2(level.Bounds.Center.X, player.Y + 600f);
                }

                ((IOriginalFallEffectsEnvironment)engine).FallEffectsProcess.SpeedMultiplier +=
                    engine.DeltaTime * 0.75f;
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 0);
                yield return null;
            }

            Process.AudioSession.Play("event:/game/06_reflection/badeline_pull_impact");
            OriginalFallEffectsState.Show(engine, visible: false);
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
            level.Flash(PackedColor.White);
            level.Session.Dreaming = false;
            level.CameraOffset.Y = 0f;
            level.Camera.Position = cameraStart;
            SetBloom(0f);
            bonfire.SetMode(OriginalBonfireState.Mode.Smoking);
            plateau.Depth = player.Depth + 10;
            plateau.OwnedComponents.Remove(plateau.Occluder);
            player.Position = playerStart + new Vector2(0f, 8f);
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            player.Sprite.Play("tentacle_dangling");
            player.Data.Facing = -1;
            theo.X -= 24f;
            theo.Sprite.Play("alert");
            foreach (OriginalReflectionTentaclesState tentacle2 in tentacles)
            {
                tentacle2.Index = 0;
                tentacle2.Nodes[0] = new Vector2(level.Bounds.Center.X, player.Y + 32f);
                tentacle2.Nodes[1] = new Vector2(level.Bounds.Center.X, player.Y + 400f);
                tentacle2.SnapTentacles();
            }

            shaking = true;
            OwnedComponents.Add(shakingLoopSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            shakingLoopSfx.Play("event:/game/06_reflection/badeline_pull_rumble_loop");
            yield return TextboxState.Say("ch6_theo_watchout", engine);
            Process.AudioSession.Play("event:/game/06_reflection/badeline_pull_cliffbreak");
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 2);
            shakingLoopSfx.Stop();
            shaking = false;
            for (int num = 0; (float)num < plateau.Width; num += 8)
            {
                level.Scheduler.QueueSourceEntity(engine.EntityPools.Create<DebrisState>()
                    .Init(
                        plateau.Position +
                        new Vector2(
                            (float)num + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 8f),
                            SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 8f)), '3')
                    .BlastFrom(plateau.Center + new Vector2(0f, 8f)));
                level.Scheduler.QueueSourceEntity(engine.EntityPools.Create<DebrisState>()
                    .Init(
                        plateau.Position +
                        new Vector2(
                            (float)num + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 8f),
                            SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 8f)), '3')
                    .BlastFrom(plateau.Center + new Vector2(0f, 8f)));
            }

            plateau.RemoveSelf();
            bonfire.RemoveSelf();
            level.Shake();
            player.Data.Motion.Normal.Speed.Y = 160f;
            player.Sprite.Play("tentacle_pull");
            player.ForceCameraUpdate = false;
            FadeWipePresentation wipe = new FadeWipePresentation(level, wipeIn: false, delegate { EndCutscene(level); })
            {
                Duration = 3f
            };
            target = level.Camera.Position;
            start = level.Camera.Position + new Vector2(0f, 400f);
            while (wipe.Percent < 1f)
            {
                level.Camera.Position = Vector2Math.Lerp(target, start,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(wipe.Percent),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                player.Data.Motion.Normal.Speed.Y += 400f * engine.DeltaTime;
                foreach (OriginalReflectionTentaclesState tentacle3 in tentacles)
                {
                    tentacle3.Nodes[0] = new Vector2(level.Bounds.Center.X, player.Y + 300f);
                    tentacle3.Nodes[1] = new Vector2(level.Bounds.Center.X, player.Y + 600f);
                }

                yield return null;
            }
        }

        private void SetMusicLayer(int index)
        {
            for (int i = 1; i <= 3; i++)
            {
                Level.Session.Audio.Music.Layer(i, index == i);
            }

            OriginalAudioSession.Apply(Level.Session.Audio, Process.AudioSession.ChannelOutput,
                Process.AudioApplyPolicy);
        }

        private IEnumerator TentaclesAppear()
        {
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
            if (tentacleIndex == 0)
            {
                Process.AudioSession.Play("event:/game/06_reflection/badeline_freakout_1");
            }
            else if (tentacleIndex == 1)
            {
                Process.AudioSession.Play("event:/game/06_reflection/badeline_freakout_2");
            }
            else if (tentacleIndex == 2)
            {
                Process.AudioSession.Play("event:/game/06_reflection/badeline_freakout_3");
            }
            else
            {
                Process.AudioSession.Play("event:/game/06_reflection/badeline_freakout_4");
            }

            if (!hidingNorthingLights)
            {
                OwnedComponents.Add(new SimulationCoroutine(engine, NothernLightsDown()));
                hidingNorthingLights = true;
            }

            Level.Shake();
            anxietyFade += 0.1f;
            if (tentacleIndex == 0)
            {
                SetMusicLayer(3);
            }

            int num = 400;
            int num2 = 140;
            List<Vector2> list = new List<Vector2>();
            list.Add(new Vector2(Level.Camera.X + 160f, Level.Camera.Y + (float)num));
            list.Add(new Vector2(Level.Camera.X + 160f, Level.Camera.Y + (float)num + 200f));
            OriginalReflectionTentaclesState reflectionTentacles = new OriginalReflectionTentaclesState(engine);
            reflectionTentacles.Create(0f, 0, tentacles.Count, list);
            reflectionTentacles.Nodes[0] = new Vector2(reflectionTentacles.Nodes[0].X, Level.Camera.Y + (float)num2);
            Level.Scheduler.QueueSourceEntity(reflectionTentacles);
            tentacles.Add(reflectionTentacles);
            charactersSpinning = false;
            tentacleIndex++;
            badeline.Sprite.Play("angry");
            maddySineTarget = 1f;
            yield return null;
        }

        private IEnumerator TentaclesGrab()
        {
            maddySineTarget = 0f;
            Process.AudioSession.Play("event:/game/06_reflection/badeline_freakout_5");
            player.Sprite.Play("tentacle_grab");
            yield return 0.1f;
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 2);
            Level.Shake();
            rumbler = new OriginalBreathingRumblerState(engine);
            Level.Scheduler.QueueSourceEntity(rumbler);
        }

        private IEnumerator StartCirclingPlayer()
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, BadelineCirclePlayer()));
            Vector2 from = player.Position;
            Vector2 to = new Vector2(Level.Bounds.Center.X, player.Y);
            SourceTweenState.Set(engine.TweenPool, OwnedComponents, SourceTweenState.TweenMode.Oneshot, 0.5f,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut,
                delegate(SourceTweenState t)
                {
                    player.Position =
                        Vector2Math.Lerp(from, to, t.Eased, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                });
            yield return null;
        }

        private IEnumerator EndCirclingPlayer()
        {
            baddyCircling = false;
            yield return null;
        }

        private IEnumerator BadelineCirclePlayer()
        {
            float offset = 0f;
            float dist =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(badeline.Position - player.Position);
            baddyCircling = true;
            while (baddyCircling)
            {
                offset -= engine.DeltaTime * 4f;
                dist = ScalarMath.Approach(dist, 24f, engine.DeltaTime * 32f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                badeline.Position = player.Position + Vector2Geometry.AngleToVector(offset, dist);
                int num = Math.Sign(player.X - badeline.X);
                if (num != 0)
                {
                    badeline.Sprite.Scale.X = num;
                }

                if (Level.OnInterval(0.1f))
                {
                    TrailManagerState.Add(engine, (Celeste.Core.Rendering.ISourceRenderEnvironment)engine, badeline,
                        PlayerHairAppearance.NormalHairColor);
                }

                yield return null;
            }

            badeline.Sprite.Scale.X = -1f;
            yield return badeline.FloatTo(player.Position + new Vector2(40f, -16f), -1, faceDirection: false);
        }

        private IEnumerator FeatherMinigame()
        {
            breathing = new OriginalBreathingMinigameState(engine, false, rumbler);
            Level.Scheduler.QueueSourceEntity(breathing);
            while (!breathing.Pausing)
            {
                yield return null;
            }
        }

        private IEnumerator EndFeatherMinigame()
        {
            baddyCircling = false;
            breathing.Pausing = false;
            while (!breathing.Completed)
            {
                yield return null;
            }

            breathing = null;
        }

        private IEnumerator BadelineFlyDown()
        {
            badeline.Sprite.Play("fallFast");
            badeline.FloatSpeed = 600f;
            badeline.FloatAccel = 1200f;
            yield return badeline.FloatTo(new Vector2(badeline.X, Level.Camera.Y + 200f), null, faceDirection: true,
                fadeLight: true);
            badeline.RemoveSelf();
        }

        private IEnumerator NothernLightsDown()
        {
            NorthernLightsBackdropPresentation bg = Level.Background.Get<NorthernLightsBackdropPresentation>();
            if (bg != null)
            {
                while (bg.NorthernLightsAlpha > 0f)
                {
                    bg.NorthernLightsAlpha -= engine.DeltaTime * 0.5f;
                    yield return null;
                }
            }
        }

        private IEnumerator SpinCharacters()
        {
            Vector2 maddyStart = player.Position;
            Vector2 baddyStart = badeline.Position;
            Vector2 center = ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(maddyStart + baddyStart, 2f);
            float dist = Math.Abs(maddyStart.X - center.X);
            float timer = (float)Math.PI / 2f;
            player.Sprite.Play("spin");
            badeline.Sprite.Play("spin");
            badeline.Sprite.Scale.X = 1f;
            while (charactersSpinning)
            {
                int num = (int)(timer / ((float)Math.PI * 2f) * 14f + 10f);
                player.Sprite.SetAnimationFrame(num);
                badeline.Sprite.SetAnimationFrame(num + 7);
                float num2 = (float)Math.Sin(timer);
                float num3 = (float)Math.Cos(timer);
                player.Position = center - new Vector2(num2 * dist, num3 * 8f);
                badeline.Position = center + new Vector2(num2 * dist, num3 * 8f);
                timer += engine.DeltaTime * 2f;
                yield return null;
            }

            player.Data.Facing = 1;
            player.Sprite.Play("fallSlow");
            badeline.Sprite.Scale.X = -1f;
            badeline.Sprite.Play("angry");
            badeline.AutoAnimator.Enabled = false;
            Vector2 maddyFrom = player.Position;
            Vector2 baddyFrom = badeline.Position;
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 3f)
            {
                player.Position = Vector2Math.Lerp(maddyFrom, maddyStart,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                badeline.Position = Vector2Math.Lerp(baddyFrom, baddyStart,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                yield return null;
            }
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            if (rumbler != null)
            {
                rumbler.RemoveSelf();
                rumbler = null;
            }

            if (breathing != null)
            {
                breathing.RemoveSelf();
            }

            SetBloom(0f);
            level.Session.Audio.Music.Event = null;
            OriginalAudioSession.Apply(level.Session.Audio, Process.AudioSession.ChannelOutput,
                Process.AudioApplyPolicy);
            level.Scheduler.RemoveEntity(player);
            level.UnloadLevel();
            level.EndCutscene();
            level.Session.SetFlag("plateau_2");
            level.SnapColorGrade(level.AreaData.ColorGrade);
            level.Session.Dreaming = false;
            level.Session.FirstLevel = false;
            if (WasSkipped)
            {
                level.OnEndOfFrame += delegate
                {
                    level.Session.Level = "00";
                    level.Session.RespawnPoint =
                        level.GetSpawnPoint(new Vector2(level.Bounds.Left, level.Bounds.Bottom));
                    level.LoadLevel(PlayerIntroType.None);
                    OriginalFallEffectsState.Show(engine, visible: false);
                    level.Session.Audio.Music.Event = "event:/music/lvl6/main";
                    OriginalAudioSession.Apply(level.Session.Audio, Process.AudioSession.ChannelOutput,
                        Process.AudioApplyPolicy);
                };
                return;
            }

            engine.Frame.Scenes.NextScene = new OverworldReflectionsFallSequence(engine, level, delegate
            {
                Process.AudioSession.SetAmbience(null);
                level.Session.Level = "04";
                level.Session.RespawnPoint = level.GetSpawnPoint(new Vector2(level.Bounds.Center.X, level.Bounds.Top));
                level.LoadLevel(PlayerIntroType.Fall);
                level.Scheduler.QueueSourceEntity(
                    new OriginalBackgroundFadeInState(PackedColor.Black, 2f, 30f, engine));
                level.Scheduler.CommitQueuedEntityLists();
                foreach (object actual in level.Scheduler.Entities.GetTrackedEntities("Celeste.CrystalStaticSpinner"))
                {
                    ((OriginalCrystalStaticSpinner)actual).ForceInstantiate();
                }
            });
        }

        private void SetBloom(float add)
        {
            Level.Session.BloomBaseAdd = add;
            Level.Bloom.Base = Level.AreaData.BloomBase + add;
        }
    }
}
