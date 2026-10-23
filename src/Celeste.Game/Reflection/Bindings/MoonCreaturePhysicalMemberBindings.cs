using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Gameplay.Decoration.MoonCreatures;

namespace Celeste.Game.Reflection.Bindings
{
    public static class MoonCreaturePhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog members)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            foreach (var name in new[] { "start", "target", "speed", "bump", "followingOffset" })
            {
                var definition =
                    members.RequireDefinition(assembly, "Celeste.MoonCreature", name, SourceMemberKind.Field);
                var field = typeof(OriginalMoonCreature).GetField(name, BindingFlags.Instance | BindingFlags.NonPublic |
                                                                        BindingFlags.DeclaredOnly)
                            ?? throw new MissingFieldException(typeof(OriginalMoonCreature).FullName, name);
                if (definition.IsStatic != field.IsStatic || definition.IsLiteral != field.IsLiteral)
                    throw new InvalidOperationException(
                        "MoonCreature source field differs from actual storage: " + name);
                members.RegisterBinding(
                    new SourcePhysicalMemberBinding(definition, typeof(OriginalMoonCreature), field));
            }
        }
    }
}
