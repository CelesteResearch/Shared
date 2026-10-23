using System;

namespace Celeste.Game.Execution.Areas
{
    public static class OriginalAreaPoemQueries
    {
        public static bool IsPoemRemix(IOriginalAreaSourceTable table, string id)
        {
            foreach (IOriginalAreaData area in table.Areas)
            {
                if (area.Mode.Length > 1 && area.Mode[1] != null && !string.IsNullOrEmpty(area.Mode[1].PoemID) &&
                    area.Mode[1].PoemID.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
