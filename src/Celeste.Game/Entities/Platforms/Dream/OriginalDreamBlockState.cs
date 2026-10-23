using System;
using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Presentation.Particles;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Physics.Collision;
using Celeste.Scene.Components.Shaking;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation.Gameplay.Platforms.DreamBlock;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Entities.Platforms.Dream
{
    public partial class OriginalDreamBlockState : SourceSolidEntityState,
        ISourceDreamBlock, IOldSiteDreamBlock
    {
        protected struct DreamParticle
        {
            public Vector2 Position;

            public int Layer;

            public PackedColor Color;

            public float TimeOffset;
        }

        private static readonly PackedColor activeBackColor = PackedColor.Black;

        private static readonly PackedColor disabledBackColor = new(0x1f, 0x2e, 0x2d);

        private static readonly PackedColor activeLineColor = PackedColor.White;

        private static readonly PackedColor disabledLineColor = new(0x6a, 0x84, 0x80);

        private bool playerHasDreamDash;

        public bool PlayerHasDreamDash => playerHasDreamDash;

        protected Vector2? node;

        private LightOccludeState occlude;

        protected AtlasEntry[] particleTextures;

        protected DreamParticle[] particles;

        private float whiteFill;

        private float whiteHeight = 1f;

        private Vector2 shake;

        protected float animTimer;

        private ShakerComponentState shaker;

        protected bool fastMoving;

        private bool oneUse;

        private float wobbleFrom;

        private float wobbleTo;

        private float wobbleEase;

        private readonly ISourceEngineContext engine;

        private readonly Func<float, float, float, float> sourceWobbleInterpolation;

        private IOriginalDreamBlockRuntimePolicy RuntimePolicy =>
            ((IOriginalDreamBlockRuntimeEnvironment)engine).DreamBlockRuntimePolicy;

        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        public OriginalDreamBlockState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Vector2? node, bool fastMoving, bool oneUse, bool below, ISourceSolidWorldFactory worlds)
            : this(engine, position, width, height, node, fastMoving, oneUse, below, worlds,
                SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, (float)Math.PI * 2f),
                SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, (float)Math.PI * 2f))
        {
        }

        private OriginalDreamBlockState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Vector2? node, bool fastMoving, bool oneUse, bool below, ISourceSolidWorldFactory worlds,
            float wobbleFrom, float wobbleTo)
            : base(position, width, height, true, worlds.Create(position, true))
        {
            this.engine = engine;
            sourceWobbleInterpolation = Lerp;
            this.wobbleFrom = wobbleFrom;
            this.wobbleTo = wobbleTo;
            Depth = -11000;
            this.node = node;
            this.fastMoving = fastMoving;
            this.oneUse = oneUse;
            if (below) Depth = 5000;
            SurfaceSoundIndex = 11;
            particleTextures =
            [
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/dreamblock/particles"]
                .GetSubtexture(14, 0, 7, 7),
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/dreamblock/particles"]
                .GetSubtexture(7, 0, 7, 7),
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/dreamblock/particles"]
                .GetSubtexture(0, 0, 7, 7),
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/dreamblock/particles"]
                .GetSubtexture(7, 0, 7, 7),
            ];
        }

        public static OriginalDreamBlockState CreateFromMapData(EntityData data, Vector2 offset,
            OriginalLevelSceneRoot actualLevel)
        {
            var position = data.Position + offset;
            float width = data.Width;
            float height = data.Height;
            var node = data.FirstNodeNullable(offset);
            var fastMoving = EntityAttributeReader.Bool(data.Values, "fastMoving");
            var oneUse = EntityAttributeReader.Bool(data.Values, "oneUse");
            var below = EntityAttributeReader.Bool(data.Values, "below");
            return new(actualLevel.EngineContext, position, width, height,
                node, fastMoving, oneUse, below, actualLevel.SolidWorldFactory);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            playerHasDreamDash = ((OriginalLevelSceneRoot)Scene).Session.Inventory.DreamDash;
            if (playerHasDreamDash && node.HasValue)
            {
                var start = Position;
                var end = node.Value;
                var num = ((ISourceVectorEnvironment)engine).VectorArithmetic.Distance(start, end) / 12f;
                if (fastMoving) num /= 3f;

                var tween = SourceTweenState.Create(engine.TweenPool,
                    SourceTweenState.TweenMode.YoyoLooping,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut, num, true);
                tween.OnUpdate = t => RuntimePolicy.MoveNode(this, start, end, t);
                Add(tween);
            }

            if (!playerHasDreamDash) Add(occlude = new());

            Setup();
        }

        public virtual void Setup()
        {
            particles = new DreamParticle[RuntimePolicy.GetParticleCount(this)];
            for (var i = 0; i < particles.Length; i++)
            {
                particles[i].Position = new(SourceRandomMath.NextFloat(Random, Width),
                    SourceRandomMath.NextFloat(Random, Height));
                particles[i].Layer = RuntimePolicy.ChooseLayer(Random);
                particles[i].TimeOffset = SourceRandomMath.NextFloat(Random);
                particles[i].Color = new PackedColor(211, 211, 211) * (0.5f + particles[i].Layer / 2f * 0.5f);
                if (playerHasDreamDash)
                    switch (particles[i].Layer)
                    {
                        case 0:
                            particles[i].Color = RuntimePolicy.ChooseColor(Random, new(0xFF, 0xEF, 0x11),
                                new(0xFF, 0x00, 0xD0), new(0x08, 0xa3, 0x10));
                            break;
                        case 1:
                            particles[i].Color = RuntimePolicy.ChooseColor(Random, new(0x5f, 0xcd, 0xe4),
                                new(0x7f, 0xb2, 0x5e), new(0xE0, 0x56, 0x4C));
                            break;
                        case 2:
                            particles[i].Color = RuntimePolicy.ChooseColor(Random, new(0x5b, 0x6e, 0xe1),
                                new(0xCC, 0x3B, 0x3B), new(0x7d, 0xaa, 0x64));
                            break;
                    }
            }
        }

        public virtual void OnPlayerExit(RoomPlayerSession player)
        {
            OriginalDustBurstSource.Burst(engine, player.Position,
                Vector2Geometry.Angle(player.Data.Motion.Normal.Speed),
                16);
            var vector = Vector2.Zero;
            if (SourceEntityCollision.CheckAt(this, player, Position + Vector2.UnitX * 4f))
                vector = Vector2.UnitX;
            else if (SourceEntityCollision.CheckAt(this, player, Position - Vector2.UnitX * 4f))
                vector = -Vector2.UnitX;
            else if (SourceEntityCollision.CheckAt(this, player, Position + Vector2.UnitY * 4f))
                vector = Vector2.UnitY;
            else if (SourceEntityCollision.CheckAt(this, player, Position - Vector2.UnitY * 4f))
                vector = -Vector2.UnitY;

            _ = vector != Vector2.Zero;
            if (oneUse) OneUseDestroy();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OneUseDestroy()
        {
            Collidable = Visible = false;
            DisableStaticMovers();
            RemoveSelf();
        }

        public override void Update()
        {
            base.Update();
            if (playerHasDreamDash)
            {
                animTimer += 6f * engine.DeltaTime;
                wobbleEase += engine.DeltaTime * 2f;
                if (wobbleEase > 1f)
                {
                    wobbleEase = 0f;
                    wobbleFrom = wobbleTo;
                    wobbleTo = SourceRandomMath.NextFloat(Random, (float)Math.PI * 2f);
                }

                SurfaceSoundIndex = 12;
            }
        }

        public bool BlockedCheck()
        {
            var theoCrystal = SourceTrackedEntityCollision.First<ISourceEntityCollider>(
                ((ISourceScene)Scene).SourceScene.Entities, "Celeste.TheoCrystal", this);
            if (theoCrystal != null && !TryActorWiggleUp(theoCrystal)) return true;

            var player = SourceTrackedEntityCollision.First<RoomPlayerSession>(
                ((ISourceScene)Scene).SourceScene.Entities,
                typeof(RoomPlayerSession).FullName,
                this);

            return player != null && !TryActorWiggleUp(player) ? true : false;
        }

        private bool TryActorWiggleUp(ISourceEntityCollider actor)
        {
            var collidable = Collidable;
            Collidable = true;
            for (var i = 1; i <= 4; i++)
                if (!SourceSceneCollisionQueries.CheckAt(actor,
                        ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.Solid"),
                        actor.Position - Vector2.UnitY * i))
                {
                    ((ISourceMutableEntityPosition)actor).Position -= Vector2.UnitY * i;
                    Collidable = collidable;
                    return true;
                }

            Collidable = collidable;
            return false;
        }

        protected virtual PackedColor RenderActiveBackColor => activeBackColor;
        protected virtual PackedColor RenderDisabledBackColor => disabledBackColor;
        protected virtual PackedColor RenderActiveLineColor => activeLineColor;
        protected virtual PackedColor RenderDisabledLineColor => disabledLineColor;

        public override void Render(ISourceRenderContext context)
        {
            var camera = ((OriginalLevelSceneRoot)Scene).Camera;
            if (Right < camera.Left || Left > camera.Right || Bottom < camera.Top ||
                Top > camera.Bottom)
                return;

            SourcePrimitiveDrawing.Rect(context, this, shake.X + X, shake.Y + Y, Width, Height,
                playerHasDreamDash ? RenderActiveBackColor : RenderDisabledBackColor);
            RenderParticles(context);

            if (whiteFill > 0f)
                SourcePrimitiveDrawing.Rect(context, this, X + shake.X, Y + shake.Y, Width,
                    Height * whiteHeight, PackedColor.White * whiteFill);

            if (RenderTopWobble)
                WobbleLine(context, shake + new Vector2(X, Y),
                    shake + new Vector2(X + Width, Y),
                    0f);
            if (RenderRightWobble)
                WobbleLine(context, shake + new Vector2(X + Width, Y),
                    shake + new Vector2(X + Width, Y + Height), 0.7f);
            if (RenderBottomWobble)
                WobbleLine(context, shake + new Vector2(X + Width, Y + Height),
                    shake + new Vector2(X, Y + Height), 1.5f);
            if (RenderLeftWobble)
                WobbleLine(context, shake + new Vector2(X, Y + Height),
                    shake + new Vector2(X, Y),
                    2.5f);
            SourcePrimitiveDrawing.Rect(context, this, shake + new Vector2(X, Y), 2f, 2f,
                playerHasDreamDash ? RenderActiveLineColor : RenderDisabledLineColor);
            SourcePrimitiveDrawing.Rect(context, this, shake + new Vector2(X + Width - 2f, Y), 2f, 2f,
                playerHasDreamDash ? RenderActiveLineColor : RenderDisabledLineColor);
            SourcePrimitiveDrawing.Rect(context, this, shake + new Vector2(X, Y + Height - 2f), 2f, 2f,
                playerHasDreamDash ? RenderActiveLineColor : RenderDisabledLineColor);
            SourcePrimitiveDrawing.Rect(context, this,
                shake + new Vector2(X + Width - 2f, Y + Height - 2f), 2f, 2f,
                playerHasDreamDash ? RenderActiveLineColor : RenderDisabledLineColor);
        }

        protected virtual void RenderParticles(ISourceRenderContext context)
        {
            var cameraPosition = ((OriginalLevelSceneRoot)Scene).Camera.Position;
            for (var index = 0; index < particles.Length; index++)
            {
                var visual = GetParticleVisual(index, cameraPosition);
                var position = PutInside(visual.Position);
                if (position.X >= X + 2f && position.Y >= Y + 2f && position.X < Right - 2f &&
                    position.Y < Bottom - 2f)
                    SourceAtlasDrawing.DrawCentered(context, this, visual.Texture, position + visual.DrawOffset,
                        visual.Color, rotation: visual.Rotation);
            }
        }

        private Vector2 PutInside(Vector2 position)
        {
            return RuntimePolicy.PutInside(this, position);
        }

        private void WobbleLine(ISourceRenderContext context, Vector2 from, Vector2 to, float offset)
        {
            var num = ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(to - from);
            var vector = ((ISourceVectorEnvironment)engine).VectorArithmetic.Normalize(to - from);
            var vector2 = new Vector2(vector.Y, 0f - vector.X);
            var color = playerHasDreamDash ? RenderActiveLineColor : RenderDisabledLineColor;
            var color2 = playerHasDreamDash ? RenderActiveBackColor : RenderDisabledBackColor;
            if (whiteFill > 0f)
            {
                color = SourceColorInterpolation.Lerp(color, PackedColor.White, whiteFill,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                color2 = SourceColorInterpolation.Lerp(color2, PackedColor.White, whiteFill,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            }

            DreamBlockBorderDrawing.DrawSegments(context, this, engine, from, num, vector, vector2,
                offset, wobbleFrom, wobbleTo, wobbleEase, color, color2, sourceWobbleInterpolation);
        }

        public IEnumerator Activate()
        {
            var level = (OriginalLevelSceneRoot)Scene;
            yield return 1f;
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 2);
            Add(shaker = new(engine, true, delegate(Vector2 t) { shake = t; }));
            shaker.Interval = 0.02f;
            shaker.On = true;
            for (var p = 0f; p < 1f; p += engine.DeltaTime)
            {
                whiteFill = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                yield return null;
            }

            shaker.On = false;
            yield return 0.5f;
            ActivateNoRoutine();
            whiteHeight = 1f;
            whiteFill = 1f;
            for (var p = 1f; p > 0f; p -= engine.DeltaTime * 0.5f)
            {
                whiteHeight = p;
                if (level.Clock.OnInterval(.1f, engine))
                    for (var num = 0; num < Width; num += 4)
                        level.ParticlesFG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.Strawberry.P_WingsBurst,
                            new(X + num, Y + Height * whiteHeight + 1f));

                if (level.Clock.OnInterval(.1f, engine)) level.Shake();

                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 0);
                yield return null;
            }

            while (whiteFill > 0f)
            {
                whiteFill -= engine.DeltaTime * 3f;
                yield return null;
            }
        }

        public void ActivateNoRoutine()
        {
            if (!playerHasDreamDash)
            {
                playerHasDreamDash = true;
                Setup();
                Remove(occlude);
            }

            whiteHeight = 0f;
            whiteFill = 0f;
            if (shaker != null) shaker.On = false;
        }

        public void FootstepRipple(Vector2 position)
        {
            if (playerHasDreamDash)
            {
                var burst = ((OriginalLevelSceneRoot)Scene).Displacement.AddBurst(position, 0.5f, 0f, 40f);
                burst.WorldClipCollider = Collider;
                burst.WorldClipPadding = 1;
            }
        }
    }
}
