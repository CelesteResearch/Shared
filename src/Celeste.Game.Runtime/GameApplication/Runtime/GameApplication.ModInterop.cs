using Celeste.Core.Reflection.Interop;
using Celeste.Everest.Reflection;

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
                var sourceReflection = ((ISourceEverestReflectionEnvironment)this).Reflection;
                return sourceModInterop = new SourceModInteropProcess(new SourceModInteropBindingCatalog(),
                    sourceReflection.SourceMembers, sourceReflection.SourceMethods);
            }
        }
    }
}
