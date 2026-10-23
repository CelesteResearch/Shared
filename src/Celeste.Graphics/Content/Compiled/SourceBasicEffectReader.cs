using System.Runtime.CompilerServices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceBasicEffectReader : SourceContentTypeReader<SourceBasicEffect>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceBasicEffect Read(SourceContentReader input,
            SourceBasicEffect existingInstance)
        {
            SourceBasicEffect basicEffect = new SourceBasicEffect(input.ContentManager.GetGraphicsDevice(),
                input.ContentManager.Process.StockEffects);
            if (input.ReadExternalReference<SourceTextureResource>() is SourceTexture2DResource texture)
            {
                basicEffect.Texture = texture;
                basicEffect.TextureEnabled = true;
            }

            basicEffect.DiffuseColor = input.ReadVector3();
            basicEffect.EmissiveColor = input.ReadVector3();
            basicEffect.SpecularColor = input.ReadVector3();
            basicEffect.SpecularPower = input.ReadSingle();
            basicEffect.Alpha = input.ReadSingle();
            basicEffect.VertexColorEnabled = input.ReadBoolean();
            return basicEffect;
        }
    }
}
