using System.Runtime.CompilerServices;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceAlphaTestEffectReader : SourceContentTypeReader<SourceAlphaTestEffect>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceAlphaTestEffect Read(SourceContentReader input,
            SourceAlphaTestEffect existingInstance)
        {
            return new(input.ContentManager.GetGraphicsDevice(),
                input.ContentManager.Process.StockEffects)
            {
                Texture = input.ReadExternalReference<SourceTextureResource>() as SourceTexture2DResource,
                AlphaFunction = (SourceCompareFunction)input.ReadInt32(),
                ReferenceAlpha = (int)input.ReadUInt32(),
                DiffuseColor = input.ReadVector3(),
                Alpha = input.ReadSingle(),
                VertexColorEnabled = input.ReadBoolean(),
            };
        }
    }
}
