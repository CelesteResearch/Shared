using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.Observation;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Diagnostics.Presentation
{
    public readonly struct SourceSpritePresentationQuad
    {
        // One captured, immutable state snapshot can be shared by all records in a batch.
        internal readonly struct HeaderSnapshot
        {
            internal readonly SourceRenderBatchState State;
            internal readonly object Target;
            internal readonly int TargetCount;
            internal readonly SourceNativeBlendState BlendState;
            internal readonly SourceNativeSamplerState SamplerState;
            internal readonly SourceNativeDepthStencilState DepthStencilState;
            internal readonly SourceNativeRasterizerState RasterizerState;

            internal HeaderSnapshot(in SourceRenderBatchState state, object target, int targetCount)
            {
                State = state;
                Target = target;
                TargetCount = targetCount;
                BlendState = state.Blend == null ? default : state.Blend.NativeState;
                SamplerState = state.Sampler == null ? default : state.Sampler.NativeState;
                DepthStencilState = state.DepthStencil == null ? default : state.DepthStencil.NativeState;
                RasterizerState = state.Rasterizer == null ? default : state.Rasterizer.NativeState;
            }

            // A false result may only forgo reuse (for example, due to padding bytes).
            // A true result must mean every exposed snapshot bit is identical.
            internal bool SameBits(in HeaderSnapshot other)
            {
                return State.SortMode == other.State.SortMode &&
                       ReferenceEquals(State.Blend, other.State.Blend) &&
                       ReferenceEquals(State.Sampler, other.State.Sampler) &&
                       ReferenceEquals(State.DepthStencil, other.State.DepthStencil) &&
                       ReferenceEquals(State.Rasterizer, other.State.Rasterizer) &&
                       ReferenceEquals(State.Effect, other.State.Effect) &&
                       ReferenceEquals(Target, other.Target) && TargetCount == other.TargetCount &&
                       BitEqual(in State.Transform, in other.State.Transform) &&
                       BitEqual(in BlendState, in other.BlendState) &&
                       BitEqual(in SamplerState, in other.SamplerState) &&
                       BitEqual(in DepthStencilState, in other.DepthStencilState) &&
                       BitEqual(in RasterizerState, in other.RasterizerState);
            }

            private static unsafe bool BitEqual<T>(in T a, in T b) where T : unmanaged
            {
                fixed (T* left = &a)
                fixed (T* right = &b)
                {
                    for (var i = 0; i < sizeof(T); i++)
                        if (((byte*)left)[i] != ((byte*)right)[i])
                            return false;
                }

                return true;
            }
        }

        internal sealed class Header
        {
            internal readonly HeaderSnapshot Value;

            internal Header(in HeaderSnapshot value)
            {
                Value = value;
            }
        }

        private static readonly Header EmptyHeader = new(default);

        // The original two triangles are 012, then 213. Consumers must retain
        // each triangle's eligibility before combining their presentation.
        public readonly bool IsPrimitiveTrianglePair;
        public readonly int UnsupportedPrimitiveCount;
        public readonly SourceTexture2DResource Texture;
        public readonly SourceSpriteQuad Quad;
        public readonly SourceRenderObservationScope Scope;

        internal Header HeaderRef { get; }

        public ref readonly SourceRenderBatchState State
        {
            get
            {
                var value = HeaderRef ?? EmptyHeader;
                return ref value.Value.State;
            }
        }

        public object Target => (HeaderRef ?? EmptyHeader).Value.Target;
        public int TargetCount => (HeaderRef ?? EmptyHeader).Value.TargetCount;

        public ref readonly SourceNativeBlendState BlendState
        {
            get
            {
                var value = HeaderRef ?? EmptyHeader;
                return ref value.Value.BlendState;
            }
        }

        public ref readonly SourceNativeSamplerState SamplerState
        {
            get
            {
                var value = HeaderRef ?? EmptyHeader;
                return ref value.Value.SamplerState;
            }
        }

        public ref readonly SourceNativeDepthStencilState DepthStencilState
        {
            get
            {
                var value = HeaderRef ?? EmptyHeader;
                return ref value.Value.DepthStencilState;
            }
        }

        public ref readonly SourceNativeRasterizerState RasterizerState
        {
            get
            {
                var value = HeaderRef ?? EmptyHeader;
                return ref value.Value.RasterizerState;
            }
        }

        internal SourceSpritePresentationQuad(in SourceSpritePresentationQuad template, in SourceSpriteQuad quad,
            bool isPrimitiveTrianglePair = false)
        {
            this = template;
            Quad = quad;
            IsPrimitiveTrianglePair = isPrimitiveTrianglePair;
        }

        internal SourceSpritePresentationQuad(in SourceSpritePresentationQuad template, int unsupportedPrimitiveCount)
        {
            this = template;
            IsPrimitiveTrianglePair = false;
            UnsupportedPrimitiveCount = unsupportedPrimitiveCount;
        }

        internal SourceSpritePresentationQuad(in SourceSpritePresentationQuad template,
            SourceTexture2DResource texture, in SourceSpriteQuad quad, in SourceRenderObservationScope owner)
        {
            IsPrimitiveTrianglePair = false;
            UnsupportedPrimitiveCount = 0;
            Texture = texture;
            Quad = quad;
            Scope = owner;
            HeaderRef = template.HeaderRef;
        }

        internal SourceSpritePresentationQuad(Header shared, SourceTexture2DResource texture,
            in SourceSpriteQuad quad, in SourceRenderObservationScope owner)
        {
            IsPrimitiveTrianglePair = false;
            UnsupportedPrimitiveCount = 0;
            Texture = texture;
            Quad = quad;
            Scope = owner;
            HeaderRef = shared;
        }

        public SourceSpritePresentationQuad(SourceTexture2DResource texture, in SourceSpriteQuad quad,
            in SourceRenderBatchState state, object target, int targetCount, in SourceRenderObservationScope scope)
        {
            IsPrimitiveTrianglePair = false;
            UnsupportedPrimitiveCount = 0;
            Texture = texture;
            Quad = quad;
            Scope = scope;
            var snapshot = new HeaderSnapshot(in state, target, targetCount);
            HeaderRef = new(in snapshot);
        }

        public unsafe bool Matches(in SourceSpritePresentationQuad other)
        {
            ref readonly var a = ref (HeaderRef ?? EmptyHeader).Value;
            ref readonly var b = ref (other.HeaderRef ?? EmptyHeader).Value;
            if (IsPrimitiveTrianglePair != other.IsPrimitiveTrianglePair ||
                UnsupportedPrimitiveCount != other.UnsupportedPrimitiveCount ||
                !ReferenceEquals(Texture, other.Texture) || !ReferenceEquals(a.Target, b.Target)
                || a.TargetCount != b.TargetCount ||
                Scope.EntityIndex != other.Scope.EntityIndex ||
                Scope.ComponentIndex != other.Scope.ComponentIndex
                || Scope.ComponentKind != other.Scope.ComponentKind ||
                !Scope.Owner.Matches(in other.Scope.Owner) ||
                !Scope.RenderPhase.Matches(in other.Scope.RenderPhase) ||
                a.State.SortMode != b.State.SortMode
                || !ReferenceEquals(a.State.Blend, b.State.Blend) ||
                !ReferenceEquals(a.State.Sampler, b.State.Sampler)
                || !ReferenceEquals(a.State.DepthStencil,
                    b.State.DepthStencil)
                || !ReferenceEquals(a.State.Rasterizer, b.State.Rasterizer)
                || !ReferenceEquals(a.State.Effect, b.State.Effect))
                return false;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (a.BlendState.colorSourceBlend != b.BlendState.colorSourceBlend
                || a.BlendState.colorDestinationBlend != b.BlendState.colorDestinationBlend
                || a.BlendState.colorBlendFunction != b.BlendState.colorBlendFunction
                || a.BlendState.alphaSourceBlend != b.BlendState.alphaSourceBlend
                || a.BlendState.alphaDestinationBlend != b.BlendState.alphaDestinationBlend
                || a.BlendState.alphaBlendFunction != b.BlendState.alphaBlendFunction
                || a.BlendState.colorWriteEnable != b.BlendState.colorWriteEnable
                || a.BlendState.colorWriteEnable1 != b.BlendState.colorWriteEnable1
                || a.BlendState.colorWriteEnable2 != b.BlendState.colorWriteEnable2
                || a.BlendState.colorWriteEnable3 != b.BlendState.colorWriteEnable3
                || a.BlendState.blendFactor != b.BlendState.blendFactor
                || a.BlendState.multiSampleMask != b.BlendState.multiSampleMask
                || a.SamplerState.filter != b.SamplerState.filter
                || a.SamplerState.addressU != b.SamplerState.addressU
                || a.SamplerState.addressV != b.SamplerState.addressV
                || a.SamplerState.addressW != b.SamplerState.addressW
                || a.SamplerState.mipMapLevelOfDetailBias != b.SamplerState.mipMapLevelOfDetailBias
                || a.SamplerState.maxAnisotropy != b.SamplerState.maxAnisotropy
                || a.SamplerState.maxMipLevel != b.SamplerState.maxMipLevel
                || a.DepthStencilState.depthBufferEnable != b.DepthStencilState.depthBufferEnable
                || a.DepthStencilState.depthBufferWriteEnable != b.DepthStencilState.depthBufferWriteEnable
                || a.DepthStencilState.depthBufferFunction != b.DepthStencilState.depthBufferFunction
                || a.DepthStencilState.stencilEnable != b.DepthStencilState.stencilEnable
                || a.DepthStencilState.stencilMask != b.DepthStencilState.stencilMask
                || a.DepthStencilState.stencilWriteMask != b.DepthStencilState.stencilWriteMask
                || a.DepthStencilState.twoSidedStencilMode != b.DepthStencilState.twoSidedStencilMode
                || a.DepthStencilState.stencilFail != b.DepthStencilState.stencilFail
                || a.DepthStencilState.stencilDepthBufferFail != b.DepthStencilState.stencilDepthBufferFail
                || a.DepthStencilState.stencilPass != b.DepthStencilState.stencilPass
                || a.DepthStencilState.stencilFunction != b.DepthStencilState.stencilFunction
                || a.DepthStencilState.ccwStencilFail != b.DepthStencilState.ccwStencilFail
                || a.DepthStencilState.ccwStencilDepthBufferFail != b.DepthStencilState.ccwStencilDepthBufferFail
                || a.DepthStencilState.ccwStencilPass != b.DepthStencilState.ccwStencilPass
                || a.DepthStencilState.ccwStencilFunction != b.DepthStencilState.ccwStencilFunction
                || a.DepthStencilState.referenceStencil != b.DepthStencilState.referenceStencil
                || a.RasterizerState.fillMode != b.RasterizerState.fillMode
                || a.RasterizerState.cullMode != b.RasterizerState.cullMode
                || /* ReSharper disable once CompareOfFloatsByEqualityOperator */ a.RasterizerState.depthBias != b.RasterizerState.depthBias
                || /* ReSharper disable once CompareOfFloatsByEqualityOperator */ a.RasterizerState.slopeScaleDepthBias != b.RasterizerState.slopeScaleDepthBias
                || a.RasterizerState.scissorTestEnable != b.RasterizerState.scissorTestEnable
                || a.RasterizerState.multiSampleAntiAlias != b.RasterizerState.multiSampleAntiAlias) return false;
            fixed (SourceSpriteQuad* quadA = &Quad)
            fixed (SourceSpriteQuad* quadB = &other.Quad)
            {
                var wordsA = (ulong*)quadA;
                var wordsB = (ulong*)quadB;
                for (var i = 0; i < sizeof(SourceSpriteQuad) / sizeof(ulong); i++)
                    if (wordsA[i] != wordsB[i])
                        return false;
            }

            fixed (Matrix4x4* transformA = &a.State.Transform)
            fixed (Matrix4x4* transformB = &b.State.Transform)
            {
                var wordsA = (ulong*)transformA;
                var wordsB = (ulong*)transformB;
                for (var i = 0; i < sizeof(Matrix4x4) / sizeof(ulong); i++)
                    if (wordsA[i] != wordsB[i])
                        return false;
                return true;
            }
        }
    }
}
