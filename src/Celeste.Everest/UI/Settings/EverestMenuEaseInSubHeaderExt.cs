using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Framework;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuEaseInSubHeaderExt : EverestMenuSubHeaderExt
    {
        private float uneasedAlpha;
        private TextMenuPresentation containingMenu;
        public bool FadeVisible { get; set; } = true;

        public EverestMenuEaseInSubHeaderExt(string title, bool initiallyVisible,
            TextMenuPresentation containingMenu, string icon = null) : base(title, icon)
        {
            this.containingMenu = containingMenu;
            FadeVisible = initiallyVisible;
            base.Alpha = FadeVisible ? 1 : 0;
            uneasedAlpha = base.Alpha;
        }

        public override float Height()
            => ScalarMath.Lerp(0f - containingMenu.ItemSpacing, base.Height(), base.Alpha,
                ((ISourceScalarEnvironment)ResourceSet.EngineContext).ScalarArithmetic);

        public override void Update()
        {
            base.Update();
            float target = FadeVisible ? 1 : 0;
            if (uneasedAlpha != target)
            {
                uneasedAlpha = ScalarMath.Approach(uneasedAlpha, target,
                    ResourceSet.EngineContext.Frame.RawDeltaTime * 3f,
                    ((ISourceExtremaEnvironment)ResourceSet.EngineContext).ExtremaArithmetic);
                if (FadeVisible)
                    base.Alpha =
                        ((ISourceEasingEnvironment)ResourceSet.EngineContext).EasingArithmetic.SineOut(uneasedAlpha);
                else
                    base.Alpha =
                        ((ISourceEasingEnvironment)ResourceSet.EngineContext).EasingArithmetic.SineIn(uneasedAlpha);
            }

            Visible = base.Alpha != 0f;
        }
    }
}
