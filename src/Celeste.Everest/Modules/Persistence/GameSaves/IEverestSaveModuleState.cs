namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public interface IEverestSaveModuleState
    {
        int LoadedModSaveDataIndex { get; set; }
        void LoadModSaveData(int slot);
    }
}
