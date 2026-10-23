using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Presentation.Hud.Tutorials.Birds;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Entities.Birds
{
    public partial class BirdNpcState : SourceActorEntityState
    {
        private OriginalBirdNpcWorld world;

        private OriginalLevelSceneRoot level;
        public Sprite Sprite;
        public VertexLightState Light;
        public Vector2 StartPosition;
        public int Facing = -1;
        public bool AutoFly;
        public MapEntityId EntityID;
        public bool FlyAwayUp = true;
        public float WaitForLightningPostDelay;
        public bool DisableFlapSfx;

        private SimulationCoroutine tutorialRoutine;

        private BirdNpcMode mode;

        private BirdTutorialGuiState gui;
        private readonly Vector2[] nodes;
        private SourceStaticMoverState staticMover;
        public ISourceEngineContext EngineContext { get; }

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public OriginalLevelSceneRoot Level => level;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public BirdNpcMode Mode => mode;
        public bool OnlyOnce { get; }

        public bool OnlyIfPlayerLeft { get; }

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public SimulationCoroutine TutorialRoutine => tutorialRoutine;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public BirdTutorialGuiState Tutorial => gui;
        public float DeltaTime => EngineContext.DeltaTime;

        public BirdNpcState(PixelActor body, ISourceEngineContext engine,
            IPlatformTargetMotionPolicy targetMotionPolicy, BirdNpcMode mode)
            : base(body, engine, targetMotionPolicy)
        {
            EngineContext = engine;
            Sprite = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory
                .Create("bird");
            OwnedComponents.Add(Sprite);
            Sprite.Scale.X = Facing;
            Sprite.UseRawDeltaTime = true;
            Sprite.OnFrameChange = OnFrameChange;
            Light = new(engine, new(0, -8),
                PackedColor.White, 1, 8, 32);
            OwnedComponents.Add(Light);
            StartPosition = Position;
            SetMode(mode);
        }

        protected BirdNpcState(OriginalLevelSceneRoot actualLevel, EntityData data,
            Vector2 offset, MapEntityId id)
            : this(new(
                    actualLevel
                        .PlatformWorld,
                    data.Position + offset), actualLevel.EngineContext,
                ((ISourcePlatformTargetMotionEnvironment)actualLevel.EngineContext).TargetMotionPolicy,
                EntityAttributeReader.Enum(data.Values, "mode", BirdNpcMode.None))
        {
            EntityID = id;
            nodes = data.NodesOffset(offset);
            OnlyOnce = EntityAttributeReader.Bool(data.Values, "onlyOnce");
            OnlyIfPlayerLeft = EntityAttributeReader.Bool(data.Values, "onlyIfPlayerLeft");
        }

        public static BirdNpcState CreateFromMapData(OriginalLevelSceneRoot actualLevel,
            EntityData data, Vector2 offset, MapEntityId id)
        {
            return new(actualLevel, data, offset, id);
        }

        public static BirdNpcState Create(OriginalLevelSceneRoot actualLevel, Vector2 position, BirdNpcMode mode)
        {
            var engine = actualLevel.EngineContext;
            return new(new(
                    actualLevel
                        .PlatformWorld, position),
                engine, ((ISourcePlatformTargetMotionEnvironment)engine).TargetMotionPolicy, mode);
        }

        private SimulationCoroutine AddCoroutine(IEnumerator routine)
        {
            var component = tutorialRoutine = new(EngineContext, routine);
            OwnedComponents.Add(component);
            return component;
        }

        public void AddExtraLight(VertexLightState light)
        {
            OwnedComponents.Add(light);
        }

        public void AddExtraBloom(BloomPointState bloom)
        {
            OwnedComponents.Add(bloom);
        }

        public void SetMode(BirdNpcMode value)
        {
            mode = value;
            if (TutorialRoutine != null) TutorialRoutine.RemoveSelf();
            switch (Mode)
            {
                case BirdNpcMode.ClimbingTutorial: tutorialRoutine = AddCoroutine(ClimbingTutorial()); break;
                case BirdNpcMode.DashingTutorial: tutorialRoutine = AddCoroutine(DashingTutorial()); break;
                case BirdNpcMode.DreamJumpTutorial: tutorialRoutine = AddCoroutine(DreamJumpTutorial()); break;
                case BirdNpcMode.SuperWallJumpTutorial: tutorialRoutine = AddCoroutine(SuperWallJumpTutorial()); break;
                case BirdNpcMode.HyperJumpTutorial: tutorialRoutine = AddCoroutine(HyperJumpTutorial()); break;
                case BirdNpcMode.FlyAway: tutorialRoutine = AddCoroutine(WaitRoutine()); break;
                case BirdNpcMode.Sleeping:
                    Sprite.Play("sleep");
                    Facing = 1;
                    break;
                case BirdNpcMode.MoveToNodes: tutorialRoutine = AddCoroutine(MoveToNodesRoutine()); break;
                case BirdNpcMode.WaitForLightningOff:
                    tutorialRoutine = AddCoroutine(WaitForLightningOffRoutine()); break;
            }
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = scene as OriginalLevelSceneRoot;
            world = new(this);
            if (Mode == BirdNpcMode.ClimbingTutorial && world.GetLevelFlag("2")) RemoveSelf();
            else if (Mode == BirdNpcMode.FlyAway && world.GetFlag(world.FlownFlag + world.SessionLevel)) RemoveSelf();
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (Mode == BirdNpcMode.SuperWallJumpTutorial)
            {
                var player = world.FirstPlayer;
                if (player != null && player.Position.Y < Position.Y + 32) RemoveSelf();
            }

            if (OnlyIfPlayerLeft)
            {
                var player = world.LevelFirstPlayer;
                if (player != null && player.Position.X > Position.X) RemoveSelf();
            }
        }

        public override bool IsRiding(ISourceEntityCollider solid)
        {
            return ((ISourceMutableEntityState)solid).Collidable && solid.Collider != null &&
                   solid.Collider.Collide(new IntRect((int)Position.X - 4, (int)Position.Y, 8, 2));
        }

        public override void Update()
        {
            Sprite.Scale.X = Facing;
            base.Update();
        }

        public override void SceneEnd(object scene)
        {
            EngineContext.Effects.TimeRate = 1;
            base.SceneEnd(scene);
        }

        private void OnFrameChange(string animation)
        {
            if (Level != null && Position.X > Level.Camera.Left + 64 && Position.X < Level.Camera.Right - 64 &&
                (animation.Equals("peck") || animation.Equals("peckRare")) && Sprite.CurrentAnimationFrame == 6)
                world.PlaySound("event:/game/general/bird_peck", Position);
            if (Level != null && Level.Session.AreaID == 10 && !DisableFlapSfx) FlapSfxCheck();
        }

        public void FlapSfxCheck()
        {
            FlapSfxCheck(EngineContext, Sprite);
        }

        public static void FlapSfxCheck(ISourceEngineContext engine, Sprite sprite)
        {
            if (sprite.Entity != null && ((ISceneEntityAssociation)sprite.Entity).Scene != null)
            {
                var camera = (((ISceneEntityAssociation)sprite.Entity).Scene as OriginalLevelSceneRoot).Camera;
                var render = sprite.RenderPosition;
                if (render.X < camera.Position.X - 32 || render.Y < camera.Position.Y - 32 ||
                    render.X > camera.Position.X + 320 + 32 || render.Y > camera.Position.Y + 180 + 32) return;
            }

            var id = sprite.CurrentAnimationID;
            var frame = sprite.CurrentAnimationFrame;
            if ((id == "hover" && frame == 0) || (id == "hoverStressed" && frame == 0) || (id == "fly" && frame == 0))
            {
                var process = (IOriginalGameplayProcess)engine;
                process.AudioSession.Play("event:/new_content/game/10_farewell/bird_wingflap", sprite.RenderPosition,
                    process.SaveContext);
            }
        }

        public IEnumerator Caw()
        {
            Sprite.Play("croak");
            while (Sprite.CurrentAnimationFrame < 9) yield return null;
            world.PlaySound("event:/game/general/bird_squawk", Position);
        }

        public IEnumerator ShowTutorial(BirdTutorialGuiState tutorial, bool caw = false)
        {
            if (caw) yield return Caw();
            gui = tutorial;
            tutorial.Open = true;
            world.AddTutorial(tutorial);
            while (tutorial.Scale < 1) yield return null;
        }

        public IEnumerator HideTutorial()
        {
            if (Tutorial != null)
            {
                Tutorial.Open = false;
                while (Tutorial.Scale > 0) yield return null;
                world.RemoveTutorial(Tutorial);
                gui = null;
            }
        }

        public IEnumerator ShowDashTutorial()
        {
            return ShowTutorial(
                world.CreateTutorial(new(0, -16), world.Clean("tutorial_dash"), new Vector2(1, -1), "+",
                    BirdTutorialButton.Dash), true);
        }

        public virtual IEnumerator StartleAndFlyAway()
        {
            Depth = -1000000;
            world.SetFlag(world.FlownFlag + world.SessionLevel);
            yield return Startle("event:/game/general/bird_startle");
            yield return FlyAway();
        }

        public IEnumerator FlyAway(float upwardsMultiplier = 1)
        {
            if (staticMover != null)
            {
                staticMover.RemoveSelf();
                staticMover = null;
            }

            Sprite.Play("fly");
            Facing = -Facing;
            var speed = new Vector2(Facing * 20, -40 * upwardsMultiplier);
            while (Position.Y > world.LevelBounds.Y)
            {
                speed += new Vector2(Facing * 140, -120 * upwardsMultiplier) * DeltaTime;
                Position += speed * DeltaTime;
                yield return null;
            }

            RemoveSelf();
        }

        private IEnumerator ClimbingTutorial()
        {
            yield return .25f;
            var player = world.FirstPlayer;
            while (Math.Abs(player.Position.X - Position.X) > 120) yield return null;
            var a = world.CreateTutorial(new(0, -16), world.Clean("tutorial_climb"),
                world.Clean("tutorial_hold"),
                BirdTutorialButton.Grab);
            var b = world.CreateTutorial(new(0, -16), world.Clean("tutorial_climb"),
                BirdTutorialButton.Grab,
                "+", new Vector2(0, -1));
            bool first = true, willEnd;
            do
            {
                yield return ShowTutorial(a, first);
                first = false;
                while (player.Machine.State != 1 && player.Position.Y > Position.Y) yield return null;
                if (player.Position.Y > Position.Y)
                {
                    world.PlaySound("event:/ui/game/tutorial_note_flip_back");
                    yield return HideTutorial();
                    yield return ShowTutorial(b);
                }

                while (player.Scene != null && (!player.OnGround() || player.Machine.State == 1)) yield return null;
                willEnd = player.Position.Y <= Position.Y + 4;
                if (!willEnd) world.PlaySound("event:/ui/game/tutorial_note_flip_front");
                yield return HideTutorial();
            } while (!willEnd);

            yield return StartleAndFlyAway();
        }

        private IEnumerator DashingTutorial()
        {
            Position = new(Position.X, world.LevelBounds.Y);
            Position += new Vector2(32, 0);
            yield return 1f;
            var player = world.FirstPlayer;
            var bridge = world.FirstBridge;
            while ((player == null || !(player.Position.X > StartPosition.X - 92) ||
                    !(player.Position.Y > StartPosition.Y - 20) || !(player.Position.Y < StartPosition.Y - 10)) &&
                   (!world.Invincible || player == null || !(player.Position.X > StartPosition.X - 60) ||
                    !(player.Position.Y > StartPosition.Y) ||
                    !(player.Position.Y < StartPosition.Y + 34))) yield return null;
            world.AddEnding(player, this, bridge);
        }

        private IEnumerator DreamJumpTutorial()
        {
            yield return ShowTutorial(
                world.CreateTutorial(new(0, -16), world.Clean("tutorial_dreamjump"), new Vector2(1, 0), "+",
                    BirdTutorialButton.Jump), true);
            while (true)
            {
                var player = world.FirstPlayer;
                if (player != null &&
                    (player.Position.X > Position.X ||
                     ((ISourceVectorEnvironment)EngineContext).VectorArithmetic.Length(Position - player.Position) <
                     32)) break;
                yield return null;
            }

            yield return HideTutorial();
            while (true)
            {
                var player = world.FirstPlayer;
                if (player != null &&
                    ((ISourceVectorEnvironment)EngineContext).VectorArithmetic.Length(Position - player.Position) <
                    24) break;
                yield return null;
            }

            yield return StartleAndFlyAway();
        }

        private IEnumerator SuperWallJumpTutorial()
        {
            Facing = 1;
            yield return .25f;
            var caw = true;
            var a = world.CreateTutorial(new(0, -16), world.GuiTexture("hyperjump/tutorial00"),
                world.Clean("TUTORIAL_DASH"), new Vector2(0, -1));
            var b = world.CreateTutorial(new(0, -16), world.GuiTexture("hyperjump/tutorial01"),
                world.Clean("TUTORIAL_DREAMJUMP"));
            RoomPlayerSession player;
            do
            {
                yield return ShowTutorial(a, caw);
                Sprite.Play("idleRarePeck");
                yield return 2f;
                gui = b;
                Tutorial.Open = true;
                Tutorial.Scale = 1;
                world.AddTutorial(Tutorial);
                yield return null;
                a.Open = false;
                a.Scale = 0;
                world.RemoveTutorial(a);
                yield return 2f;
                yield return HideTutorial();
                yield return 2f;
                caw = false;
                player = world.FirstPlayer;
            } while (player == null || !(player.Position.Y <= Position.Y) || !(player.Position.X > Position.X + 144));

            yield return StartleAndFlyAway();
        }

        private IEnumerator HyperJumpTutorial()
        {
            Facing = -1;
            var tutorial = world.CreateTutorial(new(0, -16), world.Clean("TUTORIAL_DREAMJUMP"),
                new Vector2(1, 1), "+",
                BirdTutorialButton.Dash,
                world.GuiTexture("tinyarrow"),
                BirdTutorialButton.Jump);
            yield return .3f;
            yield return ShowTutorial(tutorial, true);
        }

        private IEnumerator WaitRoutine()
        {
            while (!AutoFly)
            {
                var player = world.FirstPlayer;
                if (player != null && Math.Abs(player.Position.X - Position.X) < 120) break;
                yield return null;
            }

            yield return Caw();
            while (!AutoFly)
            {
                var player = world.FirstPlayer;
                if (player != null &&
                    ((ISourceVectorEnvironment)EngineContext).VectorArithmetic.Length(player.Center - Position) <
                    32) break;
                yield return null;
            }

            yield return StartleAndFlyAway();
        }

        public IEnumerator Startle(string startleSound, float duration = .8f, Vector2? multiplier = null)
        {
            var scale = multiplier ?? Vector2.One;
            if (!string.IsNullOrWhiteSpace(startleSound)) world.PlaySound(startleSound, Position);
            world.EmitDust(Position, -(float)Math.PI / 2, 8);
            Sprite.Play("jump");
            var tween = SourceTweenState.Create(EngineContext.TweenPool, SourceTweenState.TweenMode.Oneshot,
                ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.CubeOut, duration, true);
            tween.OnUpdate = t =>
            {
                if (t.Eased < .5f && world.OnInterval(.05f))
                    world.EmitFeather(2, Position + Vector2.UnitY * -6, Vector2.One * 4);
                var speed = Vector2Interpolation.Lerp(new Vector2(100, -100) * scale,
                    new Vector2(20, -20) * scale, t.Eased, ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic);
                speed.X *= -Facing;
                Position += speed * DeltaTime;
            };
            OwnedComponents.Add(tween);
            while (tween.Active) yield return null;
        }

        private void AddRelocateSound()
        {
            var sound = world.CreateSound();
            sound.Play("event:/new_content/game/10_farewell/bird_relocate");
            OwnedComponents.Add(sound);
        }

        public IEnumerator FlyTo(Vector2 target, float durationMult = 1, bool relocateSfx = true)
        {
            Sprite.Play("fly");
            if (relocateSfx) AddRelocateSound();
            var direction = Math.Sign(target.X - Position.X);
            if (direction != 0) Facing = direction;
            var from = Position;
            var curve = new SimpleCurve(from, target, from + (target - from) * .75f - Vector2.UnitY * 30);
            var duration = ((ISourceVectorEnvironment)EngineContext).VectorArithmetic.Length(target - from) / 100 *
                           durationMult;
            for (float p = 0; p < .95f; p += DeltaTime / duration)
            {
                var point = curve.GetPoint(((ISourceEasingEnvironment)EngineContext).EasingArithmetic.SineInOut(p),
                    ((ISourceCurveEnvironment)EngineContext).CurveArithmetic);
                Position = Vector2Geometry.Floor(point);
                Sprite.Rate = 1 - p * .5f;
                yield return null;
            }

            world.EmitDust(Position, -(float)Math.PI / 2, 8);
            Position = target;
            Facing = -1;
            Sprite.Rate = 1;
            Sprite.Play("idle");
        }

        private IEnumerator MoveToNodesRoutine()
        {
            var index = 0;
            while (true)
            {
                var player = world.FirstPlayer;
                if (player == null ||
                    !(((ISourceVectorEnvironment)EngineContext).VectorArithmetic.Length(player.Center - Position) < 80))
                {
                    yield return null;
                    continue;
                }

                Depth = -1000000;
                yield return Startle("event:/new_content/game/10_farewell/bird_startle", .2f);
                if (index < nodes.Length)
                {
                    yield return FlyTo(nodes[index], .6f);
                    index++;
                    continue;
                }

                Tags = new(
                    ((IOriginalGameTagsEnvironment)EngineContext).Tags
                    .Persistent.Value);
                AddRelocateSound();
                if (OnlyOnce) world.AddDoNotLoad(EntityID);
                Sprite.Play("fly");
                Facing = 1;
                var speed = new Vector2(Facing * 20, -40);
                while (Position.Y > world.LevelBounds.Y - 200)
                {
                    speed += new Vector2(Facing * 140, -60) * DeltaTime;
                    Position += speed * DeltaTime;
                    yield return null;
                }

                RemoveSelf();
            }
        }

        private IEnumerator WaitForLightningOffRoutine()
        {
            Sprite.Play("hoverStressed");
            while (world.LightningPresent) yield return null;
            if (WaitForLightningPostDelay > 0) yield return WaitForLightningPostDelay;
            if (!FlyAwayUp)
            {
                Sprite.Play("fly");
                var speed = new Vector2(Facing * 20, -10);
                while (Position.Y > world.LevelBounds.Y)
                {
                    speed += new Vector2(Facing * 140, -10) * DeltaTime;
                    Position += speed * DeltaTime;
                    yield return null;
                }
            }
            else
            {
                Sprite.Play("flyup");
                var speed = new Vector2(0, -32);
                while (Position.Y > world.LevelBounds.Y)
                {
                    speed += new Vector2(0, -100) * DeltaTime;
                    Position += speed * DeltaTime;
                    yield return null;
                }
            }

            RemoveSelf();
        }
    }
}
