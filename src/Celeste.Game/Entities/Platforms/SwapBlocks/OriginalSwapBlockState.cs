using Celeste.Core.Display;
using Celeste.Game.Entities.Platforms.SwapBlocks.Motion;
using Celeste.Scene.Tracking;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Audio;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Framework;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Entities.Platforms.SwapBlocks
{
    public class OriginalSwapBlockState : SourceSolidEntityState, ISwapBlockSoundResolver,
        global::Celeste.Simulation.Gameplay.Platforms.SwapBlocks.ISourceSwapBlock
    {
        public enum Themes
        {
            Normal,
            Moon
        }

        public class PathRenderer : SceneEntityState
        {
            private OriginalSwapBlockState block;

            public ISourceEngineContext EngineContext => block.engine;

            private AtlasEntry pathTexture;

            private AtlasEntry clipTexture = new AtlasEntry();

            private float timer;

            public PathRenderer(OriginalSwapBlockState block)
                : base(((ISourceEntitySourceDataEnvironment)block.engine).EntitySourceDataRegistration, block.Position)
            {
                this.block = block;
                base.Depth = 8999;
                pathTexture =
                    ((ISourceGameGraphicsEnvironment)block.engine).GameGraphics.GameAtlas[
                        block.ResolvePathTexturePrefix("objects/swapblock/path") +
                        ((block.start.X == block.end.X) ? "V" : "H")];
                timer = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)block.engine).Random);
            }

            public override void Update()
            {
                base.Update();
                timer += block.engine.DeltaTime * 4f;
            }

            public override void Render(ISourceRenderContext context)
            {
                if (block.Theme != Themes.Moon)
                {
                    for (int i = block.moveRect.Left; i < block.moveRect.Right; i += pathTexture.FrameWidth)
                    {
                        for (int j = block.moveRect.Top; j < block.moveRect.Bottom; j += pathTexture.FrameHeight)
                        {
                            pathTexture.GetSubtexture(0, 0, Math.Min(pathTexture.FrameWidth, block.moveRect.Right - i),
                                Math.Min(pathTexture.FrameHeight, block.moveRect.Bottom - j), clipTexture);
                            SourceAtlasDrawing.DrawCentered(context, this, clipTexture,
                                new Vector2(i + clipTexture.FrameWidth / 2, j + clipTexture.FrameHeight / 2),
                                PackedColor.White);
                        }
                    }
                }

                float num = 0.5f * (0.5f + ((float)Math.Sin(timer) + 1f) * 0.25f);
                block.DrawBlockStyle(context, new Vector2(block.moveRect.X, block.moveRect.Y), block.moveRect.Width,
                    block.moveRect.Height, block.nineSliceTarget, null, PackedColor.White * num);
            }
        }


        private const float ReturnTime = 0.8f;

        public Vector2 Direction;

        public bool Swapping;

        Vector2 global::Celeste.Simulation.Gameplay.Platforms.SwapBlocks.ISourceSwapBlock.Direction => Direction;
        bool global::Celeste.Simulation.Gameplay.Platforms.SwapBlocks.ISourceSwapBlock.Swapping => Swapping;

        public Themes Theme;

        public ISourceEngineContext EngineContext => engine;
        public int MovementTarget => target;
        public Vector2 MovementEnd => end;
        public IntRect MovementBounds => moveRect;
        public ref float SourceRedAlpha => ref redAlpha;
        public ISourceAudioEventReference MovementSound => moveSfx;
        public ISourceAudioEventReference ReturnSound => returnSfx;

        private Vector2 start;

        private Vector2 end;

        private float lerp;

        private int target;

        private IntRect moveRect;

        private float speed;

        private float maxForwardSpeed;

        private float maxBackwardSpeed;

        private float returnTimer;

        private float redAlpha = 1f;

        private AtlasEntry[,] nineSliceGreen;

        private AtlasEntry[,] nineSliceRed;

        private AtlasEntry[,] nineSliceTarget;

        private Sprite middleGreen;

        private Sprite middleRed;

        private PathRenderer path;

        private ISourceAudioEventReference moveSfx;

        private ISourceAudioEventReference returnSfx;

        private DisplacementBurst burst;

        private float particlesRemainder;

        private readonly ISourceEngineContext engine;
        private readonly string pathTextureRoot;
        protected Sprite SourceMiddleGreen => middleGreen;
        protected Sprite SourceMiddleRed => middleRed;
        protected virtual string ResolveSoundPath(string path) => path;
        protected virtual string ResolvePathTexturePrefix(string prefix) => pathTextureRoot ?? prefix;
        string ISwapBlockSoundResolver.ResolveSwapBlockSoundPath(string path) => ResolveSoundPath(path);

        public OriginalSwapBlockState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Vector2 node, Themes theme, ISourceSolidWorld world)
            : this(engine, position, width, height, node, theme, world, null, null)
        {
        }

        protected OriginalSwapBlockState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Vector2 node, Themes theme, ISourceSolidWorld world, string spriteRoot, string pathTextureRoot)
            : base(position, width, height, false, world)
        {
            this.pathTextureRoot = pathTextureRoot;
            this.engine = engine;
            Theme = theme;
            start = Position;
            end = node;
            maxForwardSpeed = 360f / ((ISourceVectorEnvironment)engine).VectorArithmetic.Distance(start, end);
            maxBackwardSpeed = maxForwardSpeed * 0.4f;
            Direction.X = Math.Sign(end.X - start.X);
            Direction.Y = Math.Sign(end.Y - start.Y);
            OwnedComponents.Add(new DashListenerState
            {
                OnDash = OnDash
            });
            int num = (int)SourceFrameworkMath.Min(base.X, node.X);
            int num2 = (int)SourceFrameworkMath.Min(base.Y, node.Y);
            int num3 = (int)SourceFrameworkMath.Max(base.X + base.Width, node.X + base.Width);
            int num4 = (int)SourceFrameworkMath.Max(base.Y + base.Height, node.Y + base.Height);
            moveRect = new IntRect(num, num2, num3 - num, num4 - num2);
            AtlasEntry mTexture;
            AtlasEntry mTexture2;
            AtlasEntry mTexture3;
            if (Theme == Themes.Moon)
            {
                mTexture =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/swapblock/moon/block"];
                mTexture2 =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/swapblock/moon/blockRed"];
                mTexture3 =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/swapblock/moon/target"];
            }
            else
            {
                mTexture = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas[
                    spriteRoot == null ? "objects/swapblock/block" : spriteRoot + "/block"];
                mTexture2 =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas[
                        spriteRoot == null ? "objects/swapblock/blockRed" : spriteRoot + "/blockRed"];
                mTexture3 = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas[
                    spriteRoot == null ? "objects/swapblock/target" : spriteRoot + "/target"];
            }

            nineSliceGreen = new AtlasEntry[3, 3];
            nineSliceRed = new AtlasEntry[3, 3];
            nineSliceTarget = new AtlasEntry[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    nineSliceGreen[i, j] = mTexture.GetSubtexture(i * 8, j * 8, 8, 8);
                    nineSliceRed[i, j] = mTexture2.GetSubtexture(i * 8, j * 8, 8, 8);
                    nineSliceTarget[i, j] = mTexture3.GetSubtexture(i * 8, j * 8, 8, 8);
                }
            }

            if (Theme == Themes.Normal)
            {
                OwnedComponents.Add(middleGreen =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("swapBlockLight"));
                OwnedComponents.Add(middleRed =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("swapBlockLightRed"));
            }
            else if (Theme == Themes.Moon)
            {
                OwnedComponents.Add(middleGreen =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("swapBlockLightMoon"));
                OwnedComponents.Add(middleRed =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory
                    .Create("swapBlockLightRedMoon"));
            }

            OwnedComponents.Add(new LightOccludeState(0.2f));
            base.Depth = -9999;
        }

        public OriginalSwapBlockState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            : this(engine, SourceVector2Math.Add(data.Position, offset), data.Width, data.Height,
                SourceVector2Math.Add(data.Nodes[0], offset),
                EntityAttributeReader.Enum(data.Values, "theme", Themes.Normal), world)
        {
        }

        protected OriginalSwapBlockState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world, string spriteRoot, string pathTextureRoot)
            : this(engine, SourceVector2Math.Add(data.Position, offset), data.Width, data.Height,
                SourceVector2Math.Add(data.Nodes[0], offset),
                EntityAttributeReader.Enum(data.Values, "theme", Themes.Normal), world, spriteRoot, pathTextureRoot)
        {
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(path = new PathRenderer(this));
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Stop(moveSfx);
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Stop(returnSfx);
        }

        public override void SceneEnd(object scene)
        {
            base.SceneEnd(scene);
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Stop(moveSfx);
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Stop(returnSfx);
        }

        private void OnDash(Vector2 direction)
        {
            SwapBlockMotion.Start(new MotionState(this));
        }

        public override void Update()
        {
            base.Update();
            if (returnTimer > 0f)
            {
                returnTimer -= engine.DeltaTime;
                if (returnTimer <= 0f)
                {
                    target = 0;
                    speed = 0f;
                    returnSfx = ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                        ResolveSoundPath("event:/game/05_mirror_temple/swapblock_return"), base.Center);
                }
            }

            var state = new MotionState(this);
            if (SwapBlockMotion.Advance(state, out Vector2 position))
            {
                if (position != Position) SwapBlockMotion.PositionChanged(state);
            }

            SwapBlockMotion.Complete(state);
        }

        private void MoveParticles(Vector2 normal)
        {
            SwapBlockMotion.EmitMovementParticles(this, engine, normal, ref particlesRemainder);
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 vector = SourceVector2Math.Add(Position, base.Shake);
            if (lerp != (float)target && speed > 0f)
            {
                Vector2 vector2 =
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(
                        SourceVector2Math.Subtract(end, start));
                if (target == 1)
                {
                    vector2 = SourceVector2Math.Multiply(vector2, -1f);
                }

                float num = speed / maxForwardSpeed;
                float num2 = 16f * num;
                for (int i = 2; (float)i < num2; i += 2)
                {
                    DrawBlockStyle(context, SourceVector2Math.Add(vector, SourceVector2Math.Multiply(vector2, i)),
                        base.Width, base.Height, nineSliceGreen, middleGreen,
                        PackedColor.White * (1f - (float)i / num2));
                }
            }

            if (redAlpha < 1f)
            {
                DrawBlockStyle(context, vector, base.Width, base.Height, nineSliceGreen, middleGreen,
                    PackedColor.White);
            }

            if (redAlpha > 0f)
            {
                DrawBlockStyle(context, vector, base.Width, base.Height, nineSliceRed, middleRed,
                    PackedColor.White * redAlpha);
            }
        }

        private void DrawBlockStyle(ISourceRenderContext context, Vector2 pos, float width, float height,
            AtlasEntry[,] ninSlice, Sprite middle, PackedColor color)
            => Rendering.SwapBlockDrawing.DrawBlockStyle(context, this, pos, width, height, ninSlice, middle, color);

        private readonly struct MotionState : ISwapBlockMotionState
        {
            private readonly OriginalSwapBlockState owner;

            public MotionState(OriginalSwapBlockState owner)
            {
                this.owner = owner;
            }

            public ISourceEngineContext Engine => owner.engine;
            public SourceSolidEntityState Solid => owner;
            public Vector2 Start => owner.start;
            public Vector2 End => owner.end;
            public float MaxForwardSpeed => owner.maxForwardSpeed;
            public float MaxBackwardSpeed => owner.maxBackwardSpeed;
            public Sprite MiddleRed => owner.middleRed;
            public Sprite MiddleGreen => owner.middleGreen;
            public ref bool Swapping => ref owner.Swapping;
            public ref int Target => ref owner.target;
            public ref float ReturnTimer => ref owner.returnTimer;
            public ref float Lerp => ref owner.lerp;
            public ref float Speed => ref owner.speed;
            public ref float RedAlpha => ref owner.redAlpha;
            public ref DisplacementBurst Burst => ref owner.burst;
            public ref ISourceAudioEventReference MoveSound => ref owner.moveSfx;
            public ref ISourceAudioEventReference ReturnSound => ref owner.returnSfx;
            public void EmitMovementParticles(Vector2 normal) => owner.MoveParticles(normal);
        }
    }
}
