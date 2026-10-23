using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Simulation.Presentation.PostProcessing.Bloom
{
    public sealed class BloomCustomPresentation : global::Celeste.Core.Components.Rendering.IBloomCallback
    {
        public bool Visible = true, EntityVisible = true;
        public Action OnRenderBloom;
        bool global::Celeste.Core.Components.Rendering.IBloomCallback.Visible => Visible;
        Action global::Celeste.Core.Components.Rendering.IBloomCallback.OnRenderBloom => OnRenderBloom;
    }
}
