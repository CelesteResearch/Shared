using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceTextureCollection
    {
        internal bool ignoreTargets;

        private readonly SourceTextureResource[] textures;

        private readonly bool[] modifiedSamplers;

        public SourceTextureResource this[int index]
        {
            get => textures[index];
            set
            {
                textures[index] = value;
                modifiedSamplers[index] = true;
            }
        }

        internal SourceTextureCollection(int slots, bool[] modSamplers)
        {
            textures = new SourceTextureResource[slots];
            modifiedSamplers = modSamplers;
            for (var i = 0; i < textures.Length; i++) textures[i] = null;

            ignoreTargets = false;
        }

        internal void RemoveDisposedTexture(SourceTextureResource tex)
        {
            for (var i = 0; i < textures.Length; i++)
                if (tex == textures[i])
                    this[i] = null;
        }
    }
}
