using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Input.Gameplay;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.MoveBlock;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Gameplay.Platforms.MoveBlocks
{
    public abstract class MovingBlockState : SourceSolidEntityState
    {
        public const float OccluderAlpha = .5f;
        public static readonly PackedColor IdleColor = new(71, 64, 112, 255);
        public static readonly PackedColor MovingColor = new(48, 179, 53, 255);
        public static readonly PackedColor BreakingColor = new(204, 37, 65, 255);
        private const float Pi = (float)Math.PI;
        private const string SoundPrefix = "event:/game/04_cliffside/arrowblock_";
        private float dt => SourceWorld.EngineContext.DeltaTime;
        protected RoomPlayerSession noSquish;
        public MoveBlockDirection Direction;
        public readonly bool CanSteer, Fast;
        public readonly Vector2 StartPosition;
        public float HomeAngle;
        public readonly int AngleSteerSign;

        public MoveBlockMovementState State { get; private set; }

        public bool Triggered { get; protected set; }
        public new float Speed { get; set; }
        public float TargetSpeed { get; set; }
        public float Angle { get; set; }
        public float TargetAngle { get; set; }
        public float Flash { get; private set; }
        public float ParticleRemainder { get; private set; }
        public PackedColor FillColor { get; private set; } = IdleColor;
        public bool LeftPressed { get; private set; }
        public bool RightPressed { get; private set; }
        public bool TopPressed { get; private set; }
        protected readonly List<SpriteImage> body = [], topButton = [], leftButton = [], rightButton = [];
        protected readonly List<AtlasEntry> arrows;

        private AtlasData GameAtlas =>
            ((ISourceGameGraphicsEnvironment)SourceWorld.EngineContext).GameGraphics.GameAtlas;

        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        protected readonly SoundSourceComponentState moveSfx;
        protected MovingBlockBorderState border;
        private readonly MoveBlockVisuals visuals;

        protected bool Horizontal =>
            Direction == MoveBlockDirection.Left || Direction ==
            MoveBlockDirection.Right;

        protected MovingBlockState(EntityData data, Vector2 offset, ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, data.Width, data.Height,
                EntityAttributeReader.Enum(data.Values, "direction", MoveBlockDirection.Left),
                EntityAttributeReader.Bool(data.Values, "canSteer", true),
                EntityAttributeReader.Bool(data.Values, "fast"),
                worlds.Create(data.Position + offset, false))
        {
        }

        protected MovingBlockState(Vector2 position, int width, int height, MoveBlockDirection direction,
            bool canSteer, bool fast, ISourceSolidWorld world)
            : this(position, width, height, direction, canSteer, fast, world, MoveBlockVisuals.Default)
        {
        }

        protected MovingBlockState(Vector2 position, int width, int height, MoveBlockDirection direction,
            bool canSteer, bool fast, ISourceSolidWorld world, MoveBlockVisuals visuals)
            : base(position, width, height, false, world)
        {
            this.visuals = visuals;
            FillColor = visuals.InitialFillColor;
            Depth = visuals.Depth;
            StartPosition = position;
            CanSteer = canSteer;
            Direction = direction;
            Fast = fast;
            HomeAngle = direction == MoveBlockDirection.Left ? Pi :
                direction == MoveBlockDirection.Up ? -Pi / 2f :
                direction == MoveBlockDirection.Down ? Pi / 2f : 0f;
            Angle = TargetAngle = HomeAngle;
            AngleSteerSign = direction == MoveBlockDirection.Left || direction == MoveBlockDirection.Down ? -1 : 1;
            int columns = width / 8, rows = height / 8;
            var atlas = GameAtlas;
            var texture = atlas[visuals.SpritePath + "/base"];
            var button = atlas[visuals.SpritePath + "/button"];
            if (canSteer && (direction == MoveBlockDirection.Left || direction == MoveBlockDirection.Right))
            {
                for (var x = 0; x < columns; x++)
                    AddImage(button.GetSubtexture(Section(x, columns) * 8, 0, 8, 8), new(x * 8, -4f), 0f,
                        Vector2.One, topButton);
                texture = atlas[visuals.SpritePath + "/base_h"];
            }
            else if (canSteer && (direction == MoveBlockDirection.Up || direction == MoveBlockDirection.Down))
            {
                for (var y = 0; y < rows; y++)
                {
                    AddImage(button.GetSubtexture(Section(y, rows) * 8, 0, 8, 8), new(-4f, y * 8), Pi / 2f,
                        new(1f, -1f), leftButton);
                    AddImage(button.GetSubtexture(Section(y, rows) * 8, 0, 8, 8),
                        new((columns - 1) * 8 + 4, y * 8), Pi / 2f, Vector2.One, rightButton);
                }

                texture = atlas[visuals.SpritePath + "/base_v"];
            }

            for (var x = 0; x < columns; x++)
            for (var y = 0; y < rows; y++)
                AddImage(texture.GetSubtexture(Section(x, columns) * 8, Section(y, rows) * 8, 8, 8),
                    new Vector2(x, y) * 8f, 0f, Vector2.One, body);
            arrows = atlas.GetAtlasSubtextures(visuals.SpritePath + "/arrow");
            moveSfx = ((ISourceSoundSourceEnvironment)SourceWorld.EngineContext).SoundSources.Create();
            OwnedComponents.Add(moveSfx);
            OwnedComponents.Add(new SimulationCoroutine(SourceWorld.EngineContext, ControllerRoutine()));
            UpdateColors();
            OwnedComponents.Add(new LightOccludeState(.5f));
        }

        private static int Section(int at, int count)
        {
            return at != 0 ? at < count - 1 ? 1 : 2 : 0;
        }

        private void AddImage(AtlasEntry texture, Vector2 position, float rotation, Vector2 scale,
            List<SpriteImage> addTo)
        {
            var image = new SpriteImage(texture)
                { Position = position + new Vector2(4f, 4f), Rotation = rotation, Scale = scale };
            image.CenterOrigin();
            OwnedComponents.Add(image);
            addTo?.Add(image);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            border = CreateBorder(
                ((ISourceEntitySourceDataEnvironment)SourceWorld.EngineContext)
                .EntitySourceDataRegistration);
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(border);
        }

        public override void OnStaticMoverTrigger(SourceStaticMoverState mover)
        {
            Triggered = true;
        }

        // Invoke after Platform.Update and Solid.Update, never before Controller.
        public override void Update()
        {
            base.Update();
            if (CanSteer)
            {
                var left = !Horizontal && CollidePlayerAt(Position + new Vector2(-1, 0));
                var right = !Horizontal && CollidePlayerAt(Position + new Vector2(1, 0));
                var top = Horizontal && CollidePlayerAt(Position + new Vector2(0, -1));
                foreach (var image in topButton) image.Position.Y = top ? 2f : 0f;
                foreach (var image in leftButton) image.Position.X = left ? 2f : 0f;
                foreach (var image in rightButton) image.Position.X = Width + (right ? -2f : 0f);
                if ((left && !LeftPressed) || (top && !TopPressed) || (right && !RightPressed))
                    ((ISourceSpatialAudioEnvironment)SourceWorld.EngineContext).SpatialAudio.Play(
                        SoundPrefix + "side_depress", Position);
                if ((!left && LeftPressed) || (!top && TopPressed) || (!right && RightPressed))
                    ((ISourceSpatialAudioEnvironment)SourceWorld.EngineContext).SpatialAudio.Play(
                        SoundPrefix + "side_release", Position);
                LeftPressed = left;
                RightPressed = right;
                TopPressed = top;
            }

            if (moveSfx.Playing)
            {
                var normal = Vector2Geometry.AngleToVector(Angle, 1) * new Vector2(-1, 1);
                var index = (int)Math.Floor(
                    (-(float)Math.Atan2(normal.Y, normal.X) + Pi * 2) % (Pi * 2) / (Pi * 2) * 8 + .5f);
                moveSfx.Param("arrow_influence", index + 1);
            }

            border.Visible = Visible;
            Flash = ScalarMath.Approach(Flash, 0, dt * 5,
                ((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic);
            UpdateColors();
        }

        private void UpdateColors()
        {
            FillColor = SourceColorInterpolation.Lerp(FillColor,
                State == MoveBlockMovementState.Breaking
                    ? visuals.BreakingColor
                    : State == MoveBlockMovementState.Moving
                        ? visuals.MovingColor
                        : visuals.IdleColor, 10 * dt,
                ((ISourceScalarEnvironment)SourceWorld.EngineContext).ScalarArithmetic);
            foreach (var image in topButton) image.Color = FillColor;
            foreach (var image in leftButton) image.Color = FillColor;
            foreach (var image in rightButton) image.Color = FillColor;
        }

        public override void MoveHExact(int move)
        {
            if (noSquish != null && ((move < 0 && noSquish.Position.X < Position.X) ||
                                     (move > 0 && noSquish.Position.X > Position.X)))
                while (move != 0 && noSquish.Body.CollideSolidAt(noSquish.Position + Vector2.UnitX * move))
                    move -= Math.Sign(move);
            base.MoveHExact(move);
        }

        public override void MoveVExact(int move)
        {
            if (noSquish != null && move < 0 && noSquish.Position.Y <= Position.Y)
                while (move != 0 && noSquish.Body.CollideSolidAt(noSquish.Position + Vector2.UnitY * move))
                    move -= Math.Sign(move);
            base.MoveVExact(move);
        }

        public virtual bool MoveCheck(Vector2 amount)
        {
            var horizontal = amount.X != 0;
            if (!horizontal && amount.Y == 0) return false;
            var value = horizontal ? amount.X : amount.Y;
            if (!(horizontal ? MoveHCollideSolids(value, false) : MoveVCollideSolids(value, false))) return false;
            for (var offset = 1; offset <= 3; offset++)
            for (var sign = 1; sign >= -1; sign -= 2)
                if (!CollideSolidAt(Position + (horizontal
                        ? new(Math.Sign(value), offset * sign)
                        : new Vector2(offset * sign, Math.Sign(value)))))
                {
                    if (horizontal)
                    {
                        MoveVExact(offset * sign);
                        MoveHExact(Math.Sign(value));
                    }
                    else
                    {
                        MoveHExact(offset * sign);
                        MoveVExact(Math.Sign(value));
                    }

                    return false;
                }

            return true;
        }

        public virtual IEnumerator ControllerRoutine()
        {
            return ControllerCore(ControllerEntry.Normal);
        }

        public IEnumerator ResumeMovementController()
        {
            return ControllerCore(ControllerEntry.AfterMovementYield);
        }

        public IEnumerator ResumeBreakingController()
        {
            return ControllerCore(ControllerEntry.AfterBreakShake);
        }

        public SoundSourceComponentState MovementSound => moveSfx;
        public ISourceEngineContext EngineContext => SourceWorld.EngineContext;

        private enum ControllerEntry
        {
            Normal,
            AfterMovementYield,
            AfterBreakShake,
        }

        private IEnumerator ControllerCore(ControllerEntry entry)
        {
            while (true)
            {
                // New original iterators resumed at a suspended yield have zero-initialized locals.
                float crash = 0f, crashReset = 0f, noSteer = 0f;
                if (entry == ControllerEntry.AfterBreakShake)
                {
                    entry = ControllerEntry.Normal;
                    goto AfterBreakShake;
                }

                if (entry == ControllerEntry.AfterMovementYield)
                {
                    entry = ControllerEntry.Normal;
                    goto MovementLoop;
                }

                Triggered = false;
                State = MoveBlockMovementState.Idling;
                while (!Triggered && !CanActivateFromRider()) yield return null;
                OnActivated();
                ((ISourceSpatialAudioEnvironment)SourceWorld.EngineContext).SpatialAudio.Play(SoundPrefix + "activate",
                    Position);
                State = MoveBlockMovementState.Moving;
                StartShaking(.2f);
                ActivateParticles();
                yield return .2f;
                TargetSpeed = MovementSpeed;
                moveSfx.Play(SoundPrefix + "move");
                moveSfx.Param("arrow_stop", 0);
                StopPlayerRunIntoAnimation = false;
                crash = .15f;
                crashReset = .1f;
                noSteer = .2f;
                MovementLoop:
                while (true)
                {
                    if (CanSteer)
                    {
                        TargetAngle = HomeAngle;
                        var riding = GetSteeringRider();
                        if (riding && noSteer > 0) noSteer -= dt;
                        if (riding)
                        {
                            if (noSteer <= 0)
                                TargetAngle = HomeAngle +
                                              Pi / 4 * AngleSteerSign * (Horizontal
                                                  ? ((ISourceGameInputEnvironment)SourceWorld.EngineContext).Input.MoveY
                                                  .Value
                                                  : ((ISourceGameInputEnvironment)SourceWorld.EngineContext).Input.MoveX
                                                  .Value);
                        }
                        else
                        {
                            noSteer = .2f;
                        }
                    }

                    if (OnInterval(.02f)) MoveParticles();
                    Speed = ScalarMath.Approach(Speed, TargetSpeed, 300 * dt,
                        ((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic);
                    Angle = ScalarMath.Approach(Angle, TargetAngle, Pi * 16 * dt,
                        ((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic);
                    Vector2 velocity = Vector2Geometry.AngleToVector(Angle, Speed), amount = velocity * dt;
                    bool blocked;
                    if (Horizontal)
                    {
                        blocked = MoveCheck(new(amount.X, 0));
                        noSquish = FirstPlayer;
                        MoveVCollideSolids(amount.Y, false);
                        noSquish = null;
                        LiftSpeed = velocity;
                        if (OnInterval(.03f) && amount.Y != 0)
                            ScrapeParticles(Vector2.UnitY * Math.Sign(amount.Y));
                    }
                    else
                    {
                        blocked = MoveCheck(new(0, amount.Y));
                        noSquish = FirstPlayer;
                        MoveHCollideSolids(amount.X, false);
                        noSquish = null;
                        LiftSpeed = velocity;
                        if (OnInterval(.03f) && amount.X != 0)
                            ScrapeParticles(Vector2.UnitX * Math.Sign(amount.X));
                        if (Direction == MoveBlockDirection
                                .Down &&
                            Top > Level.Bounds.Bottom + 32) blocked = true;
                    }

                    if (blocked)
                    {
                        moveSfx.Param("arrow_stop", 1);
                        crashReset = .1f;
                        if (!(crash > 0)) break;
                        crash -= dt;
                    }
                    else
                    {
                        moveSfx.Param("arrow_stop", 0);
                        if (crashReset > 0) crashReset -= dt;
                        else crash = .15f;
                    }

                    if (Left < Level.Bounds.Left || Top < Level.Bounds.Top ||
                        Right > Level.Bounds.Right) break;
                    yield return null;
                }

                ((ISourceSpatialAudioEnvironment)SourceWorld.EngineContext).SpatialAudio.Play(SoundPrefix + "break",
                    Position);
                moveSfx.Stop();
                State = MoveBlockMovementState.Breaking;
                Speed = TargetSpeed = 0;
                Angle = TargetAngle = HomeAngle;
                StartShaking(.2f);
                StopPlayerRunIntoAnimation = true;
                yield return .2f;
                AfterBreakShake:
                BreakParticles();
                var debris = new List<MovingBlockDebrisState>();
                for (var x = 0; x < Width; x += 8)
                for (var y = 0; y < Height; y += 8)
                {
                    var offset = new Vector2(x + 4f, y + 4f);
                    var item = CreateDebris(Position + offset, Center, StartPosition + offset);
                    debris.Add(item);
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(item);
                }

                MoveStaticMovers(StartPosition - Position);
                DisableStaticMovers();
                Position = StartPosition;
                Collidable = false;
                Visible = false;
                yield return 2.2f;
                foreach (var item in debris) item.StopMoving();
                while (IsReformBlocked())
                    yield return null;
                Collidable = true;
                var sound =
                    ((ISourceSpatialAudioEnvironment)SourceWorld.EngineContext).SpatialAudio.Play(
                        SoundPrefix + "reform_begin", debris[0].Position);
                var follower =
                    new SimulationCoroutine(SourceWorld.EngineContext,
                        SoundFollowsDebrisCenter(sound, debris));
                OwnedComponents.Add(follower);
                foreach (var item in debris) item.StartShaking();
                yield return .2f;
                foreach (var item in debris) item.ReturnHome(.65f);
                yield return .6f;
                follower.RemoveSelf();
                foreach (var item in debris) item.RemoveSelf();
                ((ISourceSpatialAudioEnvironment)SourceWorld.EngineContext).SpatialAudio.Play(SoundPrefix + "reappear",
                    Position);
                Visible = true;
                EnableStaticMovers();
                Speed = TargetSpeed = 0;
                Angle = TargetAngle = HomeAngle;
                noSquish = null;
                FillColor = visuals.IdleColor;
                UpdateColors();
                Flash = 1;
            }
        }

        protected virtual bool CanActivateFromRider()
        {
            return HasPlayerRider();
        }

        protected virtual void OnActivated()
        {
        }

        protected virtual float MovementSpeed => Fast ? 75 : 60;

        protected virtual bool GetSteeringRider()
        {
            return Horizontal ? HasPlayerOnTop() : HasPlayerClimbing();
        }

        protected abstract MovingBlockDebrisState CreateDebris(Vector2 position, Vector2 center, Vector2 home);

        protected abstract MovingBlockBorderState CreateBorder(
            ISourceEntitySourceDataRegistration registration);

        private bool IsReformBlocked()
        {
            return CollideAt(
                       typeof(SourceActorEntityState).FullName, Position)
                   || CollideAt("Celeste.Solid", Position);
        }

        public virtual IEnumerator SoundFollowsDebrisCenter(ISourceAudioEventReference sound,
            IReadOnlyList<MovingBlockDebrisState> debris)
        {
            while (true)
            {
                if (sound.PlaybackState == SourceAudioPlaybackState.Stopped) break;
                var center = Vector2.Zero;
                foreach (var item in debris) center += item.Position;
                center /= debris.Count;
                ((ISourceSpatialAudioEnvironment)SourceWorld.EngineContext).SpatialAudio.Position(sound, center);
                yield return null;
            }
        }

        public void ActivateParticles()
        {
            var vertical = !Horizontal;
            var left = (!CanSteer || !vertical) && !CollidePlayerAt(Position - Vector2.UnitX);
            var right = (!CanSteer || !vertical) && !CollidePlayerAt(Position + Vector2.UnitX);
            var top = (!CanSteer || vertical) && !CollidePlayerAt(Position - Vector2.UnitY);
            if (left)
                Emit(MoveBlockParticle.Activate,
                    (int)(Height / 2), new(Left, Center.Y),
                    Vector2.UnitY * (Height - 4) * .5f, Pi);
            if (right)
                Emit(MoveBlockParticle.Activate,
                    (int)(Height / 2), new(Right, Center.Y),
                    Vector2.UnitY * (Height - 4) * .5f, 0);
            if (top)
                Emit(MoveBlockParticle.Activate,
                    (int)(Width / 2), new(Center.X, Top),
                    Vector2.UnitX * (Width - 4) * .5f, -Pi / 2);
            Emit(MoveBlockParticle.Activate, (int)(Width / 2),
                new(Center.X, Bottom),
                Vector2.UnitX * (Width - 4) * .5f, Pi / 2);
        }

        public void BreakParticles()
        {
            var center = Center;
            for (var x = 0; x < Width; x += 4)
            for (var y = 0; y < Height; y += 4)
            {
                Vector2 at = Position + new Vector2(2 + x, 2 + y), difference = at - center;
                Emit(MoveBlockParticle.Break, 1, at,
                    Vector2.One * 2,
                    (float)Math.Atan2(difference.Y, difference.X));
            }
        }

        public void MoveParticles()
        {
            Vector2 at, range;
            float direction, amount;
            if (Direction == MoveBlockDirection.Right)
            {
                at = new Vector2(Left, Center.Y) + Vector2.UnitX;
                range = Vector2.UnitY * (Height - 4);
                direction = Pi;
                amount = Height / 32;
            }
            else if (Direction == MoveBlockDirection.Left)
            {
                at = new(Right, Center.Y);
                range = Vector2.UnitY * (Height - 4);
                direction = 0;
                amount = Height / 32;
            }
            else if (Direction == MoveBlockDirection.Down)
            {
                at = new Vector2(Center.X, Top) + Vector2.UnitY;
                range = Vector2.UnitX * (Width - 4);
                direction = -Pi / 2;
                amount = Width / 32;
            }
            else
            {
                at = new(Center.X, Bottom);
                range = Vector2.UnitX * (Width - 4);
                direction = Pi / 2;
                amount = Width / 32;
            }

            ParticleRemainder += amount;
            var count = (int)ParticleRemainder;
            ParticleRemainder -= count;
            range *= .5f;
            if (count > 0)
                Emit(MoveBlockParticle.Move, count, at, range,
                    direction);
        }

        public void ScrapeParticles(Vector2 direction)
        {
            Collidable = false;
            if (direction.X != 0)
            {
                var x = direction.X > 0 ? Right : Left - 1;
                for (var y = 0; y < Height; y += 8)
                {
                    var at = new Vector2(x, Top + 4 + y);
                    if (SolidAt(at))
                        Emit(MoveBlockParticle.Scrape, 1, at,
                            Vector2.Zero, 0);
                }
            }
            else
            {
                var y = direction.Y > 0 ? Bottom : Top - 1;
                for (var x = 0; x < Width; x += 8)
                {
                    var at = new Vector2(Left + 4 + x, y);
                    if (SolidAt(at))
                        Emit(MoveBlockParticle.Scrape, 1, at,
                            Vector2.Zero, 0);
                }
            }

            Collidable = true;
        }

        protected virtual void Emit(MoveBlockParticle particle, int count, Vector2 position, Vector2 range,
            float direction)
        {
            var types = ((IOriginalGameplayProcess)SourceWorld.EngineContext).ParticleTypes;
            switch (particle)
            {
                case MoveBlockParticle.Activate:
                    Level.ParticlesBG.Emit(types.MoveBlock.P_Activate, count, position, range, direction);
                    break;
                case MoveBlockParticle.Move:
                    Level.ParticlesBG.Emit(types.MoveBlock.P_Move, count, position, range, direction);
                    break;
                case MoveBlockParticle.Break:
                    Level.Particles.Emit(types.MoveBlock.P_Break, count, position, range, direction);
                    break;
                case MoveBlockParticle.Scrape:
                    Level.ParticlesFG.Emit(types.ZipMover.P_Scrape, position);
                    break;
            }
        }

        private RoomPlayerSession FirstPlayer
            => ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                typeof(RoomPlayerSession).FullName);


        private bool CollidePlayerAt(Vector2 at)
        {
            return CollideCheck(typeof(RoomPlayerSession).FullName, at);
        }

        private bool CollideSolidAt(Vector2 at)
        {
            return CollideCheck("Celeste.Solid", at);
        }

        private bool CollideAt(string key, Vector2 at)
        {
            return CollideCheck(key, at);
        }

        private bool SolidAt(Vector2 point)
        {
            return SourceSceneCollision.FirstPoint<ISourceEntityCollider>(
                ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid", point) != null;
        }

        private bool OnInterval(float interval)
        {
            return ((ISourceScene)Scene).SourceScene.Clock.OnInterval(interval, SourceWorld.EngineContext);
        }

        public override void Render(ISourceRenderContext context)
        {
            var position = Position;
            Position += Shake;
            foreach (var image in leftButton) image.Render(context);
            foreach (var image in rightButton) image.Render(context);
            foreach (var image in topButton) image.Render(context);
            SourcePrimitiveDrawing.Rect(context, this, X + 3f, Y + 3f, Width - 6f, Height - 6f, FillColor);
            foreach (var image in body) image.Render(context);
            SourcePrimitiveDrawing.Rect(context, this, Center.X - 4f, Center.Y - 4f, 8f, 8f, FillColor);
            AtlasEntry icon;
            if (State != MoveBlockMovementState.Breaking)
            {
                var value = (int)Math.Floor((-Angle + Pi * 2f) % (Pi * 2f) / (Pi * 2f) * 8f + .5f);
                icon = arrows[Math.Max(0, Math.Min(value, 7))];
            }
            else
            {
                icon = GameAtlas[visuals.BrokenIconPath];
            }

            SourceAtlasDrawing.Draw(context, this, icon, Center, new Vector2(icon.FrameWidth, icon.FrameHeight) / 2f,
                PackedColor.White, Vector2.One);
            var amount = Flash * 4f;
            SourcePrimitiveDrawing.Rect(context, this, X - amount, Y - amount, Width + amount * 2f,
                Height + amount * 2f, PackedColor.White * Flash);
            Position = position;
        }
    }
}
