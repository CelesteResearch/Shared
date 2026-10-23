using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed partial class EverestArea : IOriginalSessionAreaMetadata
    {
        public OriginalAreaData ASideAreaDataBackup;

        public void RestoreASideAreaData()
        {
            OriginalAreaData aSideAreaDataBackup = ASideAreaDataBackup;
            if (aSideAreaDataBackup != null)
            {
                IntroType = aSideAreaDataBackup.IntroType;
                ColorGrade = aSideAreaDataBackup.ColorGrade;
                DarknessAlpha = aSideAreaDataBackup.DarknessAlpha;
                BloomBase = aSideAreaDataBackup.BloomBase;
                BloomStrength = aSideAreaDataBackup.BloomStrength;
                CoreMode = aSideAreaDataBackup.CoreMode;
                Dreaming = aSideAreaDataBackup.Dreaming;
            }
        }

        public void OverrideASideMeta(int value)
        {
            if (!(LevelSet == "Celeste") && value != 0)
            {
                EverestMapMetadata mapMeta = ((EverestAreaModeData)Mode[value])?.MapMeta;
                if (mapMeta != null && mapMeta.OverrideASideMeta == true)
                {
                    mapMeta.ApplyToForOverride(this);
                }
            }
        }
    }
}
