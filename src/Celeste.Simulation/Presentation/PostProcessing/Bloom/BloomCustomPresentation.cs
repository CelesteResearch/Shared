using System;
using Celeste.Core.Components.Rendering;

namespace Celeste.Simulation.Presentation.PostProcessing.Bloom
{
    public sealed class BloomCustomPresentation : IBloomCallback
    {
        public bool Visible = true, EntityVisible = true;
        public Action OnRenderBloom;
        bool IBloomCallback.Visible => Visible;
        Action IBloomCallback.OnRenderBloom => OnRenderBloom;
    }
}
