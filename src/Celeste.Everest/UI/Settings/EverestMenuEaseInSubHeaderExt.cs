using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuEaseInSubHeaderExt : EverestMenuSubHeaderExt
    {
        private float uneasedAlpha;
        private readonly TextMenuPresentation containingMenu;
        public bool FadeVisible { get; set; } = true;

        public EverestMenuEaseInSubHeaderExt(string title, bool initiallyVisible,
            TextMenuPresentation containingMenu, string icon = null) : base(title, icon)
        {
            this.containingMenu = containingMenu;
            FadeVisible = initiallyVisible;
            Alpha = FadeVisible ? 1 : 0;
            uneasedAlpha = Alpha;
        }

        public override float Height()
        {
            return ScalarMath.Lerp(0f - containingMenu.ItemSpacing, base.Height(), Alpha,
                ((ISourceScalarEnvironment)ResourceSet.EngineContext).ScalarArithmetic);
        }

        public override void Update()
        {
            base.Update();
            float target = FadeVisible ? 1 : 0;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (uneasedAlpha != target)
            {
                uneasedAlpha = ScalarMath.Approach(uneasedAlpha, target,
                    ResourceSet.EngineContext.Frame.RawDeltaTime * 3f,
                    ((ISourceExtremaEnvironment)ResourceSet.EngineContext).ExtremaArithmetic);
                if (FadeVisible)
                    Alpha =
                        ((ISourceEasingEnvironment)ResourceSet.EngineContext).EasingArithmetic.SineOut(uneasedAlpha);
                else
                    Alpha =
                        ((ISourceEasingEnvironment)ResourceSet.EngineContext).EasingArithmetic.SineIn(uneasedAlpha);
            }

            Visible = Alpha != 0f;
        }
    }
}
