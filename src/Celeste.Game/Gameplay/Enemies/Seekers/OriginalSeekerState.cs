using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Core.Components;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Components.Shaking;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Player.Death;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState : SourceActorEntityState
    {
        private readonly IOriginalSeekerProcess engine;
        protected SimulationStateMachine CurrentStateMachine => State;
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

        private HitboxColliderGeometry physicsHitbox;

        private HitboxColliderGeometry breakWallsHitbox;

        private HitboxColliderGeometry attackHitbox;

        private HitboxColliderGeometry bounceHitbox;
        public HitboxColliderGeometry BounceHitbox => bounceHitbox;
        public HitboxColliderGeometry AttackHitbox => attackHitbox;

        private CircleColliderGeometry pushRadius;

        private CircleColliderGeometry breakWallsRadius;

        private SimulationStateMachine State;

        private Vector2 lastSpottedAt;

        private Vector2 lastPathTo;

        private bool spotted;

        private bool canSeePlayer;

        private global::Celeste.Physics.Collision.SourceCollisionHandler onCollideH;

        private global::Celeste.Physics.Collision.SourceCollisionHandler onCollideV;

        private ISourceRandom random;

        private Vector2 lastPosition;

        private ShakerComponentState shaker;

        private OscillationPulseState scaleWiggler;

        private bool lastPathFound;

        private List<Vector2> path;

        private int pathIndex;

        private Vector2[] patrolPoints;

        private SineWaveState idleSineX;

        private SineWaveState idleSineY;

        public VertexLightState Light;

        private bool dead;

        private SoundSourceComponentState boopedSfx;

        private SoundSourceComponentState aggroSfx;

        private SoundSourceComponentState reviveSfx;

        private Sprite sprite;

        private int facing = 1;

        private int spriteFacing = 1;

        private string nextSprite;

        private HoldableColliderState theo;

        private HashSet<string> flipAnimations = new HashSet<string> { "flipMouth", "flipEyes", "skid" };

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
                if (State.State == 3)
                {
                    return !attackWindUp;
                }

                return false;
            }
        }

        public bool Spotted
        {
            get
            {
                if (State.State != 3)
                {
                    return State.State == 2;
                }

                return true;
            }
        }

        public bool Regenerating => State.State == 6;

        private Vector2 FollowTarget => lastSpottedAt - Vector2.UnitY * 2f;

        public OriginalSeekerState(Vector2 position, Vector2[] patrolPoints, IOriginalSeekerProcess engine)
            : base(new PixelActor(null, position), engine, engine.TargetMotionPolicy)
        {
            this.engine = engine;
            base.Depth = -200;
            this.patrolPoints = patrolPoints;
            lastPosition = position;
            base.Collider = (physicsHitbox = new HitboxColliderGeometry(6f, 6f, -3f, -3f));
            breakWallsHitbox = new HitboxColliderGeometry(6f, 14f, -3f, -7f);
            attackHitbox = new HitboxColliderGeometry(12f, 8f, -6f, -2f);
            bounceHitbox = new HitboxColliderGeometry(16f, 6f, -8f, -8f);
            pushRadius = new CircleColliderGeometry(engine.VectorArithmetic, 40f);
            breakWallsRadius = new CircleColliderGeometry(engine.VectorArithmetic, 16f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnAttackPlayer, attackHitbox));
            OwnedComponents.Add(new PlayerColliderComponentState(OnBouncePlayer, bounceHitbox));
            OwnedComponents.Add(shaker = new ShakerComponentState(engine, on: false));
            OwnedComponents.Add(State = ((ISourceStateMachineEnvironment)engine).StateMachines.Create(engine));
            State.SetCallbacks(0, IdleUpdate, IdleCoroutine);
            State.SetCallbacks(1, PatrolUpdate, null, PatrolBegin);
            State.SetCallbacks(2, SpottedUpdate, SpottedCoroutine, SpottedBegin);
            State.SetCallbacks(3, AttackUpdate, AttackCoroutine, AttackBegin);
            State.SetCallbacks(4, StunnedUpdate, StunnedCoroutine);
            State.SetCallbacks(5, SkiddingUpdate, SkiddingCoroutine, SkiddingBegin, SkiddingEnd);
            State.SetCallbacks(6, RegenerateUpdate, RegenerateCoroutine, RegenerateBegin, RegenerateEnd);
            State.SetCallbacks(7, null, ReturnedCoroutine);
            onCollideH = OnCollideH;
            onCollideV = OnCollideV;
            OwnedComponents.Add(idleSineX = new SineWaveState(engine, 0.5f));
            OwnedComponents.Add(idleSineY = new SineWaveState(engine, 0.7f));
            OwnedComponents.Add(Light = new VertexLightState(engine, Vector2.Zero, PackedColor.White, 1f, 32, 64));
            OwnedComponents.Add(theo = new HoldableColliderState(OnHoldable, attackHitbox));
            OwnedComponents.Add(new MirrorReflectionState());
            path = new List<Vector2>();
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
                    SceneEntityState entity = new SceneEntityState(
                        ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                        .EntitySourceDataRegistration, Position);
                    DeathEffect component =
                        new DeathEffect(new PackedColor(255, 105, 180, 255), engine, base.Center - Position)
                        {
                            OnEnd = delegate { entity.RemoveSelf(); }
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
            engine.SeekerFactory.AfterOriginalConstructor(this, State);
        }
    }
}
