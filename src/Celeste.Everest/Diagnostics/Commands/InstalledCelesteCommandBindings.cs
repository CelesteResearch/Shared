using System;
using System.Reflection;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;
using Celeste.Game.Execution.Engine.Commands;

namespace Celeste.Everest.Diagnostics.Commands
{
    public static class InstalledCelesteCommandBindings
    {
        public static void Bind(SceneEntityCatalog catalog)
        {
            BindType(catalog, "Monocle.Commands", typeof(OriginalEngineCommandsBuiltins), null, 9);
            BindType(catalog, "Celeste.Commands", typeof(InstalledCelesteCommands), typeof(OriginalCelesteCommands),
                72);
            BindType(catalog, "Celeste.Mod.Helpers.Commands", typeof(InstalledEverestHelperCommands), null, 7);
        }

        private static void BindType(SceneEntityCatalog catalog, string identity, Type actualType, Type sharedType,
            int expectedCount)
        {
            var sourceType = catalog.FindLogicalMetadata(identity) ??
                             throw new InvalidOperationException(
                                 "The complete selected source command type must be published first.");
            int count = 0;
            foreach (var method in sourceType.GetDeclaredStaticMethods())
            {
                if (method.ReadDeclaredCommands().Length == 0)
                    continue;
                const BindingFlags flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
                var actualMethod = actualType.GetMethod(method.Name, flags);
                if (actualMethod == null && sharedType != null)
                    actualMethod = sharedType.GetMethod(method.Name, flags);
                catalog.BindActualCommandMethod(identity, method.MetadataToken, actualMethod);
                count++;
            }

            if (count != expectedCount)
                throw new InvalidOperationException("The selected source command declaration set is incomplete.");
        }
    }
}
