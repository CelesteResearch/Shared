using Celeste.Core.Display;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Execution.Levels;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Components.Shaking;
using Celeste.Scene.Entities;
using Celeste.Scene.Following;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Everest.Gameplay.Collectibles.Strawberries.Seeds
{
    [Celeste.Scene.Tracking.Attributes.SceneTracked(false)]
    [Celeste.Core.Reflection.Runtime.RuntimeTypeAlias("Celeste.Mod.Entities.GenericStrawberrySeed")]
    public class GenericStrawberrySeed : SceneEntityState,
        global::Celeste.Simulation.Gameplay.Collectibles.Strawberry.ISourceStrawberrySeedFollower
    {
        public static Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation P_Burst;
        public IStrawberrySeeded Strawberry;
        private Sprite sprite;
        private FollowerState follower;
        private WigglerComponent wiggler;
        private ISourcePlatformEntity attached;
        private SineWaveState sine;
        private SourceTweenState lightTween;
        private VertexLightState light;
        private BloomPointState bloom;
        private ShakerComponentState shaker;
        private int index;
        private Vector2 start;
        private RoomPlayerSession player;
        private IOriginalStrawberryScene level;
        private float canLoseTimer;
        private float loseTimer;
        private bool finished;
        private bool losing;
        private bool ghost;
        private readonly IOriginalStrawberryProcess process;

        FollowerState global::Celeste.Simulation.Gameplay.Collectibles.Strawberry.ISourceStrawberrySeedFollower.
            Follower =>
            follower;

        public bool Collected => follower.HasLeader || finished;

        public GenericStrawberrySeed(IStrawberrySeeded strawberry,
            Vector2 position, int index, bool ghost, IOriginalStrawberryProcess process)
            : base(((ISourceEntitySourceDataEnvironment)process).EntitySourceDataRegistration, position)
        {
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            Position = position;
            Strawberry = strawberry;
            Depth = -100;
            start = Position;
            Collider = new HitboxColliderGeometry(12f, 12f, -6f, -6f);
            this.index = index;
            this.ghost = ghost;
            follower = new FollowerState(process, OriginalSceneTags.Persistent,
                onGainLeader: OnGainLeader, onLoseLeader: OnLoseLeader);
            OwnedComponents.Add(follower);
            follower.FollowDelay = .2f;
            follower.PersistentFollow = false;
            OwnedComponents.Add(new SourceStaticMoverState
            {
                SolidChecker = solid => SourceEntityCollision.Check(solid, this),
                OnAttach = platform =>
                {
                    Depth = -1000000;
                    Collider = new HitboxColliderGeometry(24f, 24f, -12f, -12f);
                    attached = platform;
                    start = Position - platform.Position;
                }
            });
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            wiggler = process.WigglerPool.Create(.5f, 4f,
                value => sprite.Scale = Vector2.One * (1f + .2f * value));
            OwnedComponents.Add(wiggler);
            sine = new SineWaveState(process, .5f);
            sine.Randomize();
            OwnedComponents.Add(sine);
            shaker = new ShakerComponentState(process, false);
            OwnedComponents.Add(shaker);
            bloom = new BloomPointState(1f, 12f);
            OwnedComponents.Add(bloom);
            light = new VertexLightState(process, Vector2.Zero, global::Celeste.Core.Display.PackedColor.White, 1f,
                16, 24);
            OwnedComponents.Add(light);
            lightTween = light.CreatePulseTween(process);
            OwnedComponents.Add(lightTween);
            if (P_Burst == null) P_Burst = process.ParticleTypes.StrawberrySeed.P_Burst;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            level = (IOriginalStrawberryScene)scene;
            sprite = process.GameGraphics.SpriteFactory.Create(ghost ? "ghostberrySeed" :
                level.AreaMode == 2 ? "goldberrySeed" : "strawberrySeed");
            sprite.Position = new Vector2(sine.Value * 2f, sine.ValueOverTwo * 1f);
            OwnedComponents.Add(sprite);
            if (ghost) sprite.Color = global::Celeste.Core.Display.PackedColor.White * .8f;
            int count = level.SourceScene.Entities.GetTrackedEntities(typeof(GenericStrawberrySeed)).Count;
            float offset = 1f - (float)index / ((float)count + 1f);
            offset = .25f + offset * .75f;
            sprite.PlayOffset("idle", offset);
            sprite.OnFrameChange = _ =>
            {
                if (Visible && sprite.CurrentAnimationID == "idle" && sprite.CurrentAnimationFrame == 19)
                {
                    Play("event:/game/general/seed_pulse", index);
                    lightTween.Start();
                    level.AddStrawberryDisplacementBurst(Position, .6f, 8f, 20f, .2f);
                }
            };
            P_Burst.Color = sprite.Color;
        }

        public override void Update()
        {
            base.Update();
            if (!finished)
            {
                if (canLoseTimer > 0f) canLoseTimer -= process.DeltaTime;
                else if (follower.HasLeader && player.LoseShards) losing = true;
                if (losing)
                {
                    if (loseTimer <= 0f || player.Data.Motion.Normal.Speed.Y < 0f)
                    {
                        player.Leader.LoseFollower(follower);
                        losing = false;
                    }
                    else if (player.LoseShards) loseTimer -= process.DeltaTime;
                    else
                    {
                        loseTimer = .15f;
                        losing = false;
                    }
                }

                sprite.Position = new Vector2(sine.Value * 2f, sine.ValueOverTwo * 1f) + shaker.Value;
            }
            else
                light.Alpha = ScalarMath.Approach(light.Alpha, 0f, process.DeltaTime * 4f,
                    ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)process).ExtremaArithmetic);
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            Play("event:/game/general/seed_touch", index);
            this.player = player;
            player.Leader.GainFollower(follower);
            Collidable = false;
            Depth = -1000000;
            bool all = true;
            foreach (var seed in Strawberry.Seeds)
                if (!seed.follower.HasLeader)
                {
                    all = false;
                    break;
                }

            if (all)
                ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                    new GenericStrawberrySeedsCutsceneState(Strawberry, process));
        }

        private void OnGainLeader()
        {
            wiggler.Start();
            canLoseTimer = .25f;
            loseTimer = .15f;
        }

        private void OnLoseLeader()
        {
            if (!finished) OwnedComponents.Add(new SimulationCoroutine(process, ReturnRoutine()));
        }

        private IEnumerator ReturnRoutine()
        {
            Play("event:/game/general/seed_poof");
            Collidable = false;
            sprite.Scale = Vector2.One * 2f;
            yield return .05f;
            process.RumbleSession.Rumble(1, 1);
            EmitBurst(level.ParticlesForeground);
            Visible = false;
            yield return .3f + (float)index * .1f;
            Play("event:/game/general/seed_reappear", index);
            Position = start;
            if (attached != null) Position += attached.Position;
            shaker.ShakeFor(.4f, false);
            sprite.Scale = Vector2.One;
            Visible = true;
            Collidable = true;
            level.AddStrawberryDisplacementBurst(Position, .2f, 8f, 28f, .2f);
        }

        public void OnAllCollected()
        {
            finished = true;
            follower.Leader?.LoseFollower(follower);
            Depth = -2000002;
            Tags = OriginalSceneTags.FrozenUpdate;
            wiggler.Start();
        }

        public void StartSpinAnimation(Vector2 averagePos, Vector2 centerPos,
            float angleOffset, float time)
        {
            float spinLerp = 0f;
            Vector2 start = Position;
            sprite.Play("noFlash");
            var tween = SourceTweenState.Create(process.TweenPool,
                SourceTweenState.TweenMode.Oneshot, process.EasingArithmetic.CubeIn, time / 2f, true);
            tween.OnUpdate = t => spinLerp = t.Eased;
            OwnedComponents.Add(tween);
            tween = SourceTweenState.Create(process.TweenPool,
                SourceTweenState.TweenMode.Oneshot, process.EasingArithmetic.CubeInOut, time, true);
            tween.OnUpdate = t =>
            {
                float angle = (float)Math.PI / 2f + angleOffset -
                              process.ScalarArithmetic.Lerp(0f, 32.201324f, t.Eased);
                Vector2 value = Vector2Math.Lerp(averagePos, centerPos, spinLerp,
                    process.ScalarArithmetic) + Vector2Geometry.AngleToVector(angle, 25f);
                Position = Vector2Math.Lerp(start, value, spinLerp, process.ScalarArithmetic);
            };
            OwnedComponents.Add(tween);
        }

        public void StartCombineAnimation(Vector2 centerPos, float time,
            ParticleSystemPresentation particleSystem)
        {
            Vector2 position = Position;
            float startAngle = Vector2Geometry.Angle(centerPos, position);
            var tween = SourceTweenState.Create(process.TweenPool,
                SourceTweenState.TweenMode.Oneshot, process.EasingArithmetic.BigBackIn, time, true);
            tween.OnUpdate = t =>
            {
                float angle = process.ScalarArithmetic.Lerp(startAngle,
                    startAngle - (float)Math.PI * 2f, process.EasingArithmetic.CubeIn(t.Percent));
                float length = process.ScalarArithmetic.Lerp(25f, 0f, t.Eased);
                Position = centerPos + Vector2Geometry.AngleToVector(angle, length);
            };
            tween.OnComplete = _ =>
            {
                Visible = false;
                EmitBurst(particleSystem);
                RemoveSelf();
            };
            OwnedComponents.Add(tween);
        }

        private void EmitBurst(ParticleSystemPresentation particles)
        {
            for (int i = 0; i < 6; i++)
            {
                float angle = SourceRandomMath.NextFloat(process.SpriteRandom, (float)Math.PI * 2f);
                particles.Emit(P_Burst, 1,
                    Position + Vector2Geometry.AngleToVector(angle, 4f), Vector2.Zero, angle);
            }
        }

        private void Play(string sound, int? count = null)
        {
            if (count.HasValue)
                process.AudioSession.Play(sound, Position, process.SaveContext, "count", count.Value);
            else process.AudioSession.Play(sound, Position, process.SaveContext);
        }
    }
}
