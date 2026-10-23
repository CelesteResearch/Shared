using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Entities.Platforms.Wood
{
    public readonly struct WoodPlatformAddedScope
    {
        public readonly OriginalAreaData Area;
        public readonly string PreviousTexture;

        public WoodPlatformAddedScope(OriginalAreaData area, string previousTexture)
        {
            Area = area;
            PreviousTexture = previousTexture;
        }
    }
}
