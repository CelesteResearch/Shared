using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Components.Shaking;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Player.Death;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState : SourceActorEntityState
    {
        private readonly IOriginalSeekerProcess engine;
        protected SimulationStateMachine CurrentStateMachine { get; }

        private const int StIdle = 0;

        private const int StPatrol = 1;

        private const int StSpotted = 2;

        private const int StAttack = 3;

        private const int StStunned = 4;

        private const int StSkidding = 5;

        private const int StRegenerate = 6;

        private const int StReturned = 7;

        private const int size = 12;

        private const int bounceWidth = 16;

        private const int bounceHeight = 4;

        private const float Accel = 600f;

        private const float WallCollideStunThreshold = 100f;

        private const float StunXSpeed = 100f;

        private const float BounceSpeed = 200f;

        private const float SightDistSq = 25600f;

        private const float ExplodeRadius = 40f;

        private readonly HitboxColliderGeometry physicsHitbox;

        private readonly HitboxColliderGeometry breakWallsHitbox;

        public HitboxColliderGeometry BounceHitbox { get; }

        public HitboxColliderGeometry AttackHitbox { get; }

        private readonly CircleColliderGeometry pushRadius;

        private CircleColliderGeometry breakWallsRadius;

        private Vector2 lastSpottedAt;

        private Vector2 lastPathTo;

        private bool spotted;

        private bool canSeePlayer;

        private readonly SourceCollisionHandler onCollideH;

        private readonly SourceCollisionHandler onCollideV;

        private ISourceRandom random;

        private Vector2 lastPosition;

        private readonly ShakerComponentState shaker;

        private readonly OscillationPulseState scaleWiggler;

        private bool lastPathFound;

        private List<Vector2> path;

        private int pathIndex;

        private readonly Vector2[] patrolPoints;

        private readonly SineWaveState idleSineX;

        private readonly SineWaveState idleSineY;

        public VertexLightState Light;

        private bool dead;

        private readonly SoundSourceComponentState boopedSfx;

        private readonly SoundSourceComponentState aggroSfx;

        private readonly SoundSourceComponentState reviveSfx;

        private readonly Sprite sprite;

        private int facing = 1;

        private int spriteFacing = 1;

        private string nextSprite;

        private readonly HoldableColliderState theo;

        private readonly HashSet<string> flipAnimations = ["flipMouth", "flipEyes", "skid"];

        public Vector2 Speed;

        private const float FarDistSq = 12544f;

        private const float IdleAccel = 200f;

        private const float IdleSpeed = 50f;

        private const float PatrolSpeed = 25f;

        private const int PatrolChoices = 3;

        private const float PatrolWaitTime = 0.4f;

        private float patrolWaitTimer;

        private const float SpottedTargetSpeed = 60f;

        private const float SpottedFarSpeed = 90f;

        private const float SpottedMaxYDist = 24f;

        private const float AttackMinXDist = 16f;

        private const float SpottedLosePlayerTime = 0.6f;

        private const float SpottedMinAttackTime = 0.2f;

        private float spottedLosePlayerTimer;

        private float spottedTurnDelay;

        private const float AttackWindUpSpeed = -60f;

        private const float AttackWindUpTime = 0.3f;

        private const float AttackStartSpeed = 180f;

        private const float AttackTargetSpeed = 260f;

        private const float AttackAccel = 300f;

        private const float DirectionDotThreshold = 0.4f;

        private const int AttackTargetUpShift = 2;

        private const float AttackMaxRotateRadians = 0.61086524f;

        private float attackSpeed;

        private bool attackWindUp;

        private const float StunnedAccel = 150f;

        private const float StunTime = 0.8f;

        private const float SkiddingAccel = 200f;

        private const float StrongSkiddingAccel = 400f;

        private const float StrongSkiddingTime = 0.08f;

        private bool strongSkid;

        public bool Attacking
        {
            get
            {
                if (CurrentStateMachine.State == 3) return !attackWindUp;

                return false;
            }
        }

        public bool Spotted
        {
            get
            {
                if (CurrentStateMachine.State != 3) return CurrentStateMachine.State == 2;

                return true;
            }
        }

        public bool Regenerating => CurrentStateMachine.State == 6;

        private Vector2 FollowTarget => lastSpottedAt - Vector2.UnitY * 2f;

        public OriginalSeekerState(Vector2 position, Vector2[] patrolPoints, IOriginalSeekerProcess engine)
            : base(new(null, position), engine, engine.TargetMotionPolicy)
        {
            this.engine = engine;
            Depth = -200;
            this.patrolPoints = patrolPoints;
            lastPosition = position;
            Collider = physicsHitbox = new(6f, 6f, -3f, -3f);
            breakWallsHitbox = new(6f, 14f, -3f, -7f);
            AttackHitbox = new(12f, 8f, -6f, -2f);
            BounceHitbox = new(16f, 6f, -8f, -8f);
            pushRadius = new(engine.VectorArithmetic, 40f);
            breakWallsRadius = new(engine.VectorArithmetic, 16f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnAttackPlayer, AttackHitbox));
            OwnedComponents.Add(new PlayerColliderComponentState(OnBouncePlayer, BounceHitbox));
            OwnedComponents.Add(shaker = new(engine, false));
            OwnedComponents.Add(CurrentStateMachine =
                ((ISourceStateMachineEnvironment)engine).StateMachines.Create(engine));
            CurrentStateMachine.SetCallbacks(0, IdleUpdate, IdleCoroutine);
            CurrentStateMachine.SetCallbacks(1, PatrolUpdate, null, PatrolBegin);
            CurrentStateMachine.SetCallbacks(2, SpottedUpdate, SpottedCoroutine, SpottedBegin);
            CurrentStateMachine.SetCallbacks(3, AttackUpdate, AttackCoroutine, AttackBegin);
            CurrentStateMachine.SetCallbacks(4, StunnedUpdate, StunnedCoroutine);
            CurrentStateMachine.SetCallbacks(5, SkiddingUpdate, SkiddingCoroutine, SkiddingBegin, SkiddingEnd);
            CurrentStateMachine.SetCallbacks(6, RegenerateUpdate, RegenerateCoroutine, RegenerateBegin, RegenerateEnd);
            CurrentStateMachine.SetCallbacks(7, null, ReturnedCoroutine);
            onCollideH = OnCollideH;
            onCollideV = OnCollideV;
            OwnedComponents.Add(idleSineX = new(engine, 0.5f));
            OwnedComponents.Add(idleSineY = new(engine, 0.7f));
            OwnedComponents.Add(Light = new(engine, Vector2.Zero, PackedColor.White, 1f, 32, 64));
            OwnedComponents.Add(theo = new(OnHoldable, AttackHitbox));
            OwnedComponents.Add(new MirrorReflectionState());
            path = [];
            IgnoreJumpThrus = true;
            OwnedComponents.Add(sprite = engine.GameGraphics.SpriteFactory.Create("seeker"));
            sprite.OnLastFrame = delegate(string f)
            {
                if (flipAnimations.Contains(f) && spriteFacing != facing)
                {
                    spriteFacing = facing;
                    if (nextSprite != null)
                    {
                        sprite.Play(nextSprite);
                        nextSprite = null;
                    }
                }
            };
            sprite.OnChange = delegate(string last, string next)
            {
                nextSprite = null;
                sprite.OnLastFrame(last);
            };
            SquishCallback = delegate(PixelCollision d)
            {
                if (!dead && !TrySquishWiggle(d))
                {
                    var entity = new SceneEntityState(
                        ((ISourceEntitySourceDataEnvironment)engine)
                        .EntitySourceDataRegistration, Position);
                    var component =
                        new DeathEffect(new(255, 105, 180, 255), engine, Center - Position)
                        {
                            OnEnd = delegate { entity.RemoveSelf(); },
                        };
                    entity.OwnedComponents.Add(component);
                    entity.Depth = -1000000;
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(entity);
                    engine.SpatialAudio.Play("event:/game/05_mirror_temple/seeker_death", Position);
                    RemoveSelf();
                    dead = true;
                }
            };
            scaleWiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.8f, 2f);
            OwnedComponents.Add(scaleWiggler);
            OwnedComponents.Add(boopedSfx = engine.SoundSources.Create());
            OwnedComponents.Add(aggroSfx = engine.SoundSources.Create());
            OwnedComponents.Add(reviveSfx = engine.SoundSources.Create());
            engine.SeekerFactory.AfterOriginalConstructor(this, CurrentStateMachine);
        }
    }
}
