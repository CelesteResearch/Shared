using System.Collections.Generic;
using Celeste.Core.Display;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;

namespace Celeste.Game.Presentation.Effects.Dust
{
    public sealed class OriginalDustStyleProvider : IDustStyleProvider
    {
        public Dictionary<int, DustStylePresentation> Styles = new()
        {
            {
                3,
                new()
                {
                    EdgeColors =
                    [
                        new PackedColor(0xf2, 0x5a, 0x10).ToVector3(),
                        new PackedColor(0xff, 0x00, 0x00).ToVector3(),
                        new PackedColor(0xf2, 0x10, 0x67).ToVector3(),
                    ],
                    EyeColor = PackedColor.Red,
                    EyeTextures = "danger/dustcreature/eyes",
                }
            },
            {
                5,
                new()
                {
                    EdgeColors =
                    [
                        new PackedColor(0x24, 0x5e, 0xbb).ToVector3(),
                        new PackedColor(0x17, 0xa0, 0xff).ToVector3(),
                        new PackedColor(0x17, 0xa0, 0xff).ToVector3(),
                    ],
                    EyeColor = new(0x24, 0x5e, 0xbb),
                    EyeTextures = "danger/dustcreature/templeeyes",
                }
            },
        };

        public DustStylePresentation GetStyle(int areaId)
        {
            return !Styles.ContainsKey(areaId) ? Styles[3] : Styles[areaId];
        }

        public bool ShouldRenderEyes => true;
    }
}
