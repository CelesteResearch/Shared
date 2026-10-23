using Celeste.Game.Presentation.Environment;

namespace Celeste.Game.Menus.Overworld
{
    public interface IOriginalOverworldLoaderFactory
    {
        OverworldLoaderSequence CreateOverworldLoader(
            OverworldStartMode startMode, HiresSnowState snow = null);
    }
}
