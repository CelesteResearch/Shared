using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Display.Colors;
using Celeste.Simulation.Presentation.Backdrops.Weather.Rain;

namespace Celeste.Everest.Content.Maps.Backdrops
{
    public sealed class EverestRainBackdropPresentation : RainBackdropPresentation
    {
        public new PackedColor? Color;

        public EverestRainBackdropPresentation(ISourceEngineContext engine) : base(engine)
        {
        }

        protected override PackedColor GetRainColor(string original)
        {
            return Color ?? SourceHexColor.HexToColor(original);
        }
    }
}
