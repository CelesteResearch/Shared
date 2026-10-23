using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Environment.Debris;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Game.Gameplay.Mechanisms.Switches;
using Celeste.Game.Gameplay.Walls.Breakable;
using Celeste.Game.Presentation.Effects.Explosions;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Riding;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation.Gameplay.Hazards.Puffer;
using Celeste.Simulation.Gameplay.Interaction.Springs;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Gameplay.Hazards.Puffer
{
    public partial class OriginalPufferState :
        SourceActorEntityState, ISourcePufferEntity
    {
        private ISourceEasingArithmetic EasingArithmetic
            => ((ISourceEasingEnvironment)
                sourceEngine).EasingArithmetic;

        private ISourceCurveArithmetic CurveArithmetic
            => ((ISourceCurveEnvironment)
                sourceEngine).CurveArithmetic;


        private enum States
        {
            Idle,
            Hit,
            Gone,
        }

        private const float RespawnTime = 2.5f;
        private const float RespawnMoveTime = .5f;
        private const float BounceSpeed = 200f;
        private const float ExplodeRadius = 40f;
        private const float DetectRadius = 32f;
        private const float StunnedAccel = 320f;
        private const float AlertedRadius = 60f;
        private const float CantExplodeTime = .5f;

        private readonly ISourceEngineContext sourceEngine;

        private ISourceRandom GameplayRandom =>
            ((ISourceRandomEnvironment)sourceEngine).Random;

        private OriginalLevelSceneRoot PufferScene =>
            (OriginalLevelSceneRoot)Scene;

        private readonly CircleColliderGeometry pushRadius;
        private readonly CircleColliderGeometry detectRadius;
        private CircleColliderGeometry breakWallsRadius;

        private RoomPlayerSession FirstPlayer
        {
            get
            {
                var entities =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                        typeof(RoomPlayerSession).FullName);

                return entities.Count == 0 ? null : (RoomPlayerSession)entities[0];
            }
        }

        private readonly Sprite sprite;
        protected SineWaveState PufferIdleSine { get; }

        protected Vector2 PufferFacing => facing;
        private readonly WigglerComponent bounceWiggler;
        private readonly WigglerComponent inflateWiggler;
        private States state;
        private readonly Vector2 startPosition;
        private Vector2 anchorPosition;
        private Vector2 lastSpeedPosition;
        private Vector2 lastSinePosition;
        private Vector2 hitSpeed;

        public Vector2 HitSpeed
        {
            get => hitSpeed;
            set => hitSpeed = value;
        }

        public void LaunchFromHit(Vector2 speed)
        {
            GotoHitSpeed(speed);
        }

        private float goneTimer;
        private float cannotHitTimer;
        private float alertTimer;
        private float cantExplodeTimer;
        private Vector2 scale;
        private SimpleCurve returnCurve;
        private Vector2 lastPlayerPos;
        private float playerAliveFade;
        private Vector2 facing = Vector2.One;
        private float eyeSpin;

        private SourceCollisionHandler onCollideV;
        private readonly SourceCollisionHandler onCollideH;

        public OriginalPufferState(PixelActor body, Vector2 position, bool faceRight,
            ISourceEngineContext engine,
            IPlatformTargetMotionPolicy targetMotionPolicy)
            : base(body, engine, targetMotionPolicy)
        {
            sourceEngine = engine;
            Position = position;
            Collider = new HitboxColliderGeometry(12f, 10f, -6f, -5f);
            OwnedComponents.Add(
                new PlayerColliderComponentState(
                    OnPlayer, new HitboxColliderGeometry(14f, 12f, -7f, -7f)));
            sprite = ((ISourceGameGraphicsEnvironment)engine).GameGraphics
                .SpriteFactory.Create("pufferFish");
            OwnedComponents.Add(sprite);
            sprite.Play("idle");
            if (!faceRight) facing.X = -1f;
            PufferIdleSine = new(engine, .5f);
            PufferIdleSine.Randomize();
            OwnedComponents.Add(PufferIdleSine);
            anchorPosition = Position;
            Position += new Vector2(PufferIdleSine.Value * 3f, PufferIdleSine.ValueOverTwo * 2f);
            state = States.Idle;
            startPosition = lastSinePosition = lastSpeedPosition = Position;
            pushRadius =
                new(
                    ((ISourceVectorEnvironment)engine).VectorArithmetic, 40f);
            detectRadius =
                new(
                    ((ISourceVectorEnvironment)engine).VectorArithmetic, 32f);
            breakWallsRadius =
                new(
                    ((ISourceVectorEnvironment)engine).VectorArithmetic, 16f);
            onCollideV = OnCollideV;
            onCollideH = OnCollideH;
            scale = Vector2.One;
            var pool = ((ISourceWigglerPoolScope)engine).WigglerPool;
            bounceWiggler = pool.Create(.6f, 2.5f, v => sprite.Rotation = v * 20f * ((float)Math.PI / 180f));
            OwnedComponents.Add(bounceWiggler);
            inflateWiggler = pool.Create(.6f, 2f);
            OwnedComponents.Add(inflateWiggler);
        }

        public override bool IsRiding(ISourceEntityCollider solid)
        {
            return false;
        }

        public override bool IsRiding(ISourceJumpThruCollider jumpThru)
        {
            return false;
        }

        private bool OnGroundAt(Vector2 at)
        {
            return OnGround(at);
        }

        protected override void OnSquish(PixelCollision collision)
        {
            Explode();
            GotoGone();
        }

        private void OnCollideH(PixelCollision collision)
        {
            hitSpeed.X *= -.8f;
        }

        private void OnCollideV(PixelCollision collision)
        {
            if (!(collision.Direction.Y > 0)) return;
            for (var i = -1; i <= 1; i += 2)
            for (var j = 1; j <= 2; j++)
            {
                var at = Position + Vector2.UnitX * j * i;
                if (!SourceSceneCollisionQueries.CheckAt(this,
                        ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                            "Celeste.Solid"), at) && !OnGroundAt(at))
                {
                    Position = at;
                    return;
                }
            }

            hitSpeed.Y *= -.2f;
        }

        private void GotoIdle()
        {
            if (state == States.Gone)
            {
                Position = startPosition;
                cantExplodeTimer = .5f;
                sprite.Play("recover");
                AudioPlay("event:/new_content/game/10_farewell/puffer_reform");
            }

            lastSinePosition = lastSpeedPosition = anchorPosition = Position;
            hitSpeed = Vector2.Zero;
            PufferIdleSine.Reset();
            state = States.Idle;
        }

        private void GotoHit(Vector2 from)
        {
            scale = new(1.2f, .8f);
            hitSpeed = Vector2.UnitY * 200;
            state = States.Hit;
            bounceWiggler.Start();
            Alert(true, false);
            AudioPlay("event:/new_content/game/10_farewell/puffer_boop");
        }

        private void GotoHitSpeed(Vector2 speed)
        {
            hitSpeed = speed;
            state = States.Hit;
        }

        private void GotoGone()
        {
            var control = Position + (startPosition - Position) * .5f;
            if (((ISourceVectorEnvironment)sourceEngine).VectorArithmetic
                .LengthSquared(startPosition - Position) > 100)
            {
                if (Math.Abs(Position.Y - startPosition.Y) > Math.Abs(Position.X - startPosition.X))
                {
                    if (Position.X > startPosition.X) control += Vector2.UnitX * -24;
                    else control += Vector2.UnitX * 24;
                }
                else if (Position.Y > startPosition.Y)
                {
                    control += Vector2.UnitY * -24;
                }
                else
                {
                    control += Vector2.UnitY * 24;
                }
            }

            returnCurve = new(Position, startPosition, control);
            Collidable = false;
            goneTimer = 2.5f;
            state = States.Gone;
        }

        private void Explode()
        {
            var previous = Collider;
            Collider = pushRadius;
            AudioPlay("event:/new_content/game/10_farewell/puffer_splode");
            sprite.Play("explode");
            var player =
                SourceTrackedEntityCollision.First<RoomPlayerSession>(
                    ((ISourceScene)Scene).SourceScene.Entities,
                    typeof(RoomPlayerSession).FullName, this);

            if (player != null && !(SourceSceneCollision.FirstLine<object>(
                    ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid",
                    Position, player.Center) != null))
                player.ExplodeLaunch(Position, false, true);
            var theo = SourceTrackedEntityCollision
                .First<TheoCrystalState>(
                    ((ISourceScene)Scene).SourceScene.Entities,
                    "Celeste.TheoCrystal", this);
            if (theo != null && !(SourceSceneCollision.FirstLine<object>(
                    ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid",
                    Position, theo.Center) != null))
                theo.ExplodeLaunch(Position);
            foreach (var tracked in ((ISourceScene)Scene).SourceScene.Entities
                     .GetTrackedEntities("Celeste.TempleCrackedBlock"))
            {
                var target =
                    (OriginalTempleCrackedBlockState)tracked;
                if (SourceEntityCollision.Check(this,
                        target))
                    target.Break(Position);
            }

            foreach (var tracked in ((ISourceScene)Scene).SourceScene.Entities
                     .GetTrackedEntities("Celeste.TouchSwitch"))
            {
                var target =
                    (OriginalTouchSwitchState)tracked;
                if (SourceEntityCollision.Check(this, target)) target.TurnOn();
            }

            foreach (var tracked in ((ISourceScene)Scene).SourceScene.Entities
                     .GetTrackedEntities("Celeste.FloatingDebris"))
            {
                var target =
                    (OriginalFloatingDebrisState)tracked;
                if (SourceEntityCollision.Check(this,
                        target))
                    target.OnExplode(Position);
            }

            Collider = previous;
            var level = PufferScene;
            level.Shake();
            PufferExplosionPresentation.Emit(level, sourceEngine,
                this);
        }

        public override void Update()
        {
            base.Update();
            eyeSpin = ScalarMath.Approach(eyeSpin, 0, sourceEngine.DeltaTime * 1.5f,
                ((ISourceExtremaEnvironment)sourceEngine).ExtremaArithmetic);
            scale = ((ISourceVectorEnvironment)sourceEngine).VectorArithmetic.Approach(
                scale, Vector2.One, 1 * sourceEngine.DeltaTime);
            if (cannotHitTimer > 0) cannotHitTimer -= sourceEngine.DeltaTime;
            if (state != States.Gone && cantExplodeTimer > 0) cantExplodeTimer -= sourceEngine.DeltaTime;
            if (alertTimer > 0) alertTimer -= sourceEngine.DeltaTime;
            var player = FirstPlayer;
            if (player == null)
            {
                playerAliveFade = ScalarMath.Approach(playerAliveFade, 0,
                    1 * sourceEngine.DeltaTime,
                    ((ISourceExtremaEnvironment)sourceEngine)
                    .ExtremaArithmetic);
            }
            else
            {
                playerAliveFade = ScalarMath.Approach(playerAliveFade, 1,
                    1 * sourceEngine.DeltaTime,
                    ((ISourceExtremaEnvironment)sourceEngine)
                    .ExtremaArithmetic);
                lastPlayerPos = player.Center;
            }

            switch (state)
            {
                case States.Idle:
                    if (Position != lastSinePosition) anchorPosition += Position - lastSinePosition;
                    var at = anchorPosition + new Vector2(PufferIdleSine.Value * 3, PufferIdleSine.ValueOverTwo * 2);
                    MoveToX(at.X);
                    MoveToY(at.Y);
                    lastSinePosition = Position;
                    if (ProximityExplodeCheck())
                    {
                        Explode();
                        GotoGone();
                        break;
                    }

                    if (AlertedCheck())
                    {
                        Alert(false, true);
                    }
                    else if (sprite.CurrentAnimationID == "alerted" && alertTimer <= 0)
                    {
                        AudioPlay("event:/new_content/game/10_farewell/puffer_shrink");
                        sprite.Play("unalert");
                    }

                    CheckPufferColliders();
                    break;
                case States.Hit:
                    lastSpeedPosition = Position;
                    MoveH(hitSpeed.X * sourceEngine.DeltaTime, onCollideH);
                    MoveV(hitSpeed.Y * sourceEngine.DeltaTime, OnCollideV);
                    anchorPosition = Position;
                    hitSpeed.X = ScalarMath.Approach(hitSpeed.X, 0,
                        150 * sourceEngine.DeltaTime,
                        ((ISourceExtremaEnvironment)sourceEngine)
                        .ExtremaArithmetic);
                    hitSpeed = ((ISourceVectorEnvironment)sourceEngine)
                        .VectorArithmetic.Approach(hitSpeed, Vector2.Zero, 320 * sourceEngine.DeltaTime);
                    if (ProximityExplodeCheck())
                    {
                        Explode();
                        GotoGone();
                        break;
                    }

                    if (Top >= PufferScene.Bounds.Bottom + 5)
                    {
                        sprite.Play("hidden");
                        GotoGone();
                        break;
                    }

                    CheckPufferColliders();
                    if (hitSpeed == Vector2.Zero)
                    {
                        Body.ZeroRemainderX();
                        Body.ZeroRemainderY();
                        GotoIdle();
                    }

                    break;
                case States.Gone:
                    var previous = goneTimer;
                    goneTimer -= sourceEngine.DeltaTime;
                    if (goneTimer <= .5f)
                    {
                        if (previous > .5f && returnCurve.GetLengthParametric(8, CurveArithmetic,
                                ((ISourceVectorEnvironment)sourceEngine)
                                .VectorArithmetic) > 8) AudioPlay("event:/new_content/game/10_farewell/puffer_return");
                        Position = returnCurve.GetPoint(
                            EasingArithmetic.CubeInOut(ScalarMath.ClampedMap(goneTimer, .5f, 0)), CurveArithmetic);
                    }

                    if (goneTimer <= 0)
                    {
                        Visible = Collidable = true;
                        GotoIdle();
                    }

                    break;
            }
        }

        private void CheckPufferColliders()
        {
            var components =
                ((ISourceScene)Scene).SourceScene.Components.GetTrackedComponents(
                    "Celeste.PufferCollider");
            foreach (var tracked in components)
                ((PufferColliderState)tracked).Check(this);
        }

        public bool HitSpring(ISourceSpringEntity spring)
        {
            switch (spring.Orientation)
            {
                default:
                    if (hitSpeed.Y >= 0)
                    {
                        GotoHitSpeed(224 * -Vector2.UnitY);
                        MoveTowardsX(spring.Center.X, 4f);
                        bounceWiggler.Start();
                        Alert(true, false);
                        return true;
                    }

                    return false;
                case SpringOrientation.WallLeft:
                    if (hitSpeed.X <= 60)
                    {
                        facing.X = 1f;
                        GotoHitSpeed(280 * Vector2.UnitX);
                        MoveTowardsY(spring.Center.Y, 4f);
                        bounceWiggler.Start();
                        Alert(true, false);
                        return true;
                    }

                    return false;
                case SpringOrientation.WallRight:
                    if (hitSpeed.X >= -60)
                    {
                        facing.X = -1f;
                        GotoHitSpeed(280 * -Vector2.UnitX);
                        MoveTowardsY(spring.Center.Y, 4f);
                        bounceWiggler.Start();
                        Alert(true, false);
                        return true;
                    }

                    return false;
            }
        }

        private bool ProximityExplodeCheck()
        {
            if (cantExplodeTimer > 0f) return false;
            var result = false;
            var previous = Collider;
            Collider = detectRadius;
            var player =
                SourceTrackedEntityCollision.First<RoomPlayerSession>(
                    ((ISourceScene)Scene).SourceScene.Entities,
                    typeof(RoomPlayerSession).FullName, this);

            if (player != null && player.Center.Y >= Position.Y + previous.Bottom - 4f &&
                !(SourceSceneCollision.FirstLine<object>(
                    ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid",
                    Position, player.Center) != null))
                result = true;
            Collider = previous;
            return result;
        }

        private bool AlertedCheck()
        {
            var player = FirstPlayer;
            return player != null &&
                   ((ISourceVectorEnvironment)sourceEngine).VectorArithmetic.Length(
                       player.Center - Center) < 60f;
        }

        private void Alert(bool restart, bool playSfx)
        {
            if (sprite.CurrentAnimationID == "idle")
            {
                if (playSfx) AudioPlay("event:/new_content/game/10_farewell/puffer_expand");
                sprite.Play("alert");
                inflateWiggler.Start();
            }
            else if (restart && playSfx)
            {
                AudioPlay("event:/new_content/game/10_farewell/puffer_expand");
            }

            alertTimer = 2;
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (state == States.Gone || !(cantExplodeTimer <= 0)) return;
            if (cannotHitTimer <= 0)
            {
                if (player.Bottom > lastSpeedPosition.Y + 3)
                {
                    Explode();
                    GotoGone();
                }
                else
                {
                    player.Bounce(Top);
                    GotoHit(player.Center);
                    MoveToX(anchorPosition.X);
                    PufferIdleSine.Reset();
                    anchorPosition = lastSinePosition = Position;
                    eyeSpin = 1;
                }
            }

            cannotHitTimer = .1f;
        }

        private void AudioPlay(string name)
        {
            var process = (IOriginalGameplayProcess)sourceEngine;
            process.AudioSession.Play(name, Position, process.SaveContext);
        }

        public override void Render(ISourceRenderContext context)
        {
            sprite.Scale = scale * (1 + inflateWiggler.Value * .4f);
            sprite.Scale *= facing;
            var outline =
                (sprite.CurrentAnimationID != "hidden" && sprite.CurrentAnimationID != "explode" &&
                 sprite.CurrentAnimationID != "recover") ||
                (sprite.CurrentAnimationID == "explode" && sprite.CurrentAnimationFrame <= 1) ||
                (sprite.CurrentAnimationID == "recover" && sprite.CurrentAnimationFrame >= 4);
            if (outline) sprite.DrawSimpleOutline(context);

            var fade = playerAliveFade * ScalarMath.ClampedMap(
                ((ISourceVectorEnvironment)sourceEngine).VectorArithmetic.Length(
                    Position - lastPlayerPos), 128, 96);
            if (fade > 0 && state != States.Gone)
            {
                var above = false;
                var player = lastPlayerPos;
                if (player.Y < Position.Y)
                {
                    player.Y = Position.Y - (player.Y - Position.Y) * .5f;
                    player.X += player.X - Position.X;
                    above = true;
                }

                var targetAngle = Vector2Geometry.Angle(player - Position);
                for (var i = 0; i < 28; i++)
                {
                    var offset =
                        (float)Math.Sin(((ISourceScene)Scene).SourceScene.Clock
                            .TimeActive * .5f) * .02f;
                    var angle = ScalarMath.Map(i / 28f + offset, 0f, 1f, -(float)Math.PI / 30f, 3.2463126f);
                    angle += bounceWiggler.Value * 20 * ((float)Math.PI / 180);
                    var direction = Vector2Geometry.AngleToVector(angle, 1);
                    var at = Position + direction * 32;
                    var amount = ScalarMath.ClampedMap(ScalarMath.AbsAngleDiff(angle, targetAngle),
                        (float)Math.PI / 2, .17453292f);
                    amount = EasingArithmetic.CubeOut(amount) * .8f * fade;
                    if (!(amount > 0)) continue;
                    var color = PackedColor.White * amount;
                    if (i == 0 || i == 27)
                    {
                        SourcePrimitiveDrawing.Line(context, this, at,
                            at - direction * 10f, color,
                            ((ISourceVectorEnvironment)sourceEngine).VectorArithmetic);
                        continue;
                    }

                    var wobble = direction *
                                 (float)Math.Sin(((ISourceScene)Scene).SourceScene.Clock
                                     .TimeActive * 2 + i * .6f);
                    if (i % 2 == 0) wobble *= -1;
                    at += wobble;
                    if (!above && ScalarMath.AbsAngleDiff(angle, targetAngle) <= .17453292f)
                        SourcePrimitiveDrawing.Line(context, this, at,
                            at - direction * 3f, color,
                            ((ISourceVectorEnvironment)sourceEngine).VectorArithmetic);
                    else
                        SourcePrimitiveDrawing.Rect(context, this, at.X, at.Y, 1f,
                            1f, color);
                }
            }

            base.Render(context);
            if (sprite.CurrentAnimationID == "alerted")
            {
                var eye = Position + new Vector2(3, facing.X < 0 ? -5 : -4) * sprite.Scale;
                var to = lastPlayerPos + new Vector2(0, -4);
                var direction =
                    Vector2Geometry.AngleToVector(
                        Vector2Geometry.Angle(eye, to) +
                        eyeSpin * ((float)Math.PI * 2) * 2, 1);
                var at = eye + new Vector2((float)Math.Round(direction.X),
                    (float)Math.Round(ScalarMath.ClampedMap(direction.Y, -1f, 1f, -1f, 2f)));
                SourcePrimitiveDrawing.Rect(context, this, at.X, at.Y, 1f, 1f,
                    PackedColor.Black);
            }

            sprite.Scale /= facing;
        }
    }
}
