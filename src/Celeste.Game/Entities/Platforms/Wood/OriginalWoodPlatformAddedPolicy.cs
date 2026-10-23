namespace Celeste.Game.Entities.Platforms.Wood
{
    public sealed class OriginalWoodPlatformAddedPolicy : IWoodPlatformAddedPolicy
    {
        public WoodPlatformAddedScope Begin(object incomingScene, string overrideTexture)
        {
            return default;
        }

        public void End(WoodPlatformAddedScope scope)
        {
        }
    }
}
