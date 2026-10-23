using Celeste.Core.Display;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Presentation.Particles;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision;
using Celeste.Scene.Components.Shaking;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.Platforms.Dream
{
    public partial class OriginalDreamBlockState : SourceSolidEntityState,
        global::Celeste.Simulation.Gameplay.Platforms.DreamBlock.ISourceDreamBlock, IOldSiteDreamBlock
    {
        protected struct DreamParticle
        {
            public Vector2 Position;

            public int Layer;

            public PackedColor Color;

            public float TimeOffset;
        }

        private static PackedColor activeBackColor = PackedColor.Black;

        private static PackedColor disabledBackColor = new PackedColor(0x1f, 0x2e, 0x2d);

        private static PackedColor activeLineColor = PackedColor.White;

        private static PackedColor disabledLineColor = new PackedColor(0x6a, 0x84, 0x80);

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
            : base(position, width, height, safe: true, worlds.Create(position, true))
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
            particleTextures = new AtlasEntry[4]
            {
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/dreamblock/particles"]
                .GetSubtexture(14, 0, 7, 7),
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/dreamblock/particles"]
                .GetSubtexture(7, 0, 7, 7),
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/dreamblock/particles"]
                .GetSubtexture(0, 0, 7, 7),
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/dreamblock/particles"]
                .GetSubtexture(7, 0, 7, 7)
            };
        }

        public static OriginalDreamBlockState CreateFromMapData(EntityData data, Vector2 offset,
            OriginalLevelSceneRoot actualLevel)
        {
            Vector2 position = data.Position + offset;
            float width = data.Width;
            float height = data.Height;
            Vector2? node = data.FirstNodeNullable(offset);
            bool fastMoving = EntityAttributeReader.Bool(data.Values, "fastMoving");
            bool oneUse = EntityAttributeReader.Bool(data.Values, "oneUse");
            bool below = EntityAttributeReader.Bool(data.Values, "below");
            return new OriginalDreamBlockState(actualLevel.EngineContext, position, width, height,
                node, fastMoving, oneUse, below, actualLevel.SolidWorldFactory);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            playerHasDreamDash = ((OriginalLevelSceneRoot)Scene).Session.Inventory.DreamDash;
            if (playerHasDreamDash && node.HasValue)
            {
                Vector2 start = Position;
                Vector2 end = node.Value;
                float num = ((ISourceVectorEnvironment)engine).VectorArithmetic.Distance(start, end) / 12f;
                if (fastMoving)
                {
                    num /= 3f;
                }

                SourceTweenState tween = SourceTweenState.Create(engine.TweenPool,
                    SourceTweenState.TweenMode.YoyoLooping,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut, num, start: true);
                tween.OnUpdate = t => RuntimePolicy.MoveNode(this, start, end, t);
                Add(tween);
            }

            if (!playerHasDreamDash)
            {
                Add(occlude = new LightOccludeState());
            }

            Setup();
        }

        public virtual void Setup()
        {
            particles = new DreamParticle[RuntimePolicy.GetParticleCount(this)];
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Position = new Vector2(SourceRandomMath.NextFloat(Random, base.Width),
                    SourceRandomMath.NextFloat(Random, base.Height));
                particles[i].Layer = RuntimePolicy.ChooseLayer(Random);
                particles[i].TimeOffset = SourceRandomMath.NextFloat(Random);
                particles[i].Color = new PackedColor(211, 211, 211) * (0.5f + (float)particles[i].Layer / 2f * 0.5f);
                if (playerHasDreamDash)
                {
                    switch (particles[i].Layer)
                    {
                        case 0:
                            particles[i].Color = RuntimePolicy.ChooseColor(Random, new PackedColor(0xFF, 0xEF, 0x11),
                                new PackedColor(0xFF, 0x00, 0xD0), new PackedColor(0x08, 0xa3, 0x10));
                            break;
                        case 1:
                            particles[i].Color = RuntimePolicy.ChooseColor(Random, new PackedColor(0x5f, 0xcd, 0xe4),
                                new PackedColor(0x7f, 0xb2, 0x5e), new PackedColor(0xE0, 0x56, 0x4C));
                            break;
                        case 2:
                            particles[i].Color = RuntimePolicy.ChooseColor(Random, new PackedColor(0x5b, 0x6e, 0xe1),
                                new PackedColor(0xCC, 0x3B, 0x3B), new PackedColor(0x7d, 0xaa, 0x64));
                            break;
                    }
                }
            }
        }

        public virtual void OnPlayerExit(RoomPlayerSession player)
        {
            OriginalDustBurstSource.Burst(engine, player.Position,
                Vector2Geometry.Angle(player.Data.Motion.Normal.Speed),
                16);
            Vector2 vector = Vector2.Zero;
            if (SourceEntityCollision.CheckAt(this, player, Position + Vector2.UnitX * 4f))
            {
                vector = Vector2.UnitX;
            }
            else if (SourceEntityCollision.CheckAt(this, player, Position - Vector2.UnitX * 4f))
            {
                vector = -Vector2.UnitX;
            }
            else if (SourceEntityCollision.CheckAt(this, player, Position + Vector2.UnitY * 4f))
            {
                vector = Vector2.UnitY;
            }
            else if (SourceEntityCollision.CheckAt(this, player, Position - Vector2.UnitY * 4f))
            {
                vector = -Vector2.UnitY;
            }

            _ = vector != Vector2.Zero;
            if (oneUse)
            {
                OneUseDestroy();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OneUseDestroy()
        {
            Collidable = (Visible = false);
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
            if (theoCrystal != null && !TryActorWiggleUp(theoCrystal))
            {
                return true;
            }

            var player = SourceTrackedEntityCollision.First<RoomPlayerSession>(
                ((ISourceScene)Scene).SourceScene.Entities,
                typeof(global::Celeste.Simulation.RoomPlayerSession).FullName,
                this);

            if (player != null && !TryActorWiggleUp(player))
            {
                return true;
            }

            return false;
        }

        private bool TryActorWiggleUp(ISourceEntityCollider actor)
        {
            bool collidable = Collidable;
            Collidable = true;
            for (int i = 1; i <= 4; i++)
            {
                if (!SourceSceneCollisionQueries.CheckAt(actor,
                        ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.Solid"),
                        actor.Position - Vector2.UnitY * i))
                {
                    ((ISourceMutableEntityPosition)actor).Position -= Vector2.UnitY * i;
                    Collidable = collidable;
                    return true;
                }
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
            if (base.Right < camera.Left || base.Left > camera.Right || base.Bottom < camera.Top ||
                base.Top > camera.Bottom)
            {
                return;
            }

            SourcePrimitiveDrawing.Rect(context, this, shake.X + base.X, shake.Y + base.Y, base.Width, base.Height,
                (playerHasDreamDash ? RenderActiveBackColor : RenderDisabledBackColor));
            RenderParticles(context);

            if (whiteFill > 0f)
            {
                SourcePrimitiveDrawing.Rect(context, this, base.X + shake.X, base.Y + shake.Y, base.Width,
                    base.Height * whiteHeight, (PackedColor.White * whiteFill));
            }

            if (RenderTopWobble)
                WobbleLine(context, shake + new Vector2(base.X, base.Y),
                    shake + new Vector2(base.X + base.Width, base.Y),
                    0f);
            if (RenderRightWobble)
                WobbleLine(context, shake + new Vector2(base.X + base.Width, base.Y),
                    shake + new Vector2(base.X + base.Width, base.Y + base.Height), 0.7f);
            if (RenderBottomWobble)
                WobbleLine(context, shake + new Vector2(base.X + base.Width, base.Y + base.Height),
                    shake + new Vector2(base.X, base.Y + base.Height), 1.5f);
            if (RenderLeftWobble)
                WobbleLine(context, shake + new Vector2(base.X, base.Y + base.Height),
                    shake + new Vector2(base.X, base.Y),
                    2.5f);
            SourcePrimitiveDrawing.Rect(context, this, shake + new Vector2(base.X, base.Y), 2f, 2f,
                (playerHasDreamDash ? RenderActiveLineColor : RenderDisabledLineColor));
            SourcePrimitiveDrawing.Rect(context, this, shake + new Vector2(base.X + base.Width - 2f, base.Y), 2f, 2f,
                (playerHasDreamDash ? RenderActiveLineColor : RenderDisabledLineColor));
            SourcePrimitiveDrawing.Rect(context, this, shake + new Vector2(base.X, base.Y + base.Height - 2f), 2f, 2f,
                (playerHasDreamDash ? RenderActiveLineColor : RenderDisabledLineColor));
            SourcePrimitiveDrawing.Rect(context, this,
                shake + new Vector2(base.X + base.Width - 2f, base.Y + base.Height - 2f), 2f, 2f,
                (playerHasDreamDash ? RenderActiveLineColor : RenderDisabledLineColor));
        }

        protected virtual void RenderParticles(ISourceRenderContext context)
        {
            Vector2 cameraPosition = ((OriginalLevelSceneRoot)Scene).Camera.Position;
            for (int index = 0; index < particles.Length; index++)
            {
                DreamParticleVisual visual = GetParticleVisual(index, cameraPosition);
                Vector2 position = PutInside(visual.Position);
                if (position.X >= base.X + 2f && position.Y >= base.Y + 2f && position.X < base.Right - 2f &&
                    position.Y < base.Bottom - 2f)
                    SourceAtlasDrawing.DrawCentered(context, this, visual.Texture, position + visual.DrawOffset,
                        visual.Color, rotation: visual.Rotation);
            }
        }

        private Vector2 PutInside(Vector2 position)
            => RuntimePolicy.PutInside(this, position);

        private void WobbleLine(ISourceRenderContext context, Vector2 from, Vector2 to, float offset)
        {
            float num = ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(to - from);
            Vector2 vector = ((ISourceVectorEnvironment)engine).VectorArithmetic.Normalize(to - from);
            Vector2 vector2 = new Vector2(vector.Y, 0f - vector.X);
            PackedColor color = (playerHasDreamDash ? RenderActiveLineColor : RenderDisabledLineColor);
            PackedColor color2 = (playerHasDreamDash ? RenderActiveBackColor : RenderDisabledBackColor);
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
            OriginalLevelSceneRoot level = ((OriginalLevelSceneRoot)Scene);
            yield return 1f;
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 2);
            Add(shaker = new ShakerComponentState(engine, on: true, delegate(Vector2 t) { shake = t; }));
            shaker.Interval = 0.02f;
            shaker.On = true;
            for (float p = 0f; p < 1f; p += engine.DeltaTime)
            {
                whiteFill = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                yield return null;
            }

            shaker.On = false;
            yield return 0.5f;
            ActivateNoRoutine();
            whiteHeight = 1f;
            whiteFill = 1f;
            for (float p = 1f; p > 0f; p -= engine.DeltaTime * 0.5f)
            {
                whiteHeight = p;
                if (level.Clock.OnInterval(.1f, engine))
                {
                    for (int num = 0; (float)num < base.Width; num += 4)
                    {
                        level.ParticlesFG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.Strawberry.P_WingsBurst,
                            new Vector2(base.X + (float)num, base.Y + base.Height * whiteHeight + 1f));
                    }
                }

                if (level.Clock.OnInterval(.1f, engine))
                {
                    level.Shake();
                }

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
            if (shaker != null)
            {
                shaker.On = false;
            }
        }

        public void FootstepRipple(Vector2 position)
        {
            if (playerHasDreamDash)
            {
                var burst = ((OriginalLevelSceneRoot)Scene).Displacement.AddBurst(position, 0.5f, 0f, 40f);
                burst.WorldClipCollider = base.Collider;
                burst.WorldClipPadding = 1;
            }
        }
    }
}
