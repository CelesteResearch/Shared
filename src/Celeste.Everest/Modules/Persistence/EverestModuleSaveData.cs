using YamlDotNet.Serialization;

namespace Celeste.Everest.Modules.Persistence
{
    public abstract class EverestModuleSaveData
    {
        [YamlIgnore] public int Index { get; set; }
    }
}
