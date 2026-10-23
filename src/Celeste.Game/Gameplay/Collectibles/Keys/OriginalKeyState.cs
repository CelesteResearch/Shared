using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Display;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Animation;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Following;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Particles.Emission;

namespace Celeste.Game.Gameplay.Collectibles.Keys
{
    public class OriginalKeyState : SceneEntityState
    {
        public MapEntityId ID;
        public bool IsUsed;
        public bool StartedUsing;
        public bool Turning { get; private set; }
        private readonly Sprite sprite;
        private readonly WigglerComponent wiggler;
        private readonly VertexLightState light;
        private ParticleEmitterState shimmerParticles;
        private float wobble;
        private bool wobbleActive;
        private SourceTweenState tween;
        private SourceAlarmState alarm;
        private readonly Vector2[] nodes;
        private readonly IOriginalKeyProcess process;
        public FollowerState Follower { get; }

        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;

        public OriginalKeyState(EntityData data, Vector2 offset, MapEntityId id,
            IOriginalKeyProcess process) : this(data.Position + offset, id, data.NodesOffset(offset), process)
        {
        }

        public OriginalKeyState(Vector2 position, MapEntityId id, Vector2[] nodes, IOriginalKeyProcess process)
            : base(((ISourceEntitySourceDataEnvironment)process).EntitySourceDataRegistration, position)
        {
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            ID = id;
            Collider = new HitboxColliderGeometry(12f, 12f, -6f, -6f);
            this.nodes = nodes;
            Follower = new(process,
                ((ISourcePersistentTransitionExecutionTagsEnvironment)process).PersistentTransitionExecutionTags
                .Persistent
                .Value, id);
            OwnedComponents.Add(Follower);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(new MirrorReflectionState());
            sprite = process.GameGraphics.SpriteFactory.Create("key");
            OwnedComponents.Add(sprite);
            sprite.CenterOrigin();
            sprite.Play("idle");
            OwnedComponents.Add(new RoomTransitionListener { OnOut = TransitionOut });
            wiggler = process.WigglerPool.Create(.4f, 4f, v => sprite.Scale = Vector2.One * (1f + v * .35f));
            OwnedComponents.Add(wiggler);
            light = new(process, Vector2.Zero, PackedColor.White, 1f, 32, 48);
            OwnedComponents.Add(light);
        }

        public OriginalKeyState(RoomPlayerSession player, MapEntityId id, IOriginalKeyProcess process)
            : this(player.Position + new Vector2(-12 * player.Facing, -8f), id, null, process)
        {
            player.Leader.GainFollower(Follower);
            Collidable = false;
            Depth = -1000000;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            shimmerParticles = new(Level.ParticlesFG,
                process.ParticleTypes.Key.P_Shimmer, Vector2.Zero, new(6f, 6f), 1, .1f, process);
            OwnedComponents.Add(shimmerParticles);
            shimmerParticles.SimulateCycle();
        }

        public override void Update()
        {
            if (wobbleActive)
            {
                wobble += process.DeltaTime * 4f;
                sprite.Position.Y = (float)Math.Sin(wobble);
            }

            base.Update();
        }

        private void TransitionOut(float percent)
        {
            StartedUsing = false;
            if (IsUsed) return;
            if (tween != null)
            {
                tween.RemoveSelf();
                tween = null;
            }

            if (alarm != null)
            {
                alarm.RemoveSelf();
                alarm = null;
            }

            Turning = false;
            Visible = true;
            sprite.Visible = true;
            sprite.Rate = 1f;
            sprite.Scale = Vector2.One;
            sprite.Play("idle");
            sprite.Rotation = 0f;
            wiggler.Stop();
            Follower.MoveTowardsLeader = true;
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            Level.Particles.Emit(process.ParticleTypes.Key.P_Collect, 10, Position, Vector2.One * 3f);
            process.AudioSession.Play("event:/game/general/key_get", Position, process.SaveContext);
            process.RumbleSession.Rumble(1, 1);
            player.Leader.GainFollower(Follower);
            Collidable = false;
            var session = Level.Session;
            session.DoNotLoad.Add(ID);
            session.Keys.Add(ID);
            session.UpdateLevelStartDashes();
            wiggler.Start();
            Depth = -1000000;
            if (nodes != null && nodes.Length >= 2)
                OwnedComponents.Add(new SimulationCoroutine(process, NodeRoutine(player)));
        }

        private IEnumerator NodeRoutine(RoomPlayerSession player)
        {
            yield return .3f;
            if (!player.Dead)
            {
                process.AudioSession.Play("event:/game/general/cassette_bubblereturn",
                    Level.Camera.Position + new Vector2(160f, 90f), process.SaveContext);
                player.StartCassetteFly(nodes[1], nodes[0]);
            }
        }

        public void RegisterUsed()
        {
            IsUsed = true;
            if (Follower.Leader != null) Follower.Leader.LoseFollower(Follower);
            Level.Session.Keys.Remove(ID);
        }

        public IEnumerator UseRoutine(Vector2 target)
        {
            Turning = true;
            Follower.MoveTowardsLeader = false;
            wiggler.Start();
            wobbleActive = false;
            sprite.Position.Y = 0f;
            var position = Position;
            var curve = new SimpleCurve(position, target, (target + position) / 2f + new Vector2(0f, -48f));
            tween = SourceTweenState.Create(process.TweenPool, SourceTweenState.TweenMode.Oneshot,
                process.EasingArithmetic.CubeOut, 1f, true);
            tween.OnUpdate = t =>
            {
                Position = process.CurveArithmetic.GetPoint(curve, t.Eased);
                sprite.Rate = 1f + t.Eased * 2f;
            };
            OwnedComponents.Add(tween);
            yield return tween.Wait();
            tween = null;
            while (sprite.CurrentAnimationFrame != 4) yield return null;
            shimmerParticles.Active = false;
            process.RumbleSession.Rumble(1, 1);
            for (var i = 0; i < 16; i++)
                Level.ParticlesFG.Emit(process.ParticleTypes.Key.P_Insert, Center, (float)Math.PI / 8f * i);
            sprite.Play("enter");
            yield return .3f;
            tween = SourceTweenState.Create(process.TweenPool, SourceTweenState.TweenMode.Oneshot,
                process.EasingArithmetic.CubeIn, .3f, true);
            tween.OnUpdate = t => sprite.Rotation = t.Eased * ((float)Math.PI / 2f);
            OwnedComponents.Add(tween);
            yield return tween.Wait();
            tween = null;
            process.RumbleSession.Rumble(0, 1);
            alarm = SourceAlarmState.Set(process.AlarmPool, OwnedComponents, 1f, () =>
            {
                alarm = null;
                tween = SourceTweenState.Create(process.TweenPool, SourceTweenState.TweenMode.Oneshot, null, 1f, true);
                tween.OnUpdate = t => light.Alpha = 1f - t.Eased;
                tween.OnComplete = t => RemoveSelf();
                OwnedComponents.Add(tween);
            });
            yield return .2f;
            for (var i = 0; i < 8; i++)
                Level.ParticlesFG.Emit(process.ParticleTypes.Key.P_Insert, Center, (float)Math.PI / 4f * i);
            sprite.Visible = false;
            Turning = false;
        }
    }
}
