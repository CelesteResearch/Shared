using Celeste.Core.Rendering;
using System;

namespace Celeste.Graphics.Rendering.Textures
{
    public struct SourceRenderTargetBinding
    {
        private readonly SourceTextureResource renderTarget;

        private readonly SourceCubeMapFace cubeMapFace;

        public SourceTextureResource RenderTarget => renderTarget;

        public SourceCubeMapFace CubeMapFace => cubeMapFace;

        public SourceRenderTargetBinding(SourceRenderTarget2DResource renderTarget)
        {
            if (renderTarget == null)
            {
                throw new ArgumentNullException("renderTarget");
            }

            this.renderTarget = renderTarget;
            cubeMapFace = SourceCubeMapFace.PositiveX;
        }

        public SourceRenderTargetBinding(SourceRenderTargetCubeResource renderTarget, SourceCubeMapFace cubeMapFace)
        {
            if (renderTarget == null)
            {
                throw new ArgumentNullException("renderTarget");
            }

            if (cubeMapFace < SourceCubeMapFace.PositiveX || cubeMapFace > SourceCubeMapFace.NegativeZ)
            {
                throw new ArgumentOutOfRangeException("cubeMapFace");
            }

            this.renderTarget = renderTarget;
            this.cubeMapFace = cubeMapFace;
        }

        public static implicit operator SourceRenderTargetBinding(SourceRenderTarget2DResource renderTarget)
        {
            return new SourceRenderTargetBinding(renderTarget);
        }
    }
}
