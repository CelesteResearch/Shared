using Celeste.Input.Bindings;
using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Framework;
using Celeste.Game.Controls.Source;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
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
            base.Alpha = (FadeVisible ? 1 : 0);
            uneasedAlpha = base.Alpha;
        }

        public override float Height()
        {
            if (Container != null)
            {
                return ScalarMath.Lerp(0f - Container.ItemSpacing, base.Height(), base.Alpha,
                    ((ISourceScalarEnvironment)ResourceSet.EngineContext).ScalarArithmetic);
            }

            return base.Height();
        }

        public override void Update()
        {
            base.Update();
            float num = (FadeVisible ? 1 : 0);
            if (uneasedAlpha != num)
            {
                uneasedAlpha = ScalarMath.Approach(uneasedAlpha, num, ResourceSet.EngineContext.Frame.RawDeltaTime * 3f,
                    ((ISourceExtremaEnvironment)ResourceSet.EngineContext).ExtremaArithmetic);
                if (FadeVisible)
                {
                    base.Alpha =
                        ((ISourceEasingEnvironment)ResourceSet.EngineContext).EasingArithmetic.SineOut(uneasedAlpha);
                }
                else
                {
                    base.Alpha =
                        ((ISourceEasingEnvironment)ResourceSet.EngineContext).EasingArithmetic.SineIn(uneasedAlpha);
                }
            }

            Visible = base.Alpha != 0f;
        }
    }
}
