namespace Celeste.Everest.Modules.Persistence
{
    public interface IEverestModuleDataStorage
    {
        byte[] Read(string fileName);
        void Write(string fileName, byte[] data, bool flushToDisk);
    }
}
