using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Engine.Actions;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Audio;
using Celeste.Game.Entities.Lightning;
using Celeste.Game.Gameplay.Clutter.Blocks;
using Celeste.Game.Gameplay.Clutter.Absorption;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Clutter;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Audio.Sources;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;

namespace Celeste.Game.Gameplay.Clutter.Switches
{
    public class OriginalClutterSwitchState : SourceSolidEntityState
    {
        private ISourceEngineContext Engine => SourceWorld.EngineContext;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)Engine;
        private IRumbleSession Rumble => ((ISourceRumbleEnvironment)Engine).RumbleSession;

        public const float LightingAlphaAdd = 0.05f;

        private const int PressedAdd = 10;

        private const int PressedSpriteAdd = 2;

        private const int UnpressedLightRadius = 32;

        private const int PressedLightRadius = 24;

        private const int BrightLightRadius = 64;

        private ClutterColor color;

        private float startY;

        private float atY;

        private float speedY;

        private bool pressed;

        private Sprite sprite;

        private SpriteImage icon;

        private float targetXScale = 1f;

        private VertexLightState vertexLight;

        private bool playerWasOnTop;

        private SoundSourceComponentState cutsceneSfx;

        public OriginalClutterSwitchState(Vector2 position, ClutterColor color, ISourceSolidWorld world)
            : base(position, 32f, 16f, true, world)
        {
            this.color = color;
            startY = (atY = base.Y);
            OnDashCollide = OnDashed;
            SurfaceSoundIndex = 21;
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.SpriteFactory.Create("clutterSwitch"));
            sprite.Position = new Vector2(16f, 16f);
            sprite.Play("idle");
            OwnedComponents.Add(icon =
                new SpriteImage(
                    ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas[
                        "objects/resortclutter/icon_" + color]));
            icon.CenterOrigin();
            icon.Position = new Vector2(16f, 8f);
            OwnedComponents.Add(vertexLight = new VertexLightState(Engine, new Vector2(base.CenterX - base.X, -1f),
                PackedColor.Aqua, 1f, 32, 64));
        }

        public OriginalClutterSwitchState(EntityData data, Vector2 offset, ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, EntityAttributeReader.Enum(data.Values, "type", ClutterColor.Green),
                worlds.Create(data.Position + offset, true))
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (color == ClutterColor.Lightning &&
                (Scene as OriginalLevelSceneRoot).Session.GetFlag("disable_lightning"))
            {
                BePressed();
            }
            else if ((Scene as OriginalLevelSceneRoot).Session.GetFlag("oshiro_clutter_cleared_" + (int)color))
            {
                BePressed();
            }
        }

        private void BePressed()
        {
            pressed = true;
            atY += 10f;
            base.Y += 10f;
            sprite.Position.Y += 2f;
            sprite.Play("active");
            OwnedComponents.Remove(icon);
            vertexLight.StartRadius = 24f;
            vertexLight.EndRadius = 48f;
        }

        public override void Update()
        {
            base.Update();
            if (HasPlayerOnTop())
            {
                if (speedY < 0f)
                {
                    speedY = 0f;
                }

                speedY = ScalarMath.Approach(speedY, 70f, 200f * Engine.DeltaTime,
                    ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic);
                MoveTowardsY(atY + (float)(pressed ? 2 : 4), speedY * Engine.DeltaTime);
                targetXScale = 1.2f;
                if (!playerWasOnTop)
                {
                    Process.AudioSession.Play("event:/game/03_resort/clutterswitch_squish", Position,
                        Process.SaveContext);
                }

                playerWasOnTop = true;
            }
            else
            {
                if (speedY > 0f)
                {
                    speedY = 0f;
                }

                speedY = ScalarMath.Approach(speedY, -150f, 200f * Engine.DeltaTime,
                    ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic);
                MoveTowardsY(atY, (0f - speedY) * Engine.DeltaTime);
                targetXScale = 1f;
                if (playerWasOnTop)
                {
                    Process.AudioSession.Play("event:/game/03_resort/clutterswitch_return", Position,
                        Process.SaveContext);
                }

                playerWasOnTop = false;
            }

            sprite.Scale.X = ScalarMath.Approach(sprite.Scale.X, targetXScale, 0.8f * Engine.DeltaTime,
                ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic);
        }

        private DashCollisionResult OnDashed(RoomPlayerSession player, Vector2 direction)
        {
            if (!pressed && direction == Vector2.UnitY)
            {
                OriginalCelesteFreeze.Freeze(Engine, .2f);
                Rumble.Rumble(2, 1);
                OriginalLevelSceneRoot obj = base.Scene as OriginalLevelSceneRoot;
                obj.Session.SetFlag("oshiro_clutter_cleared_" + (int)color);
                obj.Session.SetFlag("oshiro_clutter_door_open", setTo: false);
                vertexLight.StartRadius = 64f;
                vertexLight.EndRadius = 128f;
                obj.DirectionalShake(Vector2.UnitY, 0.6f);
                obj.Particles.Emit(Process.ParticleTypes.ClutterSwitch.P_Pressed, 20,
                    base.TopCenter - Vector2.UnitY * 10f,
                    new Vector2(16f, 8f));
                BePressed();
                sprite.Scale.X = 1.5f;
                if (color == ClutterColor.Lightning)
                {
                    OwnedComponents.Add(new SimulationCoroutine(Engine, LightningRoutine(player)));
                }
                else
                {
                    OwnedComponents.Add(new SimulationCoroutine(Engine, AbsorbRoutine(player)));
                }
            }

            return DashCollisionResult.NormalCollision;
        }

        private IEnumerator LightningRoutine(RoomPlayerSession player)
        {
            OriginalLevelSceneRoot level = (Scene as OriginalLevelSceneRoot);
            level.Session.SetFlag("disable_lightning");
            var music = level.Session.Audio.Music;
            music.SetProgress(music.GetProgress() + 1);
            global::Celeste.Game.Audio.OriginalAudioSession.Apply(level.Session.Audio,
                Process.AudioSession.ChannelOutput, Process.AudioApplyPolicy);
            yield return OriginalLightningSequence.RemoveRoutine(level);
        }

        private IEnumerator AbsorbRoutine(RoomPlayerSession player)
        {
            OwnedComponents.Add(cutsceneSfx = ((ISourceSoundSourceEnvironment)Engine).SoundSources.Create());
            float duration = 0f;
            if (color == ClutterColor.Green)
            {
                cutsceneSfx.Play("event:/game/03_resort/clutterswitch_books");
                duration = 6.366f;
            }
            else if (color == ClutterColor.Red)
            {
                cutsceneSfx.Play("event:/game/03_resort/clutterswitch_linens");
                duration = 6.15f;
            }
            else if (color == ClutterColor.Yellow)
            {
                cutsceneSfx.Play("event:/game/03_resort/clutterswitch_boxes");
                duration = 6.066f;
            }

            OwnedComponents.Add(SourceAlarmState.Create(Engine.AlarmPool, SourceAlarmState.AlarmMode.Oneshot,
                delegate
                {
                    Process.AudioSession.Play("event:/game/03_resort/clutterswitch_finish", Position,
                        Process.SaveContext);
                }, duration, start: true));
            player.Machine.State = 11;
            Vector2 target = Position + new Vector2(base.Width / 2f, 0f);
            OriginalClutterAbsorbEffectState effect = new OriginalClutterAbsorbEffectState(Engine);
            ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(effect);
            sprite.Play("break");
            OriginalLevelSceneRoot level = (Scene as OriginalLevelSceneRoot);
            var music = level.Session.Audio.Music;
            music.SetProgress(music.GetProgress() + 1);
            global::Celeste.Game.Audio.OriginalAudioSession.Apply(level.Session.Audio,
                Process.AudioSession.ChannelOutput, Process.AudioApplyPolicy);
            level.Session.LightingAlphaAdd -= 0.05f;
            float start = level.Lighting.Alpha;
            SourceTweenState tween = SourceTweenState.Create(Engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                ((ISourceEasingEnvironment)Engine).EasingArithmetic.SineInOut, 2f, start: true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                level.Lighting.Alpha = ScalarMath.Lerp(start, 0.05f, t.Eased,
                    ((ISourceScalarEnvironment)Engine).ScalarArithmetic);
            };
            OwnedComponents.Add(tween);
            SourceAlarmState.Set(Engine.AlarmPool, OwnedComponents, 3f, delegate
            {
                float start2 = vertexLight.StartRadius;
                float end = vertexLight.EndRadius;
                SourceTweenState tween2 = SourceTweenState.Create(Engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                    ((ISourceEasingEnvironment)Engine).EasingArithmetic.SineInOut, 2f, start: true);
                tween2.OnUpdate = delegate(SourceTweenState t)
                {
                    level.Lighting.Alpha = ScalarMath.Lerp(0.05f,
                        level.BaseLightingAlpha + level.Session.LightingAlphaAdd,
                        t.Eased, ((ISourceScalarEnvironment)Engine).ScalarArithmetic);
                    vertexLight.StartRadius = (int)Math.Round(ScalarMath.Lerp(start2, 24f, t.Eased,
                        ((ISourceScalarEnvironment)Engine).ScalarArithmetic));
                    vertexLight.EndRadius = (int)Math.Round(ScalarMath.Lerp(end, 48f, t.Eased,
                        ((ISourceScalarEnvironment)Engine).ScalarArithmetic));
                };
                OwnedComponents.Add(tween2);
            });
            Rumble.Rumble(0, 1);
            foreach (OriginalClutterBlockState item in ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                     .FindAll<OriginalClutterBlockState>())
            {
                if (item.BlockColor == color)
                {
                    item.Absorb(effect);
                }
            }

            foreach (OriginalClutterBlockBaseState item2 in ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                     .FindAll<OriginalClutterBlockBaseState>())
            {
                if (item2.BlockColor == color)
                {
                    item2.Deactivate();
                }
            }

            yield return 1.5f;
            player.Machine.State = 0;
            List<AtlasEntry> images =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.Frames("objects/resortclutter/" +
                    color.ToString() + "_");
            for (int i = 0; i < 25; i++)
            {
                for (int num = 0; num < 5; num++)
                {
                    Vector2 position = target + Vector2Geometry.AngleToVector(
                        SourceRandomMath.NextFloat(((ISourceRandomEnvironment)Engine).Random, (float)Math.PI * 2f),
                        320f);
                    effect.FlyClutter(position, images[((ISourceRandomEnvironment)Engine).Random.Next(images.Count)],
                        shake: false, 0f);
                }

                level.Shake();
                Rumble.Rumble(0, 2);
                yield return 0.05f;
            }

            yield return 1.5f;
            effect.CloseCabinets();
            yield return 0.2f;
            Rumble.Rumble(1, 3);
            yield return 0.3f;
        }

        public override void Removed(object scene)
        {
            OriginalLevelSceneRoot level = scene as OriginalLevelSceneRoot;
            level.Lighting.Alpha = level.BaseLightingAlpha + level.Session.LightingAlphaAdd;
            base.Removed(scene);
        }
    }
}
