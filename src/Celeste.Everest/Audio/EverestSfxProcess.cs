using Celeste.Game.Audio;
using Celeste.Core.Reflection.Members;

namespace Celeste.Everest.Audio
{
    public sealed class EverestSfxProcess : OriginalSfxProcess
    {
        public EverestSfxProcess(SourceMemberCatalog members) : base(members)
        {
        }

        public override string EventnameByHandle(string handle)
        {
            if (byHandle.TryGetValue(handle, out var value)) return value;
            if (handle == "env_amb_03_interior_main") return EventnameByHandle("env_amb_03_interior");
            return handle;
        }
    }
}
