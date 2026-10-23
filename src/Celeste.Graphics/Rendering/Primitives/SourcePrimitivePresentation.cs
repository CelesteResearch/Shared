using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Content;
using Celeste.Graphics.Diagnostics.Presentation;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Primitives
{
    internal static class SourcePrimitivePresentation
    {
        internal readonly struct Observation
        {
            private readonly SourceSpritePresentationCapture capture;
            private readonly SourceSpritePresentationQuad template;
            private readonly Vector2 uv;
            private readonly bool supported;
            private readonly bool hasMetadata;
            private readonly bool textured;

            internal Observation(SourceSpritePresentationCapture capture)
            {
                this.capture = capture;
                template = default;
                uv = default;
                supported = false;
                hasMetadata = false;
                textured = false;
            }

            internal Observation(SourceSpritePresentationCapture capture,
                in SourceSpritePresentationQuad template, Vector2 uv, bool supported = true, bool textured = false)
            {
                this.capture = capture;
                this.template = template;
                this.uv = uv;
                this.supported = supported;
                hasMetadata = true;
                this.textured = textured;
            }

            private void RecordUnsupported(int primitiveCount)
            {
                if (hasMetadata) capture.RecordUnsupported(in template, primitiveCount);
                else capture.RecordDropped(primitiveCount);
            }

            [MethodImpl(MethodImplOptions
                .AggressiveInlining)]
            private static unsafe bool Finite(Vector2 value)
            {
                var words = (uint*)&value;
                return (words[0] & 0x7f800000) != 0x7f800000 && (words[1] & 0x7f800000) != 0x7f800000;
            }

            [MethodImpl(MethodImplOptions
                .AggressiveInlining)]
            private static unsafe bool FiniteVertex(in SourceVertexPositionColor value)
            {
                fixed (SourceVertexPositionColor* vertex = &value)
                {
                    var words = (uint*)vertex;
                    return (words[0] & 0x7f800000) != 0x7f800000 &&
                           (words[1] & 0x7f800000) != 0x7f800000 &&
                           (words[2] & 0x7f800000) != 0x7f800000;
                }
            }

            [MethodImpl(MethodImplOptions
                .AggressiveInlining)]
            private static unsafe bool FiniteVertex(in SourceVertexPositionColorTexture value)
            {
                fixed (SourceVertexPositionColorTexture* vertex = &value)
                {
                    var words = (uint*)vertex;
                    return (words[0] & 0x7f800000) != 0x7f800000 &&
                           (words[1] & 0x7f800000) != 0x7f800000 &&
                           (words[2] & 0x7f800000) != 0x7f800000 &&
                           (words[4] & 0x7f800000) != 0x7f800000 &&
                           (words[5] & 0x7f800000) != 0x7f800000;
                }
            }

            [MethodImpl(MethodImplOptions
                .AggressiveInlining)]
            private static unsafe bool SameVertex(in SourceVertexPositionColor a, in SourceVertexPositionColor b)
            {
                fixed (SourceVertexPositionColor* left = &a)
                fixed (SourceVertexPositionColor* right = &b)
                {
                    var wordsA = (uint*)left;
                    var wordsB = (uint*)right;
                    return wordsA[0] == wordsB[0] && wordsA[1] == wordsB[1] &&
                           wordsA[2] == wordsB[2] && wordsA[3] == wordsB[3];
                }
            }

            [MethodImpl(MethodImplOptions
                .AggressiveInlining)]
            private static unsafe bool SameVertex(in SourceVertexPositionColorTexture a,
                in SourceVertexPositionColorTexture b)
            {
                fixed (SourceVertexPositionColorTexture* left = &a)
                fixed (SourceVertexPositionColorTexture* right = &b)
                {
                    var wordsA = (uint*)left;
                    var wordsB = (uint*)right;
                    return wordsA[0] == wordsB[0] && wordsA[1] == wordsB[1] &&
                           wordsA[2] == wordsB[2] && wordsA[3] == wordsB[3] &&
                           wordsA[4] == wordsB[4] && wordsA[5] == wordsB[5];
                }
            }

            internal void Record<T>(T[] vertices, int vertexCount, int[] indices, int primitiveCount)
                where T : struct, ISourceVertexType
            {
                if (capture == null || !capture.IsRecording || primitiveCount <= 0) return;
                if (!supported ||
                    (textured
                        ? typeof(T) != typeof(SourceVertexPositionColorTexture)
                        : typeof(T) != typeof(SourceVertexPositionColor)) || vertices == null ||
                    vertexCount < 0 || vertexCount > vertices.Length || primitiveCount > int.MaxValue / 3)
                {
                    RecordUnsupported(primitiveCount);
                    return;
                }

                var count = primitiveCount * 3;
                if (indices == null ? count > vertexCount : count > indices.Length)
                {
                    RecordUnsupported(primitiveCount);
                    return;
                }

                if (indices != null)
                    for (var i = 0; i < count; i++)
                        if ((uint)indices[i] >= (uint)vertexCount)
                        {
                            RecordUnsupported(primitiveCount);
                            return;
                        }

                if (textured)
                {
                    var texturedSource =
                        MemoryMarshal.Cast<T, SourceVertexPositionColorTexture>(vertices.AsSpan(0, vertexCount));
                    for (var i = 0; i < count; i += 3)
                    {
                        ref readonly var a = ref texturedSource[indices == null ? i : indices[i]];
                        ref readonly var b = ref texturedSource[indices == null ? i + 1 : indices[i + 1]];
                        ref readonly var c = ref texturedSource[indices == null ? i + 2 : indices[i + 2]];
                        var d = c;
                        var paired = false;
                        if (i + 3 < count)
                        {
                            ref readonly var nextA = ref texturedSource[indices == null ? i + 3 : indices[i + 3]];
                            ref readonly var nextB = ref texturedSource[indices == null ? i + 4 : indices[i + 4]];
                            ref readonly var nextC = ref texturedSource[indices == null ? i + 5 : indices[i + 5]];
                            paired = SameVertex(in c, in nextA) && SameVertex(in b, in nextB) && FiniteVertex(in a) &&
                                     FiniteVertex(in b) && FiniteVertex(in c) && FiniteVertex(in nextC);
                            if (paired)
                            {
                                d = nextC;
                                i += 3;
                            }
                        }

                        var quad = new SourceSpriteQuad
                        {
                            Position0 = a.Position, Position1 = b.Position,
                            Position2 = c.Position, Position3 = d.Position,
                            Color0 = a.Color.PackedValue, Color1 = b.Color.PackedValue,
                            Color2 = c.Color.PackedValue, Color3 = d.Color.PackedValue,
                            TextureCoordinate0 = a.TextureCoordinate, TextureCoordinate1 = b.TextureCoordinate,
                            TextureCoordinate2 = c.TextureCoordinate, TextureCoordinate3 = d.TextureCoordinate,
                        };
                        capture.RecordPrepared(in template, in quad, paired);
                    }

                    return;
                }

                var source = MemoryMarshal.Cast<T, SourceVertexPositionColor>(vertices.AsSpan(0, vertexCount));
                for (var i = 0; i < count; i += 3)
                {
                    ref readonly var a = ref source[indices == null ? i : indices[i]];
                    ref readonly var b = ref source[indices == null ? i + 1 : indices[i + 1]];
                    ref readonly var c = ref source[indices == null ? i + 2 : indices[i + 2]];
                    var d = c;
                    var paired = false;
                    if (i + 3 < count)
                    {
                        ref readonly var nextA = ref source[indices == null ? i + 3 : indices[i + 3]];
                        ref readonly var nextB = ref source[indices == null ? i + 4 : indices[i + 4]];
                        ref readonly var nextC = ref source[indices == null ? i + 5 : indices[i + 5]];
                        paired = SameVertex(in c, in nextA) && SameVertex(in b, in nextB) && FiniteVertex(in a) &&
                                 FiniteVertex(in b) && FiniteVertex(in c) && FiniteVertex(in nextC) && Finite(uv);
                        if (paired)
                        {
                            d = nextC;
                            i += 3;
                        }
                    }

                    var quad = new SourceSpriteQuad
                    {
                        Position0 = a.Position, Position1 = b.Position,
                        Position2 = c.Position, Position3 = d.Position,
                        Color0 = a.Color.PackedValue, Color1 = b.Color.PackedValue,
                        Color2 = c.Color.PackedValue, Color3 = d.Color.PackedValue,
                        TextureCoordinate0 = uv, TextureCoordinate1 = uv,
                        TextureCoordinate2 = uv, TextureCoordinate3 = uv,
                    };
                    capture.RecordPrepared(in template, in quad, paired);
                }
            }
        }

        internal static Observation Prepare(ISourcePrimitiveGraphicsDevice source, Matrix4x4 transform,
            Vector2 projectionViewport, SourceEffect effect)
        {
            if (source is not ISourceDrawScope drawScope) return default;
            var draw = drawScope.Draw;
            var capture = draw?.SpriteBatch?.ActivePresentationCapture;
            if (capture == null || !capture.IsRecording) return default;
            if (source is not ISourceGraphicsDeviceEnvironment environment) return new(capture);
            var device = environment.GraphicsDevice;
            var primitive = ReferenceEquals(effect, source.FxPrimitive);
            var textured = source is ISourceGameGraphicsEnvironment graphics &&
                           graphics.GameGraphics is ISourceBackdropEffectResources resources &&
                           ReferenceEquals(effect, resources.FxTexture);
            var pixel = primitive ? draw.Pixel : null;
            // Raw field only: observing primitives must never load a virtual texture or change GPU state.
            var texture = textured ? device.Textures[0] as SourceTexture2DResource : pixel?.Texture?.Texture;
            var sampler = textured ? device.SamplerStates[0] : SourceSamplerState.PointClamp;
            var state = new SourceRenderBatchState(SourceSpriteSortMode.Deferred, device.BlendState,
                sampler, device.DepthStencilState, device.RasterizerState,
                primitive || textured ? null : effect, transform);
            var quad = default(SourceSpriteQuad);
            var owner = capture.CurrentScopeRef;
            var initialSnapshot = new SourceSpritePresentationQuad.HeaderSnapshot(in state,
                device.CurrentRenderTarget, device.renderTargetCount);
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if ((!primitive && !textured) || texture == null || texture.IsDisposed ||
                projectionViewport.X == 0 || projectionViewport.Y == 0 ||
                transform.M14 != 0 || transform.M24 != 0 || transform.M34 != 0 || transform.M44 != 1)
            {
                var unsupportedTemplate = capture.CreateTemplate(texture, in quad, in initialSnapshot, in owner);
                return new(capture, in unsupportedTemplate, default, false);
            }

            var viewport = device.Viewport;
            // The actual viewport scales/offsets the original projected pixel coordinates.
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (viewport.Width != projectionViewport.X || /* ReSharper disable once CompareOfFloatsByEqualityOperator */
                viewport.Height != projectionViewport.Y)
                transform = SourceMatrixMath.Multiply(transform,
                    SourceMatrixMath.CreateScale(viewport.Width / projectionViewport.X,
                        viewport.Height / projectionViewport.Y, 1f));
            if (viewport.X != 0 || viewport.Y != 0)
                transform = SourceMatrixMath.Multiply(transform,
                    SourceMatrixMath.CreateTranslation(viewport.X, viewport.Y, 0f));
            state = new(SourceSpriteSortMode.Deferred, device.BlendState,
                sampler, device.DepthStencilState, device.RasterizerState, null, transform);
            var finalSnapshot = new SourceSpritePresentationQuad.HeaderSnapshot(in state,
                device.CurrentRenderTarget, device.renderTargetCount);
            var template = capture.CreateTemplate(texture, in quad, in finalSnapshot, in owner);
            return new(capture, in template,
                textured ? default : new Vector2((pixel.X + .5f) / texture.Width, (pixel.Y + .5f) / texture.Height),
                textured: textured);
        }
    }
}
