using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Game.Presentation.Effects.Blur
{
    public interface IGaussianBlurOutput
    {
        bool EffectAvailable { get; }
        void SetTechnique(string technique);
        void SetFade(float fade);
        void SetPixel(Vector2 pixel);
        void SetTarget(object target);

        void ClearTransparent();

        // One complete SpriteBatch: AlphaBlend, PointClamp, DepthStencil.Default,
        // CullNone, optional blur effect, identity matrix; draw color is White.
        void DrawBlurPass(object source, global::Celeste.Core.Geometry.IntRect destination, bool useEffect);
    }
}
