using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components.Timing;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display.Colors;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
    public partial class OriginalHeartGemState
    {
        public override void Awake(object scene)
        {
            base.Awake(scene);
            var area = ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(
                ((OriginalLevelSceneRoot)Scene).Session);
            IsGhost = !IsFake &&
                      ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(
                          ((IOriginalGameplayProcess)engine)
                          .SaveContext.CurrentSave)[area.ID].Modes[area.Mode].HeartGem;
            var id = IsFake ? "heartgem3" : !IsGhost ? "heartgem" + area.Mode : "heartGemGhost";
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create(id));
            sprite.Play("spin");
            sprite.OnLoop = anim =>
            {
                if (Visible && anim == "spin" && autoPulse)
                {
                    if (IsFake)
                        ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                            "event:/new_content/game/10_farewell/fakeheart_pulse", Position);
                    else
                        ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                            "event:/game/general/crystalheart_pulse", Position);
                    ScaleWiggler.Start();
                    ((OriginalLevelSceneRoot)Scene).Displacement.AddBurst(Position, 0.35f, 8f, 48f, 0.25f);
                }
            };
            if (IsGhost)
                sprite.Color = PackedColor.White * 0.8f;
            Collider = new HitboxColliderGeometry(16f, 16f, -8f, -8f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(ScaleWiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(
                0.5f, 4f, f => sprite.Scale = Vector2.One * (1f + f * 0.25f)));
            OwnedComponents.Add(bloom = new(0.75f, 16f));
            PackedColor value;
            if (IsFake)
            {
                value = PackedColor.FromHex("dad8cc");
                shineParticle = ((IOriginalGameplayProcess)engine).ParticleTypes.HeartGem.P_FakeShine;
            }
            else if (area.Mode == 0)
            {
                value = PackedColor.Aqua;
                shineParticle = ((IOriginalGameplayProcess)engine).ParticleTypes.HeartGem.P_BlueShine;
            }
            else if (area.Mode == 1)
            {
                value = PackedColor.Red;
                shineParticle = ((IOriginalGameplayProcess)engine).ParticleTypes.HeartGem.P_RedShine;
            }
            else
            {
                value = PackedColor.Gold;
                shineParticle = ((IOriginalGameplayProcess)engine).ParticleTypes.HeartGem.P_GoldShine;
            }

            value = SourceColorInterpolation.Lerp(value, PackedColor.White, 0.5f,
                ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            OwnedComponents.Add(light = new(engine, value, 1f, 32, 64));
            if (IsFake)
            {
                bloom.Alpha = 0f;
                light.Alpha = 0f;
            }

            moveWiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.8f, 2f);
            moveWiggler.StartZero = true;
            OwnedComponents.Add(moveWiggler);
            if (!IsFake)
                return;
            var player = FirstPlayer();
            if ((player != null && player.X > X) || ((OriginalLevelSceneRoot)scene).Session.GetFlag("fake_heart"))
            {
                Visible = false;
                SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 0.0001f, () =>
                {
                    FakeRemoveCameraTrigger();
                    RemoveSelf();
                });
            }
            else
            {
                fakeRightWall = new(
                    engine, new(X + 160f, Y - 200f), 8f, 400f,
                    ((OriginalLevelSceneRoot)Scene).SolidWorldFactory);
                ((OriginalLevelSceneRoot)scene).Scheduler.QueueSourceEntity(fakeRightWall);
            }
        }
    }
}
