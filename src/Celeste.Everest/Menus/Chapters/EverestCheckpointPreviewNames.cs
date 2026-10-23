using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;

namespace Celeste.Everest.Menus.Chapters
{
    public static class EverestCheckpointPreviewNames
    {
        public static string Get(ISourceEngineContext engine, OriginalAreaKey area, string level)
        {
            var keys = ((IOriginalAreaKeyEnvironment)engine).AreaKeys;
            int separator = level?.IndexOf('|') ?? -1;
            if (separator >= 0)
            {
                var actualArea = keys.GetAreaBySID(level.Substring(0, separator));
                area = actualArea == null ? area : keys.ToKey(actualArea, (int)area.Mode);
                level = level.Substring(separator + 1);
            }

            string text = keys.Format(area);
            if (keys.GetLevelSet(area) != "Celeste")
                text = keys.GetSID(area);
            if (level != null)
                text = text + "_" + level;
            if (((IOriginalMountainEnvironment)engine).MountainResources.Checkpoints.Has(text))
                return text;
            return string.Format("{0}/{1}/{2}", keys.GetSID(area), (char)(65 + (int)area.Mode), level ?? "start");
        }
    }
}
