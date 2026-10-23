using Celeste.Core.Reflection.Interop;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceModInteropEnvironment
    {
        private SourceModInteropProcess sourceModInterop;

        public SourceModInteropProcess ModInterop
        {
            get
            {
                if (sourceModInterop != null) return sourceModInterop;
                var sourceReflection = Reflection;
                return sourceModInterop = new(new(),
                    sourceReflection.SourceMembers, sourceReflection.SourceMethods);
            }
        }
    }
}
