using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Input.Gameplay;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Lifecycle;
using Celeste.Scene.Tracking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Audio;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Entities.Platforms.Barriers;
using Celeste.Game.Entities.Effects.AbsorbOrbs;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Presentation.Hud.Poems;
using Celeste.Game.Execution.Engine.Actions;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Platform.Statistics;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Emitters;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
    public partial class OriginalHeartGemState
    {
        private IEnumerator OriginalCollectRoutine(RoomPlayerSession player)
        {
            OriginalLevelSceneRoot level = Scene as OriginalLevelSceneRoot;
            OriginalAreaKey area = GetArea(level);
            string poemID = level.AreaData.Mode[(int)area.Mode].PoemID;
            bool completeArea = HeartPolicy.IsCompleteArea(level, IsFake, !IsFake && (area.Mode != 0 || area.ID == 9));
            if (IsFake)
            {
                level.StartCutscene(SkipFakeHeartCutscene);
            }
            else
            {
                level.CanRetry = false;
            }

            if (completeArea || IsFake)
            {
                Process.AudioSession.SetMusic(null);
                Process.AudioSession.SetAmbience(null);
            }

            if (completeArea)
            {
                List<OriginalStrawberryState> list = new List<OriginalStrawberryState>();
                foreach (var follower in player.Leader.Followers)
                {
                    if (follower.Entity is OriginalStrawberryState)
                    {
                        list.Add(follower.Entity as OriginalStrawberryState);
                    }
                }

                foreach (OriginalStrawberryState item in list)
                {
                    item.OnCollect();
                }
            }

            string text = "event:/game/general/crystalheart_blue_get";
            if (IsFake)
            {
                text = "event:/new_content/game/10_farewell/fakeheart_get";
            }
            else if (area.Mode == 1)
            {
                text = "event:/game/general/crystalheart_red_get";
            }
            else if (area.Mode == 2)
            {
                text = "event:/game/general/crystalheart_gold_get";
            }

            sfx = SoundEmitterState.Play(text, this, engine);
            OwnedComponents.Add(new LevelEndingHookState(delegate { sfx.Source.Stop(); }));
            walls.Add(new OriginalInvisibleBarrierState(engine, new Vector2(level.Bounds.Right, level.Bounds.Top), 8f,
                level.Bounds.Height, level.SolidWorldFactory));
            walls.Add(new OriginalInvisibleBarrierState(engine, new Vector2(level.Bounds.Left - 8, level.Bounds.Top),
                8f,
                level.Bounds.Height, level.SolidWorldFactory));
            walls.Add(new OriginalInvisibleBarrierState(engine, new Vector2(level.Bounds.Left, level.Bounds.Top - 8),
                level.Bounds.Width, 8f, level.SolidWorldFactory));
            foreach (OriginalInvisibleBarrierState wall in walls)
            {
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(wall);
            }

            OwnedComponents.Add(white =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("heartGemWhite"));
            base.Depth = -2000000;
            yield return null;
            OriginalCelesteFreeze.Freeze(engine, 0.2f);
            yield return null;
            engine.Effects.TimeRate = 0.5f;
            player.Depth = -2000000;
            for (int num = 0; num < 10; num++)
            {
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new OriginalAbsorbOrbState(engine, Position));
            }

            level.Shake();
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
            level.Flash(PackedColor.White);
            level.FormationBackdrop.Display = true;
            level.FormationBackdrop.Alpha = 1f;
            light.Alpha = (bloom.Alpha = 0f);
            Visible = false;
            for (float t = 0f; t < 2f; t += engine.RawDeltaTime)
            {
                engine.Effects.TimeRate =
                    ScalarMath.Approach(engine.Effects.TimeRate, 0f, engine.RawDeltaTime * 0.25f, Extrema);
                yield return null;
            }

            yield return null;
            if (player.Dead)
            {
                yield return 100f;
            }

            engine.Effects.TimeRate = 1f;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.FrozenUpdate.Value;
            level.Frozen = true;
            if (!IsFake)
            {
                RegisterAsCollected(level, poemID);
                if (completeArea)
                {
                    level.TimerStopped = true;
                    level.RegisterAreaComplete();
                }
            }

            string text2 = null;
            if (!string.IsNullOrEmpty(poemID))
            {
                text2 =
                    ((global::Celeste.Game.Content.Dialogs.IOriginalGameTextEnvironment)engine).Text.CleanDialog(
                        "poem_" + poemID);
            }

            poem = new PoemState(engine, text2, (int)(IsFake ? 3 : area.Mode), (area.Mode == 2 || IsFake) ? 1f : 0.6f);
            poem.Alpha = 0f;
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(poem);
            for (float t = 0f; t < 1f; t += engine.RawDeltaTime)
            {
                poem.Alpha = Easing.CubeOut(t);
                yield return null;
            }

            if (IsFake)
            {
                yield return DoFakeRoutineWithBird(player);
                yield break;
            }

            while (!((ISourceGameInputEnvironment)engine).Input.MenuConfirm.Pressed &&
                   !((ISourceGameInputEnvironment)engine).Input.MenuCancel.Pressed)
            {
                yield return null;
            }

            sfx.Source.Param("end", 1f);
            if (!completeArea)
            {
                level.FormationBackdrop.Display = false;
                for (float t = 0f; t < 1f; t += engine.RawDeltaTime * 2f)
                {
                    poem.Alpha = Easing.CubeIn(1f - t);
                    yield return null;
                }

                player.Depth = 0;
                EndCutscene();
            }
            else
            {
                FadeWipePresentation fadeWipe = new FadeWipePresentation(level, wipeIn: false);
                fadeWipe.Duration = 3.25f;
                yield return fadeWipe.Duration;
                level.CompleteArea(false, true, false);
            }
        }

        private IEnumerator DoFakeRoutineWithBird(RoomPlayerSession player)
        {
            OriginalLevelSceneRoot level = Scene as OriginalLevelSceneRoot;
            int panAmount = 64;
            Vector2 panFrom = level.Camera.Position;
            Vector2 panTo = level.Camera.Position + new Vector2(-panAmount, 0f);
            Vector2 birdFrom = new Vector2(panTo.X - 16f, player.Y - 20f);
            Vector2 birdTo = new Vector2(panFrom.X + 320f + 16f, player.Y - 20f);
            yield return 2f;
            engine.Effects.Glitch = 0.75f;
            while (engine.Effects.Glitch > 0f)
            {
                engine.Effects.Glitch =
                    ScalarMath.Approach(engine.Effects.Glitch, 0f, engine.RawDeltaTime * 4f, Extrema);
                level.Shake();
                yield return null;
            }

            yield return 1.1f;
            engine.Effects.Glitch = 0.75f;
            while (engine.Effects.Glitch > 0f)
            {
                engine.Effects.Glitch =
                    ScalarMath.Approach(engine.Effects.Glitch, 0f, engine.RawDeltaTime * 4f, Extrema);
                level.Shake();
                yield return null;
            }

            yield return 0.4f;
            for (float p = 0f; p < 1f; p += engine.RawDeltaTime / 2f)
            {
                level.Camera.Position = panFrom + (panTo - panFrom) * Easing.CubeInOut(p);
                poem.Offset = new Vector2(panAmount * 8, 0f) * Easing.CubeInOut(p);
                yield return null;
            }

            bird = BirdNpcState.Create(level, birdFrom, BirdNpcMode.None);
            bird.Sprite.Play("fly");
            bird.Sprite.UseRawDeltaTime = true;
            bird.Facing = 1;
            bird.Depth = -2000100;
            bird.Tags = ((IOriginalGameTagsEnvironment)engine).Tags.FrozenUpdate.Value;
            bird.OwnedComponents.Add(new VertexLightState(engine, PackedColor.White, 0.5f, 8, 32));
            bird.OwnedComponents.Add(new BloomPointState(0.5f, 12f));
            level.Scheduler.QueueSourceEntity(bird);
            for (float p = 0f; p < 1f; p += engine.RawDeltaTime / 2.6f)
            {
                level.Camera.Position = panTo + (panFrom - panTo) * Easing.CubeInOut(p);
                poem.Offset = new Vector2(panAmount * 8, 0f) * Easing.CubeInOut(1f - p);
                float num = 0.1f;
                float num2 = 0.9f;
                if (p > num && p <= num2)
                {
                    float num3 = (p - num) / (num2 - num);
                    bird.Position = birdFrom + (birdTo - birdFrom) * num3 +
                                    Vector2.UnitY * (float)Math.Sin(num3 * 8f) * 8f;
                }

                if (level.OnRawInterval(0.2f))
                {
                    TrailManagerState.Add(engine, (ISourceRenderEnvironment)engine, bird, PackedColor.FromHex("639bff"),
                        1f,
                        frozenUpdate: true, useRawDeltaTime: true);
                }

                yield return null;
            }

            bird.RemoveSelf();
            bird = null;
            engine.Effects.TimeRate = 0f;
            level.Frozen = false;
            player.Active = false;
            player.Machine.State = 11;
            while (engine.Effects.TimeRate != 1f)
            {
                engine.Effects.TimeRate =
                    ScalarMath.Approach(engine.Effects.TimeRate, 1f, 0.5f * engine.RawDeltaTime, Extrema);
                yield return null;
            }

            engine.Effects.TimeRate = 1f;
            yield return global::Celeste.Game.UI.Dialogue.Textboxes.TextboxState.Say(
                HeartPolicy.InstalledDialogs ? fakeHeartDialog : "CH9_FAKE_HEART", engine);
            sfx.Source.Param("end", 1f);
            yield return 0.283f;
            level.FormationBackdrop.Display = false;
            for (float p = 0f; p < 1f; p += engine.RawDeltaTime / 0.2f)
            {
                poem.TextAlpha = Easing.CubeIn(1f - p);
                poem.ParticleSpeed = poem.TextAlpha;
                yield return null;
            }

            poem.Heart.Play("break");
            while (poem.Heart.Animating)
            {
                poem.Shake += engine.DeltaTime;
                yield return null;
            }

            poem.RemoveSelf();
            poem = null;
            for (int i = 0; i < 10; i++)
            {
                Vector2 position = level.Camera.Position + new Vector2(320f, 180f) * 0.5f;
                Vector2 value = level.Camera.Position + new Vector2(160f, -64f);
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new OriginalAbsorbOrbState(engine, position, null,
                    value));
            }

            level.Shake();
            engine.Effects.Glitch = 0.8f;
            while (engine.Effects.Glitch > 0f)
            {
                engine.Effects.Glitch -= engine.DeltaTime * 4f;
                yield return null;
            }

            yield return 0.25f;
            level.Session.Audio.Music.Event = "event:/new_content/music/lvl10/intermission_heartgroove";
            OriginalAudioSession.Apply(level.Session.Audio, Process.AudioSession.ChannelOutput,
                Process.AudioApplyPolicy);
            player.Active = true;
            player.Depth = 0;
            player.Machine.State = 11;
            while (!player.OnGround() && player.Bottom < (float)level.Bounds.Bottom)
            {
                yield return null;
            }

            player.Data.Facing = 1;
            yield return 0.5f;
            yield return global::Celeste.Game.UI.Dialogue.Textboxes.TextboxState.Say(
                HeartPolicy.InstalledDialogs ? keepGoingDialog : "CH9_KEEP_GOING", engine, PlayerStepForward);
            SkipFakeHeartCutscene(level);
            level.EndCutscene();
        }

        private IEnumerator PlayerStepForward()
        {
            yield return 0.1f;
            RoomPlayerSession entity = FirstPlayer();
            if (entity != null && PlayerCollidesSolidAt(entity, entity.Position + new Vector2(12f, 1f)))
            {
                yield return entity.DummyWalkToExact((int)entity.X + 10);
            }

            yield return 0.2f;
        }

        private void SkipFakeHeartCutscene(OriginalLevelSceneRoot level)
        {
            engine.Effects.TimeRate = 1f;
            engine.Effects.Glitch = 0f;
            if (sfx != null)
            {
                sfx.Source.Stop();
            }

            level.Session.SetFlag("fake_heart");
            level.Frozen = false;
            level.FormationBackdrop.Display = false;
            level.Session.Audio.Music.Event = "event:/new_content/music/lvl10/intermission_heartgroove";
            OriginalAudioSession.Apply(level.Session.Audio, Process.AudioSession.ChannelOutput,
                Process.AudioApplyPolicy);
            RoomPlayerSession entity = FirstPlayer();
            if (entity != null)
            {
                entity.Sprite.Play("idle");
                entity.Active = true;
                entity.Machine.State = 0;
                entity.Data.Dashes = 1;
                entity.Data.Motion.Normal.Speed = Vector2.Zero;
                entity.MoveV(200f);
                entity.Depth = 0;
                for (int i = 0; i < 10; i++)
                {
                    entity.UpdateHair(applyGravity: true);
                }
            }

            foreach (OriginalAbsorbOrbState item in ((ISourceScene)Scene).SourceScene.Entities
                     .FindAll<OriginalAbsorbOrbState>())
            {
                item.RemoveSelf();
            }

            if (poem != null)
            {
                poem.RemoveSelf();
            }

            if (bird != null)
            {
                bird.RemoveSelf();
            }

            if (fakeRightWall != null)
            {
                fakeRightWall.RemoveSelf();
            }

            FakeRemoveCameraTrigger();
            foreach (OriginalInvisibleBarrierState wall in walls)
            {
                wall.RemoveSelf();
            }

            RemoveSelf();
        }
    }
}
