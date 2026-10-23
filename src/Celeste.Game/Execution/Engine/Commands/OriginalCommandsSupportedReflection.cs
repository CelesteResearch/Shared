using System.Reflection;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Execution.Engine.Commands
{
// The supported real CLR group is not an emulation of Assembly.GetTypes.
    public static class OriginalCommandsSupportedReflection
    {
        public static void Register(SceneEntityCatalog catalog)
        {
            var definition = new SceneEntityType("Monocle.Commands", (string[])["System.Object"], (string[])[]);
            definition.ConfigureLogicalTypeName("Commands");
            catalog.Register(definition);
            catalog.RegisterRuntimeType(typeof(SourceCommands), "Monocle.Commands");
            catalog.RegisterRuntimeType(typeof(OriginalEngineCommandsBuiltins), "Monocle.Commands");
        }

        public static MethodInfo[] GetBuiltinMethods(SceneEntityCatalog catalog)
        {
            var type = catalog.RequireRegisteredRuntimeType(typeof(OriginalEngineCommandsBuiltins).FullName);
            return type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }
    }
}
