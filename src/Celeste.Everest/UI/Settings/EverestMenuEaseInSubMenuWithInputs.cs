using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Input.Bindings;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuEaseInSubMenuWithInputs : EverestMenuSubMenuWithInputs
    {
        private float uneasedAlpha;

        public bool FadeVisible { get; set; } = true;

        public EverestMenuEaseInSubMenuWithInputs(TextMenuResources resources, string text, char separator,
            SourceVirtualButton[] buttons, bool initiallyVisible)
            : base(resources, text, separator, buttons)
        {
            FadeVisible = initiallyVisible;
            Alpha = FadeVisible ? 1 : 0;
            uneasedAlpha = Alpha;
        }

        public override float Height()
        {
            if (Container != null)
                return ScalarMath.Lerp(0f - Container.ItemSpacing, base.Height(), Alpha,
                    ((ISourceScalarEnvironment)ResourceSet.EngineContext).ScalarArithmetic);

            return base.Height();
        }

        public override void Update()
        {
            base.Update();
            float num = FadeVisible ? 1 : 0;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (uneasedAlpha != num)
            {
                uneasedAlpha = ScalarMath.Approach(uneasedAlpha, num, ResourceSet.EngineContext.Frame.RawDeltaTime * 3f,
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
