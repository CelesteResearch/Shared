using Celeste.Core.Display;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;
using Celeste.Graphics.Display;

namespace Celeste.Game.Presentation.Effects.Dust
{
    public sealed class OriginalDustStyleProvider : IDustStyleProvider
    {
        public Dictionary<int, DustStylePresentation> Styles = new Dictionary<int, DustStylePresentation>
        {
            {
                3,
                new DustStylePresentation
                {
                    EdgeColors = new Vector3[]
                    {
                        new PackedColor(0xf2, 0x5a, 0x10).ToVector3(),
                        new PackedColor(0xff, 0x00, 0x00).ToVector3(),
                        new PackedColor(0xf2, 0x10, 0x67).ToVector3()
                    },
                    EyeColor = PackedColor.Red,
                    EyeTextures = "danger/dustcreature/eyes"
                }
            },
            {
                5,
                new DustStylePresentation
                {
                    EdgeColors = new Vector3[]
                    {
                        new PackedColor(0x24, 0x5e, 0xbb).ToVector3(),
                        new PackedColor(0x17, 0xa0, 0xff).ToVector3(),
                        new PackedColor(0x17, 0xa0, 0xff).ToVector3()
                    },
                    EyeColor = new PackedColor(0x24, 0x5e, 0xbb),
                    EyeTextures = "danger/dustcreature/templeeyes"
                }
            }
        };

        public DustStylePresentation GetStyle(int areaId)
        {
            if (!Styles.ContainsKey(areaId)) return Styles[3];
            return Styles[areaId];
        }

        public bool ShouldRenderEyes => true;
    }
}
