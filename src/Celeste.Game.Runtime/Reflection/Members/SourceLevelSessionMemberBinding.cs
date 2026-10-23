using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Runtime.Reflection.Members
{
    public static class SourceLevelSessionMemberBinding
    {
        public static void Register(SourceMemberCatalog catalog)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var definition = catalog.RequireDefinition(assembly, "Celeste.Level", "Session", SourceMemberKind.Field);
            if (definition.IsStatic || !definition.IsPublic || !definition.CanRead || !definition.CanWrite
                || definition.ValueTypeIdentity != "Celeste.Session")
                throw new InvalidOperationException(
                    "The original Level.Session field differs from its actual storage.");
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            var storage = typeof(OriginalLevelSceneRoot).GetProperty(nameof(OriginalLevelSceneRoot.Session), flags)
                          ?? throw new MissingMemberException(typeof(OriginalLevelSceneRoot).FullName,
                              nameof(OriginalLevelSceneRoot.Session));
            if (storage.PropertyType != typeof(ChapterCompletionSession) || !storage.CanRead || !storage.CanWrite)
                throw new InvalidOperationException("The actual Level.Session storage is not the original session.");
            catalog.RegisterBinding(
                new(definition, typeof(OriginalLevelSceneRoot), storage));
        }
    }
}
