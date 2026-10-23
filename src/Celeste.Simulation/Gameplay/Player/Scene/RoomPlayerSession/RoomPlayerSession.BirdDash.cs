using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Scene.Lifecycle;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Gameplay.Player.Events;
using Celeste.Simulation.Gameplay.Player.Presentation.Particles;
using Celeste.Simulation.Gameplay.Player.Scene.Effects;
using Celeste.Simulation.Presentation.ScreenEffects;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public PlayerBirdDashSequence BirdDash { get; private set; }
        public Action CancelCutsceneRequested;

        private sealed class BirdTrailAlarm
        {
            public float TimeLeft;
            public bool Removed;
        }

        private readonly List<BirdTrailAlarm> birdTrailAlarms = [];
        private readonly List<BirdTrailAlarm> pendingBirdTrailAlarms = [];

        private void BindBirdDash()
        {
            BirdDash =
                new(Data, Input, Body, Machine,
                    Motor.Dash, new BirdDashWorld(this), EngineContext);
        }

        private void UpdateBirdTrailAlarms(float dt)
        {
            foreach (var alarm in birdTrailAlarms)
            {
                alarm.TimeLeft -= dt;
                if (alarm.TimeLeft <= 0)
                {
                    alarm.TimeLeft = 0;
                    CreateTrail();
                    Report(RoomPlayerEventKind.Dash, "Trail",
                        Body.Position);
                    alarm.Removed = true;
                }
            }
        }

        private void CommitBirdTrailAlarms()
        {
            birdTrailAlarms.RemoveAll(a => a.Removed);
            birdTrailAlarms.AddRange(pendingBirdTrailAlarms);
            pendingBirdTrailAlarms.Clear();
        }

        private sealed class BirdDashWorld : IPlayerBirdDashWorld
        {
            private readonly RoomPlayerSession p;

            public BirdDashWorld(RoomPlayerSession player)
            {
                p = player;
            }

            public bool OnGround()
            {
                return p.OnGround();
            }

            public bool SolidAt(Vector2 offset)
            {
                return p.World.Platforms.SolidAt(p.Body.BoundsAt(p.Body.Position + offset));
            }

            public float LevelBottom => p.World.Contacts.RoomBounds.Bottom;

            public void PlaySprite(string animation)
            {
                p.Sprite.Play(animation);
            }

            public void PlaySound(string sound)
            {
                p.Report(RoomPlayerEventKind.Sound, sound,
                    p.World.Center);
            }

            public void CreateTrail()
            {
                p.CreateTrail();
            }

            public void AddTrailAlarm(float delay)
            {
                var alarm = new BirdTrailAlarm { TimeLeft = delay };
                (p.UpdatingComponents ? p.pendingBirdTrailAlarms : p.birdTrailAlarms).Add(alarm);
            }

            public void DirectionalShake(Vector2 direction, float duration)
            {
                ((ISourceLevelShakeScene)p.Level)
                    .DirectionalShake(direction, duration);
                p.Report(RoomPlayerEventKind.Dash,
                    "DirectionalShake", p.Body.Position, duration, direction);
            }

            public void Slash(Vector2 position, float direction)
            {
                p.CreateDashSlash(position, direction);
                p.Report(RoomPlayerEventKind.Dash, "BirdSlash",
                    position, direction);
            }

            public void EmitDashParticle(Vector2 center, Vector2 range, float direction)
            {
                ((ISourcePlayerDashEffectsScene)p.Level)
                    .EmitPlayerBirdDashParticle(center, range, direction);
                p.Report(RoomPlayerEventKind.Dash, "BirdParticle",
                    center, direction, range);
            }

            public bool OnInterval(float interval)
            {
                return p.World.OnInterval(interval);
            }

            public void DustBurst(Vector2 position, float direction, int count)
            {
                ((ISourcePlayerDashEffectsScene)p.Level)
                    .BurstPlayerDashDust(position, direction, count);
                p.World.Report(new(
                    RoomPlayerEventKind.Particles, position,
                    Vector2.Zero, "BirdDust",
                    dust: new PlayerDustEmission(
                        position, direction, count)));
            }

            public void CancelCutscene()
            {
                ((ISceneCutsceneState)p.Scene).ClearInCutscene();
                p.CancelCutsceneRequested?.Invoke();
            }

            public void Die(Vector2 direction)
            {
                p.Die(direction);
            }
        }
    }
}
