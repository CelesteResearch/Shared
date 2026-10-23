using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Reflection;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestLoaderAssemblyEnvironment
    {
        SourceReflectionTypeSafetyState IEverestLoaderAssemblyEnvironment.TypeSafety => Reflection.TypeSafety;
    }
}
