using Celeste.Core.Rendering.States;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceSamplerStateCollection
    {
        private readonly SourceSamplerState[] samplers;

        private readonly bool[] modifiedSamplers;

        public SourceSamplerState this[int index]
        {
            get => samplers[index];
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
            for (var i = 0; i < samplers.Length; i++) samplers[i] = SourceSamplerState.LinearWrap;
        }
    }
}
