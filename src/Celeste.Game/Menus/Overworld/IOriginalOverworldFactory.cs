namespace Celeste.Game.Menus.Overworld
{
    public interface IOriginalOverworldFactory
    {
        OverworldSequence CreateOverworld(OverworldLoaderSequence loader);
    }
}
