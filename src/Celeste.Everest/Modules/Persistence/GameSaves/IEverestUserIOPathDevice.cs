namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public interface IEverestUserIOPathDevice
    {
        string GetEnvironmentVariable(string name);
        bool IsLinux { get; }
        bool IsOSX { get; }
        string ApplicationBaseDirectory { get; }
        string ExecutingAssemblyLocation { get; }
    }
}
