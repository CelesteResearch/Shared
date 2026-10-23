using System;
using System.Numerics;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.Resources;
using Celeste.Core.Rendering.Sprites;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Diagnostics.Presentation;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Batches
{
    public partial class SourceSpriteBatch : SourceGraphicsResource
    {
        private readonly SourceSpriteBatchProcess process;
        private readonly SourceGraphicsDevice device;
        private readonly SourceDynamicVertexBuffer vertexBuffer;
        private readonly SourceIndexBuffer indexBuffer;
        private readonly SourceEffect spriteEffect;
        private readonly SourceEffectParameter spriteMatrixTransform;
        private readonly SourceEffectPass spriteEffectPass;
        private readonly bool supportsNoOverwrite;
        private SourceSpriteQuad[] vertexInfo;
        private SourceTexture2DResource[] textureInfo;
        private SourceSpriteInfo[] spriteInfos;
        private IntPtr[] sortedSpriteInfos;
        private SourceRenderBatchState state;

        private bool beginCalled;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public bool IsBatchOpen => beginCalled;
        public SourceRenderBatchState CurrentState => state;
        private int numSprites;
        private int bufferOffset;

        public SourceSpriteBatch(SourceGraphicsDevice device, SourceSpriteBatchProcess process)
        {
            process.EnsureInitialized();
            this.process = process;
            if (device == null) throw new ArgumentNullException("graphicsDevice");
            this.device = device;
            GraphicsDevice = device;
            vertexInfo = new SourceSpriteQuad[2048];
            textureInfo = new SourceTexture2DResource[2048];
            spriteInfos = new SourceSpriteInfo[2048];
            sortedSpriteInfos = new IntPtr[2048];
            vertexBuffer = new(device, typeof(SourceVertexPositionColorTexture), 8192,
                SourceBufferUsage.WriteOnly);
            indexBuffer =
                new(device, SourceIndexElementSize.SixteenBits, 12288, SourceBufferUsage.WriteOnly);
            indexBuffer.SetData(process.IndexData);
            spriteEffect = new(device, process.SpriteEffectCode);
            spriteMatrixTransform = spriteEffect.Parameters["MatrixTransform"] ?? throw new NullReferenceException();
            spriteEffectPass = spriteEffect.CurrentTechnique.Passes[0];
            beginCalled = false;
            numSprites = 0;
            supportsNoOverwrite = device.PhysicalIO.SupportsNoOverwrite() == 1;
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                spriteEffect.Dispose();
                indexBuffer.Dispose();
                vertexBuffer.Dispose();
            }

            base.Dispose(disposing);
        }

        public void Begin(in SourceRenderBatchState nextState)
        {
            if (IsBatchOpen)
                throw new InvalidOperationException(
                    "Begin has been called before calling End after the last call to Begin. Begin cannot be called again until End has been successfully called.");
            beginCalled = true;
            state = new(nextState.SortMode,
                nextState.Blend ?? SourceBlendState.AlphaBlend,
                nextState.Sampler ?? SourceSamplerState.LinearClamp,
                nextState.DepthStencil ?? SourceDepthStencilState.None,
                nextState.Rasterizer ?? SourceRasterizerState.CullCounterClockwise,
                nextState.Effect, nextState.Transform);
            if (state.SortMode == SourceSpriteSortMode.Immediate) PrepareRenderState();
        }

        public void End()
        {
            if (!IsBatchOpen)
                throw new InvalidOperationException(
                    "End was called, but Begin has not yet been called. You must call Begin  successfully before you can call End.");
            beginCalled = false;
            if (state.SortMode != SourceSpriteSortMode.Immediate) FlushBatch();
            state = new(state.SortMode, state.Blend, state.Sampler,
                state.DepthStencil, state.Rasterizer, null, state.Transform);
        }

        public void Draw(SourceTexture2DResource actualTexture, in SourceSpriteInfo sprite)
        {
            CheckBegin("Draw");
            PushSprite(actualTexture,
                sprite.SourceX, sprite.SourceY, sprite.SourceWidth, sprite.SourceHeight, sprite.DestinationX,
                sprite.DestinationY, sprite.DestinationWidth, sprite.DestinationHeight, sprite.Color, sprite.OriginX,
                sprite.OriginY, sprite.RotationSin, sprite.RotationCos, sprite.Depth, sprite.Effects);
        }

        private unsafe void PushSprite(SourceTexture2DResource texture, float sourceX, float sourceY, float sourceW,
            float sourceH,
            float destinationX, float destinationY, float destinationW, float destinationH, uint color,
            float originX, float originY, float rotationSin, float rotationCos, float depth, byte effects)
        {
            if (numSprites >= vertexInfo.Length)
            {
                if (vertexInfo.Length >= 699050)
                {
                    FlushBatch();
                }
                else
                {
                    var size = Math.Min(vertexInfo.Length * 2, 699050);
                    Array.Resize(ref vertexInfo, size);
                    Array.Resize(ref textureInfo, size);
                    Array.Resize(ref spriteInfos, size);
                    Array.Resize(ref sortedSpriteInfos, size);
                }
            }

            if (state.SortMode == SourceSpriteSortMode.Immediate)
            {
                SourceSpriteGeometry.Generate(ref vertexInfo[0],
                    sourceX, sourceY, sourceW, sourceH,
                    destinationX, destinationY, destinationW, destinationH,
                    color, originX, originY, rotationSin, rotationCos, depth,
                    effects);
                var immediateCapture = ActivePresentationCapture;
                if (immediateCapture != null)
                {
                    var owner = immediateCapture.CurrentScopeRef;
                    immediateCapture.Record(texture, in vertexInfo[0], in state, device.CurrentRenderTarget,
                        device.renderTargetCount, in owner);
                }

                var immediateLayer = PresentationCapture?.CameraLayer;
                if (immediateLayer?.IsRecording == true)
                    immediateLayer.Record(texture, in vertexInfo[0], in state, device.CurrentRenderTarget,
                        device.renderTargetCount);

                int baseSprite;
                if (supportsNoOverwrite)
                {
                    baseSprite = UpdateVertexBuffer(0, 1);
                }
                else
                {
                    baseSprite = 0;
                    fixed (SourceSpriteQuad* vertices = &vertexInfo[0])
                    {
                        vertexBuffer.SetDataPointerEXT(0, (IntPtr)vertices, 96, SourceSetDataOptions.None);
                    }
                }

                DrawPrimitives(texture, baseSprite, 1);
                return;
            }

            if (state.SortMode == SourceSpriteSortMode.Deferred)
            {
                SourceSpriteGeometry.Generate(ref vertexInfo[numSprites],
                    sourceX, sourceY, sourceW, sourceH,
                    destinationX, destinationY, destinationW, destinationH,
                    color, originX, originY, rotationSin, rotationCos, depth,
                    effects);
            }
            else
            {
                spriteInfos[numSprites].SourceX = sourceX;
                spriteInfos[numSprites].SourceY = sourceY;
                spriteInfos[numSprites].SourceWidth = sourceW;
                spriteInfos[numSprites].SourceHeight = sourceH;
                spriteInfos[numSprites].DestinationX = destinationX;
                spriteInfos[numSprites].DestinationY = destinationY;
                spriteInfos[numSprites].DestinationWidth = destinationW;
                spriteInfos[numSprites].DestinationHeight = destinationH;
                spriteInfos[numSprites].Color = color;
                spriteInfos[numSprites].OriginX = originX;
                spriteInfos[numSprites].OriginY = originY;
                spriteInfos[numSprites].RotationSin = rotationSin;
                spriteInfos[numSprites].RotationCos = rotationCos;
                spriteInfos[numSprites].Depth = depth;
                spriteInfos[numSprites].Effects = effects;
                spriteInfos[numSprites].TextureHash = texture.GetHashCode();
            }

            var capture = ActivePresentationCapture;
            if (capture != null)
            {
                EnsurePresentationScopes();
                presentationScopes[numSprites] = capture.CurrentScopeRef;
            }

            textureInfo[numSprites] = texture;
            numSprites++;
        }

        private void DrawPrimitives(SourceTexture2DResource actualTexture, int baseSprite, int count)
        {
            SourceFrameDiagnostics.Current?.RecordSpriteBatchGroup(count);
            if (state.Effect != null)
            {
                foreach (var pass in ((SourceEffect)state.Effect).CurrentTechnique.Passes)
                {
                    pass.Apply();
                    device.Textures[0] = actualTexture;
                    var difference = PresentationCapture?.GameplayDifference;
                    if (difference?.IsRecording == true) DrawObservedPrimitives(difference, baseSprite, count);
                    else
                        device.DrawIndexedPrimitives(SourcePrimitiveType.TriangleList, unchecked(baseSprite * 4), 0,
                            unchecked(count * 4), 0, unchecked(count * 2));
                }

                return;
            }

            device.Textures[0] = actualTexture;
            var plainDifference = PresentationCapture?.GameplayDifference;
            if (plainDifference?.IsRecording == true) DrawObservedPrimitives(plainDifference, baseSprite, count);
            else
                device.DrawIndexedPrimitives(SourcePrimitiveType.TriangleList, unchecked(baseSprite * 4), 0,
                    unchecked(count * 4), 0, unchecked(count * 2));
        }

        private void DrawObservedPrimitives(
            SourceCameraPresentationDifference difference,
            int baseSprite, int count)
        {
            var blend = device.BlendState;
            var nativeBlend = blend == null ? default : blend.NativeState;
            var target = device.CurrentRenderTarget;
            var targetCount = device.renderTargetCount;
            device.DrawIndexedPrimitives(SourcePrimitiveType.TriangleList, unchecked(baseSprite * 4), 0,
                unchecked(count * 4), 0, unchecked(count * 2));
            difference.Observe(in nativeBlend, blend != null, target, targetCount, count);
        }

        private void PrepareRenderState()
        {
            device.BlendState = state.Blend;
            device.SamplerStates[0] = state.Sampler;
            device.DepthStencilState = state.DepthStencil;
            device.RasterizerState = state.Rasterizer;
            device.SetVertexBuffer(vertexBuffer);
            device.Indices = indexBuffer;
            var viewport = device.Viewport;
            var width = viewport.Width;
            var height = viewport.Height;
            var transform = new SourceSpriteShaderTransform(state.Transform, width, height);
            spriteMatrixTransform.SetValueTranspose(new Matrix4x4(
                transform.Value0, transform.Value1, transform.Value2, transform.Value3,
                transform.Value4, transform.Value5, transform.Value6, transform.Value7,
                transform.Value8, transform.Value9, transform.Value10, transform.Value11,
                transform.Value12, transform.Value13, transform.Value14, transform.Value15));
            spriteEffectPass.Apply();
        }

        private unsafe void FlushBatch()
        {
            var diagnostics = SourceFrameDiagnostics.Current;
            long flushStarted = 0;
            var measuringFlush = diagnostics?.BeginSpriteBatchFlush(out flushStarted) ?? false;
            try
            {
                PrepareRenderState();
                if (numSprites == 0) return;
                var capture = ActivePresentationCapture;
                if (state.SortMode != SourceSpriteSortMode.Deferred)
                {
                    var comparer = state.SortMode == SourceSpriteSortMode.Texture
                        ? process.TextureCompare
                        : state.SortMode == SourceSpriteSortMode.BackToFront
                            ? process.BackToFrontCompare
                            : process.FrontToBackCompare;
                    fixed (SourceSpriteInfo* source = &spriteInfos[0])
                    {
                        fixed (IntPtr* sorted = &sortedSpriteInfos[0])
                        {
                            fixed (SourceSpriteQuad* vertices = &vertexInfo[0])
                            {
                                for (var index = 0; index < numSprites; index++)
                                    sorted[index] = (IntPtr)(source + index);

                                Array.Sort(sortedSpriteInfos, textureInfo, 0, numSprites, comparer);
                                for (var index = 0; index < numSprites; index++)
                                {
                                    var sprite = (SourceSpriteInfo*)sorted[index];
                                    sprite->Generate(ref vertices[index]);
                                    if (capture != null)
                                        sortedPresentationScopes[index] = presentationScopes[(int)(sprite - source)];
                                }
                            }
                        }
                    }
                }

                if (capture != null)
                {
                    var owners = state.SortMode == SourceSpriteSortMode.Deferred
                        ? presentationScopes
                        : sortedPresentationScopes;
                    var target = device.CurrentRenderTarget;
                    capture.RecordBatch(textureInfo, vertexInfo, owners, numSprites, in state, target,
                        device.renderTargetCount);
                }

                var cameraLayer = PresentationCapture?.CameraLayer;
                if (cameraLayer?.IsRecording == true)
                    cameraLayer.RecordBatch(textureInfo, vertexInfo, numSprites, in state,
                        device.CurrentRenderTarget, device.renderTargetCount);

                var start = 0;
                while (true)
                {
                    var count = Math.Min(numSprites, 2048);
                    var destination = UpdateVertexBuffer(start, count);
                    if (state.Effect != null || PresentationCapture?.GameplayDifference?.IsRecording == true ||
                        !device.TryDrawSpriteGroups(textureInfo, start, count, destination))
                    {
                        var first = 0;
                        var texture = textureInfo[start];
                        for (var i = 1; i < count; i++)
                        {
                            var next = textureInfo[start + i];
                            if (!ReferenceEquals(next, texture))
                            {
                                DrawPrimitives(texture, destination + first, i - first);
                                texture = next;
                                first = i;
                            }
                        }

                        DrawPrimitives(texture, destination + first, count - first);
                    }

                    if (numSprites <= 2048) break;
                    numSprites -= 2048;
                    start += 2048;
                }

                numSprites = 0;
            }
            finally
            {
                if (measuringFlush) diagnostics.EndSpriteBatchFlush(flushStarted);
            }
        }

        private unsafe int UpdateVertexBuffer(int start, int count)
        {
            int destination;
            SourceSetDataOptions mode;
            if (bufferOffset + count > 2048 || !supportsNoOverwrite)
            {
                destination = 0;
                mode = SourceSetDataOptions.Discard;
            }
            else
            {
                destination = bufferOffset;
                mode = SourceSetDataOptions.NoOverwrite;
            }

            fixed (SourceSpriteQuad* vertices = &vertexInfo[start])
            {
                vertexBuffer.SetDataPointerEXT(destination * 96, (IntPtr)vertices, count * 96, mode);
            }

            bufferOffset = destination + count;
            return destination;
        }
    }
}
