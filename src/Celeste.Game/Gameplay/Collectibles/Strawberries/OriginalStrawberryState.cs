using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Physics.Collision.Shapes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Following;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Collectibles.Strawberry;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Game.Gameplay.Collectibles.Strawberries
{
    public class OriginalStrawberryState : SceneEntityState, ISourceStrawberryCollectible,
        ISourceStrawberryFollower
    {
        public MapEntityId ID;
        private Sprite sprite;
        public FollowerState Follower;
        private WigglerComponent wiggler;
        private WigglerComponent rotateWiggler;
        private BloomPointState bloom;
        private VertexLightState light;
        private SourceTweenState lightTween;
        private float wobble;
        private Vector2 start;
        private float collectTimer;
        private bool collected;
        protected bool Collected => collected;

        protected Vector2 StartPosition
        {
            get => start;
            set => start = value;
        }

        private bool isGhostBerry;
        private bool flyingAway;
        private float flapSpeed;
        public bool ReturnHomeWhenLost = true;
        public bool WaitingOnSeeds;
        public List<OriginalStrawberrySeedState> Seeds;
        public bool Winged { get; private set; }
        public bool Golden { get; protected set; }
        public bool Moon { get; private set; }
        private readonly IOriginalStrawberryProcess process;
        private IOriginalStrawberryScene Level => (IOriginalStrawberryScene)Scene;
        MapEntityId ISourceStrawberryFollower.ID => ID;
        FollowerState ISourceStrawberryFollower.Follower => Follower;

        private string gotSeedFlag =>
            "collected_seeds_of_" + global::Celeste.Formats.Map.Identifiers.EntityIdCodec.Format(ID);

        private bool IsFirstStrawberry
        {
            get
            {
                for (int i = Follower.FollowIndex - 1; i >= 0; i--)
                    if (Follower.Leader.Followers[i].Entity is OriginalStrawberryState { Golden: false })
                        return false;
                return true;
            }
        }

        public OriginalStrawberryState(EntityData data, Vector2 offset,
            MapEntityId id, IOriginalStrawberryProcess process)
            : base(
                ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)process)
                .EntitySourceDataRegistration,
                data.Position + offset)
        {
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            ID = id;
            Position = start = data.Position + offset;
            Winged = EntityAttributeReader.Bool(data.Values, "winged") || data.Name == "memorialTextController";
            Golden = data.Name == "memorialTextController" || data.Name == "goldenBerry";
            Moon = EntityAttributeReader.Bool(data.Values, "moon");
            isGhostBerry = process.CheckStrawberry(ID);
            Depth = -100;
            Collider = new HitboxColliderGeometry(14f, 14f, -7f, -7f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(new MirrorReflectionState());
            Follower = new FollowerState(process, OriginalSceneTags.Persistent, ID,
                onLoseLeader: OnLoseLeader);
            OwnedComponents.Add(Follower);
            Follower.FollowDelay = .3f;
            if (Winged) OwnedComponents.Add(new DashListenerState { OnDash = OnDash });
            if (data.Nodes != null && data.Nodes.Length != 0)
            {
                Seeds = new List<OriginalStrawberrySeedState>();
                for (int i = 0; i < data.Nodes.Length; i++)
                    Seeds.Add(new OriginalStrawberrySeedState(this, offset + data.Nodes[i], i, isGhostBerry, process));
            }
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            bool ghost = process.CheckStrawberry(ID);
            sprite = CreateSprite(ghost);
            if (ghost) sprite.Color = global::Celeste.Core.Display.PackedColor.White * .8f;
            OwnedComponents.Add(sprite);
            if (Winged) sprite.Play("flap");
            sprite.OnFrameChange = OnAnimate;
            wiggler = process.WigglerPool.Create(.4f, 4f,
                value => sprite.Scale = Vector2.One * (1f + value * .35f));
            OwnedComponents.Add(wiggler);
            rotateWiggler = process.WigglerPool.Create(.5f, 4f,
                value => sprite.Rotation = value * 30f * ((float)Math.PI / 180f));
            OwnedComponents.Add(rotateWiggler);
            bloom = new BloomPointState(Golden || Moon || isGhostBerry ? .5f : 1f, 12f);
            OwnedComponents.Add(bloom);
            light = new VertexLightState(process, Vector2.Zero, global::Celeste.Core.Display.PackedColor.White, 1f,
                16, 24);
            OwnedComponents.Add(light);
            lightTween = light.CreatePulseTween(process);
            OwnedComponents.Add(lightTween);
            if (Seeds != null && Seeds.Count > 0 && !Level.GetSeedCollectionFlag(ID))
            {
                foreach (var seed in Seeds) Level.SourceScene.QueueSourceEntity(seed);
                Visible = false;
                Collidable = false;
                WaitingOnSeeds = true;
                bloom.Visible = light.Visible = false;
            }

            if (Level.BloomBaseAdd > .1f) bloom.Alpha *= .5f;
        }

        public override void Update()
        {
            if (WaitingOnSeeds) return;
            if (!collected)
            {
                if (!Winged)
                {
                    wobble += process.DeltaTime * 4f;
                    sprite.Y = bloom.Y = light.Y = (float)Math.Sin(wobble) * 2f;
                }

                int followIndex = Follower.FollowIndex;
                if (Follower.Leader != null && Follower.DelayTimer <= 0f && IsFirstStrawberry)
                {
                    var player = Follower.Leader.Entity as RoomPlayerSession;
                    bool collect = false;
                    if (player != null && player.Scene != null && !player.StrawberriesBlocked)
                    {
                        if (Golden)
                        {
                            if (CanCollectGolden(player)) collect = true;
                        }
                        else if (player.OnSafeGround && (!Moon || player.Machine.State != 13)) collect = true;
                    }

                    if (collect)
                    {
                        collectTimer += process.DeltaTime;
                        if (collectTimer > .15f) OnCollect();
                    }
                    else
                        collectTimer =
                            ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)process)
                            .ExtremaArithmetic
                            .Min(collectTimer, 0f);
                }
                else
                {
                    if (followIndex > 0) collectTimer = -.15f;
                    if (Winged)
                    {
                        Position += new Vector2(0f, flapSpeed * process.DeltaTime);
                        if (flyingAway)
                        {
                            if (Position.Y < (float)unchecked(Level.Bounds.Top - 16)) RemoveSelf();
                        }
                        else
                        {
                            flapSpeed = ScalarMath.Approach(flapSpeed, 20f, 170f * process.DeltaTime,
                                ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)process)
                                .ExtremaArithmetic);
                            if (Position.Y < start.Y - 5f) Position = new Vector2(Position.X, start.Y - 5f);
                            else if (Position.Y > start.Y + 5f) Position = new Vector2(Position.X, start.Y + 5f);
                        }
                    }
                }
            }

            base.Update();
            if (Follower.Leader != null && Level.SourceScene.Clock.OnInterval(.08f, process))
            {
                var type = GetGlowParticle();
                Level.ParticlesForeground.Emit(type, Position +
                                                     SourceRandomMath.Range(process.SpriteRandom, -Vector2.One * 6f,
                                                         Vector2.One * 6f));
            }
        }

        private void OnDash(Vector2 direction)
        {
            if (!flyingAway && Winged && !WaitingOnSeeds)
            {
                Depth = -1000000;
                OwnedComponents.Add(new SimulationCoroutine(process, FlyAwayRoutine()));
                flyingAway = true;
            }
        }

        private void OnAnimate(string animation)
        {
            if (!flyingAway && animation == "flap" && sprite.CurrentAnimationFrame % 9 == 4)
            {
                Play("event:/game/general/strawberry_wingflap");
                flapSpeed = -50f;
            }

            int frame = animation == "flap" ? 25 : Golden ? 30 : Moon ? 30 : 35;
            if (sprite.CurrentAnimationFrame == frame)
            {
                lightTween.Start();
                float alpha = !collected && (CollideCheck("Celeste.FakeWall") || CollideCheck("Celeste.Solid"))
                    ? .1f
                    : .2f;
                Play("event:/game/general/strawberry_pulse");
                Level.AddStrawberryDisplacementBurst(Position, .6f, 4f, 28f, alpha);
            }
        }

        public void OnPlayer(RoomPlayerSession player)
        {
            if (Follower.Leader != null || collected || WaitingOnSeeds) return;
            ReturnHomeWhenLost = true;
            if (Winged)
            {
                var level = Level;
                Winged = false;
                sprite.Rate = 0f;
                SourceAlarmState.Set(process.AlarmPool, OwnedComponents, Follower.FollowDelay, () =>
                {
                    sprite.Rate = 1f;
                    sprite.Play("idle");
                    level.Particles.Emit(process.ParticleTypes.Strawberry.P_WingsBurst, 8,
                        Position + new Vector2(8f, 0f), new Vector2(4f, 2f));
                    level.Particles.Emit(process.ParticleTypes.Strawberry.P_WingsBurst, 8,
                        Position - new Vector2(8f, 0f), new Vector2(4f, 2f));
                });
            }

            if (Golden) Level.SetGrabbedGolden();
            Play(isGhostBerry ? "event:/game/general/strawberry_blue_touch" : "event:/game/general/strawberry_touch");
            player.Leader.GainFollower(Follower);
            wiggler.Start();
            Depth = -1000000;
        }

        public void OnCollect()
        {
            if (collected) return;
            int collectIndex = 0;
            collected = true;
            if (Follower.Leader != null)
            {
                var player = Follower.Leader.Entity as RoomPlayerSession;
                collectIndex = player.StrawberryCollectIndex;
                player.StrawberryCollectIndex++;
                player.StrawberryCollectResetTimer = 2.5f;
                Follower.Leader.LoseFollower(Follower);
            }

            if (Moon) process.RegisterMoonBerryAchievement();
            Level.RegisterCollectedStrawberry(this);
            OwnedComponents.Add(new SimulationCoroutine(process, CollectRoutine(collectIndex)));
        }

        private IEnumerator FlyAwayRoutine()
        {
            rotateWiggler.Start();
            flapSpeed = -200f;
            var tween = SourceTweenState.Create(process.TweenPool, SourceTweenState.TweenMode.Oneshot,
                process.EasingArithmetic.CubeOut, .25f, true);
            tween.OnUpdate = t => flapSpeed = process.ScalarArithmetic.Lerp(-200f, 0f, t.Eased);
            OwnedComponents.Add(tween);
            yield return .1f;
            Play("event:/game/general/strawberry_laugh");
            yield return .2f;
            if (!Follower.HasLeader) Play("event:/game/general/strawberry_flyaway");
            tween = SourceTweenState.Create(process.TweenPool, SourceTweenState.TweenMode.Oneshot, null, .5f, true);
            tween.OnUpdate = t => flapSpeed = process.ScalarArithmetic.Lerp(0f, -200f, t.Eased);
            OwnedComponents.Add(tween);
        }

        private IEnumerator CollectRoutine(int collectIndex)
        {
            _ = Scene;
            Tags = OriginalSceneTags.TransitionUpdate;
            Depth = -2000010;
            int colour = Moon ? 3 : isGhostBerry ? 1 : Golden ? 2 : 0;
            process.AudioSession.Play(CollectSound, Position,
                process.SaveContext, "colour", colour, "count", collectIndex);
            process.RumbleSession.Rumble(1, 1);
            sprite.Play("collect");
            while (sprite.Animating) yield return null;
            Level.QueueStrawberryPoints(Position, isGhostBerry, collectIndex, Moon);
            RemoveSelf();
        }

        private void OnLoseLeader()
        {
            if (collected || !ReturnHomeWhenLost) return;
            SourceAlarmState.Set(process.AlarmPool, OwnedComponents, .15f, () =>
            {
                Vector2 direction = process.VectorArithmetic.SafeNormalize(start - Position);
                float distance = process.VectorArithmetic.Distance(Position, start);
                float bulge = ScalarMath.ClampedMap(distance, 16f, 120f, 16f, 96f);
                Vector2 control = start + direction * 16f + Vector2Geometry.Perpendicular(direction) * bulge *
                    RandomSelection.Choose(process.SpriteRandom, 1, -1);
                var curve = new SimpleCurve(Position, start, control);
                var tween = SourceTweenState.Create(process.TweenPool, SourceTweenState.TweenMode.Oneshot,
                    process.EasingArithmetic.SineOut,
                    ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)process).ExtremaArithmetic.Max(
                        distance / 100f, .4f), true);
                tween.OnUpdate = t => Position = process.CurveArithmetic.GetPoint(curve, t.Eased);
                tween.OnComplete = _ => Depth = 0;
                OwnedComponents.Add(tween);
            });
        }

        public void CollectedSeeds()
        {
            WaitingOnSeeds = false;
            Visible = true;
            Collidable = true;
            bloom.Visible = light.Visible = true;
            Level.SetSeedCollectionFlag(ID);
        }


        protected virtual Sprite CreateSprite(bool ghost) => process.GameGraphics.SpriteFactory.Create(ghost
            ? Moon ? "moonghostberry" : Golden ? "goldghostberry" : "ghostberry"
            : Moon
                ? "moonberry"
                : Golden
                    ? "goldberry"
                    : "strawberry");

        protected virtual Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation
            GetGlowParticle() => isGhostBerry ? process.ParticleTypes.Strawberry.P_GhostGlow
            : Golden ? process.ParticleTypes.Strawberry.P_GoldGlow
            : Moon ? process.ParticleTypes.Strawberry.P_MoonGlow : process.ParticleTypes.Strawberry.P_Glow;

        protected virtual bool CanCollectGolden(RoomPlayerSession player)
            => Level.PlayerInGoldenCollectTrigger(player) || Level.Completed;

        protected virtual string CollectSound => "event:/game/general/strawberry_get";

        private void Play(string sound) => process.AudioSession.Play(sound, Position, process.SaveContext);
    }
}
