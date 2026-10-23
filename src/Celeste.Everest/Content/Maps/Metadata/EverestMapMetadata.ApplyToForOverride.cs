using System;
using Celeste.Everest.Content.Maps.Registry;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public partial class EverestMapMetadata
    {
        public void ApplyToForOverride(EverestArea area)
        {
            if (IntroType.HasValue)
            {
                area.IntroType = IntroType.Value;
            }

            if (Dreaming.HasValue)
            {
                area.Dreaming = Dreaming.Value;
            }

            if (!string.IsNullOrEmpty(ColorGrade))
            {
                area.ColorGrade = ColorGrade;
            }

            if (DarknessAlpha.HasValue)
            {
                area.DarknessAlpha = DarknessAlpha.Value;
            }

            if (BloomBase.HasValue)
            {
                area.BloomBase = BloomBase.Value;
            }

            if (BloomStrength.HasValue)
            {
                area.BloomStrength = BloomStrength.Value;
            }

            if (CoreMode.HasValue)
            {
                area.CoreMode = CoreMode.Value;
            }
        }
    }
}
