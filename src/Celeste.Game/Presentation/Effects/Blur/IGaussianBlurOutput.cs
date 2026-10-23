using System.Numerics;
using Celeste.Core.Geometry;

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
        void DrawBlurPass(object source, IntRect destination, bool useEffect);
    }
}
