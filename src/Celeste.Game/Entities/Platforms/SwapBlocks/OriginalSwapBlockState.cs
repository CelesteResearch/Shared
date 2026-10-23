using System;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Framework;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Platforms.SwapBlocks.Motion;
using Celeste.Game.Entities.Platforms.SwapBlocks.Rendering;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.SwapBlocks;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;
using JetBrains.Annotations;

namespace Celeste.Game.Entities.Platforms.SwapBlocks
{
    public class OriginalSwapBlockState : SourceSolidEntityState, ISwapBlockSoundResolver,
        ISourceSwapBlock
    {
        public enum Themes
        {
            Normal,
            Moon,
        }

        public class PathRenderer : SceneEntityState
        {
            private readonly OriginalSwapBlockState block;

            public ISourceEngineContext EngineContext => block.engine;

            private readonly AtlasEntry pathTexture;

            private readonly AtlasEntry clipTexture = new();

            private float timer;

            public PathRenderer(OriginalSwapBlockState block)
                : base(((ISourceEntitySourceDataEnvironment)block.engine).EntitySourceDataRegistration, block.Position)
            {
                this.block = block;
                Depth = 8999;
                pathTexture =
                    ((ISourceGameGraphicsEnvironment)block.engine).GameGraphics.GameAtlas[
                        block.ResolvePathTexturePrefix("objects/swapblock/path") +
                        (block.start.X == block.end.X ? "V" : "H")];
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
                    for (var i = block.moveRect.Left; i < block.moveRect.Right; i += pathTexture.FrameWidth)
                    for (var j = block.moveRect.Top; j < block.moveRect.Bottom; j += pathTexture.FrameHeight)
                    {
                        pathTexture.GetSubtexture(0, 0, Math.Min(pathTexture.FrameWidth, block.moveRect.Right - i),
                            Math.Min(pathTexture.FrameHeight, block.moveRect.Bottom - j), clipTexture);
                        SourceAtlasDrawing.DrawCentered(context, this, clipTexture,
                            new(i + clipTexture.FrameWidth / 2, j + clipTexture.FrameHeight / 2),
                            PackedColor.White);
                    }

                var num = 0.5f * (0.5f + ((float)Math.Sin(timer) + 1f) * 0.25f);
                block.DrawBlockStyle(context, new(block.moveRect.X, block.moveRect.Y), block.moveRect.Width,
                    block.moveRect.Height, block.nineSliceTarget, null, PackedColor.White * num);
            }
        }


        private const float ReturnTime = 0.8f;

        public Vector2 Direction;

        public bool Swapping;

        Vector2 ISourceSwapBlock.Direction => Direction;
        bool ISourceSwapBlock.Swapping => Swapping;

        public Themes Theme;

        public ISourceEngineContext EngineContext => engine;
        public int MovementTarget => target;
        public Vector2 MovementEnd => end;
        public IntRect MovementBounds => moveRect;
        public ref float SourceRedAlpha => ref redAlpha;
        public ISourceAudioEventReference MovementSound => moveSfx;
        public ISourceAudioEventReference ReturnSound => returnSfx;

        private readonly Vector2 start;

        private readonly Vector2 end;

        private float lerp;

        private int target;

        private IntRect moveRect;

        private float speed;

        private readonly float maxForwardSpeed;

        private readonly float maxBackwardSpeed;

        private float returnTimer;

        private float redAlpha = 1f;

        private readonly AtlasEntry[,] nineSliceGreen;

        private readonly AtlasEntry[,] nineSliceRed;

        private readonly AtlasEntry[,] nineSliceTarget;

        private PathRenderer path;

        private ISourceAudioEventReference moveSfx;

        private ISourceAudioEventReference returnSfx;

        private DisplacementBurst burst;

        private float particlesRemainder;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private readonly ISourceEngineContext engine;

        private readonly string pathTextureRoot;
        protected Sprite SourceMiddleGreen { get; }

        protected Sprite SourceMiddleRed { get; }

        protected virtual string ResolveSoundPath(string path)
        {
            return path;
        }

        protected virtual string ResolvePathTexturePrefix(string prefix)
        {
            return pathTextureRoot ?? prefix;
        }

        string ISwapBlockSoundResolver.ResolveSwapBlockSoundPath(string path)
        {
            return ResolveSoundPath(path);
        }

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
                OnDash = OnDash,
            });
            var num = (int)SourceFrameworkMath.Min(X, node.X);
            var num2 = (int)SourceFrameworkMath.Min(Y, node.Y);
            var num3 = (int)SourceFrameworkMath.Max(X + Width, node.X + Width);
            var num4 = (int)SourceFrameworkMath.Max(Y + Height, node.Y + Height);
            moveRect = new(num, num2, num3 - num, num4 - num2);
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
            for (var i = 0; i < 3; i++)
            for (var j = 0; j < 3; j++)
            {
                nineSliceGreen[i, j] = mTexture.GetSubtexture(i * 8, j * 8, 8, 8);
                nineSliceRed[i, j] = mTexture2.GetSubtexture(i * 8, j * 8, 8, 8);
                nineSliceTarget[i, j] = mTexture3.GetSubtexture(i * 8, j * 8, 8, 8);
            }

            if (Theme == Themes.Normal)
            {
                OwnedComponents.Add(SourceMiddleGreen =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("swapBlockLight"));
                OwnedComponents.Add(SourceMiddleRed =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("swapBlockLightRed"));
            }
            else if (Theme == Themes.Moon)
            {
                OwnedComponents.Add(SourceMiddleGreen =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("swapBlockLightMoon"));
                OwnedComponents.Add(SourceMiddleRed =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory
                    .Create("swapBlockLightRedMoon"));
            }

            OwnedComponents.Add(new LightOccludeState(0.2f));
            Depth = -9999;
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
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(path = new(this));
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
                        ResolveSoundPath("event:/game/05_mirror_temple/swapblock_return"), Center);
                }
            }

            var state = new MotionState(this);
            if (SwapBlockMotion.Advance(state, out var position))
                if (position != Position)
                    SwapBlockMotion.PositionChanged(state);

            SwapBlockMotion.Complete(state);
        }

        private void MoveParticles(Vector2 normal)
        {
            SwapBlockMotion.EmitMovementParticles(this, engine, normal, ref particlesRemainder);
        }

        public override void Render(ISourceRenderContext context)
        {
            var vector = SourceVector2Math.Add(Position, Shake);
            if (lerp != target && speed > 0f)
            {
                var vector2 =
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(
                        SourceVector2Math.Subtract(end, start));
                if (target == 1) vector2 = SourceVector2Math.Multiply(vector2, -1f);

                var num = speed / maxForwardSpeed;
                var num2 = 16f * num;
                for (var i = 2; i < num2; i += 2)
                    DrawBlockStyle(context, SourceVector2Math.Add(vector, SourceVector2Math.Multiply(vector2, i)),
                        Width, Height, nineSliceGreen, SourceMiddleGreen,
                        PackedColor.White * (1f - i / num2));
            }

            if (redAlpha < 1f)
                DrawBlockStyle(context, vector, Width, Height, nineSliceGreen, SourceMiddleGreen,
                    PackedColor.White);

            if (redAlpha > 0f)
                DrawBlockStyle(context, vector, Width, Height, nineSliceRed, SourceMiddleRed,
                    PackedColor.White * redAlpha);
        }

        private void DrawBlockStyle(ISourceRenderContext context, Vector2 pos, float width, float height,
            AtlasEntry[,] ninSlice, Sprite middle, PackedColor color)
        {
            SwapBlockDrawing.DrawBlockStyle(context, this, pos, width, height, ninSlice, middle, color);
        }

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
            public Sprite MiddleRed => owner.SourceMiddleRed;
            public Sprite MiddleGreen => owner.SourceMiddleGreen;
            public ref bool Swapping => ref owner.Swapping;
            public ref int Target => ref owner.target;
            public ref float ReturnTimer => ref owner.returnTimer;
            public ref float Lerp => ref owner.lerp;
            public ref float Speed => ref owner.speed;
            public ref float RedAlpha => ref owner.redAlpha;
            public ref DisplacementBurst Burst => ref owner.burst;
            public ref ISourceAudioEventReference MoveSound => ref owner.moveSfx;
            public ref ISourceAudioEventReference ReturnSound => ref owner.returnSfx;

            public void EmitMovementParticles(Vector2 normal)
            {
                owner.MoveParticles(normal);
            }
        }
    }
}
