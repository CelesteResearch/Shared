using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup
{
    public static partial class OriginalLogicalTypeFacts
    {
        public static void Register(SceneEntityCatalog catalog, string assemblyIdentity,
            Celeste.Core.Reflection.ISourceAssemblyMetadata assembly)
        {
            RegisterPart0(catalog, assemblyIdentity, assembly);
            RegisterPart1(catalog, assemblyIdentity, assembly);
            RegisterPart2(catalog, assemblyIdentity, assembly);
            RegisterPart3(catalog, assemblyIdentity, assembly);
            RegisterPart4(catalog, assemblyIdentity, assembly);
            RegisterPart5(catalog, assemblyIdentity, assembly);
            RegisterPart6(catalog, assemblyIdentity, assembly);
            RegisterPart7(catalog, assemblyIdentity, assembly);
            RegisterPart8(catalog, assemblyIdentity, assembly);
            RegisterPart9(catalog, assemblyIdentity, assembly);
        }
    }
}
