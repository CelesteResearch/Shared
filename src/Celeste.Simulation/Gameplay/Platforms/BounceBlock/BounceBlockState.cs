using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components.Timing;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Platforms.BounceBlock
{
    public class BounceBlockState : SourceSolidEntityState
    {
        public enum States
        {
            Waiting,
            WindingUp,
            Bouncing,
            BounceEnd,
            Broken,
        }

        private IBounceBlockEffects effects => (IBounceBlockEffects)Scene;
        public readonly Vector2 StartPosition;

        public readonly List<SpriteImage> HotImages = [],
            ColdImages = [];

        public readonly Sprite HotCenter, ColdCenter;

        public States State { get; private set; }
        public Vector2 BounceDirection { get; private set; }
        public float MoveSpeed { get; private set; }
        public float WindUpStartTimer { get; private set; }
        public float WindUpProgress { get; private set; }
        public bool IceMode { get; private set; }
        public bool IceModeNext { get; private set; }
        public float RespawnTimer { get; private set; }
        public float BounceEndTimer { get; private set; }
        public Vector2 BounceLift { get; private set; }
        public float ReappearFlash { get; private set; }
        public bool Reformed { get; private set; } = true;
        public Vector2 DebrisDirection { get; private set; }

        public BounceBlockState(Vector2 position, float width, float height, ISourceSolidWorld world) : base(position,
            width, height, false, world)
        {
            var graphics = ((ISourceGameGraphicsEnvironment)world.EngineContext)
                .GameGraphics;
            var atlas = graphics.GameAtlas;
            var bank = graphics.SpriteFactory;
            State = States.Waiting;
            StartPosition = Position;
            Build(HotImages, atlas.Entries["objects/bumpblocknew/fire00"]);
            HotCenter = bank.Create("bumpBlockCenterFire");
            HotCenter.Position = new Vector2(Width, Height) / 2f;
            HotCenter.Visible = false;
            OwnedComponents.Add(HotCenter);
            Build(ColdImages, atlas.Entries["objects/bumpblocknew/ice00"]);
            ColdCenter = bank.Create("bumpBlockCenterIce");
            ColdCenter.Position = new Vector2(Width, Height) / 2f;
            ColdCenter.Visible = false;
            OwnedComponents.Add(ColdCenter);
            OwnedComponents.Add(new CoreModeListenerState(OnChangeMode));
        }

        private void Build(List<SpriteImage> list, AtlasEntry source)
        {
            int columns = source.FrameWidth / 8, rows = source.FrameHeight / 8;
            for (var x = 0; x < Width; x += 8)
            for (var y = 0; y < Height; y += 8)
            {
                var tx = x != 0
                    ? x >= Width - 8f
                        ? columns - 1
                        : ((ISourceRandomEnvironment)SourceWorld.EngineContext).Random
                        .Next(1, columns - 1)
                    : 0;
                var ty = y != 0
                    ? y >= Height - 8f
                        ? rows - 1
                        : ((ISourceRandomEnvironment)SourceWorld.EngineContext).Random
                        .Next(1, rows - 1)
                    : 0;
                var image = new SpriteImage(source.GetSubtexture(tx * 8, ty * 8, 8, 8));
                image.Position = new(x, y);
                list.Add(image);
                OwnedComponents.Add(image);
            }
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            IceModeNext = IceMode = InitialIceMode;
            Toggle();
        }

        protected virtual bool InitialIceMode => ((ISourceCoreModeScene)Scene).CoreMode == RoomCoreMode.Cold;

        public void OnChangeMode(RoomCoreMode mode)
        {
            IceModeNext = mode == RoomCoreMode.Cold;
        }

        private void Toggle()
        {
            HotCenter.Visible = !IceMode;
            ColdCenter.Visible = IceMode;
            foreach (var image in HotImages) image.Visible = !IceMode;
            foreach (var image in ColdImages) image.Visible = IceMode;
        }

        private void CheckMode()
        {
            if (IceModeNext != IceMode)
            {
                IceMode = IceModeNext;
                Toggle();
            }
        }

        public RoomPlayerSession WindUpPlayerCheck()
        {
            var p = CollideFirst<RoomPlayerSession>(typeof(RoomPlayerSession).FullName,
                Position - Vector2.UnitY);

            if (p != null && p.Data.Motion.Normal.Speed.Y < 0) p = null;
            if (p == null)
            {
                p = CollideFirst<RoomPlayerSession>(typeof(RoomPlayerSession).FullName,
                    Position + Vector2.UnitX);

                if (p == null || p.Machine.State != 1 || p.Data.Facing != -1)
                {
                    p = CollideFirst<RoomPlayerSession>(typeof(RoomPlayerSession).FullName,
                        Position - Vector2.UnitX);

                    if (p == null || p.Machine.State != 1 || p.Data.Facing != 1) p = null;
                }
            }

            return p;
        }

        public void ShakeOffPlayer(Vector2 lift)
        {
            var p = WindUpPlayerCheck();
            if (p != null)
            {
                p.Machine.State = 0;
                p.Data.Motion.Normal.Speed = lift;
                p.StartJumpGraceTime();
            }
        }

        public override void Update()
        {
            base.Update();
            var dt = SourceWorld.EngineContext.DeltaTime;
            ReappearFlash = Approach(ReappearFlash, 0, dt * 8);
            if (State == States.Waiting)
            {
                CheckMode();
                MoveSpeed = Approach(MoveSpeed, 100, 400 * dt);
                var next = Approach(ExactPosition, StartPosition, MoveSpeed * dt);
                var lift = Normalize(next - ExactPosition, MoveSpeed);
                lift.X *= .75f;
                MoveTo(next, lift);
                WindUpProgress = Approach(WindUpProgress, 0, dt);
                var p = WindUpPlayerCheck();
                if (p != null)
                {
                    MoveSpeed = 80;
                    WindUpStartTimer = 0;
                    BounceDirection = IceMode ? -Vector2.UnitY : Normalize(p.Center - Center);
                    State = States.WindingUp;
                    effects.Rumble(true);
                    if (IceMode)
                    {
                        StartShaking(.2f);
                        effects.PlaySound("event:/game/09_core/iceblock_touch", Center);
                    }
                    else
                    {
                        effects.PlaySound("event:/game/09_core/bounceblock_touch", Center);
                    }
                }
            }
            else if (State == States.WindingUp)
            {
                var p = WindUpPlayerCheck();
                if (p != null) BounceDirection = IceMode ? -Vector2.UnitY : Normalize(p.Center - Center);
                if (WindUpStartTimer > 0)
                {
                    WindUpStartTimer -= dt;
                    WindUpProgress = Approach(WindUpProgress, 0, dt);
                    return;
                }

                MoveSpeed = Approach(MoveSpeed, IceMode ? 35 : 40, 600 * dt);
                var scale = IceMode ? .333f : 1;
                var target = StartPosition - BounceDirection * (IceMode ? 16 : 10);
                var next = Approach(ExactPosition, target, MoveSpeed * scale * dt);
                var lift = Normalize(next - ExactPosition, MoveSpeed * scale);
                lift.X *= .75f;
                MoveTo(next, lift);
                WindUpProgress = Clamp((VectorArithmetic.Distance(ExactPosition, target) - 16) / (2 - 16));
                if (IceMode && DistanceSquared(ExactPosition, target) <= 12) StartShaking(.1f);
                else if (!IceMode && WindUpProgress >= .5f) StartShaking(.1f);
                if (DistanceSquared(ExactPosition, target) <= 2)
                {
                    if (IceMode) Break();
                    else State = States.Bouncing;
                    MoveSpeed = 0;
                }
            }
            else if (State == States.Bouncing)
            {
                MoveSpeed = Approach(MoveSpeed, 140, 800 * dt);
                var target = StartPosition + BounceDirection * 24;
                var next = Approach(ExactPosition, target, MoveSpeed * dt);
                var lift = Normalize(next - ExactPosition, Extrema.Min(MoveSpeed * 3, 200));
                lift.X *= .75f;
                BounceLift = lift;
                MoveTo(next, lift);
                WindUpProgress = 1;
                if (ExactPosition == target || (!IceMode && WindUpPlayerCheck() == null))
                {
                    DebrisDirection = Normalize(target - StartPosition);
                    State = States.BounceEnd;
                    effects.Rumble(true);
                    MoveSpeed = 0;
                    BounceEndTimer = .05f;
                    ShakeOffPlayer(BounceLift);
                }
            }
            else if (State == States.BounceEnd)
            {
                BounceEndTimer -= dt;
                if (BounceEndTimer <= 0) Break();
            }
            else if (State == States.Broken)
            {
                Depth = 8990;
                Reformed = false;
                if (RespawnTimer > 0)
                {
                    RespawnTimer -= dt;
                    return;
                }

                var previous = Position;
                Position = StartPosition;
                if (!(CollideCheck(typeof(SourceActorEntityState)
                        .FullName) || CollideCheck("Celeste.Solid")))

                {
                    CheckMode();
                    effects.PlaySound(
                        IceMode ? "event:/game/09_core/iceblock_reappear" : "event:/game/09_core/bounceblock_reappear",
                        Center);
                    for (var x = 0; x < Width; x += 8)
                    for (var y = 0; y < Height; y += 8)
                    {
                        var to = Position + new Vector2(x + 4, y + 4);
                        ((ISourceScene)Scene).SourceScene.QueueSourceEntity(SourceWorld.EngineContext.EntityPools
                            .Create<BounceBlockRespawnDebrisState>()
                            .Init(to + Normalize(to - Center) * 12, to, IceMode, .35f));
                    }

                    SourceAlarmState.Set(SourceWorld.EngineContext.AlarmPool, OwnedComponents, .35f, () =>
                    {
                        Reformed = true;
                        ReappearFlash = .6f;
                        EnableStaticMovers();
                        ReformParticles();
                    });
                    Depth = -9000;
                    MoveStaticMovers(Position - previous);
                    Collidable = true;
                    State = States.Waiting;
                }
                else
                {
                    Position = previous;
                }
            }
        }

        public void Break()
        {
            if (!IceMode) effects.PlaySound("event:/game/09_core/bounceblock_break", Center);
            effects.Rumble(false);
            State = States.Broken;
            Collidable = false;
            DisableStaticMovers();
            RespawnTimer = 1.6f;
            var direction = IceMode ? Vector2.UnitY : DebrisDirection;
            var center = Center;
            for (var x = 0; x < Width; x += 8)
            for (var y = 0; y < Height; y += 8)
            {
                var at = Position + new Vector2(x + 4, y + 4);
                if (IceMode) direction = Normalize(at - center);
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(SourceWorld.EngineContext.EntityPools
                    .Create<BounceBlockBreakDebrisState>().Init(at, direction, IceMode));
            }

            var angle = Angle(DebrisDirection);
            for (var x = 0; x < Width; x += 4)
            for (var y = 0; y < Height; y += 4)
            {
                var at = Position + new Vector2(2 + x, 2 + y) + new Vector2(
                    -1 + 2 *
                    (float)((ISourceRandomEnvironment)SourceWorld.EngineContext).Random
                    .NextDouble(),
                    -1 + 2 *
                    (float)((ISourceRandomEnvironment)SourceWorld.EngineContext).Random
                    .NextDouble());
                effects.Emit(
                    IceMode
                        ? BounceBlockParticle.IceBreak
                        : BounceBlockParticle.FireBreak, at,
                    IceMode ? Angle(at - center) : angle);
            }
        }

        public void ReformParticles()
        {
            for (var x = 0; x < Width; x += 4)
            {
                effects.Emit(BounceBlockParticle.Reform,
                    new(
                        Position.X + 2 + x +
                        ((ISourceRandomEnvironment)SourceWorld.EngineContext).Random
                        .Next(-1, 1), Position.Y), -(float)Math.PI / 2);
                effects.Emit(BounceBlockParticle.Reform,
                    new(
                        Position.X + 2 + x +
                        ((ISourceRandomEnvironment)SourceWorld.EngineContext).Random
                        .Next(-1, 1), Bottom - 1f),
                    (float)Math.PI / 2);
            }

            for (var y = 0; y < Height; y += 4)
            {
                effects.Emit(BounceBlockParticle.Reform,
                    new(Position.X,
                        Position.Y + 2 + y +
                        ((ISourceRandomEnvironment)SourceWorld.EngineContext).Random
                        .Next(-1, 1)), (float)Math.PI);
                effects.Emit(BounceBlockParticle.Reform,
                    new(Right - 1f,
                        Position.Y + 2 + y +
                        ((ISourceRandomEnvironment)SourceWorld.EngineContext).Random
                        .Next(-1, 1)), 0);
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            var position = Position;
            Position += Shake;
            if (State != States.Broken && Reformed) base.Render(context);
            if (ReappearFlash > 0f)
            {
                float inverse = 1f - ReappearFlash, amount = 1f - inverse * inverse * inverse, pad = amount * 2f;
                SourcePrimitiveDrawing.Rect(context, this, X - pad, Y - pad, Width + pad * 2f, Height + pad * 2f,
                    PackedColor.White * amount);
            }

            Position = position;
        }

        private ISourceVectorArithmetic VectorArithmetic =>
            ((ISourceVectorEnvironment)SourceWorld.EngineContext).VectorArithmetic;

        private ISourceExtremaArithmetic Extrema =>
            ((ISourceExtremaEnvironment)SourceWorld.EngineContext)
            .ExtremaArithmetic;

        private float Approach(float value, float target, float amount)
        {
            return value > target ? Extrema.Max(value - amount, target) : Extrema.Min(value + amount, target);
        }

        private Vector2 Normalize(Vector2 value, float length = 1f)
        {
            return VectorArithmetic.SafeNormalize(value, length);
        }

        private Vector2 Approach(Vector2 value, Vector2 target, float maxMove)
        {
            return VectorArithmetic.Approach(value, target, maxMove);
        }

        private float DistanceSquared(Vector2 first, Vector2 second)
        {
            return VectorArithmetic.DistanceSquared(first, second);
        }

        private static float Clamp(float value)
        {
            value = value > 1f ? 1f : value;
            value = value < 0f ? 0f : value;
            return value;
        }

        internal static float Angle(Vector2 d)
        {
            return (float)Math.Atan2(d.Y, d.X);
        }
    }
}
