using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Gameplay.Hazards.Bumpers;

namespace Celeste.Game.Reflection.Bindings
{
    public static class BumperPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog members)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            foreach (var name in new[]
                     {
                         "RespawnTime", "MoveCycleTime", "SineCycleFreq", "sprite", "spriteEvil", "light",
                         "bloom", "node", "goBack", "anchor", "sine", "respawnTimer", "fireMode", "hitWiggler",
                         "hitDir",
                     })
            {
                var definition = members.RequireDefinition(assembly, "Celeste.Bumper", name, SourceMemberKind.Field);
                var field = typeof(OriginalBumperState).GetField(name, BindingFlags.Instance | BindingFlags.Static |
                                                                       BindingFlags.Public | BindingFlags.NonPublic |
                                                                       BindingFlags.DeclaredOnly)
                            ?? throw new MissingFieldException(typeof(OriginalBumperState).FullName, name);
                if (definition.IsStatic != field.IsStatic || definition.IsLiteral != field.IsLiteral)
                    throw new InvalidOperationException("Bumper source field differs from actual storage: " + name);
                members.RegisterBinding(new(definition, typeof(OriginalBumperState),
                    field));
            }
        }
    }
}
