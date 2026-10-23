namespace Celeste.Game.Entities.Platforms.Wood
{
    public interface IWoodPlatformAddedPolicy
    {
        WoodPlatformAddedScope Begin(object incomingScene, string overrideTexture);
        void End(WoodPlatformAddedScope scope);
    }
}
