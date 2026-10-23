using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public global::Celeste.Simulation.Gameplay.Player.Dash.PlayerBirdDashSequence BirdDash { get; private set; }
        public Action CancelCutsceneRequested;

        private sealed class BirdTrailAlarm
        {
            public float TimeLeft;
            public bool Removed;
        }

        private readonly List<BirdTrailAlarm> birdTrailAlarms = new List<BirdTrailAlarm>();
        private readonly List<BirdTrailAlarm> pendingBirdTrailAlarms = new List<BirdTrailAlarm>();

        private void BindBirdDash() => BirdDash =
            new global::Celeste.Simulation.Gameplay.Player.Dash.PlayerBirdDashSequence(Data, Input, Body, Machine,
                Motor.Dash, new BirdDashWorld(this), engineContext);

        private void UpdateBirdTrailAlarms(float dt)
        {
            foreach (var alarm in birdTrailAlarms)
            {
                alarm.TimeLeft -= dt;
                if (alarm.TimeLeft <= 0)
                {
                    alarm.TimeLeft = 0;
                    CreateTrail();
                    Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Dash, "Trail",
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

        private sealed class BirdDashWorld : global::Celeste.Simulation.Gameplay.Player.Dash.IPlayerBirdDashWorld
        {
            private readonly RoomPlayerSession p;

            public BirdDashWorld(RoomPlayerSession player)
            {
                p = player;
            }

            public bool OnGround() => p.OnGround();
            public bool SolidAt(Vector2 offset) => p.World.Platforms.SolidAt(p.Body.BoundsAt(p.Body.Position + offset));
            public float LevelBottom => p.World.Contacts.RoomBounds.Bottom;
            public void PlaySprite(string animation) => p.Sprite.Play(animation);

            public void PlaySound(string sound) =>
                p.Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Sound, sound,
                    p.World.Center);

            public void CreateTrail() => p.CreateTrail();

            public void AddTrailAlarm(float delay)
            {
                var alarm = new BirdTrailAlarm { TimeLeft = delay };
                (p.UpdatingComponents ? p.pendingBirdTrailAlarms : p.birdTrailAlarms).Add(alarm);
            }

            public void DirectionalShake(Vector2 direction, float duration)
            {
                ((global::Celeste.Simulation.Presentation.ScreenEffects.ISourceLevelShakeScene)p.Level)
                    .DirectionalShake(direction, duration);
                p.Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Dash,
                    "DirectionalShake", p.Body.Position, duration, direction);
            }

            public void Slash(Vector2 position, float direction)
            {
                p.CreateDashSlash(position, direction);
                p.Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Dash, "BirdSlash",
                    position, direction);
            }

            public void EmitDashParticle(Vector2 center, Vector2 range, float direction)
            {
                ((global::Celeste.Simulation.Gameplay.Player.Scene.Effects.ISourcePlayerDashEffectsScene)p.Level)
                    .EmitPlayerBirdDashParticle(center, range, direction);
                p.Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Dash, "BirdParticle",
                    center, direction, range);
            }

            public bool OnInterval(float interval) => p.World.OnInterval(interval);

            public void DustBurst(Vector2 position, float direction, int count)
            {
                ((global::Celeste.Simulation.Gameplay.Player.Scene.Effects.ISourcePlayerDashEffectsScene)p.Level)
                    .BurstPlayerDashDust(position, direction, count);
                p.World.Report(new global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEvent(
                    global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Particles, position,
                    Vector2.Zero, "BirdDust",
                    dust: new global::Celeste.Simulation.Gameplay.Player.Presentation.Particles.PlayerDustEmission(
                        position, direction, count)));
            }

            public void CancelCutscene()
            {
                ((global::Celeste.Scene.Lifecycle.ISceneCutsceneState)p.Scene).ClearInCutscene();
                p.CancelCutsceneRequested?.Invoke();
            }

            public void Die(Vector2 direction) => p.Die(direction);
        }
    }
}
