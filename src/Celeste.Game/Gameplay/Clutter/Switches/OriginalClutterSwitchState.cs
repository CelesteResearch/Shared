using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Audio;
using Celeste.Game.Entities.Lightning;
using Celeste.Game.Execution.Engine.Actions;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Clutter.Absorption;
using Celeste.Game.Gameplay.Clutter.Blocks;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Clutter;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;
using Celeste.Simulation.Presentation.Lighting;

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

        private readonly ClutterColor color;

        private float startY;

        private float atY;

        private float speedY;

        private bool pressed;

        private readonly Sprite sprite;

        private readonly SpriteImage icon;

        private float targetXScale = 1f;

        private readonly VertexLightState vertexLight;

        private bool playerWasOnTop;

        private SoundSourceComponentState cutsceneSfx;

        public OriginalClutterSwitchState(Vector2 position, ClutterColor color, ISourceSolidWorld world)
            : base(position, 32f, 16f, true, world)
        {
            this.color = color;
            startY = atY = Y;
            OnDashCollide = OnDashed;
            SurfaceSoundIndex = 21;
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.SpriteFactory.Create("clutterSwitch"));
            sprite.Position = new(16f, 16f);
            sprite.Play("idle");
            OwnedComponents.Add(icon =
                new(
                    ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas[
                        "objects/resortclutter/icon_" + color]));
            icon.CenterOrigin();
            icon.Position = new(16f, 8f);
            OwnedComponents.Add(vertexLight = new(Engine, new(CenterX - X, -1f),
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
                BePressed();
            else if ((Scene as OriginalLevelSceneRoot).Session.GetFlag("oshiro_clutter_cleared_" + (int)color))
                BePressed();
        }

        private void BePressed()
        {
            pressed = true;
            atY += 10f;
            Y += 10f;
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
                if (speedY < 0f) speedY = 0f;

                speedY = ScalarMath.Approach(speedY, 70f, 200f * Engine.DeltaTime,
                    ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic);
                MoveTowardsY(atY + (pressed ? 2 : 4), speedY * Engine.DeltaTime);
                targetXScale = 1.2f;
                if (!playerWasOnTop)
                    Process.AudioSession.Play("event:/game/03_resort/clutterswitch_squish", Position,
                        Process.SaveContext);

                playerWasOnTop = true;
            }
            else
            {
                if (speedY > 0f) speedY = 0f;

                speedY = ScalarMath.Approach(speedY, -150f, 200f * Engine.DeltaTime,
                    ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic);
                MoveTowardsY(atY, (0f - speedY) * Engine.DeltaTime);
                targetXScale = 1f;
                if (playerWasOnTop)
                    Process.AudioSession.Play("event:/game/03_resort/clutterswitch_return", Position,
                        Process.SaveContext);

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
                var obj = Scene as OriginalLevelSceneRoot;
                obj.Session.SetFlag("oshiro_clutter_cleared_" + (int)color);
                obj.Session.SetFlag("oshiro_clutter_door_open", false);
                vertexLight.StartRadius = 64f;
                vertexLight.EndRadius = 128f;
                obj.DirectionalShake(Vector2.UnitY, 0.6f);
                obj.Particles.Emit(Process.ParticleTypes.ClutterSwitch.P_Pressed, 20,
                    TopCenter - Vector2.UnitY * 10f,
                    new(16f, 8f));
                BePressed();
                sprite.Scale.X = 1.5f;
                if (color == ClutterColor.Lightning)
                    OwnedComponents.Add(new SimulationCoroutine(Engine, LightningRoutine(player)));
                else
                    OwnedComponents.Add(new SimulationCoroutine(Engine, AbsorbRoutine(player)));
            }

            return DashCollisionResult.NormalCollision;
        }

        private IEnumerator LightningRoutine(RoomPlayerSession player)
        {
            var level = Scene as OriginalLevelSceneRoot;
            level.Session.SetFlag("disable_lightning");
            var music = level.Session.Audio.Music;
            music.SetProgress(music.GetProgress() + 1);
            OriginalAudioSession.Apply(level.Session.Audio,
                Process.AudioSession.ChannelOutput, Process.AudioApplyPolicy);
            yield return OriginalLightningSequence.RemoveRoutine(level);
        }

        private IEnumerator AbsorbRoutine(RoomPlayerSession player)
        {
            OwnedComponents.Add(cutsceneSfx = ((ISourceSoundSourceEnvironment)Engine).SoundSources.Create());
            var duration = 0f;
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
                }, duration, true));
            player.Machine.State = 11;
            var target = Position + new Vector2(Width / 2f, 0f);
            var effect = new OriginalClutterAbsorbEffectState(Engine);
            ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(effect);
            sprite.Play("break");
            var level = Scene as OriginalLevelSceneRoot;
            var music = level.Session.Audio.Music;
            music.SetProgress(music.GetProgress() + 1);
            OriginalAudioSession.Apply(level.Session.Audio,
                Process.AudioSession.ChannelOutput, Process.AudioApplyPolicy);
            level.Session.LightingAlphaAdd -= 0.05f;
            var start = level.Lighting.Alpha;
            var tween = SourceTweenState.Create(Engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                ((ISourceEasingEnvironment)Engine).EasingArithmetic.SineInOut, 2f, true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                level.Lighting.Alpha = ScalarMath.Lerp(start, 0.05f, t.Eased,
                    ((ISourceScalarEnvironment)Engine).ScalarArithmetic);
            };
            OwnedComponents.Add(tween);
            SourceAlarmState.Set(Engine.AlarmPool, OwnedComponents, 3f, delegate
            {
                var start2 = vertexLight.StartRadius;
                var end = vertexLight.EndRadius;
                var tween2 = SourceTweenState.Create(Engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                    ((ISourceEasingEnvironment)Engine).EasingArithmetic.SineInOut, 2f, true);
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
            foreach (var item in ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                     .FindAll<OriginalClutterBlockState>())
                if (item.BlockColor == color)
                    item.Absorb(effect);

            foreach (var item2 in ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                     .FindAll<OriginalClutterBlockBaseState>())
                if (item2.BlockColor == color)
                    item2.Deactivate();

            yield return 1.5f;
            player.Machine.State = 0;
            var images =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.GameAtlas.Frames("objects/resortclutter/" +
                    color + "_");
            for (var i = 0; i < 25; i++)
            {
                for (var num = 0; num < 5; num++)
                {
                    var position = target + Vector2Geometry.AngleToVector(
                        SourceRandomMath.NextFloat(((ISourceRandomEnvironment)Engine).Random, (float)Math.PI * 2f),
                        320f);
                    effect.FlyClutter(position, images[((ISourceRandomEnvironment)Engine).Random.Next(images.Count)],
                        false, 0f);
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
            var level = scene as OriginalLevelSceneRoot;
            level.Lighting.Alpha = level.BaseLightingAlpha + level.Session.LightingAlphaAdd;
            base.Removed(scene);
        }
    }
}
