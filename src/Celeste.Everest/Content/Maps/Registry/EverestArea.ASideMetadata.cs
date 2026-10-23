using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed partial class EverestArea : IOriginalSessionAreaMetadata
    {
        public OriginalAreaData ASideAreaDataBackup;

        public void RestoreASideAreaData()
        {
            var aSideAreaDataBackup = ASideAreaDataBackup;
            if (aSideAreaDataBackup == null) return;
            IntroType = aSideAreaDataBackup.IntroType;
            ColorGrade = aSideAreaDataBackup.ColorGrade;
            DarknessAlpha = aSideAreaDataBackup.DarknessAlpha;
            BloomBase = aSideAreaDataBackup.BloomBase;
            BloomStrength = aSideAreaDataBackup.BloomStrength;
            CoreMode = aSideAreaDataBackup.CoreMode;
            Dreaming = aSideAreaDataBackup.Dreaming;
        }

        public void OverrideASideMeta(int value)
        {
            if (LevelSet == "Celeste" || value == 0) return;
            if (((EverestAreaModeData)Mode[value])?.MapMeta is { OverrideASideMeta: true } mapMeta)
                mapMeta.ApplyToForOverride(this);
        }
    }
}
