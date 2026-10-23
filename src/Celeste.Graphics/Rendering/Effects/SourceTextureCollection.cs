using Celeste.Graphics.Rendering.Textures;
using System.Numerics;
using Celeste.Core.Rendering.Resources;
using Celeste.Core.Rendering.States;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceTextureCollection
    {
        internal bool ignoreTargets;

        private readonly SourceTextureResource[] textures;

        private readonly bool[] modifiedSamplers;

        public SourceTextureResource this[int index]
        {
            get { return textures[index]; }
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
            for (int i = 0; i < textures.Length; i++)
            {
                textures[i] = null;
            }

            ignoreTargets = false;
        }

        internal void RemoveDisposedTexture(SourceTextureResource tex)
        {
            for (int i = 0; i < textures.Length; i++)
            {
                if (tex == textures[i])
                {
                    this[i] = null;
                }
            }
        }
    }
}
