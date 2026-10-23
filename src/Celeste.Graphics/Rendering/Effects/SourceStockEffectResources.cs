using System.IO;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceStockEffectResources(ISourceStockEffectResourceReader source)
    {
        private readonly ISourceStockEffectResourceReader source = source;
        private byte[] alphaTestEffect;
        private byte[] basicEffect;
        private byte[] dualTextureEffect;
        private byte[] environmentMapEffect;
        private byte[] skinnedEffect;
        private byte[] spriteEffect;
        private byte[] yuvToRGBAEffect;

        public byte[] AlphaTestEffect
        {
            get
            {
                if (alphaTestEffect == null)
                    alphaTestEffect = GetResource("AlphaTestEffect");
                return alphaTestEffect;
            }
        }

        public byte[] BasicEffect
        {
            get
            {
                if (basicEffect == null)
                    basicEffect = GetResource("BasicEffect");
                return basicEffect;
            }
        }

        public byte[] DualTextureEffect
        {
            get
            {
                if (dualTextureEffect == null)
                    dualTextureEffect = GetResource("DualTextureEffect");
                return dualTextureEffect;
            }
        }

        public byte[] EnvironmentMapEffect
        {
            get
            {
                if (environmentMapEffect == null)
                    environmentMapEffect = GetResource("EnvironmentMapEffect");
                return environmentMapEffect;
            }
        }

        public byte[] SkinnedEffect
        {
            get
            {
                if (skinnedEffect == null)
                    skinnedEffect = GetResource("SkinnedEffect");
                return skinnedEffect;
            }
        }

        public byte[] SpriteEffect
        {
            get
            {
                if (spriteEffect == null)
                    spriteEffect = GetResource("SpriteEffect");
                return spriteEffect;
            }
        }

        public byte[] YUVToRGBAEffect
        {
            get
            {
                if (yuvToRGBAEffect == null)
                    yuvToRGBAEffect = GetResource("YUVToRGBAEffect");
                return yuvToRGBAEffect;
            }
        }

        private byte[] GetResource(string name)
        {
            var manifestResourceStream =
                source.OpenResource("Microsoft.Xna.Framework.Graphics.Effect.Resources." + name + ".fxb");
            using var memoryStream = new MemoryStream();
            manifestResourceStream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
