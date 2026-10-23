namespace Celeste.Game.Settings
{
    public interface IOriginalSettingsAllocationEnvironment
    {
        ISettingsFactory SettingsAllocation { get; }
    }
}
