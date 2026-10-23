using System;
using System.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Execution.Engine.Commands
{
    public static class OriginalCelesteCommandBindings
    {
        public static void Bind(SceneEntityCatalog catalog)
        {
            BindType(catalog, "Monocle.Commands", typeof(OriginalEngineCommandsBuiltins), null, 9);
            BindType(catalog, "Celeste.Commands", typeof(OriginalCelesteCommands), null, 67);
        }

        private static void BindType(SceneEntityCatalog catalog, string identity, Type actualType, Type sharedType,
            int expectedCount)
        {
            var sourceType = catalog.FindLogicalMetadata(identity) ??
                             throw new InvalidOperationException(
                                 "The complete selected source command type must be published first.");
            var count = 0;
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
