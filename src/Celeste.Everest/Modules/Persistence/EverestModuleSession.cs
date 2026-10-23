using YamlDotNet.Serialization;

namespace Celeste.Everest.Modules.Persistence
{
    public abstract class EverestModuleSession
    {
        [YamlIgnore] public int Index { get; set; }
    }
}
