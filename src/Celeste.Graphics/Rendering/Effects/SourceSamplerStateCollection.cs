using System.Numerics;
using Celeste.Core.Rendering.Resources;
using Celeste.Core.Rendering.States;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceSamplerStateCollection
    {
        private readonly SourceSamplerState[] samplers;

        private readonly bool[] modifiedSamplers;

        public SourceSamplerState this[int index]
        {
            get { return samplers[index]; }
            set
            {
                samplers[index] = value;
                modifiedSamplers[index] = true;
            }
        }

        internal SourceSamplerStateCollection(int slots, bool[] modSamplers)
        {
            samplers = new SourceSamplerState[slots];
            modifiedSamplers = modSamplers;
            for (int i = 0; i < samplers.Length; i++)
            {
                samplers[i] = SourceSamplerState.LinearWrap;
            }
        }
    }
}
