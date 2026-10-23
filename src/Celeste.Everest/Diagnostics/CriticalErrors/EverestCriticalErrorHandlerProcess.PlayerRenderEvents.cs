using System;
using System.Numerics;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public sealed partial class EverestCriticalErrorHandlerProcess
    {
        public delegate void BeforePlayerRenderHandler(ref SourceSpriteSortMode sortMode,
            ref SourceBlendState blendState, ref SourceSamplerState samplerState,
            ref SourceDepthStencilState depthStencilState, ref SourceRasterizerState rasterizerState,
            ref SourceEffect effect, ref Matrix4x4 matrix);

        public event BeforePlayerRenderHandler OnBeforePlayerRender;
        public event Action OnAfterPlayerRender;

        internal void BeforePlayerRender(ref SourceSpriteSortMode sortMode,
            ref SourceBlendState blendState, ref SourceSamplerState samplerState,
            ref SourceDepthStencilState depthStencilState, ref SourceRasterizerState rasterizerState,
            ref SourceEffect effect, ref Matrix4x4 matrix)
        {
            OnBeforePlayerRender?.Invoke(ref sortMode, ref blendState, ref samplerState,
                ref depthStencilState, ref rasterizerState, ref effect, ref matrix);
        }

        internal void AfterPlayerRender()
        {
            OnAfterPlayerRender?.Invoke();
        }
    }
}
