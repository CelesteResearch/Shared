namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveAllocationEnvironment
    {
        IOriginalSaveAllocationPolicy SaveAllocation { get; }
    }
}
